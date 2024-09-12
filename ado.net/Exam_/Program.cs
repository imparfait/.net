using Microsoft.EntityFrameworkCore;
using Exam_.classes;

namespace Exam_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicStoreContex())
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. Add vynil");
                    Console.WriteLine("2. Edit vynil");
                    Console.WriteLine("3. Deleye vynil");
                    Console.WriteLine("4. Sell vynil");
                    Console.WriteLine("5. Show vynil");
                    Console.WriteLine("6. Exit");

                    Console.Write("Choose an option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            AddVinyl(context);
                            break;
                        case "2":
                            EditVinyl(context);
                            break;
                        case "3":
                            DeleteVinyl(context);
                            break;
                        case "4":
                            SellVinyl(context);
                            break;
                        case "5":
                            ShowVinyls(context);
                            break;
                        case "6":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Wrong option.");
                            break;
                    }
                }
            }
        }
        static void AddVinyl(MusicStoreContex context)
        {
            var vinyl = new VinylRecord();

            Console.Write("Enter vinyl title: ");
            vinyl.Title = Console.ReadLine();

            Console.Write("Enter artist name: ");
            vinyl.Artist = Console.ReadLine();

            Console.Write("Enter publisher name: ");
            vinyl.Publisher = Console.ReadLine();

            Console.Write("Enter track count: ");
            vinyl.TrackCount = int.Parse(Console.ReadLine());

            Console.Write("Enter genre: ");
            vinyl.Genre = Console.ReadLine();

            Console.Write("Enter release year: ");
            vinyl.ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Enter cost price: ");
            vinyl.CostPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter selling price: ");
            vinyl.SellingPrice = decimal.Parse(Console.ReadLine());

            context.VinylRecords.Add(vinyl);
            context.SaveChanges();
            Console.WriteLine("Vinyl record added successfully.");
        }

        static void EditVinyl(MusicStoreContex context)
        {
            Console.Write("Enter vinyl ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var vinyl = context.VinylRecords.FirstOrDefault(v => v.Id == id);
            if (vinyl != null)
            {
                Console.Write("Enter new title (current: " + vinyl.Title + "): ");
                vinyl.Title = Console.ReadLine();
                context.SaveChanges();
                Console.WriteLine("Vinyl record updated successfully.");
            }
            else
            {
                Console.WriteLine("Vinyl record not found.");
            }
        }

        static void DeleteVinyl(MusicStoreContex context)
        {
            Console.Write("Enter vinyl ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var vinyl = context.VinylRecords.FirstOrDefault(v => v.Id == id);
            if (vinyl != null)
            {
                context.VinylRecords.Remove(vinyl);
                context.SaveChanges();
                Console.WriteLine("Vinyl record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Vinyl record not found.");
            }
        }

        static void SellVinyl(MusicStoreContex context)
        {
            Console.Write("Enter vinyl ID to sell: ");
            int id = int.Parse(Console.ReadLine());

            var vinyl = context.VinylRecords.FirstOrDefault(v => v.Id == id);
            if (vinyl != null)
            {
                context.VinylRecords.Remove(vinyl);
                context.SaveChanges();
                Console.WriteLine("Vinyl record sold successfully.");
            }
            else
            {
                Console.WriteLine("Vinyl record not found.");
            }
        }

        static void ShowVinyls(MusicStoreContex context)
        {
            var vinyls = context.VinylRecords.ToList();
            foreach (var vinyl in vinyls)
            {
                Console.WriteLine($"{vinyl.Id}: {vinyl.Title} - {vinyl.Artist} ({vinyl.Genre}, {vinyl.ReleaseYear})");
            }
        }
    }
}
