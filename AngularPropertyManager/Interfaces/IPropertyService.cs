using AngularPropertyManager.Models;
using System;
using System.Threading.Tasks;

namespace AngularPropertyManager.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> GetProperty(Guid propertyId);
        Task<Property> UpdateProperty(Property property);
        Task<Property> CreateProperty(Portfolio portfolio, Property property); 
        Task<bool> DeleteProperty(Guid propertyId);
    }
}
