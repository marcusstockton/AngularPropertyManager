using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularPropertyManager.Data;
using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Property;
using System.Security.Claims;
using AutoMapper;

namespace AngularPropertyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertiesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Properties
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        //{
        //    return await _context.Properties.ToListAsync();
        //}

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDetailsDto>> GetProperty(Guid id)
        {
            var @property = await _context.Properties
                .Include(x => x.Address)
                .Include(x => x.Tenants)
                    .ThenInclude(x => x.Notes)
                .Include(x => x.Documents)
                .Include(x => x.Images)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (@property == null)
            {
                return NotFound();
            }
            var property_detail = _mapper.Map<PropertyDetailsDto>(@property);
            return Ok(property_detail);
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(Guid id, Property @property)
        {
            if (id != @property.Id)
            {
                return BadRequest();
            }

            property.UpdatedDateTime = DateTime.Now;
            property.Address.UpdatedDateTime = DateTime.Now;

            _context.Entry(@property).State = EntityState.Modified;
            _context.Entry(property.Address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{portfolioId}")]
        public async Task<ActionResult<Property>> PostProperty(Guid portfolioId, PropertyCreateDto @property)
        {
            var address = _mapper.Map<Address>(@property.Address);
            var portfolio = await _context.Portfolios.FindAsync(portfolioId);
            var new_property = new Property
            {
                Address = address,
                CreatedDateTime = DateTime.Now,
                PurchaseDate = @property.PurchaseDate,
                PurchasePrice = @property.PurchasePrice,
                Portfolio = portfolio,
                //Documents = @property.Documents,
                //Images = @property.Images,
                //Tenants = @property.Tenants,
            };
            _context.Properties.Add(new_property);
            _context.Address.Add(new_property.Address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = new_property.Id }, new_property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(Guid id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return @property;
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
