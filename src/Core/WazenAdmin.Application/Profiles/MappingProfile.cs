using AutoMapper;
using WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs;
using WazenAdmin.Application.Features.AboutUs.Commands.UpdateAboutUs;
using WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsDetail;
using WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsList;
using WazenAdmin.Application.Features.CancellationRequests.Queries.GetCancellationRequestByPolicyID;
using WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaintByCustomerID;
using WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaintByCustomerID;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetail;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetailByCustomerID;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintList;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintListByCustomerID;
using WazenAdmin.Application.Features.ContactUs.Commands.CreateContactUs;
using WazenAdmin.Application.Features.ContactUs.Commands.DeleteContactUs;
using WazenAdmin.Application.Features.ContactUs.Commands.UpdateContactUs;
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsDetail;
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsList;
using WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPoliciesByCustomerID;
using WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyByVehicleID;
using WazenAdmin.Application.Features.Customers.Commands.CreateCustomer;
using WazenAdmin.Application.Features.Customers.Commands.UpdateCustomer;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerByID;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerByNINAndDOB;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerList;
using WazenAdmin.Application.Features.Drivers.Queries.GetDriverByVehicleID;
using WazenAdmin.Application.Features.FAQ.Commands.CreateFAQ;
using WazenAdmin.Application.Features.FAQ.Commands.UpdateFAQ;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQDetail;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQList;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQListByModule;
using WazenAdmin.Application.Features.HomePageBanners.Commands.CreateHomePageBanner;
using WazenAdmin.Application.Features.HomePageBanners.Commands.UpdateHomePageBanner;
using WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannerDetail;
using WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.CreateICAPIDetails;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDeatils;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDetailsByICID;
using WazenAdmin.Application.Features.ICAPIDetails.Queries;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsByICID;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsList;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsListByICID;
using WazenAdmin.Application.Features.InsuranceCompanies.Commands.CreateInsuranceCompanies;
using WazenAdmin.Application.Features.InsuranceCompanies.Commands.UpdateInsuranceCompanies;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceComapniesNameList;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesDetail;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;
using WazenAdmin.Application.Features.Notification.Commands.UpdateNotification;
using WazenAdmin.Application.Features.Notifications.Commands.CreateNotifications;
using WazenAdmin.Application.Features.Notifications.Queries.GetNotificationDetail;
using WazenAdmin.Application.Features.Notifications.Queries.GetNotificationList;
using WazenAdmin.Application.Features.PolicyRequests.Queries.GetPolicyRequestList;
using WazenAdmin.Application.Features.StaticContents.Commands.CreateStaticContent;
using WazenAdmin.Application.Features.StaticContents.Commands.UpdateStaticContent;
using WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentDetail;
using WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentsList;
using WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions;
using WazenAdmin.Application.Features.TermsAndConditions.Commands.UpdateTermsAndConditions;
using WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsDetail;
using WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsList;
using WazenAdmin.Application.Features.Users.Commands.CreateUser;
using WazenAdmin.Application.Features.Users.Commands.UpdateUser;
using WazenAdmin.Application.Features.Users.Queries.GetUserByUserId;
using WazenAdmin.Application.Features.Users.Queries.GetUserDetail;
using WazenAdmin.Application.Features.Users.Queries.GetUsersList;
using WazenAdmin.Application.Features.Users.Queries.VerifyOTP;
using WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID;
using WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;
using WazenAdmin.Application.Models.Authentication;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Features.HomePageBanners.Commands.CreateHomePageBanner;

