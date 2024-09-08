using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Data.Models
{

	public class Context : DbContext
	{
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-MALS7DKQ\\SQLEXPRESS01;database=DbFood;integrated security=true;Encrypt=True;TrustServerCertificate=True;");
		}
	}
}

