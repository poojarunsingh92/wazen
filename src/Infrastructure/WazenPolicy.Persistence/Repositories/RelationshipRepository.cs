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
    public class RelationshipRepository : BaseRepository<ICRelationship>, IRelationshipRepository
    {
        private readonly ILogger _logger;
        public RelationshipRepository(ApplicationDbContext dbContext, ILogger<ICRelationship> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICRelationship>> GetRelationship()
        {
            var relationships = await _dbContext.ICRelationships.ToListAsync();
            return relationships;
        }   
    }
}
