using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;
using AngularPropertyManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AngularPropertyManager.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Property> GetProperty(Guid propertyId)
        {
            return await _context.Properties
                .Include(x => x.Address)
                .Include(x => x.Tenants)
                    .ThenInclude(x => x.Notes)
                .Include(x => x.Documents)
                .Include(x => x.Images)
                .SingleOrDefaultAsync(x => x.Id == propertyId);
        }

    }
}
