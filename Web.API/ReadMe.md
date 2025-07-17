1.加入專案WebAPI及WebView
2.DB First
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NorthWind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YourDbContext

3.安裝SwaggerUI
dotnet add Web.API/Web.API.csproj package Swashbuckle.AspNetCore

4.新增 CustomersController 以實現 CRUD 操作

5.