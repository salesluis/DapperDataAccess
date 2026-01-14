using Microsoft.Data.SqlClient;
using DapperDataAccess.Query;
using DapperDataAccess.Command;

var connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

using var connection = new SqlConnection(connectionString);

// Query
// var categories = QueryCategories.ListCategories(connection);
// foreach (var c in categories)
// {
//      Console.WriteLine($"{c.Id} - {c.Title}");
// }

var category = QueryCategories.GetById(connection, new Guid("09CE0B7B-CFCA-497B-92C0-3290AD9D5142"));
Console.WriteLine(category);
// Command

// CreateCategories(connection);
CommandCategory.UpdateCategoty(connection);





