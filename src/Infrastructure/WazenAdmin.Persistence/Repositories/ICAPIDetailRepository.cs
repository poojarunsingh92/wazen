using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class ICAPIDetailRepository : BaseRepository<ICAPIDetail>, IICAPIDetailRepository
    {
        private readonly ILogger _logger;
        public ICAPIDetailRepository(ApplicationDbContext dbContext, ILogger<ICAPIDetail> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<ICAPIDetail> GetICAPIDetailsByICIDAsync(Guid ICID)
        {
            var iCAPIDetails = _dbContext.ICAPIDetails.FirstOrDefault(x => x.ICID == ICID);
            return iCAPIDetails;
        }

        public async Task<IEnumerable<ICAPIDetail>> ListAllByICIDAsync(Guid ICID)
        {
            var iCAPIDetailsList = _dbContext.ICAPIDetails.Where(s => s.ICID == ICID).ToList();
            return iCAPIDetailsList;
        }
    }
}
