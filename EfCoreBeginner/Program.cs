using EfCoreBeginner.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDBContext();
// xóa database nếu nó đã tồn tại và tạo lại database mới
//db.Database.EnsureDeleted();
//// tạo database nếu nó chưa tồn tại
//db.Database.EnsureCreated();
// create  thêm dữ liệu mẫu nếu bảng đang trống
// any nghĩa là xó tồn tại ít nhất 1 dữ liẹu nào không. nó trả về bool thì chỉ có true và false \
// phụ định bảng product có ít nhất 1 sản phẩm nào không 
// nếu bảng product không có sản phẩm nào thì thêm bàn phím cơ vào và giá 
//if (!db.Products.Any())
//{
//    db.Products.Add(new Product
//    {
//        Name = "Bàn phím cơ",
//        Price = 500000
//    });
//    db.Products.Add(new Product
//    {
//        Name = "Chuột không dây",
//        Price = 3000
//    });

//    db.SaveChanges();
//}\
// lọc xem trong bảng đã có những sản phẩm này chưa nếu chưa thì thêm vào tránh trường hợp bị trung sản phẩm
if (!db.Products.Any(x => x.Name == "Chuột không dây"))
{
    db.Products.Add(new Product
    {
        Name = "Chuột không dây",
        Price = 2500
    });
}
if (!db.Products.Any(x => x.Name == "Tai nghe blutooth"))
{
    db.Products.Add(new Product
    {
        Name = " tai nghe blutooth",
        Price = 5000
    });
}
if (!db.Products.Any(x => x.Name == "Màn Hình 24 Inch"))
{
    db.Products.Add(new Product
    {
        Name = " Màn hình 24 inch",
        Price = 400000
    });
 
}
db.SaveChanges();
// Read lây tất cả sản phẩm
Console.WriteLine("Danh sách tất cả các sản phẩm");
var products = db.Products.ToList();// lấy danh sách từ database về

// với mỗi product trong danh sách products in tên nó ra 
foreach (var product in products)
{
    Console.WriteLine($"{product.Id} - {product.Name} - {product.Price:N0} VND");
}
// Update tìm sản phẩm có id = 1 ròi đổi giá trị nó
var productUpdate = db.Products.FirstOrDefault(x => x.Id == 1);//  với mỗi sản phẩm x kiểm tra xem id nó có bằng 1 không nếu có thì trả về sản phẩm đó còn không thì trả về null
if (productUpdate != null)
{
    productUpdate.Price = 600000;
    db.SaveChanges();
    Console.WriteLine("Đã cập nhập giá san pham id =1");
}
// Delete xóa sản phẩm có id = 2
var productDelete = db.Products.FirstOrDefault(x => x.Id == 2);
if (productDelete != null)
{
    db.Products.Remove(productDelete);
    db.SaveChanges();
    Console.WriteLine("Đã xóa sản phẩm id = 2");
}
//read lại danh sách sản phẩm sau khi update và delete
Console.WriteLine("Danh sách sản phẩm sau khi update và delete");
var productsAfterUpdateDelete = db.Products.ToList();
foreach (var product in productsAfterUpdateDelete)
{
    Console.WriteLine($"{product.Id} - {product.Name} - {product.Price:N0} VND");
}
// lọc sản phẩm có giá tren 5000
var expensiveProducts = db.Products
    .Where(x => x.Price >= 5000)
    .ToList();
Console.WriteLine("San pham co gia tu 5000 tro len");
foreach(var product in expensiveProducts)
{
    Console.WriteLine($"{product.Id}-{product.Name}-{product.Price:N0} VND");
}
// tìm kiếm sản phẩm có chữ "tai" trong tên
var keywork = "tai";
var searchproducts = db.Products
    .Where(x => x.Name.Contains(keywork)).ToList();
Console.WriteLine("Ket qua tim kiem san pham co chu tai");
foreach(var product in searchproducts)
{
    Console.WriteLine($"{product.Id}-{product.Name}-{product.Price:N0} VND");
}

// sắp xếp sản phẩm theo giá tăng dần
var productOderby = db.Products
    .OrderBy(x=>x.Price)
    .ToList();
Console.WriteLine("Danh sách sản phẩm theo giá tăng dần");
foreach(var product in productOderby)
{
    Console.WriteLine($"{product.Name}-{product.Price:N0} VND");
}

// sắp xếp sản phẩm theo giá giảm dần
var descproducts = db.Products
    .OrderByDescending(x=>x.Price)
    .ToList();
Console.WriteLine("Danh sách sản phẩm theo giá giảm dần");
foreach(var product in descproducts)
{
    Console.WriteLine($"{product.Name}-{product.Price:N0} VND");
}

//select chỉ lấy cột tên sản phẩm
var names = db.Products
    .Select(x => x.Name)
    .ToList();
Console.WriteLine("Danh sách tên sản phẩm");
foreach (var name in names)
{
    Console.WriteLine(name);
}
// selecct lâsy tên và giá sản phẩm
var nameAndPrice = db.Products
    .Select(x => new 
    { x.Name,
      x.Price,
      x.Id
    })
    .ToList();
Console.WriteLine("Danh sách tên và giá sản phẩm");
foreach (var item in nameAndPrice)
{
    Console.WriteLine($"{item.Id}-{item.Name}-{item.Price:N0} VND");
}

// Tính tổng giá trị tất cả sản phẩm
decimal toolPrice = db.Products.Sum(x => x.Price);
Console.WriteLine($"Tổng giá trị tất cả sản phẩm: {toolPrice:N0} VND");
// tìm giá sanr phẩm lớn nhất
 decimal maxPrice = db.Products.Max(x => x.Price);
Console.WriteLine($"Gia san pham cao nhat {maxPrice:N0} VND");

// tìm giá sản phẩm thấp nhất
decimal minPrice = db.Products.Min(x => x.Price);
Console.WriteLine($"Gia san pham thap nhat {minPrice:N0}");

//tim gia tri trung binh
decimal averagePrice = db.Products.Average(x => x.Price);
Console.WriteLine($"gia tri trung binh {averagePrice:N0} VND");