using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularPropertyManager.Data;
using AngularPropertyManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AngularPropertyManager.Models.DTOs.Portfolio;

namespace AngularPropertyManager.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortfoliosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Portfolios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portfolio>>> GetPortfolios()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }
            return await _context.Portfolios.Include(x=>x.Owner).Where(x=>x.Owner.Id == userId).ToListAsync();
        }

        // GET: api/Portfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> GetPortfolio(Guid id)
        {
            var portfolio = await _context.Portfolios
                .Include(x=>x.Properties)
                    .ThenInclude(x=>x.Tenants)
                        .ThenInclude(x=>x.Notes)
                .Include(x=>x.Properties)
                    .ThenInclude(x=>x.Address)
                .Include(x=>x.Owner)
                .SingleOrDefaultAsync(x=>x.Id == id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // PUT: api/Portfolios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolio(Guid id, Portfolio portfolio)
        {
            if (id != portfolio.Id)
            {
                return BadRequest();
            }

            _context.Entry(portfolio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
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

        // POST: api/Portfolios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Portfolio>> PostPortfolio(PortfolioCreateDto portfolio)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _context.Users.FindAsync(userId);
            var new_portfolio = new Portfolio
            {
                Name = portfolio.Name,
            };
            new_portfolio.CreatedDateTime = DateTime.Now;
            new_portfolio.Owner = user;
           
            _context.Portfolios.Add(new_portfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolio", new { id =  new_portfolio.Id }, new_portfolio);
        }

        // DELETE: api/Portfolios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Portfolio>> DeletePortfolio(Guid id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();

            return portfolio;
        }

        private bool PortfolioExists(Guid id)
        {
            return _context.Portfolios.Any(e => e.Id == id);
        }
    }
}
