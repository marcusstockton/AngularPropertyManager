using AngularPropertyManager.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AngularPropertyManager.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PropertyDocument> PropertyDocuments { get; set; }
        public DbSet<Image> PropertyImages { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
    }
}
