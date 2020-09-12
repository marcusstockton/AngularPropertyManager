using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;
using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Tenant;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TenantService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<List<Tenant>> GetTenantsForProperty(Guid propertyId)
        {
            var property = await _context.Properties.Include(x=>x.Tenants).FirstOrDefaultAsync(x=>x.Id == propertyId);
            return property.Tenants;
        }
    }
}
