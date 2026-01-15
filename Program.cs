using Microsoft.Data.SqlClient;
using DapperDataAccess.Command;
using DapperDataAccess.Models;
using DapperDataAccess.Query;

var connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

using var connection = new SqlConnection(connectionString);
var commandCategory = new CommandCategory();
var queryCategories = new QueryCategories();

// ----------------------  get all categories  ---------------------- //
var categories = queryCategories.ListCategories(connection);
foreach (var c in categories)
{
     Console.WriteLine($"{c.Id} - {c.Title}");
}

// ----------------------  get by id  ---------------------- //
var category = queryCategories.GetById(connection, new Guid("09CE0B7B-CFCA-497B-92C0-3290AD9D5142"));
Console.WriteLine(category.Title);

// ----------------------  insert category  ---------------------- //
var newCategory = new Category("New Category3", "new-category-title2", "summary2", 34, "test insert category", true);
commandCategory.CreateCategories(connection, newCategory);

// ----------------------  get by name  ---------------------- //
var categoryByName = queryCategories.GetByName(connection, "New Category3");
Console.WriteLine(categoryByName.Title);


// CommandCategory.UpdateCategoty(connection);





