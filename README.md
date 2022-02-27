## Aplicação ASP.NET Core Web API que permite o gerenciamento de produtos e suas categorias.

### Escopo Geral

- Funcionalidades CRUD de produtos e categorias;
- Modelo de domínio usando classes com propriedades e comportamentos;
- Arquitetura: Clean Architecture;
- Padrões e implementação: Web API, Repository e CQRS;
- Atributos do domínio
    - **Product**: Id(int, identity), Name(string), Description(string), Price(decimal), Stock(int), Image(string);
    - **Category**: CategoryId (int, identity), Name(string);
- Relacionamento usado: uma para muitos entre Category e Product

### Persistência de dados

- Banco de dados: SQL Server;
- ORM: Entity Framework Core;
- Abordagem: Code-First;
- Padrão: Repository

### Estrutura
![image](https://user-images.githubusercontent.com/69182287/155903055-3648f4a7-ad82-4599-89c3-ec9b86e0f5d7.png)

### Fluxo de Processamento 
![image](https://user-images.githubusercontent.com/69182287/155903064-b054b11c-43ea-4c52-8d22-fddb6921ed2c.png)

### Estrutura da implementação do padrão CQRS em Product
![image](https://user-images.githubusercontent.com/69182287/155903590-a2876377-52bd-4bcb-8525-e06ab7681e9b.png)

Padrão usado: Mediator. Usando o Mediator definimos um Request e um Handler, onde o Request é criado e enviado a partir do front-end para o Mediator que contém o mapeamento dos Requests e seus Handlers.

#### Fluxo do Request
![image](https://user-images.githubusercontent.com/69182287/155903419-f0afb2ff-eab3-477c-b0ee-6faf3af1160b.png)

<i>Projeto de estudo feito em acompanhamento do curso Clean Architecture Essencial do Macoratti.<i>
