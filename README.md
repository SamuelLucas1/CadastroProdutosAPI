# 📦 CadastroProdutosAPI

<p align="left">
  <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white" />
  <img src="https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" />
</p>

API REST desenvolvida com **C#, ASP.NET Core 10 e Entity Framework Core**, voltada ao cadastro e gerenciamento de produtos, com autenticação JWT e autorização baseada em funções.

O projeto foi desenvolvido para fins educacionais, com o objetivo de praticar uma abordagem baseada em Controllers e compreender a implementação de autenticação e autorização em aplicações ASP.NET Core.

## 📌 Sobre o projeto

O CadastroProdutosAPI é uma aplicação backend que disponibiliza endpoints para consulta, cadastro, atualização e exclusão de produtos.

A aplicação utiliza JWT (JSON Web Token) para autenticação dos usuários e controle de acesso por funções (*Roles*), diferenciando usuários comuns de administradores.

A persistência dos dados é realizada com Entity Framework Core e SQLite.

## 🛠️ Tecnologias utilizadas

| Tecnologia | Utilização |
|---|---|
| C# | Linguagem de programação |
| .NET 10 | Plataforma de desenvolvimento |
| ASP.NET Core Web API | Construção da API |
| Controllers | Organização dos endpoints |
| JWT Bearer | Autenticação |
| Role-based Authorization | Controle de acesso por funções |
| Entity Framework Core 10 | ORM e persistência |
| SQLite | Banco de dados |
| Swagger / OpenAPI | Documentação e testes |
| Git e GitHub | Versionamento |

## ⚙️ Funcionalidades

- Cadastro de produtos.
- Consulta de todos os produtos.
- Consulta de produto por identificador.
- Atualização de produtos.
- Exclusão de produtos.
- Autenticação utilizando JWT.
- Autorização baseada em funções (`Admin` e `User`).
- Validação de dados dos produtos.
- Persistência utilizando Entity Framework Core.
- Banco de dados SQLite.
- Documentação e testes dos endpoints com Swagger.

## 🔐 Autenticação e autorização

A API utiliza autenticação baseada em JWT.

Após enviar as credenciais para o endpoint de login, a aplicação valida o usuário e retorna um token JWT.

O token contém informações (*claims*) sobre o usuário e sua função, permitindo controlar o acesso aos endpoints.

### Funções disponíveis

| Função | Permissões |
|---|---|
| User | Consultar produtos |
| Admin | Consultar, cadastrar, atualizar e excluir produtos |

### Credenciais demonstrativas

Para facilitar os testes, o projeto utiliza usuários fixos:

| Usuário | Senha | Função |
|---|---|---|
| admin | 1234 | Admin |
| user | 1234 | User |

**Importante:** as credenciais são fixas e utilizadas exclusivamente para demonstração da autenticação e autorização. Esta implementação não representa um sistema de gerenciamento de usuários adequado para produção.

### Como autenticar

1. Execute a aplicação.
2. Acesse o Swagger.
3. Localize `POST /api/Login`.
4. Envie as credenciais de um dos usuários demonstrativos.
5. Copie o token retornado.
6. Utilize o botão **Authorize** do Swagger para informar o token JWT.
7. Teste os endpoints protegidos de acordo com a função do usuário.

## 🌐 Endpoints

Todos os endpoints de produtos exigem autenticação.

### Autenticação

| Método | Endpoint | Descrição |
|---|---|---|
| POST | `/api/Login` | Valida as credenciais e gera um token JWT |

### Produtos

| Método | Endpoint | Permissão | Descrição |
|---|---|---|---|
| GET | `/api/Produtos` | User / Admin | Lista os produtos |
| GET | `/api/Produtos/{id}` | User / Admin | Consulta produto por ID |
| POST | `/api/Produtos` | Admin | Cadastra um produto |
| PUT | `/api/Produtos/{id}` | Admin | Atualiza um produto |
| DELETE | `/api/Produtos/{id}` | Admin | Exclui um produto |

## 📋 Validações dos produtos

A entidade `Produto` possui validações utilizando Data Annotations e regras complementares no serviço.

| Propriedade | Regra |
|---|---|
| Nome | Obrigatório, máximo de 100 caracteres |
| Preço | Deve ser maior que zero |
| Quantidade em estoque | Deve ser maior ou igual a zero |

## 🏗️ Estrutura do projeto

