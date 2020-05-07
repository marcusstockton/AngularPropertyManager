using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;
using AngularPropertyManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ApplicationDbContext _context;

        public PortfolioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Portfolio>> GetPortfoliosForUser(string userId)
        {
            return await _context.Portfolios.Include(x => x.Owner).Where(x => x.Owner.Id == userId).ToListAsync();
        }

        public async Task<Portfolio> GetPortfolio(Guid portfolioId)
        {
            return await _context.Portfolios
                .Include(x => x.Properties)
                    .ThenInclude(x => x.Tenants)
                        .ThenInclude(x => x.Notes)
                .Include(x => x.Properties)
                    .ThenInclude(x => x.Address)
                .Include(x => x.Owner)
                .SingleOrDefaultAsync(x => x.Id == portfolioId);
        }

        public async Task<bool> UpdatePortfolio(Portfolio portfolio)
        {
            portfolio.UpdatedDateTime = DateTime.Now;
            _context.Entry(await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == portfolio.Id)).CurrentValues.SetValues(portfolio);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Portfolio> CreatePortfolio(Portfolio portfolio, string userId)
        {
            portfolio.Owner.Id = userId;
            portfolio.CreatedDateTime = DateTime.Now;
            await _context.AddAsync<Portfolio>(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<bool> DeletePortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Remove(portfolio);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
