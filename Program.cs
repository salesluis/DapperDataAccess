using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

var connectionString = "";

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

using (var connection = new SqlConnection(connectionString))
{
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
     
     var item = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
     foreach (var c in item)
     {
          Console.WriteLine($"{c.Id} -> {c.Title}");
     }
}