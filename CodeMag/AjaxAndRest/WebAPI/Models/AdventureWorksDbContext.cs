using Microsoft.EntityFrameworkCore;

namespace WebAPI {
    public partial class AdventureWorksDbContext : DbContext {
        public AdventureWorksDbContext(
            DbContextOptions<AdventureWorksDbContext>
            options) : base(options) {
        }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}