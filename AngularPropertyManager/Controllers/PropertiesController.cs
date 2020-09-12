using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Property;
using AutoMapper;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertyService propertyService, IPortfolioService portfolioService, IMapper mapper)
        {
            _propertyService = propertyService;
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDetailsDto>> GetProperty(Guid id)
        {
            var @property = await _propertyService.GetProperty(id);
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
        public async Task<IActionResult> PutProperty(Guid id, [FromForm]PropertyUpdateDto @property)
        {
            if (id != @property.Id)
            {
                return BadRequest();
            }
            var data = _mapper.Map<Property>(@property);
            await _propertyService.UpdateProperty(data);

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{portfolioId}")]
        public async Task<ActionResult<Property>> PostProperty(Guid portfolioId, PropertyCreateDto @property)
        {
            //var address = _mapper.Map<Address>(@property.Address);
            var portfolio = await _portfolioService.GetPortfolio(portfolioId);

            var newProperty = _mapper.Map<Property>(@property);
            var result = await _propertyService.CreateProperty(portfolio, newProperty);

            return CreatedAtAction("GetProperty", new { id = result.Id }, result);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _propertyService.DeleteProperty(id);
            return NoContent();
        }
    }
}
