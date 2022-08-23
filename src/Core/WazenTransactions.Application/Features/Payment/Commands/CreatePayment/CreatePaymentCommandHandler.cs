using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;
using System.Security.Cryptography;
using System.Linq;
using WazenTransactions.Application.Contracts.Infrastructure;
using WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage;

namespace WazenTransactions.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Response<string>>
    {
        private readonly IMediator _mediator;
        private readonly IQueueService _queueService;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPolicyTypeRepository _policyTypeRepository;
        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;
        private readonly ILogger<CreatePaymentCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IMapper mapper, IMediator mediator, IQueueService queueService, ICustomerPolicyRepository customerPolicyRepository, ITransactionRepository transactionRepository, IPolicyTypeRepository policyTypeRepository, IAdditionalCoverageRepository additionalCoverageRepository, ILogger<CreatePaymentCommandHandler> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _queueService = queueService;
            _customerPolicyRepository = customerPolicyRepository;
            _transactionRepository = transactionRepository;
            _policyTypeRepository = policyTypeRepository;
            _additionalCoverageRepository = additionalCoverageRepository;
            _logger = logger;
        }

        public async Task<Response<string>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            string icId = string.Empty;
            decimal WpAmount = request.TotalAmount * .3m;
            decimal IcAmount = request.TotalAmount * .7m;
            for (int i = 0; i < request.VehicleList.Count; i++)
            {
                icId = icId.ToString() + request.VehicleList[i].ICID.ToString() + ",";
            }

            try
            {

                var transaction = new Transaction()
                {
                    TransactionDate = DateTime.Now,
                    StatusDsc = "Completed",
                    PaymentMethod = "Debit Card",
                    CardNumber = "5105105105105100",
                    ICId = icId.ToString(),
                    WpAmount = WpAmount,
                    IcAmount = IcAmount,
                    TotalAmount = request.TotalAmount,
                    TransactionType = "Online",
                    PaymentGatewayResponse = "",
                    CustomerId = request.CustomerId
                };
                var transactionResponse = await _transactionRepository.AddAsync(transaction);
                _logger.LogInformation("Transaction Recorded");
                _queueService.SendMessageAsync<Transaction>(transactionResponse, "Transaction");
                for (int r = 0; r < request.VehicleList.Count; r++)
                {
                    Random ran = new Random();
                    String b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int length = 3;
                    String random = "";
                    for (int i = 0; i < length; i++)
                    {
                        int a = ran.Next(26);
                        random = random + b.ElementAt(a);
                    }

                    var policyType = await _policyTypeRepository.GetPolicyTypeByDescription(request.VehicleList[r].PolicyTypeId);

                    var customerPolicy = new CustomerPolicy()
                    {
                        PolicyRequestRefNo = "REQ-" + random + "/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day,
                        VehicleId = request.VehicleList[r].ID,
                        CustomerId = request.CustomerId,
                        TransactionId = transactionResponse.Id,
                        PolicyTypeId = policyType.Id,
                        PolicyNumber = "PN-" + random + "/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day,
                        PolicyResponse = "",
                        PremiumAmount = request.VehicleList[r].PremiumAmount,
                        ServiceChargeAmount = request.VehicleList[r].ServiceChargeAmount,
                        AdditionalCoverageAmount = request.VehicleList[r].AdditionalCoverageAmount,
                        VAT = request.VehicleList[r].VAT,
                        GroundTotal = (double.Parse(request.VehicleList[r].PremiumAmount) + double.Parse(request.VehicleList[r].ServiceChargeAmount) + double.Parse(request.VehicleList[r].AdditionalCoverageAmount)).ToString(),
                        IsUpgraded = false,
                        IsCancelled = false,
                    };
                    customerPolicy.IssueDate = DateTime.Now;
                    customerPolicy.StartDate = DateTime.Now.AddDays(1);
                    customerPolicy.ExpiryDate = DateTime.Now.AddYears(1);
                    var policy = await _customerPolicyRepository.AddAsync(customerPolicy);
                    _logger.LogInformation("Policy Recorded");
                    _queueService.SendMessageAsync<CustomerPolicy>(policy, "CustomerPolicy");
                    var additionalCoverage = new AddAdditionalCoverageCommand()
                    {
                        AdditionalCoverage = request.VehicleList[r].AdditionalCoverage,
                        CustomerPolicyId = policy.Id
                    };
                    //var additionalCover = await _additionalCoverageRepository.AddAsync(additionalCoverage);
                    var additionalCover = await _mediator.Send(additionalCoverage);
                    _logger.LogInformation("Additional Coverage Recorded");
                    _queueService.SendMessageAsync<CustomerPolicyAdditionalCoverage>(_mapper.Map<CustomerPolicyAdditionalCoverage>(additionalCover.Data), "AdditionalCoverage");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            _logger.LogInformation("Transaction and Policy Recorded...");

            //DirectPay Payment Gateway Form Generation Code Starts
            string SECRET_KEY = "YTk4ODI5OTYzODI1ZGEyMDZiYzliMmUz";
            SortedDictionary<string, string> parameters = new SortedDictionary<string, string>(StringComparer.Ordinal);
            string benName = Uri.EscapeDataString("DIGITAL CO");
            long transactionId = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            parameters.Add("Amount", request.TotalAmount.ToString());
            parameters.Add("Channel", "0");
            parameters.Add("CurrencyISOCode", "682");
            parameters.Add("Language", "en");
            parameters.Add("MerchantID", "DP00000007");
            parameters.Add("MessageID", "1");
            parameters.Add("Quantity", "1");

            //Old Application
            //parameters.Add("ResponseBackURL", "https://wplusdev.aspnetdevelopment.in/wazen/quotes/payment/thank-you");

            //AzureServer
            parameters.Add("ResponseBackURL", "http://transaction.wazen.ml/api/v1/PaymentCallbackResponse");

            //Local
            //parameters.Add("ResponseBackURL", "http://localhost:44332/api/v1/PaymentCallbackResponse");

            //Server
            //parameters.Add("ResponseBackURL", "http://180.149.247.134:8098/api/v1/PaymentCallbackResponse");


            parameters.Add("ThemeID", "1000000001");
            parameters.Add("TransactionID", transactionId.ToString());
            parameters.Add("Version", "1.0");
            parameters.Add("ServiceAmount1", "100.5");
            parameters.Add("BankIdCode1", "12345d6f");
            parameters.Add("IBanNum1", "987656743281926354276254");
            parameters.Add("BeneficiaryName1", benName);
            parameters.Add("ValueDate1", "20220105");



            StringBuilder redirectURL = new StringBuilder("https://paytest.directpay.sa/SmartRoutePaymentWeb/SRPayMsgHandler");
            StringBuilder merchantID = new StringBuilder("DP00000007");
            StringBuilder amount = new StringBuilder(request.TotalAmount.ToString());
            StringBuilder currencyCode = new StringBuilder("682");
            StringBuilder language = new StringBuilder("en");
            StringBuilder messageID = new StringBuilder("1");
            StringBuilder transactionID = new StringBuilder(transactionId.ToString());
            StringBuilder themeID = new StringBuilder("1000000001");

            //Old Application
            //StringBuilder responseBackURL = new StringBuilder("https://wplusdev.aspnetdevelopment.in/wazen/quotes/payment/thank-you");

            //AzureServer
            StringBuilder responseBackURL = new StringBuilder("http://transaction.wazen.ml/api/v1/PaymentCallbackResponse");

            //Local
            //StringBuilder responseBackURL = new StringBuilder("http://localhost:44332/api/v1/PaymentCallbackResponse");

            //Server
            //StringBuilder responseBackURL = new StringBuilder("http://180.149.247.134:8098/api/v1/PaymentCallbackResponse");
            //StringBuilder responseBackURL = new StringBuilder("https://wplusapidev.aspnetdevelopment.in/api/v1/DemoCallBack");

            StringBuilder channel = new StringBuilder("0");
            StringBuilder quantity = new StringBuilder("1");
            StringBuilder version = new StringBuilder("1.0");
            StringBuilder serviceAmount1 = new StringBuilder("100.5");
            StringBuilder bankIdCode1 = new StringBuilder("12345d6f");
            StringBuilder iBanNum1 = new StringBuilder("987656743281926354276254");
            StringBuilder beneficiaryName1 = new StringBuilder(benName);
            StringBuilder valueDate1 = new StringBuilder("20220105");
            StringBuilder orderedString = new StringBuilder();

            orderedString.Append(SECRET_KEY);
            foreach (KeyValuePair<string, string> kv in parameters)
            {
                orderedString.Append(kv.Value);
            }
            Console.WriteLine("orderdString: " + orderedString);

            // Generate SecureHash with SHA256 
            SHA256 sha256;
            byte[] bytes, hash;
            string secureHash = string.Empty;

            bytes = Encoding.UTF8.GetBytes(orderedString.ToString().ToString());

            sha256 = SHA256Managed.Create();
            hash = sha256.ComputeHash(bytes);
            foreach (byte x in hash)
            {
                secureHash += String.Format("{0:x2}", x);
            }

            StringBuilder formString = new StringBuilder("<input name ='MerchantID' type ='hidden' value =" + merchantID + " />" +
                "<input name ='Amount' type = 'hidden' value = " + request.TotalAmount + " />" +
                "<input name ='CurrencyISOCode' type ='hidden' value = " + currencyCode + " />" +
                "<input name ='Language' type ='hidden' value = " + language + " />" +
                "<input name ='MessageID' type ='hidden' value = " + messageID + " />" +
                "<input name ='TransactionID' type ='hidden' value = " + transactionID + " />" +
                "<input name ='ThemeID' type ='hidden' value = " + themeID + " />" +
                "<input name ='ResponseBackURL' type ='hidden' value = " + responseBackURL + " />" +
                "<input name ='Quantity' type ='hidden' value = " + quantity + " />" +
                "<input name ='Channel' type ='hidden' value = " + channel + " />" +
                "<input name ='Version' type ='hidden' value = " + version + " />" +
                "<input name ='ServiceAmount1' type ='hidden' value = " + serviceAmount1 + " />" +
                "<input name ='BankIdCode1' type ='hidden' value = " + bankIdCode1 + " />" +
                "<input name ='IBanNum1' type ='hidden' value = " + iBanNum1 + " />" +
                "<input name ='BeneficiaryName1' type ='hidden' value = " + beneficiaryName1 + " />" +
                "<input name ='ValueDate1' type ='hidden' value = " + valueDate1 + " />" +
                "<input name ='SecureHash' type ='hidden' value = " + secureHash + " />");

            var response = new Response<string>(formString.ToString(), "Created successfully ");
            //DirectPay Payment Gateway Form Generation Code Ends

            return response;
        }
    }
}
