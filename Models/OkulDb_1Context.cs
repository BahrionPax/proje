using Microsoft.EntityFrameworkCore;

namespace MVCProjesi.Models
{
    public class OkulDb_1Context : DbContext 
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SKILLPOINTSS\\SQLEXPRESSTABANI;Database=OkulDbMVC;Integrated Security=true;TrustServerCertificate=true");
        }
       
    }
}
