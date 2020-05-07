using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularPropertyManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AngularPropertyManager.Models.DTOs.Portfolio;
using AutoMapper;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfoliosController(IPortfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
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
            return await _portfolioService.GetPortfoliosForUser(userId);
        }

        // GET: api/Portfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioDetailsDto>> GetPortfolio(Guid id)
        {
            var portfolio = await _portfolioService.GetPortfolio(id);
            
            if (portfolio == null)
            {
                return NotFound();
            }
            try
            {
                var portfolioDetails = _mapper.Map<PortfolioDetailsDto>(portfolio);
                return Ok(portfolioDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }            
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

            await _portfolioService.UpdatePortfolio(portfolio);
            return NoContent();
        }

        // POST: api/Portfolios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Portfolio>> PostPortfolio(PortfolioCreateDto portfolio)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var newPortfolio = _mapper.Map<Portfolio>(portfolio);

            var data = await _portfolioService.CreatePortfolio(newPortfolio, userId);

            return CreatedAtAction("GetPortfolio", new { id =  data.Id }, data);
        }

        // DELETE: api/Portfolios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Portfolio>> DeletePortfolio(Guid id)
        {
            var portfolio = await _portfolioService.GetPortfolio(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            await _portfolioService.DeletePortfolio(portfolio);

            return NoContent();
        }
    }
}
