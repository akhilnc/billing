using Microsoft.EntityFrameworkCore;
using billing.Data.Models;
using billing.Data.EntitiyConfigurations;

namespace billing.Data.DbContexts
{
    public  class BillingAppContext : DbContext
    {
        public BillingAppContext(DbContextOptions<BillingAppContext> options) : base(options)
        {
        }

        public  DbSet<AdminAppLogs> AdminAppLogs { get; set; }
        public  DbSet<AdminUserRefreshToken> AdminUserRefreshToken { get; set; }
        public  DbSet<MstUser> MstUser { get; set; }
        public  DbSet<MstUserRole> MstUserRole { get; set; }
        public DbSet<MstService> MstService { get; set; }
        public DbSet<MstCustomer> MstCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MstUserConfiguration).Assembly);
        }
     

    }
}
