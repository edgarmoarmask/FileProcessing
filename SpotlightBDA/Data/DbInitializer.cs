using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpotlightBDA.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext db;

        public DbInitializer(
            ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();
        }
    }
}
