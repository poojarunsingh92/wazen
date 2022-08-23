﻿using Microsoft.EntityFrameworkCore;
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
    public class PaymentMethodRepository : BaseRepository<ICPaymentMethod>, IPaymentMethodRepository
    {
        private readonly ILogger _logger;
        public PaymentMethodRepository(ApplicationDbContext dbContext, ILogger<ICPaymentMethod> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICPaymentMethod>> GetPaymentMethod()
        {
            var paymentMethods = await _dbContext.ICPaymentMethods.ToListAsync();
            return paymentMethods;
        }
    }
}
