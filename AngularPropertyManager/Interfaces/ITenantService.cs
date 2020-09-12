using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Interfaces
{
    public interface ITenantService
    {
        Task<List<Tenant>> GetTenantsForProperty(Guid propertyId);
    }
}
