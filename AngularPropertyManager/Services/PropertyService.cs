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

        public async Task<Property> UpdateProperty(Property property)
        {
            property.UpdatedDateTime = DateTime.Now;
            property.Address.UpdatedDateTime = DateTime.Now;

            _context.Entry(property).State = EntityState.Modified;
            _context.Entry(property.Address).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property> CreateProperty(Portfolio portfolio, Property property)
        {
            property.CreatedDateTime = DateTime.Now;
            property.Portfolio = portfolio;

            _context.Properties.Add(property);

            if (_context.Entry(property.Address).State == EntityState.Added)
            {
                _context.Address.Add(property.Address);
            }
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<bool> DeleteProperty(Guid propertyId)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            _context.Properties.Remove(property);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