```text
CadastroProdutos/
│
├── CadastroProdutos/
│   ├── Controllers/
│   │   ├── LoginController.cs
│   │   └── ProdutosController.cs
│   │
│   ├── DbContext/
│   │   └── AplicationDbContext.cs
│   │
│   ├── Migrations/
│   │
│   ├── Models/
│   │   ├── Login.cs
│   │   └── Produto.cs
│   │
│   ├── Services/
│   │   ├── Contracts/
│   │   │   └── IProduct.cs
│   │   ├── ProdutoDataBaseService.cs
│   │   └── ProdutoService.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── CadastroProdutos.csproj
│
├── CadastroProdutos.slnx
└── README.md
```

### Organização das responsabilidades

- **Controllers:** recebem as requisições HTTP e retornam as respostas da API.
- **Models:** representam as entidades e os dados utilizados pela aplicação.
- **DbContext:** configura o acesso ao banco de dados por meio do Entity Framework Core.
- **Services:** concentram as operações de gerenciamento dos produtos.
- **Contracts:** definem a interface utilizada para abstrair os serviços.
- **Migrations:** registram as alterações do esquema do banco de dados.

O projeto também possui uma implementação de serviço em memória (`ProdutoService`) e uma implementação com persistência (`ProdutoDataBaseService`). A aplicação utiliza atualmente a implementação com Entity Framework Core.

## 🚀 Como executar o projeto

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Git](https://git-scm.com/)
- Visual Studio com a carga de trabalho **ASP.NET e desenvolvimento Web**, ou Visual Studio Code com a extensão **C# Dev Kit**.

### 1. Clonar o repositório

```bash
git clone https://github.com/SamuelLucas1/CadastroProdutosAPI.git
```

### 2. Acessar a pasta da solução

```bash
cd CadastroProdutosAPI/CadastroProdutos
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Instalar a ferramenta do Entity Framework Core (caso ainda não esteja instalada)

```bash
dotnet tool install --global dotnet-ef --version 10.*
```

Se já possuir a ferramenta instalada, você pode verificar sua versão com:

```bash
dotnet ef --version
```

### 5. Aplicar as migrations

```bash
dotnet ef database update --project CadastroProdutos/CadastroProdutos.csproj
```

Esse comando cria ou atualiza o banco SQLite de acordo com as migrations disponíveis.

### 6. Executar a aplicação

```bash
dotnet run --project CadastroProdutos/CadastroProdutos.csproj
```

A aplicação utiliza as portas configuradas no `launchSettings.json`:

- HTTP: `http://localhost:5219`
- HTTPS: `https://localhost:7075`

### 7. Acessar o Swagger

Com a aplicação em execução no ambiente de desenvolvimento, acesse:

```text
https://localhost:7075/swagger
```

## 💻 Executando pelo Visual Studio

1. Clone o repositório.
2. Abra `CadastroProdutos.slnx` no Visual Studio.
3. Aguarde a restauração dos pacotes NuGet.
4. Verifique se o projeto `CadastroProdutos` está definido como projeto de inicialização.
5. Execute com `F5` ou `Ctrl + F5`.
6. Acesse o Swagger pelo endereço HTTPS configurado.

Antes de testar os endpoints, aplique as migrations com o comando indicado anteriormente.

## 🧑‍💻 Executando pelo Visual Studio Code

1. Instale o [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Instale a extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).
3. Abra a pasta da solução no VS Code.
4. Abra o terminal integrado.
5. Execute os comandos de restauração, migrations e inicialização apresentados anteriormente.
6. Acesse o Swagger pelo navegador.

## 📚 Aprendizados

Durante o desenvolvimento deste projeto, pratiquei:

- Criação de APIs REST utilizando ASP.NET Core Controllers.
- Organização de endpoints com Controllers e atributos HTTP.
- Implementação de autenticação utilizando JWT.
- Criação e validação de tokens com Claims.
- Autorização baseada em funções (*Role-based Authorization*).
- Injeção de dependência e abstração com interfaces.
- Separação de operações em serviços.
- Persistência de dados com Entity Framework Core.
- Utilização de SQLite e migrations.
- Validação de dados com Data Annotations.
- Documentação e testes utilizando Swagger.

## 👨‍💻 Autor

**Samuel Lucas**

Estudante de Jogos Digitais e desenvolvedor em formação, com foco em C#, .NET e desenvolvimento backend.

- GitHub: [SamuelLucas1](https://github.com/SamuelLucas1)
- LinkedIn: [Samuel Lucas](https://www.linkedin.com/in/samuel-lucas-916b583b2/)

---

Projeto desenvolvido para fins educacionais e de portfólio, com foco no aprendizado de desenvolvimento backend utilizando o ecossistema .NET.
