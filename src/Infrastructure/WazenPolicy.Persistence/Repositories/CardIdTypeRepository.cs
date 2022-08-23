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
    public class CardIdTypeRepository : BaseRepository<ICCardIdType>, ICardIdTypeRepository
    {
        private readonly ILogger _logger;
        public CardIdTypeRepository(ApplicationDbContext dbContext, ILogger<ICCardIdType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICCardIdType>> GetCardIdType()
        {
            var cardIdTypes = await _dbContext.ICCardIdTypes.ToListAsync();
            return cardIdTypes;
        }
    }
}
