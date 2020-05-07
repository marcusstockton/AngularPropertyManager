using AngularPropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetPortfoliosForUser(string userId);
        Task<Portfolio> GetPortfolio(Guid portfolioId);
        Task<bool> UpdatePortfolio(Portfolio portfolio);
        Task<Portfolio> CreatePortfolio(Portfolio portfolio, string userId);
        Task<bool> DeletePortfolio(Portfolio portfolio);
    }
}
