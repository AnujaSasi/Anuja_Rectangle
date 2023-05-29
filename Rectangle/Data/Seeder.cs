using Project_Rectangle.Models;

namespace Project_Rectangle.Data
{
    public static class Seeder
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //your seeding data here

            if (!context.Rectangles.Any())
            {
                Random random = new Random();

                for (int i = 0; i < 200; i++)
                {
                    var rectangle = new RectangleClass
                    {
                        X = random.Next(0, 100),
                        Y = random.Next(0, 100),
                        Width = random.Next(1, 10),
                        Height = random.Next(1, 10)
                    };

                    context.Rectangles.Add(rectangle);
                }

                context.SaveChanges();
            }
        }       

        
    }
}


