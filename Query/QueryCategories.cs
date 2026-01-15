using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DapperDataAccess.Query;

public class QueryCategories
{
     public IEnumerable<Category> ListCategories(SqlConnection connection)
     {
          var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
          return categories;
     }

     public Category GetById(SqlConnection connection, Guid id)
     {
          var selectSql = $"SELECT * FROM [Category] WHERE [Id] = @Id";
          var category = connection.QueryFirst<Category>(selectSql, new { id });
          return category;
     }
     
     public Category GetByName(SqlConnection connection, string title)
     {
          var selectSql = $"SELECT * FROM [Category] WHERE [Title] = @Title";
          var category = connection.QueryFirst<Category>(
               selectSql,
               new { title });
          
          return category;
     }
}