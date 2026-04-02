\# Escola Pet API



API REST para gerenciamento de escolas pet, tutores e animais desenvolvida com ASP.NET Core.



\## Tecnologias



\- C# / .NET 8

\- ASP.NET Core Web API

\- Entity Framework Core

\- SQL Server

\- AutoMapper

\- Swagger / OpenAPI

\- Arquitetura em camadas (Domain, Application, Infrastructure, Web)

\- Repositório Genérico com Generics



\## Funcionalidades



\- CRUD completo de Escolas Pet

\- CRUD completo de Tutores

\- CRUD completo de Pets

\- Busca de escola com seus tutores

\- Busca de tutor com seus pets

\- Espécies de animais via Enum (Cachorro, Gato, Passarinho, Hamster)



\## Como rodar



1\. Clone o repositório

2\. Configure a connection string no `appsettings.json` apontando para o seu SQL Server

3\. Execute as migrations: `dotnet ef database update`

4\. Rode o projeto: `dotnet run`

5\. Acesse o Swagger em: `https://localhost:{porta}/swagger`

