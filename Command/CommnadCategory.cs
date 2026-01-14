using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DapperDataAccess.Command;

public static class CommandCategory
{
    public static void CreateCategories(SqlConnection connection)
    {

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


        var category = new Category(
            "Amazon AWS",
            "amazon",
            "AWS Cloud",
            8,
            "CAtegoria destinada a serviços AWS",
            false
        );
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

    public static void UpdateCategoty(SqlConnection connection)
    {
        var updateSql = "UPDATE [Category] SET [Title] = @title WHERE  [Id] = @id";
        var rows = connection.Execute(updateSql, new
        {
            title = "teste",
            id = new Guid("3E0B748B-8D26-4753-9393-00F7F49972C4"),
        });

        Console.WriteLine($"{rows}Insert successful");
    }


    public static void DeleteCategoty(SqlConnection connection)
    {
        var updateSql = "UPDATE [Category] SET [Title] = @title WHERE  [Id] = @id";
        var rows = connection.Execute(updateSql, new
        {
            title = "teste",
            id = new Guid("3E0B748B-8D26-4753-9393-00F7F49972C4"),
        });

        Console.WriteLine($"{rows}Insert successful");
    }
}