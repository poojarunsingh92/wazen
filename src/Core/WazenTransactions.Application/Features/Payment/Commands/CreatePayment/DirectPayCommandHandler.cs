using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Payment.Commands.CreatePayment
{
    public class DirectPayCommandHandler : IRequestHandler<CreatePaymentCommand, Response<string>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePaymentCommandHandler> _logger;

        public DirectPayCommandHandler(IMapper mapper, ITransactionRepository transactionRepository, ILogger<CreatePaymentCommandHandler> logger)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }
        public async Task<Response<string>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            string SECRET_KEY = "YTk4ODI5OTYzODI1ZGEyMDZiYzliMmUz";
            SortedDictionary<string, string> parameters = new SortedDictionary<string, string>(StringComparer.Ordinal);
            string benName = Uri.EscapeDataString("DIGITAL CO");
            long transactionId = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            // Guid transactionId = transaction.ID;
            parameters.Add("Amount", request.TotalAmount.ToString());
            parameters.Add("Channel", "0");
            parameters.Add("CurrencyISOCode", "682");
            parameters.Add("Language", "en");
            parameters.Add("MerchantID", "DP00000007");
            parameters.Add("MessageID", "1");
            parameters.Add("Quantity", "1");
            parameters.Add("ResponseBackURL", "https://localhost:44330/api/v1/DemoCallBack");
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
            _ = new StringBuilder(request.TotalAmount.ToString());
            StringBuilder currencyCode = new StringBuilder("682");
            StringBuilder language = new StringBuilder("English");
            StringBuilder messageID = new StringBuilder("1");
            StringBuilder transactionID = new StringBuilder(transactionId.ToString());
            StringBuilder themeID = new StringBuilder("1000000001");

            StringBuilder responseBackURL = new StringBuilder("https://localhost:44330/api/v1/DemoCallBack");
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

            return response;

        }
    }
}
