using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _context;

        public TenantService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
