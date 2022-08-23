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
    public class ImageTitleRepository : BaseRepository<ICImageTitle>, IImageTitleRepository
    {
        private readonly ILogger _logger;
        public ImageTitleRepository(ApplicationDbContext dbContext, ILogger<ICImageTitle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICImageTitle>> GetImageTitle()
        {
            var imageTitles = await _dbContext.ICImageTitles.ToListAsync();
            return imageTitles;
        }
    }
}
