using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DapperDataAccess.Command;

public class CommandCategory
{
    public void CreateCategories(SqlConnection connection, Category category)
    {
        // usar parametros do SQLServer ao invés de interpolação de strings
        // para evitar ataques de SQLInjection
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

    public void UpdateTitleCategoty(SqlConnection connection, string title, Guid id)
    {
        var updateSql = "UPDATE [Category] SET [Title] = @title WHERE  [Id] = @id";
        var rows = connection.Execute(updateSql, new
        {
            title,
            id,
        });

        Console.WriteLine($"{rows}Insert successful");
    }
    
    public void DeleteCategoty(SqlConnection connection,  Guid id)
    {
        var updateSql = "DELETE FROM [Category] WHERE [Id] = @Id";
        var rows = connection.Execute(updateSql, new
        {
            title = "teste",
            id = new Guid("3E0B748B-8D26-4753-9393-00F7F49972C4"),
        });

        Console.WriteLine($"{rows}Insert successful");
    }
    
    
}