<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="ProjTeste.Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>CRUD</title>
  <link rel="stylesheet" type="text/css" href="Css/Listagem.css" />
  <script src="/Scripts/jquery-3.6.0.min.js"></script>
  <link rel="stylesheet" type="text/css" href="/Content/bootstrap.min.css" />
  <script src="/Scripts/bootstrap.min.js"></script>
</head>
<body class="d-flex flex-column">
  <div class="d-flex">
    <h1 class="mx-auto">Clientes Cadastrados</h1>
  </div>

  <div>
    <button type="button" id="btn" class="btn btn-success">Cadastrar novo cliente</button>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>ID</th>
          <th>Razão Social</th>
          <th>Nome Fantasia</th>
          <th>CPF</th>
          <th>RG</th>
          <th>Endereço</th>
          <th>Número</th>
          <th>Bairro</th>
          <th>Cidade</th>
          <th>CEP</th>
          <th>Telefone</th>
          <th>Celular</th>
          <th>E-mail</th>
          <th>Opções</th>
        </tr>
      </thead>
      <tbody id="dados"></tbody>
    </table>
  </div>
    
  <div class="modal fade bd-example-modal-lg" id="cadastrar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Cadastro de Cliente</h5>
          <button type="button" class="btn btn-danger close" data-bs-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">X</span>
          </button>
        </div>
        
        <div class="modal-body">
          <form id="cadastrar-form">
            <div class="row">
              <div class="col-6">
                <label for="cadRazaoSocial">Razão Social</label>
                <input type="text" class="form-control" id="cadRazaoSocial" maxlength="50" />
              </div>
              <div class="col-6">
                <label for="cadNomeFantasia">Nome Fantasia</label>
                <input type="text" class="form-control" id="cadNomeFantasia" maxlength="50" />
              </div>
            </div>
            <div class="row">
              <div class="col-6">
                <label for="cadCPF">CPF</label>
                <input type="text" class="form-control" id="cadCPF" maxlength="20" />
              </div>
              <div class="col-6">
                <label for="cadRG">RG</label>
                <input type="text" class="form-control" id="cadRG" maxlength="20" />
              </div>
            </div>
            <div class="row">
              <div class="col-8">
                <label for="cadEndereco">Endereço</label>
                <input type="text" class="form-control" id="cadEndereco" maxlength="80" />
              </div>
              <div class="col-4">
                <label for="cadNumero">Número</label>
                <input type="number" class="form-control" id="cadNumero" maxlength="10" />
              </div>
            </div>
            <div class="row">
              <div class="col-4">
                <label for="cadBairro">Bairro</label>
                <input type="text" class="form-control" id="cadBairro" maxlength="50" />
              </div>
              <div class="col-4">
                <label for="cadCidade">Cidade</label>
                <input type="text" class="form-control" id="cadCidade" maxlength="40" />
              </div>
              <div class="col-4">
                <label for="cadCEP">CEP</label>
                <input type="text" class="form-control" id="cadCEP" maxlength="9" />
              </div>
            </div>
            <div class="row">
              <div class="col-4">
                <label for="cadTelefone">Telefone</label>
                <input type="tel" class="form-control" id="cadTelefone" maxlength="20" />
              </div>
              <div class="col-4">
                <label for="cadCelular">Celular</label>
                <input type="tel" class="form-control" id="cadCelular" maxlength="20" />
              </div>
              <div class="col-4">
                <label for="cadEmail">E-mail</label>
                <input type="email" class="form-control" id="cadEmail" maxlength="50" />
              </div>
            </div>
          </form>
          <div id="cadSaida" class="h4"></div>
        </div>

        <div class="modal-footer">
          <input type="hidden" id="cadId" />
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Sair</button>
          <button  type="button" id="btCadastrar" value="Cadastrar" class="btn btn-success">Cadastrar</button>
        </div>
      </div>
    </div>
  </div>
  <script src="Listagem.js"></script>
</body>
</html>
