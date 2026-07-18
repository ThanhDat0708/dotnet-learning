using EfCoreBeginner.Models;
using Microsoft.EntityFrameworkCore;
using EfCoreBeginner.Models;



using var db = new AppDBContext();

Console.WriteLine(db.Database.GetConnectionString());

try
{
    db.Database.OpenConnection();
    Console.WriteLine("Kết nối thành công!");
    db.Database.CloseConnection();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}