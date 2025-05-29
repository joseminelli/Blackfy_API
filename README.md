# Blackfy_API

API desenvolvida em **ASP.NET Core**, com foco em rotas organizadas e conexão direta ao banco de dados **PostgreSQL**

---

## ⚙️ Escolhas Técnicas

* **PostgreSQL**: banco de dados relacional ideal para garantir integridade e desempenho
* **Dapper**: micro-ORM que facilita o mapeamento entre objetos C# e o banco, mantendo controle total sobre as queries
* **ASP.NET Core**: framework moderno e eficiente, perfeito para construir APIs rápidas e seguras
* **Swagger**: utilizado para documentar e testar a API de forma simples e prática durante o desenvolvimento
---

## 🚀 Como executar o projeto localmente

### **Pré-requisitos:**

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Git](https://git-scm.com/)

---

### **Passos:**

1. **Clone o repositório:**

```bash
git clone https://github.com/joseminelli/Blackfy_API.git
cd Blackfy_API
```

2. **Configure o banco de dados:**

Certifique-se de que o PostgreSQL está rodando e que o banco `blacfyTest` foi criado com o usuário e senha configurados na conexão

**Exemplo de string de conexão no `appsettings.json`:**

```json
{
  ...
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=SuaDB;Username=postgres;Password=postgres"
  }
}
```

3. **Restaurar pacotes:**

```bash
dotnet restore
```

4. **Executar a aplicação:**

```bash
dotnet run
```

5. **Acessar a API:**

* Swagger: *Abre automáticamente ao executar*

---

## 📄 Endpoints principais

### **ExternalLinkController**

| Método | Rota                             | Descrição                                                       |
| ------ | -------------------------------- | --------------------------------------------------------------- |
| GET    | /ExternalLink?driverNumber={driverId} | Consulta informações de um piloto com base no número fornecido |

---

### **UsersController**

| Método | Rota           | Descrição                      |
| ------ | -------------- | ------------------------------ |
| GET    | /Users         | Lista todos os usuários       |
| POST   | /Users         | Cria um novo usuário          |
| DELETE | /Users?id={id} | Deleta um usuário pelo `id`   |
| PUT    | /Users?id={id} | Atualiza um usuário pelo `id` |


---

## 📫 Contato

Desenvolvido por [José Minelli](https://github.com/joseminelli)
