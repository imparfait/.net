using _05_fluentAPI.classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Seed;


public class ShopDbInitializer : DropCreateDatabaseIfModelChanges<ShopDbContext>
{
    public override void Seed(ShopDbContext context)
    {
        var countries = new List<Country>
        {
            new Country { Name = "USA" },
            new Country { Name = "Germany" },
            new Country { Name = "Japan" }
        };
        var cities = new List<City>
        {
            new City { Name = "New York", Country = countries[0] },
            new City { Name = "Berlin", Country = countries[1] },
            new City { Name = "Tokyo", Country = countries[2] }
        };
        var positions = new List<Position>
        {
            new Position { Name = "Manager" },
            new Position { Name = "Cashier" },
            new Position { Name = "Sales Associate" }
        };
        var shops = new List<Shop>
        {
            new Shop { Name = "TechStore", Address = "123 Tech Lane", City = cities[0], ParkingArea = 50 },
            new Shop { Name = "FashionHub", Address = "456 Fashion Ave", City = cities[1], ParkingArea = 30 },
            new Shop { Name = "GadgetWorld", Address = "789 Gadget St", City = cities[2], ParkingArea = 40 }
        };
        var categories = new List<Category>
        {
            new Category { Name = "Electronics" },
            new Category { Name = "Clothing" },
            new Category { Name = "Home Appliances" }
        };
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200m, Discount = 10f, Category = categories[0], Quantity = 20, IsInStock = true },
            new Product { Name = "Smartphone", Price = 800m, Discount = 5f, Category = categories[0], Quantity = 50, IsInStock = true },
            new Product { Name = "Jeans", Price = 60m, Discount = 20f, Category = categories[1], Quantity = 100, IsInStock = true },
            new Product { Name = "T-Shirt", Price = 20m, Discount = 15f, Category = categories[1], Quantity = 150, IsInStock = true },
            new Product { Name = "Blender", Price = 70m, Discount = 10f, Category = categories[2], Quantity = 40, IsInStock = true }
        };
        var workers = new List<Worker>
        {
            new Worker { Name = "John", Surname = "Doe", Salary = 50000m, Email = "john.doe@example.com", PhoneNumber = "1234567890", Position = positions[0], Shop = shops[0] },
            new Worker { Name = "Jane", Surname = "Smith", Salary = 35000m, Email = "jane.smith@example.com", PhoneNumber = "0987654321", Position = positions[1], Shop = shops[1] },
            new Worker { Name = "Alice", Surname = "Johnson", Salary = 30000m, Email = "alice.johnson@example.com", PhoneNumber = "1122334455", Position = positions[2], Shop = shops[2] }
        };

        context.Countries.AddRange(countries);
        context.Cities.AddRange(cities);
        context.Positions.AddRange(positions);
        context.Shops.AddRange(shops);
        context.Categories.AddRange(categories);
        context.Products.AddRange(products);
        context.Workers.AddRange(workers);

        context.SaveChanges();
    }
}

