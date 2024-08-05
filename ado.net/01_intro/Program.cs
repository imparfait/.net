using System.Data.SqlClient;

namespace _01_intro
{
    internal class Program
    {
        static string connectionString = @"Data Source = computer\sqlexpress; Database=Sales;Integrated Security=True;";
        private static bool TableExists(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableName", tableName);
                int tableCount = (int)command.ExecuteScalar();
                return tableCount > 0;
            }
        }
        private static void CreateTable(string tableCreationQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(tableCreationQuery, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Table created successfully.");
            }
        }
        private static void InsertTable(string tableInsertionQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(tableInsertionQuery, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Table inserted successfully.");
            }
        }
        private static void EnsureTablesExist()
        {
            string customersTableQuery = @"
            CREATE TABLE Customers (
                Id INT PRIMARY KEY IDENTITY,
                FirstName NVARCHAR(50),
                LastName NVARCHAR(50)
            )";
            string customersInsertQuery = @"INSERT INTO Customers (FirstName, LastName) VALUES " +
                    "('John', 'Doe'), " +
                    "('Jane', 'Smith')";

            string sellersTableQuery = @"
            CREATE TABLE Sellers (
                Id INT PRIMARY KEY IDENTITY,
                FirstName NVARCHAR(50),
                LastName NVARCHAR(50)
            )";
            string sellersInsertQuery = @"INSERT INTO Sellers (FirstName, LastName) VALUES " +
                "('Alice', 'Johnson'), " +
                "('Bob', 'Brown')";
            string salesTableQuery = @"
            CREATE TABLE Sales (
                Id INT PRIMARY KEY IDENTITY,
                CustomerId INT,
                SellerId INT,
                SaleAmount DECIMAL(18, 2),
                SaleDate DATE,
                FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
                FOREIGN KEY (SellerId) REFERENCES Sellers(Id)
            )";
            string salesInsertQuery = @"INSERT INTO Sales (CustomerId, SellerId, Amount, SaleDate) VALUES " +
                "(1, 1, 150.00, '2023-01-01'), " +
                "(2, 2, 250.00, '2023-02-01')";

            if (!TableExists("Customers"))
            {
                CreateTable(customersTableQuery);
                InsertTable(customersInsertQuery);
            }

            if (!TableExists("Sellers"))
            {
                CreateTable(sellersTableQuery);
                InsertTable(sellersInsertQuery);
            }

            if (!TableExists("Sales"))
            {
                CreateTable(salesTableQuery);
                InsertTable(salesInsertQuery);
            }
        }
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected success");
            EnsureTablesExist();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show all customers");
                Console.WriteLine("2. Show all sellers");
                Console.WriteLine("3. Show sales by a specific seller");
                Console.WriteLine("4. Show sales above a specific amount");
                Console.WriteLine("5. Show the most expensive and cheapest purchase by a specific customer");
                Console.WriteLine("6. Show the first sale by a specific seller");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowAllCustomers();
                        break;
                    case 2:
                        ShowAllSellers();
                        break;
                    case 3:
                        ShowSalesBySeller();
                        break;
                    case 4:
                        ShowSalesAboveAmount();
                        break;
                    case 5:
                        ShowMostAndLeastExpensivePurchaseByCustomer();
                        break;
                    case 6:
                        ShowFirstSaleBySeller();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        private static void ShowAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    Console.WriteLine($"ID: {id}, First Name: {firstName}, Last Name: {lastName}");
                }
            }
        }
        private static void ShowAllSellers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Sellers", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    Console.WriteLine($"ID: {id}, First Name: {firstName}, Last Name: {lastName}");
                }
            }
        }

        private static void ShowSalesBySeller()
        {
            Console.Write("Enter seller's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter seller's last name: ");
            string lastName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT Sales.* FROM Sales JOIN Sellers ON Sales.SellerId = Sellers.Id " +
                    "WHERE Sellers.FirstName = @FirstName AND Sellers.LastName = @LastName", connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int customerId = reader.GetInt32(1);
                    int sellerId = reader.GetInt32(2);
                    decimal amount = reader.GetDecimal(3);
                    DateTime date = reader.GetDateTime(4);
                    Console.WriteLine($"ID: {id}, Customer ID: {customerId}, Seller ID: {sellerId}, Amount: {amount}, Date: {date}");
                }
            }
        }

        private static void ShowSalesAboveAmount()
        {
            Console.Write("Enter the amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Sales WHERE Amount > @Amount", connection);
                command.Parameters.AddWithValue("@Amount", amount);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int customerId = reader.GetInt32(1);
                    int sellerId = reader.GetInt32(2);
                    decimal saleAmount = reader.GetDecimal(3);
                    DateTime date = reader.GetDateTime(4);
                    Console.WriteLine($"ID: {id}, Customer ID: {customerId}, Seller ID: {sellerId}, Amount: {saleAmount}, Date: {date}");
                }
            }
        }

        private static void ShowMostAndLeastExpensivePurchaseByCustomer()
        {
            Console.Write("Enter customer's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter customer's last name: ");
            string lastName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT MAX(Amount) FROM Sales JOIN Customers ON Sales.CustomerId = Customers.Id " +
                    "WHERE Customers.FirstName = @FirstName AND Customers.LastName = @LastName", connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                object result = command.ExecuteScalar();
                decimal maxAmount = result != DBNull.Value ? (decimal)result : 0;
                Console.WriteLine($"Most expensive purchase amount: {maxAmount}");

                command.CommandText =
                    "SELECT MIN(Amount) FROM Sales JOIN Customers ON Sales.CustomerId = Customers.Id " +
                    "WHERE Customers.FirstName = @FirstName AND Customers.LastName = @LastName";
                result = command.ExecuteScalar();
                decimal minAmount = result != DBNull.Value ? (decimal)result : 0;
                Console.WriteLine($"Cheapest purchase amount: {minAmount}");
            }
        }
        private static void ShowFirstSaleBySeller()
        {
            Console.Write("Enter seller's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter seller's last name: ");
            string lastName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT TOP 1 Sales.* FROM Sales " +
                    "JOIN Sellers ON Sales.SellerId = Sellers.Id " +
                    "WHERE Sellers.FirstName = @FirstName AND Sellers.LastName = @LastName " +
                    "ORDER BY Sales.SaleDate ASC", connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int customerId = reader.GetInt32(1);
                    int sellerId = reader.GetInt32(2);
                    decimal amount = reader.GetDecimal(3);
                    DateTime date = reader.GetDateTime(4);
                    Console.WriteLine($"First Sale ID: {id}, Customer ID: {customerId}, Seller ID: {sellerId}, Amount: {amount}, Date: {date}");
                }
                else
                {
                    Console.WriteLine("No sales found for the specified seller.");
                }
            }
        }
    }
}
