# Projeto WebAPI com Entity Framework

Este projeto tem como objetivo apresentar uma implementação de uma API RESTful utilizando o framework .NET e o Entity Framework para persistência de dados em um banco de dados SQL Server. A API foi desenvolvida em C# e oferece as operações CRUD (Create, Read, Update, Delete) para a entidade "Produto".

## Tecnologias utilizadas
Visual Studio Code
.NET Framework 4.8
C#
Entity Framework
SQL Server


##  Endpoints disponíveis

### GET  https://localhost:3000/produto
Retorna uma lista com todos os produtos cadastrados.

### GET  https://localhost:3000/produto{id}
Retorna um produto específico com base no ID informado.

### POST  https://localhost:3000/produto
Cadastra um novo produto no banco de dados.

### PUT  https://localhost:3000/produto/id
Atualiza as informações de um produto específico com base no ID informado.

### DELETE  https://localhost:3000/produto/id
Remove um produto específico com base no ID informado.

