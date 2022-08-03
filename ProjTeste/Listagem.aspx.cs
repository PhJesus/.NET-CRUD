using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace ProjTeste {
    public partial class Listagem : System.Web.UI.Page {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e) {

        }

        [WebMethod]
        public static Object ListarItens() {
            using (NpgsqlConnection connection = new NpgsqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand {
                    Connection = connection,
                    CommandText = "SELECT * FROM cliente",
                    CommandType = CommandType.Text
                };
                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Cliente> dados = new List<Cliente>();

                while (dr.Read()) {
                    dados.Add(new Cliente() {
                        Id = (int)dr["id"],
                        RazaoSocial = dr["razao_social"].ToString(),
                        NomeFantasia = dr["nome_fantasia"].ToString(),
                        Cpf = dr["cpf"].ToString(),
                        Rg = dr["rg"].ToString(),
                        Endereco = dr["endereco"].ToString(),
                        Numero = dr["numero"].ToString(),
                        Bairro = dr["numero"].ToString(),
                        Cidade = dr["cidade"].ToString(),
                        Cep = dr["cep"].ToString(),
                        Telefone = dr["telefone"].ToString(),
                        Celular = dr["celular"].ToString(),
                        Email = dr["email"].ToString()
                    });
                }

                cmd.Dispose();
                connection.Close();
                return dados;
            }
        }

        [WebMethod]
        public static void DeletarItem(string id) {
            using (NpgsqlConnection connection = new NpgsqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand {
                    Connection = connection,
                    CommandText = "Delete from cliente where id=@ID",
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add(new NpgsqlParameter("@ID", Convert.ToInt32(id)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
            }
        }


        [WebMethod]
        public static Object SetData(Cliente data) {
            try {
                using (NpgsqlConnection connection = new NpgsqlConnection()) {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();
                    connection.Open();

                    if (data.Id > 0) {
                        NpgsqlCommand cmd = new NpgsqlCommand {
                            Connection = connection,
                            CommandText = $@"UPDATE cliente SET
                        razao_social = @RazaoSocial, nome_fantasia = @NomeFantasia, cpf = @Cpf, rg = @Rg, endereco = @Endereco, numero = @Numero,
                        bairro = @Bairro, cidade = @Cidade, cep = @Cep, telefone = @Telefone, celular = @Celular, email = @Email
                        WHERE id = @Id",
                            CommandType = CommandType.Text
                        };
                        cmd.Parameters.Add(new NpgsqlParameter("@Id", data.Id));
                        cmd.Parameters.Add(new NpgsqlParameter("@RazaoSocial", data.RazaoSocial));
                        cmd.Parameters.Add(new NpgsqlParameter("@NomeFantasia", data.NomeFantasia));
                        cmd.Parameters.Add(new NpgsqlParameter("@Cpf", data.Cpf));
                        cmd.Parameters.Add(new NpgsqlParameter("@Rg", data.Rg));
                        cmd.Parameters.Add(new NpgsqlParameter("@Endereco", data.Endereco));
                        cmd.Parameters.Add(new NpgsqlParameter("@Numero", data.Numero));
                        cmd.Parameters.Add(new NpgsqlParameter("@Bairro", data.Bairro));
                        cmd.Parameters.Add(new NpgsqlParameter("@Cidade", data.Cidade));
                        cmd.Parameters.Add(new NpgsqlParameter("@Cep", data.Cep));
                        cmd.Parameters.Add(new NpgsqlParameter("@Telefone", data.Telefone));
                        cmd.Parameters.Add(new NpgsqlParameter("@Celular", data.Celular));
                        cmd.Parameters.Add(new NpgsqlParameter("@Email", data.Email));
                        cmd.ExecuteNonQuery();
                    } else {

                        NpgsqlCommand cmd = new NpgsqlCommand {
                            Connection = connection,
                            CommandText = "Insert into cliente (razao_social, nome_fantasia, cpf, rg, endereco, numero, bairro, cidade, cep, telefone, celular, email ) " +
                            "values (@razao_social, @nome_fantasia, @cpf, @rg, @endereco, @numero, @bairro, @cidade, @cep, @telefone, @celular, @email)",
                            CommandType = CommandType.Text
                        };
                        cmd.Parameters.Add(new NpgsqlParameter("@razao_social", data.RazaoSocial));
                        cmd.Parameters.Add(new NpgsqlParameter("@nome_fantasia", data.NomeFantasia));
                        cmd.Parameters.Add(new NpgsqlParameter("@cpf", data.Cpf));
                        cmd.Parameters.Add(new NpgsqlParameter("@rg", data.Rg));
                        cmd.Parameters.Add(new NpgsqlParameter("@endereco", data.Endereco));
                        cmd.Parameters.Add(new NpgsqlParameter("@numero", data.Numero));
                        cmd.Parameters.Add(new NpgsqlParameter("@bairro", data.Bairro));
                        cmd.Parameters.Add(new NpgsqlParameter("@cidade", data.Cidade));
                        cmd.Parameters.Add(new NpgsqlParameter("@cep", data.Cep));
                        cmd.Parameters.Add(new NpgsqlParameter("@telefone", data.Telefone));
                        cmd.Parameters.Add(new NpgsqlParameter("@celular", data.Celular));
                        cmd.Parameters.Add(new NpgsqlParameter("@email", data.Email));
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return "Cliente cadastrado com sucesso";
                }
            } catch (Exception error) {
                return "Ocorreu um arro ao realizar o cadastro - " + error;
            }
        }


        [WebMethod]
        public static Object CarregarCampos(string id) {
            try {
                using (NpgsqlConnection connection = new NpgsqlConnection()) {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand {
                        Connection = connection,
                        CommandText = "SELECT * FROM cliente WHERE id=" + id,
                        CommandType = CommandType.Text
                    };
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    List<Cliente> dados = new List<Cliente>();

                    while (dr.Read()) {
                        dados.Add(new Cliente() {
                            Id = Convert.ToInt32(id),
                            RazaoSocial = dr["razao_social"].ToString(),
                            NomeFantasia = dr["nome_fantasia"].ToString(),
                            Cpf = dr["cpf"].ToString(),
                            Rg = dr["rg"].ToString(),
                            Endereco = dr["endereco"].ToString(),
                            Numero = dr["numero"].ToString(),
                            Bairro = dr["numero"].ToString(),
                            Cidade = dr["cidade"].ToString(),
                            Cep = dr["cep"].ToString(),
                            Telefone = dr["telefone"].ToString(),
                            Celular = dr["celular"].ToString(),
                            Email = dr["email"].ToString()
                        });
                    }

                    cmd.Dispose();
                    connection.Close();
                    return dados;
                }
            } catch (Exception error) {
                return error;
            }
        }

        public class Cliente {
            public int Id { get; set; }
            public string RazaoSocial { get; set; }
            public string NomeFantasia { get; set; }
            public string Cpf { get; set; }
            public string Rg { get; set; }
            public string Endereco { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Cep { get; set; }
            public string Telefone { get; set; }
            public string Celular { get; set; }
            public string Email { get; set; }
        }
    }
}
