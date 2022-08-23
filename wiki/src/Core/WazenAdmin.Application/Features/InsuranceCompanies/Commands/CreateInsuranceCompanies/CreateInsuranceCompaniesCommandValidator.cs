using FluentValidation;
using System;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.CreateInsuranceCompanies
{
    public class CreateInsuranceCompaniesCommandValidator : AbstractValidator<CreateInsuranceCompaniesCommand>
    {
        public CreateInsuranceCompaniesCommandValidator()
        {
            RuleFor(p => p.NameoftheIC)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull()
                 .MaximumLength(40).WithMessage("{PropertyName} must not exceed 40 characters.");

            RuleFor(p => p.NameofICAdmin)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ICAdminEmailAddress)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ICAdminPassword)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ICAdminPhoneNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.");
           
            RuleFor(p => p.Location)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.City)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.OfficeNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Agreements)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.NoofPolicies)
               .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ConfigurableParameters);
            RuleFor(p => p.AdminExpenseForNAJM);
            RuleFor(p => p.AdminExpenseForELM);
            RuleFor(p => p.BankFees);
            RuleFor(p => p.DefaultExpenses);
            RuleFor(p => p.SharingPercentageForCancellation);
            RuleFor(p => p.SharingPercentageForAdministrationFees);
            RuleFor(p => p.CommissionAgreed);
            RuleFor(p => p.APIAvailable)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.EndpointURL);

            RuleFor(p => p.RequestType);


            RuleFor(p => p.Header);

            RuleFor(p => p.Body);
              
            RuleFor(p => p.CancelAPIAvailable);

            RuleFor(p => p.CancelEndpointURL);

            RuleFor(p => p.CancelRequestType);

            RuleFor(p => p.CancelHeader);

            RuleFor(p => p.CancelBody);


            RuleFor(p => p.RefundEndpointURL);

            RuleFor(p => p.RefundRequestType);
               ;
            RuleFor(p => p.RefundHeader);

            RuleFor(p => p.RefundBody);

            RuleFor(p => p.AddOnsRemoveEndpointURL);

            RuleFor(p => p.AddOnsRemoveRequestType);

            RuleFor(p => p.AddOnsRemoveHeader);


            RuleFor(p => p.AddOnsRemoveBody);

            RuleFor(p => p.AddOnsRemovePolicyPricing);
            
        }
    }
}