namespace WazenAdmin.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //AboutUs
            CreateMap<AboutUs, UpdateAboutUsCommand>().ReverseMap();
            CreateMap<AboutUs, CreateAboutUsDto>();
            CreateMap<AboutUs, CreateAboutUsCommand>();
            CreateMap<AboutUs, AboutUsListVm>();
            CreateMap<AboutUs, AboutUsDetailVm>();

            //CancellationRequest
            CreateMap<CancellationRequest, CancellationRequestByPolicyIDVm>();

            //Complaint
            CreateMap<Complaint, CreateComplaintCommand>().ReverseMap();
            CreateMap<Complaint, CreateComplaintDto>();
            CreateMap<Complaint, DeleteComplaintCommand>().ReverseMap();
            CreateMap<Complaint, DeleteComplaintByCustomerIDCommand>().ReverseMap();
            CreateMap<Complaint, UpdateComplaintCommand>().ReverseMap();
            CreateMap<Complaint, UpdateComplaintByCustomerIDCommand>().ReverseMap();
            CreateMap<Complaint, GetComplaintDetailQuery>().ReverseMap();
            CreateMap<Complaint, ComplaintDetailVm>().ReverseMap();
            CreateMap<Complaint, ComplaintListVm>().ReverseMap();
            CreateMap<Complaint, ComplaintByCustomerIDListVm>().ReverseMap();
            CreateMap<Complaint, GetComplaintByCustomerIDDetailVm>().ReverseMap();
            CreateMap<Complaint, GetComplaintByCustomerIDDetailQuery>().ReverseMap();
            CreateMap<Complaint, GetComplaintListQuery>().ReverseMap();
            CreateMap<Complaint, GetComplaintByCustomerIDListQuery>().ReverseMap();

            //ContactUs
            CreateMap<ContactUs, CreateContactUsCommand>().ReverseMap();
            CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, DeleteContactUsCommand>().ReverseMap();
            CreateMap<ContactUs, ContactUsDetailVm>().ReverseMap();
            CreateMap<ContactUs, ContactUsListVm>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsCommand>().ReverseMap();

            //Customer
            CreateMap<Customer, GetCitizenByInfoVm>().ReverseMap();
            CreateMap<Customer, GetCustomerByNINAndDOBVm>();
            CreateMap<Customer, CustomerListVm>();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerByIDVm>();

            //CustomerPolicy
            CreateMap<CustomerPolicy, CustomerPoliciesByCustomerIDVm>();
            CreateMap<CustomerPolicy, CustomerPolicyByVehicleIDVm>();

            //Driver
            CreateMap<Driver, DriverByVehicleIDVm>();

            //HomePageBanner
            CreateMap<HomePageBanner, HomePageBannerDto>();
            CreateMap<HomePageBanner, HomePageBannerListVm>();
            CreateMap<HomePageBanner, CreateHomePageBannerCommand>();
            CreateMap<HomePageBanner, CreateHomePageBannerDto>();
            CreateMap<HomePageBanner, HomePageBannerDetailVm>();
            CreateMap<HomePageBanner, UpdateHomePageBannerCommand>().ReverseMap();

            //ICAPIDetails
            CreateMap<ICAPIDetail, ICAPIDetailsListVm>();
            CreateMap<ICAPIDetail, ICAPIDetailsVm>();
            CreateMap<ICAPIDetail, CreateICAPIDetailsCommand>();
            CreateMap<ICAPIDetail, CreateICAPIDetailsDto>();
            CreateMap<ICAPIDetail, UpdateICAPIDetailsCommand>().ReverseMap();
            CreateMap<ICAPIDetail, UpdateICAPIDetailsByICIDCommand>().ReverseMap();
            CreateMap<ICAPIDetail, ICAPIDetailsByICIDDto>();
            CreateMap<ICAPIDetail, ICAPIDetailsByICIDVm>();
            CreateMap<ICAPIDetail, ICAPIDetailsListByICIDVm>();
            CreateMap<GetICAPIDetailsListQuery, ICAPIDetailsListByICIDVm>();

            //InsuranceCompanies
            CreateMap<InsuranceCompany, UpdateInsuranceCompaniesCommand>().ReverseMap();
            CreateMap<InsuranceCompany, CreateInsuranceCompaniesDto>();
            CreateMap<InsuranceCompany, InsuranceCompaniesDetailVm>();
            CreateMap<InsuranceCompany, InsuranceCompaniesListVm>();
            CreateMap<InsuranceCompany, CreateInsuranceCompaniesCommand>();
            CreateMap<InsuranceCompany, InsuranceCompaniesNameListVm>();

            //Notification
            CreateMap<Notification, NotificationListVm>();
            CreateMap<Notification, CreateNotificationDto>();
            CreateMap<Notification, CreateNotificationCommand>();
            CreateMap<Notification, NotificationDetailVm>();
            CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();

            //FAQ
            CreateMap<FAQ, UpdateFAQCommand>().ReverseMap();
            CreateMap<FAQ, CreateFAQDto>();
            CreateMap<FAQ, CreateFAQCommand>();
            CreateMap<FAQ, FAQListVm>();
            CreateMap<FAQ, FAQDetailVm>();
            CreateMap<FAQ, FAQs>();
            CreateMap<FAQ, FAQListByModuleVm>();

            //PolicyRequest
            CreateMap<PolicyRequest, PolicyRequestListVm>().ReverseMap();
            CreateMap<PolicyRequest, GetPolicyRequestListQuery>().ReverseMap();

            //StaticContent
            CreateMap<StaticContent, StaticContentDto>();
            CreateMap<StaticContent, StaticContentListVm>();
            CreateMap<StaticContent, CreateStaticContentCommand>();
            CreateMap<StaticContent, CreateStaticContentDto>();
            CreateMap<StaticContent, StaticContentDetailVm>();
            CreateMap<StaticContent, UpdateStaticContentCommand>().ReverseMap();

            //TermsAndConditions
            CreateMap<TermsAndConditions, UpdateTermsAndConditionsCommand>().ReverseMap();
            CreateMap<TermsAndConditions, CreateTermsAndConditionsDto>();
            CreateMap<TermsAndConditions, CreateTermsAndConditionsCommand>();
            CreateMap<TermsAndConditions, TermsAndConditionsListVm>();
            CreateMap<TermsAndConditions, TermsAndConditionsDetailVm>();

            //User
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserDto>();
            CreateMap<User, UserListVm>();
            CreateMap<User, CreateUserCommand>();
            CreateMap<User, UserDetailVm>();
            CreateMap<User, AdminResponse>();
            CreateMap<User, AdminResponse>().ReverseMap();
            CreateMap<User, GetUserByUserIdQuery>().ReverseMap();
            CreateMap<User, GetUserListVm>().ReverseMap();
            CreateMap<User, VerifyOTPVm>().ReverseMap();


            //Vehicle
            CreateMap<Vehicle, VehicleListByCustomerIDVm>();
            CreateMap<Vehicle, VehicleBySeqNumAndCustomerIdVm>();


        }
    }
}
