using Dapper;
using DapperDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DapperDataAccess.Query;

public static class QueryCategories
{
     public static IEnumerable<Category> ListCategories(SqlConnection connection)
     {
          var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
          return categories;
     }

     public static Category GetById(SqlConnection Connection, Guid id)
     {
          var sql = $"SELECT * FROM [Category] WHERE [Id] = {id}";
          var category = Connection.QueryFirst<Category>(sql);
          return category;
     }
}