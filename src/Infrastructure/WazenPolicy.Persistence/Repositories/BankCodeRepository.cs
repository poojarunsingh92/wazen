using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class BankCodeRepository : BaseRepository<ICBankCode>, IBankCodeRepository
    {
        private readonly ILogger _logger;
        public BankCodeRepository(ApplicationDbContext dbContext, ILogger<ICBankCode> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICBankCode>> GetBankCode()
        {
            var bankCodes = await _dbContext.ICBankCodes.ToListAsync();
            return bankCodes;
        }
    }
}
