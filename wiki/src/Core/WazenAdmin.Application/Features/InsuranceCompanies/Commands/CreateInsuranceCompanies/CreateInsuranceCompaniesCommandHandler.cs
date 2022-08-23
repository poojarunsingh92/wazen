using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.CreateInsuranceCompanies
{
    class CreateInsuranceCompaniesCommandHandler : IRequestHandler<CreateInsuranceCompaniesCommand, Response<CreateInsuranceCompaniesDto>>
    {
        private readonly IInsuranceCompaniesRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateInsuranceCompaniesCommandHandler(IMapper mapper, IInsuranceCompaniesRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<CreateInsuranceCompaniesDto>> Handle(CreateInsuranceCompaniesCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new Response<CreateInsuranceCompaniesDto>();

            var validator = new CreateInsuranceCompaniesCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserCommandResponse.Succeeded = false;
                createUserCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createUserCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var user = new WazenAdmin.Domain.Entities.InsuranceCompany()
                {
                    NameoftheIC = request.NameoftheIC,
                    NameofICAdmin = request.NameofICAdmin,
                    ICAdminEmailAddress = request.ICAdminEmailAddress,
                    ICAdminPassword = request.ICAdminPassword,
                    ICAdminPhoneNumber = request.ICAdminPhoneNumber,
                    StartDateofCollaboration = request.StartDateofCollaboration,
                    Location = request.Location,
                    City = request.City,
                    OfficeNumber = request.OfficeNumber,
                    Agreements = request.Agreements,
                    NoofPolicies = request.NoofPolicies,
                    ConfigurableParameters = request.ConfigurableParameters,
                    IsAdminExpenseForNAJM = request.IsAdminExpenseForNAJM,
                    AdminExpenseForNAJM = request.AdminExpenseForNAJM,
                    IsAdminExpenseForELM = request.IsAdminExpenseForELM,
                    AdminExpenseForELM = request.AdminExpenseForELM,
                    IsBankFees = request.IsBankFees,
                    BankFees = request.BankFees,
                    IsDefaultExpenses = request.IsDefaultExpenses,
                    DefaultExpenses = request.DefaultExpenses,
                    IsSharingPercentageForCancellation = request.IsSharingPercentageForCancellation,
                    SharingPercentageForCancellation = request.SharingPercentageForCancellation,
                    IsSharingPercentageForAdministrationFees = request.IsSharingPercentageForAdministrationFees,
                    SharingPercentageForAdministrationFees = request.SharingPercentageForAdministrationFees,
                    IsCommissionAgreed = request.IsCommissionAgreed,
                    CommissionAgreed = request.CommissionAgreed,
                    APIAvailable = request.APIAvailable,
                    EndpointURL = request.EndpointURL,
                    RequestType = request.RequestType,
                    Header = request.Header,
                    Body = request.Body,
                    CancelAPIAvailable = request.CancelAPIAvailable,
                    CancelEndpointURL = request.CancelEndpointURL,
                    CancelRequestType = request.CancelRequestType,
                    CancelHeader = request.CancelHeader,
                    CancelBody = request.CancelBody,
                    RefundEndpointURL = request.RefundEndpointURL,
                    RefundRequestType = request.RefundRequestType,
                    RefundHeader = request.RefundHeader,
                    RefundBody = request.RefundBody,
                    AddOnsRemoveEndpointURL = request.AddOnsRemoveEndpointURL,
                    AddOnsRemoveRequestType = request.AddOnsRemoveRequestType,
                    AddOnsRemoveHeader = request.AddOnsRemoveHeader,
                    AddOnsRemoveBody = request.AddOnsRemoveBody,
                    AddOnsRemovePolicyPricing = request.AddOnsRemovePolicyPricing,
                    IsActive = request.IsActive,
                    adminExpenseForNAJMType = request.adminExpenseForNAJMType,
                    adminExpenseForELMType = request.adminExpenseForELMType,
                    bankFeesType = request.bankFeesType,
                    defaultExpensesType = request.defaultExpensesType,
                    sharingPercentageForCancellationType = request.sharingPercentageForCancellationType,
                    sharingPercentageForAdministrationFeesType = request.sharingPercentageForAdministrationFeesType,
                    commissionAgreedType = request.commissionAgreedType,
                };
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.Data = _mapper.Map<CreateInsuranceCompaniesDto>(user);
                createUserCommandResponse.Succeeded = true;
                createUserCommandResponse.Message = "success";
            }

            return createUserCommandResponse;
        }
    }
}
