using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.CreateInsuranceCompanies
{
   public class CreateInsuranceCompaniesCommand : IRequest<Response<CreateInsuranceCompaniesDto>>
    {
        public string NameoftheIC { get; set; }
        public string NameofICAdmin { get; set; }
        public string ICAdminEmailAddress { get; set; }
        public string ICAdminPassword { get; set; }
        public string ICAdminPhoneNumber { get; set; }
        public DateTime StartDateofCollaboration { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string OfficeNumber { get; set; }
        public string Agreements { get; set; }
        public string NoofPolicies { get; set; }
        public string ConfigurableParameters { get; set; }
        public string IsAdminExpenseForNAJM { get; set; }
        public string AdminExpenseForNAJM { get; set; }
        public string IsAdminExpenseForELM { get; set; }
        public string AdminExpenseForELM { get; set; }
        public string IsBankFees { get; set; }
        public string BankFees { get; set; }
        public string IsDefaultExpenses { get; set; }
        public string DefaultExpenses { get; set; }
        public string IsSharingPercentageForCancellation { get; set; }
        public string SharingPercentageForCancellation { get; set; }
        public string IsSharingPercentageForAdministrationFees { get; set; }
        public string SharingPercentageForAdministrationFees { get; set; }
        public string IsCommissionAgreed { get; set; }
        public string CommissionAgreed { get; set; }
        public string APIAvailable { get; set; }
        public string EndpointURL { get; set; }
        public string RequestType { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string CancelAPIAvailable { get; set; }
        public string CancelEndpointURL { get; set; }
        public string CancelRequestType { get; set; }
        public string CancelHeader { get; set; }
        public string CancelBody { get; set; }
        public string RefundEndpointURL { get; set; }
        public string RefundRequestType { get; set; }
        public string RefundHeader { get; set; }
        public string RefundBody { get; set; }
        public string AddOnsRemoveEndpointURL { get; set; }
        public string AddOnsRemoveRequestType { get; set; }
        public string AddOnsRemoveHeader { get; set; }
        public string AddOnsRemoveBody { get; set; }
        public string AddOnsRemovePolicyPricing { get; set; }
        public Boolean IsActive { get; set; }
        public Double CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Double ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string adminExpenseForNAJMType { get; set; }
        public string adminExpenseForELMType { get; set; }
        public string bankFeesType { get; set; }
        public string defaultExpensesType { get; set; }
        public string sharingPercentageForCancellationType { get; set; }
        public string sharingPercentageForAdministrationFeesType { get; set; }
        public string commissionAgreedType { get; set; }
    }
}
