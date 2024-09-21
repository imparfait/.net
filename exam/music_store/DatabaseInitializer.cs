using music_store.classes;

namespace music_store
{
    public static class DatabaseInitializer
    {
        public static void Seed(MusicStoreContext context)
        {
            if (!context.VinylRecords.Any())
            {
                context.VinylRecords.AddRange(new List<VinylRecord>
                {
                    new VinylRecord
                    {
                        Title = "The Dark Side of the Moon",
                        Artist = "Pink Floyd",
                        Publisher = "Harvest Records",
                        TrackCount = 10,
                        Genre = "Rock",
                        ReleaseYear = 1973,
                        CostPrice = 5.0m,
                        SellingPrice = 25.0m
                    },
                    new VinylRecord
                    {
                        Title = "Abbey Road",
                        Artist = "The Beatles",
                        Publisher = "Apple Records",
                        TrackCount = 17,
                        Genre = "Rock",
                        ReleaseYear = 1969,
                        CostPrice = 4.0m,
                        SellingPrice = 30.0m
                    }
                });

                context.SaveChanges();
            }
        }
    }
}