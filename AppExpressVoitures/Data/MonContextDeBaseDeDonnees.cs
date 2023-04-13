using AppExpressVoitures.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppExpressVoitures.Data
{
    public class MonContextDeBaseDeDonnees : DbContext
    {
        public MonContextDeBaseDeDonnees(DbContextOptions<MonContextDeBaseDeDonnees> options) : base(options)
                { }
        public DbSet<Voitures> Voitures { get; set; }
        public DbSet<Reparations> Reparations { get; set; }

    }
}

