# Desafio de Código Full Stack Junior Junior - Aplicação de E-commerce

## Visão Geral do Projeto

Este projeto é uma solução full stack para uma aplicação de vendas online (e-commerce), desenvolvida para avaliar habilidades práticas em desenvolvimento web. 
O sistema é composto por um backend em ASP.NET Core, um frontend em Angular e um banco de dados SQL Server, todos orquestrados e containerizados com Docker.

O foco principal é a criação de uma API RESTful para gerenciar produtos, uma interface de usuário altamente responsiva otimizada para dispositivos móveis e a implementação de boas práticas de desenvolvimento como SOLID, DDD e Clean Code.

## Estrutura do Projeto

- Separado em dois repositórios
    - O backend com o docker-compose e o dockerfile 
    - E o frontend com o seu dockerfile

## Tecnologias Utilizadas

-   **Backend**: ASP.NET Core 9, Entity Framework Core
-   **Frontend**: Angular 19
-   **Banco de Dados**: SQL Server
-   **Containerização**: Docker

## Como Executar a Solução Completa


1.  **Clone os repositórios:**

3.  **Inicie os containers:**

4.  **Acesse os serviços:**
    Após a conclusão do comando, os serviços estarão disponíveis nos seguintes endereços: [cite: 51]
    -   **Aplicação Frontend (Angular)**: `http://localhost:4200`
    -   **API Backend (ASP.NET Core)**: `http://localhost:5000`
    -   **Banco de Dados (SQL Server)**: Acesso pela porta `1433`

## Como Testar a Aplicação

### Testando o Frontend e a Responsividade
 Para testar a responsividade da interface:

1.  Abra a aplicação frontend em seu navegador: `http://localhost:4200`.
2.  Abra as **Ferramentas de Desenvolvedor** do seu navegador (geralmente pressionando `F12` ou `Ctrl+Shift+I`).
3.  Ative o **Modo de Dispositivo** (geralmente um ícone de celular/tablet ou `Ctrl+Shift+M`).
4.  Simule diferentes tamanhos de tela para observar como a interface se adapta:
    -   **Telas Pequenas (Mobile < 768px)**: A lista de produtos deve exibir 1 card por linha. [cite: 38] Os elementos interativos, como botões, devem ser fáceis de tocar. 
    -   **Telas Médias (Tablet ~768px-1023px)**: A lista deve exibir 2 cards por linha. [cite: 37]
    -   **Telas Grandes (Desktop > 1024px)**: A lista deve exibir de 3 a 4 cards por linha. [cite: 36]

### Testando a API Backend

Você pode usar uma ferramenta como Postman, Insomnia ou cURL para testar os endpoints da API que estarão rodando em `http://localhost:5000`.

**Endpoints Disponíveis:**

-   `GET /api/products`: Retorna uma lista de todos os produtos. 
-   `GET /api/products/paginated?pageNumber=2&pageSize=7`: Retorna uma lista de todos os produtos paginados. É possível passar a página e a quantidade de itens por página; 
-   `GET /api/products/{id}`: Retorna um produto específico pelo seu ID. 
-   `POST /api/products`: Cria um novo produto. 
-   `DELETE /api/products/{id}`: Deleta um produto específico pelo seu ID.

**Exemplo de corpo para a requisição POST:**
```json
{
  "name": "Produto de Teste",
  "price": 99.99,
  "imageUrl": "https://placehold.co/300x200"
}
```

### Banco de Dados

O banco de dados SQL Server é persistido através de um volume Docker, garantindo que os dados não sejam perdidos ao reiniciar os containers. A estrutura das tabelas é criada automaticamente pelas *migrations* do Entity Framework Core, e os dados iniciais são populados via *seeding* do EF Core, conforme especificado no desafio.