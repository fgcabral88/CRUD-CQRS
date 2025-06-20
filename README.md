**Sobre o Projeto**
================

Este projeto é um CRUD CQRS (Command Query Responsibility Segregation) para a entidade Tax (Imposto), desenvolvido em .NET 8 utilizando o padrão de arquitetura em camadas (Layered Architecture) e o framework CQRS. O objetivo é demonstrar uma estrutura de código organizada, separando responsabilidades em camadas distintas para facilitar manutenção, testes e escalabilidade.

**Tecnologias Utilizadas**
-------------------------

* .NET 8
* ASP.NET Core
* Entity Framework Core
* MySQL
* CQRS Framework

**Estrutura do Projeto**
------------------------

* **Domain**: Contém as entidades de domínio e interfaces dos repositórios.
* **Application**: Inclui os serviços de aplicação, DTOs e comandos de CQRS.
* **Infrastructure**: Implementa os repositórios e o contexto de dados.
* **Presentation (Controllers)**: Expõe as APIs para interação externa.
* **CQRS**: Implementa os comandos e consultas de CQRS.

**Endpoints Principais**
-----------------------

* **GET /api/tax**: Lista todos os impostos
* **GET /api/tax/{id}**: Busca imposto por ID
* **POST /api/tax**: Cria um novo imposto
* **PUT /api/tax/{id}**: Atualiza um imposto existente
* **DELETE /api/tax/{id}**: Remove um imposto

**Comandos de CQRS**
-------------------

* **CreateTaxCommand**: Cria um novo imposto
* **UpdateTaxCommand**: Atualiza um imposto existente
* **DeleteTaxCommand**: Remove um imposto

**Consultas de CQRS**
--------------------

* **GetTaxQuery**: Busca imposto por ID
* **GetAllTaxesQuery**: Lista todos os impostos

**Boas Práticas Adotadas**
-------------------------

* Separação de responsabilidades por camadas (Layered Architecture)
* Injeção de dependência para facilitar testes e manutenção
* Uso de DTOs para transferência de dados entre camadas
* Uso de comandos e consultas de CQRS para separar responsabilidades

**Contribuição**
----------------

Contribuições são bem-vindas! Para grandes mudanças, abra uma issue para discussão prévia.
