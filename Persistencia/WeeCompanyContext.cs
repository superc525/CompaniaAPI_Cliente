
namespace Persistencia
{
    using Dominio;
    using Microsoft.EntityFrameworkCore;

    public class WeeCompanyContext: DbContext
    {
        public WeeCompanyContext(DbContextOptions<WeeCompanyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Compania>(entity => { entity.HasKey(e => e.Id); });
        }
        public DbSet<Compania> Compania { get; set; }

    }
}
