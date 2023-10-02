using Microsoft.EntityFrameworkCore;
using WoofHub_App.Models;

namespace WoofHub_App.Data
{
    public class WoofHubContext : DbContext
    {
        public WoofHubContext(DbContextOptions<WoofHubContext> options)
            : base(options)
        {
            
        }

        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<AdressModel> Adress { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<AdoptionModel> Adoption { get; set; }

    }
}
