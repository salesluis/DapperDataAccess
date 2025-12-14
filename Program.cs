using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

var connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
     ListCategories(connection);
     // CreateCategories(connection);
     UpdateCategoty(connection);
}


static void ListCategories(SqlConnection connection)
{
     var item = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
     foreach (var c in item)
     {
          Console.WriteLine($"{c.Id} -> {c.Title}");
     }
}
static void CreateCategories(SqlConnection connection)
{
     var category = new Category (
          "Amazon AWS",
          "amazon", 
          "AWS Cloud",
          8, 
          "CAtegoria destinada a serviços AWS", 
          false
     );
     
     var insertSql = @"INSERT INTO 
                    [Category] 
                  VALUES (
                      @Id, 
                      @Title, 
                      @Url, 
                      @Summary, 
                      @Order,
                      @Description,
                      @Featured)";
     
     var rows = connection.Execute(insertSql, new
     {
          category.Id,
          category.Title,
          category.Url,
          category.Summary,
          category.Order,
          category.Description,
          category.Featured
     });
     Console.WriteLine($"{rows}Insert successful");
}

static void UpdateCategoty(SqlConnection connection)
{
     var updateSql = "UPDATE [Category] SET [Title] = @title WHERE  [Id] = @id";
     var rows = connection.Execute(updateSql, new
     {
          title = "teste",
          id = new Guid("3E0B748B-8D26-4753-9393-00F7F49972C4"),
     });
}