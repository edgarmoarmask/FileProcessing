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

            List<SpecialCharacter> chars = new List<SpecialCharacter>()
            {
                new SpecialCharacter(){ Description="Tab", Value="\t"},
                new SpecialCharacter(){ Description="Space", Value=" "},
                new SpecialCharacter(){ Description="Empty String", Value=""},
                new SpecialCharacter(){ Description=";", Value=";"},
                new SpecialCharacter(){ Description="#", Value="#"},
                new SpecialCharacter(){ Description="$", Value="$"},
                new SpecialCharacter(){ Description="%", Value="%"},
                new SpecialCharacter(){ Description="^", Value="^"},
                new SpecialCharacter(){ Description="m² (m squared)", Value="m²"},
                new SpecialCharacter(){ Description="m³ (m power three)", Value="m³"},
                new SpecialCharacter(){ Description="*", Value="*"},
            };

            this.db.SpecialCharacters.AddRange(chars);
            this.db.SaveChanges();
        }
    }
}

