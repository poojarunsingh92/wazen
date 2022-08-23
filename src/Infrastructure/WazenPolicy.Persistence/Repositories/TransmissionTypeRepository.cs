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
    public class TransmissionTypeRepository : BaseRepository<ICTransmissionType>, ITransmissionTypeRepository
    {
        private readonly ILogger _logger;
        public TransmissionTypeRepository(ApplicationDbContext dbContext, ILogger<ICTransmissionType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICTransmissionType>> GetTransmissionType()
        {
            var TransmissionTypes = await _dbContext.ICTransmissionTypes.ToListAsync();
            return TransmissionTypes;
        }
    }
}
