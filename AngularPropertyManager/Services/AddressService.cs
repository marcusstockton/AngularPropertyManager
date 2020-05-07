using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
