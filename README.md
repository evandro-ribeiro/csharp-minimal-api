# Minimal API - Veículos

## Contexto

Projeto de uma Minimal API utilizando .NET, C#, Entity Framework e SQL Server. O projeto funciona como uma API com operações CRUD para gerenciamento de veículos.

## Administradores

Para utilizar a API, é necessário estar autenticado e autorizado, realizando login como Administrador (chamado aqui de "Adm") ou Editor (chamado de "Editor" mesmo). Com o login realizado, o sistema gera um token JWT para que possa acessar e utilizar os métodos da API, dependendo do perfil do seu usuário (Adm ou Editor).

Os Administradores possuem as seguintes props:

- `Id`: `int`
- `Email`: `string`
- `Senha`: `string`
- `Perfil`: `string`

## Veículos

Os veículos possuem as seguintes props:

- `Id`: `int`
- `Nome`: `string`
- `Marca`: `string`
- `Ano`: `int`

### Testes

Foram realizados alguns testes com a classe de Administradores para validar estava tudo conforme o que foi desenvolvido e planejado.
