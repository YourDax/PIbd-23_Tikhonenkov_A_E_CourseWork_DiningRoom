using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DiningRoomDatabaseImplement
{
    public class DiningRoomDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if (!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=DiningRoom;Username=postgres;Password=postgres");
            }

            base.OnConfiguring(OptionsBuilder);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<Component> Components { get; set; }

		public virtual DbSet<Drink> Drinks { get; set; }

		public virtual DbSet<DrinkComponent> DrinkComponents { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<ProductComponent> ProductComponents { get; set; }


		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Card> Cards { get; set; }
		
	}
}
