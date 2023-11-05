using Microsoft.EntityFrameworkCore;
using WeatherApp.ViewModel;

namespace WeatherApp.Model
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api 
            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Book>()
                .Property(p => p.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Book>().HasData(ProductSeeder.GenerateProductData());
        }
    }
}
