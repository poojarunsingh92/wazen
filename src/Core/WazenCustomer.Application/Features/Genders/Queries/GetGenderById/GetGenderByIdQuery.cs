using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Genders.Queries.GetGenderById
{
  public class GetGenderByIdQuery : IRequest<Response<GetGenderListVm>>
    {
        public int Id { get; set; }
    }
}
