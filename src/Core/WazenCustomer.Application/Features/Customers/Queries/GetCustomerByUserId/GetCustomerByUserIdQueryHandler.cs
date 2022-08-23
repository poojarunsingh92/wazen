using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerByUserId
{   
    public class GetCustomerByUserIdQueryHandler : IRequestHandler<GetCustomerByUserIdQuery,  GetCustomerByUserIdListVm>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByUserIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<GetCustomerByUserIdListVm> Handle(GetCustomerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByUserId(request.UserId);
            if (customer == null)
            {
                var resposeObject = new GetCustomerByUserIdListVm(); 
                return resposeObject;
            }

            var response = _mapper.Map<GetCustomerByUserIdListVm>(customer);
          
            return response;
        }
    }
}
