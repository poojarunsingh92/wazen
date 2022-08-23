using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class ComplaintRepository : BaseRepository<Complaint>, IComplaintRepository
    {
        private readonly ILogger _logger;
        public ComplaintRepository(ApplicationDbContext dbContext, ILogger<Complaint> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<Complaint> GetComplaintByCustomerIDAsync(Guid CustomerID)
        {
            var complaint = _dbContext.Complaints.FirstOrDefault(x => (x.CustomerID == CustomerID));

            return complaint;
        }

        public async Task<IEnumerable<Complaint>> GetComplaintByCustomerIDListAsync(Guid CustomerID)
        {
            var complaints = await _dbContext.Complaints.Where(x => x.CustomerID == CustomerID).ToListAsync();

            return complaints;
        }

        public async Task<Complaint> GetByIdAsync(int ID)
        {
            var complaint = _dbContext.Complaints.FirstOrDefault(x => (x.ID == ID));

            return complaint;
        }
    }
}
