namespace SpotlightBDA.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
        public DbSet<ReplacePolicy> ReplacePolicies { get; set; }
        public DbSet<CheckLimitPolicy> CheckLimitPolicies { get; set; }
        public DbSet<FileProcessPolicy> FileProcessPolicies { get; set; }
        public DbSet<FolderData> FolderData { get; set; }
        public DbSet<SpecialCharacter> SpecialCharacters { get; set; }
    }
}
