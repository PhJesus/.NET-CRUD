$(document).ready(() => {

    function appendTable() {
        $.ajax({
            type: "POST",
            url: "Listagem.aspx/ListarItens",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: MontarTabela,
            error: function (result) {
                console.log(result);
            }
        });
    };

    const MontarTabela = (dbdata) => {
        let tabela = "";
        const data = dbdata.d;
        for (let i = 0; i < data.length; i++) {
            tabela += `
      <tr>
        <td>${data[i].Id}</td>
        <td>${data[i].RazaoSocial}</td>
        <td>${data[i].NomeFantasia}</td>
        <td>${data[i].Cpf}</td>
        <td>${data[i].Rg}</td>
        <td>${data[i].Endereco}</td>
        <td>${data[i].Numero}</td>
        <td>${data[i].Bairro}</td>
        <td>${data[i].Cidade}</td>
        <td>${data[i].Cep}</td>
        <td>${data[i].Telefone}</td>
        <td>${data[i].Celular}</td>
        <td>${data[i].Email}</td>
        <td>
          <button type="button" data-id="${data[i].Id}" name="edit" class="btn btn-warning btn-sm">Editar</button>
          <button type="button" data-id="${data[i].Id}" name="delete" class="btn btn-danger btn-sm">Deletar</button>
        </td>
      </tr>`;
        };
        $("#dados").html(tabela);
    };

    $('#dados').on('click', 'button[name="delete"]', function () {
        const id = $(this).data('id');
        console.log(id);
        if (window.confirm("Deseja mesmo deletar esse cliente?")) {
            $.ajax({
                type: "POST",
                url: "Listagem.aspx/DeletarItem",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ 'id': id }),
                async: false,
                success: () => {
                    appendTable();
                },
                error: (result) => {
                    console.log(result);
                }
            });
        };
        
    });

    $('#dados').on('click', 'button[name="edit"]', function () {
        const id = $(this).data('id');
        console.log(id);

        $.ajax({
            type: "POST",
            url: "Listagem.aspx/CarregarCampos",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ 'id': id }),
            async: false,
            success: (response) => {
                let data = response.d;
                console.log(data);
                $("#cadId").val(data[0].Id);
                $("#cadRazaoSocial").val(data[0].RazaoSocial);
                $("#cadNomeFantasia").val(data[0].NomeFantasia);
                $("#cadCPF").val(data[0].Cpf);
                $("#cadRG").val(data[0].Rg);
                $("#cadEndereco").val(data[0].Endereco);
                $("#cadNumero").val(data[0].Numero);
                $("#cadBairro").val(data[0].Bairro);
                $("#cadCidade").val(data[0].Cidade);
                $("#cadCEP").val(data[0].Cep);
                $("#cadTelefone").val(data[0].Telefone);
                $("#cadCelular").val(data[0].Celular);
                $("#cadEmail").val(data[0].Email);

                $('#cadastrar').modal('show')
          },
            error: function (result) {
                console.log(result);
            }
        });
    });

    $('#btn').click(function () {
        $('#cadId').val('');
        $('#cadastrar').modal('show')
    });

    $("#btCadastrar").click(() => {
        let Dados = {}

        if (parseInt($('#cadId').val()))
            Dados.Id = parseInt($('#cadId').val());

        Dados.RazaoSocial = $("#cadRazaoSocial").val();
        Dados.NomeFantasia = $("#cadNomeFantasia").val();
        Dados.Cpf = $("#cadCPF").val();
        Dados.Rg = $("#cadRG").val();
        Dados.Endereco = $("#cadEndereco").val();
        Dados.Numero = $("#cadNumero").val();
        Dados.Bairro = $("#cadBairro").val();
        Dados.Cidade = $("#cadCidade").val();
        Dados.Cep = $("#cadCEP").val();
        Dados.Telefone = $("#cadTelefone").val();
        Dados.Celular = $("#cadCelular").val();
        Dados.Email = $("#cadEmail").val();

        $.ajax({
            type: "POST",
            url: "Listagem.aspx/SetData",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            data: JSON.stringify({ data: Dados }),
            success: () => {
                $('#cadastrar-form').trigger("reset");

                alert('Registro salvo com sucesso!');

                appendTable();

                $('#cadastrar').modal('hide')
            },
            error: (result) => { console.log(result); }
        });
    });
    
    appendTable();
});
