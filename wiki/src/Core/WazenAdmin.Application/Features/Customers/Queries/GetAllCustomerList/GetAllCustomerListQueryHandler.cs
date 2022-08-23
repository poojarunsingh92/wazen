using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerList;
using WazenAdmin.Application.Features.TempCustomers.Queries.GetTempCustomerList;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetAllCustomerList
{
    public class GetAllCustomerListQueryHandler : IRequestHandler<GetAllCustomerListQuery, Response<IEnumerable<AllCustomerListVm>>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        public GetAllCustomerListQueryHandler(IMediator mediator, IMapper mapper, ILogger<GetAllCustomerListQueryHandler> logger, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
        }

        public async Task<Response<IEnumerable<AllCustomerListVm>>> Handle(GetAllCustomerListQuery request, CancellationToken cancellationToken)
        {

            var response = new Response<IEnumerable<AllCustomerListVm>>();
            _logger.LogInformation("Handle Initiated");
            var customerList = await _customerRepository.GetListAllAsync();
            if (customerList == null)
            {
                var resposeObject = new Response<IEnumerable<AllCustomerListVm>>("Id is not found");
                return resposeObject;
            }
            var tempCustomerList = await _tempCustomerRepository.GetListAllAsync();
            if (tempCustomerList == null)
            {
                var resposeObject = new Response<IEnumerable<AllCustomerListVm>>("Id is not found");
                return resposeObject;
            }
            var resp = (from a in customerList
                        select new AllCustomerListVm()
                        {
                            ArabicFirstName = a.ArabicFirstName,
                            ArabicLastName = a.ArabicLastName,
                            ArabicMiddleName = a.ArabicMiddleName,
                            DateOfBirth = a.DateOfBirth,
                            EducationId = a.EducationId,
                            Email = a.Email,
                            EnglishFirstName = a.EnglishFirstName,
                            EnglishLastName = a.EnglishLastName,
                            EnglishMiddleName = a.EnglishMiddleName,
                            GenderId = a.GenderId,
                            ID = a.ID,
                            IsActive = a.IsActive,
                            IsRegistered = true,
                            MaritalStatusId = a.MaritalStatusId,
                            Mobile = a.Mobile,
                            NationalIdTypeId = a.NationalIdTypeId,
                            NIN = a.NIN,
                            OccupationId = a.OccupationId,
                            SalutationId = a.SalutationId
                        }).ToList();
            var resp2 = (from a in tempCustomerList
                         select new AllCustomerListVm()
                         {
                             ArabicFirstName = a.ArabicFirstName,
                             ArabicLastName = a.ArabicLastName,
                             ArabicMiddleName = a.ArabicMiddleName,
                             DateOfBirth = a.DateOfBirth,
                             //EducationId = a.EducationId,
                             Email = a.Email,
                             EnglishFirstName = a.EnglishFirstName,
                             EnglishLastName = a.EnglishLastName,
                             EnglishMiddleName = a.EnglishMiddleName,
                             //GenderId = a.GenderId,
                             ID = a.ID,
                             IsActive = a.IsActive,
                             IsRegistered = false,
                             //MaritalStatusId = a.MaritalStatusId,
                             Mobile = a.Mobile,
                             //NationalIdTypeId = a.NationalIdTypeId,
                             NIN = a.NIN,
                             //OccupationId = a.OccupationId,
                             //SalutationId = a.SalutationId
                         }).ToList();

            var responsedata = new List<AllCustomerListVm>();

            responsedata.AddRange(resp);
            responsedata.AddRange(resp2);

            _logger.LogInformation("Hanlde Completed");
            response.Succeeded = true;
            response.Message = "Customer and Temp Customer List";
            response.Data = responsedata;
            return response;
        }
    }
}