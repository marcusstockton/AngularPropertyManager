using AngularPropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> GetProperty(Guid propertyId);

    }
}
