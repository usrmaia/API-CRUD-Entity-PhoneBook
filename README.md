# Entity-CRUD

1. Instalando EntityFrameworkCore (via terminal):
```
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.5
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.5
```
2. Criar as classes equivalentes as tabelas em Entities;
3. Em Context criar a classe que chama o DB, onde cada prop é equivalente a uma tabela;
4. Em appsettings.Development, criar a conexão:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\sqlexpress; Initial Catalog=Phone Book; Integrated Security=True"
}
```
5. Criar Migrations (no terminal):
```
dotnet-ef migrations add CreateTableContact
```
6. Subir o banco de dados (via terminal):
```
dotnet-ef database update
```