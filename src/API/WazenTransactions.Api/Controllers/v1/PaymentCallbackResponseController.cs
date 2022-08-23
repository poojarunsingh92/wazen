using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace WazenTransactions.Api.Controllers.v1
{
     [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PaymentCallbackResponseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public PaymentCallbackResponseController(IMediator mediator, ILogger<PaymentCallbackResponseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public RedirectResult CallBackResponse([FromForm] dynamic callBackResponse)
        {
            var testResponse = JsonSerializer.Serialize(callBackResponse);
            String SECRET_KEY = "YTk4ODI5OTYzODI1ZGEyMDZiYzliMmUz";
            SortedDictionary<string, string> responseParameters = new SortedDictionary <String, String>(StringComparer.Ordinal);

            foreach (string s in Request.Form.Keys)
            {
                if (!"Response.SecureHash".Equals(s.ToString()))
                {
                    if ("Response.StatusDescription".Equals(s.ToString()) ||
                    "Response.GatewayStatusDescription".Equals(s.ToString()))
                    {
                        responseParameters.Add(s.ToString(),
                            HttpUtility.UrlEncode(Request.Form[s], System.Text.Encoding.UTF8));
                    }
                    else
                    {
                        responseParameters.Add(s.ToString(), Request.Form[s]);
                    }
                }
            }


            StringBuilder responseOrderdString = new StringBuilder();
            responseOrderdString.Append(SECRET_KEY);
            foreach (KeyValuePair<string, string> kv in responseParameters)
            {
                responseOrderdString.Append(kv.Value);
            }
            Console.WriteLine("Response Ordered String is: " + responseOrderdString.ToString());


            SHA256 sha256;
            byte[] bytes, hash;
            string generatedsecureHash = string.Empty;

            bytes = Encoding.UTF8.GetBytes(responseOrderdString.ToString().ToString());
            sha256 = SHA256Managed.Create();
            hash = sha256.ComputeHash(bytes);
            foreach (byte x in hash)
            {
                generatedsecureHash += String.Format("{0:x2}", x);
            }

            String receivedSecurehash = Request.Form["Response.SecureHash"];
            if (receivedSecurehash != generatedsecureHash.ToString())
            {

                Console.WriteLine("Received Secure Hash does not Equal generated Secure hash");
                //Local
                //return Redirect("http://localhost:4200/wazen/quotes/payment/thank-you");

                //AzureClientServer
                //return Redirect("http://client.wazen.ml/wazen/quotes/payment/thank-you");

                //AzureLatestClientServer
                return Redirect("http://frontend.wazen.ml/wazen/quotes/payment/thank-you");

                //Server
                //return Redirect("https://wplusdev.aspnetdevelopment.in/wazen/quotes/payment/thank-you");
            }
            else
            {
                String statusDescription = Request.Form["Response.StatusDescription"];
                Console.WriteLine("Status is: " + statusDescription);
                if (statusDescription == "Transaction was processed successfully")
                {
                    //Need to write logic to send mail to CustomerMail with Policy Purchase Invoice

                    //System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    //string newResponse = "";

                    ////Server
                    ////RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

                    ////Local
                    //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);
                    //var sentOTP = new RestRequest(Method.GET);
                    //sentOTP.AddHeader("Content-Type", "application/json");
                    //sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);
                    //IRestResponse sendOTPResponse = client.Execute(sentOTP);
                    //if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    newResponse = sendOTPResponse.Content;
                    //}

                    //End of CustomerMail wth Policy Purchase Invoice 

                    //Local
                    //return Redirect("http://localhost:4200/wazen/quotes/payment/thank-you?type=Success");

                    //AzureClientServer
                    //return Redirect("http://client.wazen.ml/wazen/quotes/payment/thank-you?type=Success");

                    //AzureLatestClientServer
                    return Redirect("http://frontend.wazen.ml/wazen/quotes/payment/thank-you?type=Success");

                    //Server
                    //return Redirect("https://wplusdev.aspnetdevelopment.in/wazen/quotes/payment/thank-you?type=Success");
                }
                else
                {
                    //Local
                    //return Redirect("http://localhost:4200/wazen/quotes/payment/thank-you?type=Failed");

                    //AzureClientServer
                    //return Redirect("http://client.wazen.ml/wazen/quotes/payment/thank-you?type=Success");

                    //AzureLatestClientServer
                    return Redirect("http://frontend.wazen.ml/wazen/quotes/payment/thank-you?type=Success");

                    //Server
                    //return Redirect("https://wplusdev.aspnetdevelopment.in/wazen/quotes/payment/thank-you?type=Failed");
                }
            }

        }
    }
}
