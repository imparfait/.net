namespace _05_fluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopDbContext())
            {
                context.Database.Migrate();
                var initializer = new ShopDbInitializer();
                initializer.Seed(context);
            }

            Console.WriteLine("Database has been initialized with seed data.");
        }
    }
}