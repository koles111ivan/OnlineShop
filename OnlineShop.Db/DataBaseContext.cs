using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;


namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Линекс форте", Cost = 1099, Description = "Лактобактерии ацидофиллус, Бифидобактерии ВВ12", ImagePath = "/images/линекс форте.png" },
                new Product { Id = 2, Name = "Дона", Cost = 1671, Description = "Глюкозамин", ImagePath = "/images/Дона.webp" },
                new Product { Id = 3, Name = "Фитолакс", Cost = 521, Description = "Эвалар", ImagePath = "/images/Фитолакс.webp" },
                new Product { Id = 4, Name = "Гептрал", Cost = 1939, Description = "Действующим веществом является адеметионин.", ImagePath = "/images/Гептрал.jpg" },
                new Product { Id = 5, Name = "Тантум верде", Cost = 860, Description = "От боли в горле", ImagePath = "/images/тантум верде.jpg" },
                new Product { Id = 6, Name = "Зодак", Cost = 290, Description = "Таблетки от аллергии", ImagePath = "/images/Зодак.jpg" },
                new Product { Id = 7, Name = "Nivea Sun", Cost = 1132, Description = "Спрей от солнца", ImagePath = "/images/Nivea_Sun.jpg" },
                new Product { Id = 8, Name = "Нурофен", Cost = 197, Description = "От боли в голове", ImagePath = "/images/нурофен.webp" }
            );
        }
    }
}
