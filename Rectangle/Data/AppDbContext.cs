using Microsoft.EntityFrameworkCore;
using Project_Rectangle.Models;

namespace Project_Rectangle.Data
{
    public class AppDbContext: DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<RectangleClass> Rectangles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //To seed the first data into the datbase
          //  modelBuilder.Entity<RectangleClass>().HasData(
            //    new RectangleClass { Id = 1, X = 1,Y=1,Height=1,Width=1 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
