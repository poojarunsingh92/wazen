using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Drawing.Printing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Drawing;
using WazenTransactions.Application.Contracts.Infrastructure;
using System.Net;
using WazenTransactions.Application.Models.Mail;
using PdfSharp.Drawing.Layout;
using WazenTransactions.Application.Exceptions;
using WazenTransactions.Application.Features.CoverNote.Queries.GetCoverNote;
using WazenTransactions.Application.Features.CoverNotes.GetCoverNote;

namespace Wazen.Application.Features.CoverNote.Queries.GetCoverNote
{
    public class GetCoverNoteDetailQueryHandler : IRequestHandler<GetCoverNoteDetailQuery, Response<CoverNoteDetailVm>>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public GetCoverNoteDetailQueryHandler(IMapper mapper,ILogger<GetCoverNoteDetailQueryHandler> logger, IEmailService emailService)
        {
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<CoverNoteDetailVm>> Handle(GetCoverNoteDetailQuery request, CancellationToken cancellationToken)
        {

            PdfDocument pdfDocument = new PdfDocument();
            PdfPage page = pdfDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.Alignment = XParagraphAlignment.Center;

            //English
            string Content = Environment.NewLine + Environment.NewLine + Environment.NewLine + "Cover Note" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                "-	Insured Name\t\t\t:FirstName NastName" + Environment.NewLine +
                "-	ID/Iq.No/ CR No.\t\t:1030605080" + Environment.NewLine +
                "-	Policy No\t\t\t\t:PL 190090" + Environment.NewLine +
                "-	Type of Policy\t\t\t:CO" + Environment.NewLine +
                "-	Make / Model of Vehicle\t:Toyota Camry" + Environment.NewLine +
                "-	Chassis No\t\t\t\t:JMT3660CT401" + Environment.NewLine +
                "-	Sequence No\t\t\t\t:14623" + Environment.NewLine +
                "-	Plate NO\t\t\t\t:A S D 6 6 6" + Environment.NewLine +
                "-	Period of insurance\t\t: from20 /02 / 2021 To19 /02 /2022" + Environment.NewLine +
                "-	Contribution\t\t\t:SR 2000" + Environment.NewLine +
                "-	Admin Fee\t\t\t\t:SR 25" + Environment.NewLine +
                "-	No Claim Discount(NCD)\t:SR 500" + Environment.NewLine +
                "-	VAT Amount (15%)\t\t:SR 300" + Environment.NewLine +
                "-	Total contribution\t\t:SR 1825" + Environment.NewLine +
                "-	Commission Amount (15%)\t:SR 300";

            tf.DrawString(Content, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), new XStringFormat()/*XStringFormats.Default*/);
            string WazenDocumentsPath = "WazenUploads";
            if (!Directory.Exists(WazenDocumentsPath))
            {
                Directory.CreateDirectory(WazenDocumentsPath);
            }
            
            pdfDocument.Save(WazenDocumentsPath + "\\WazenCoverNote.pdf");
            var email = new Email();
            email.Subject = "Welcome | Thank you for using our services...";
            email.Attachments = new Attachment(WazenDocumentsPath + "\\WazenCoverNote.pdf", "application/pdf");
            email.Body = "Hello " + "<CustomerName>," +
                Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                "Please do find the attachment." +
                Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                "Regards," +
                Environment.NewLine +
                "Wazen Plus Insurance";
            email.To = "shevateganeshd@gmail.com";
            await _emailService.SendEmail(email);
            pdfDocument.Close();

            //Try catch for after sending file need to delete else it will create unneccessary files in the folder at API end
            try
            {
                if (File.Exists(WazenDocumentsPath + "\\WazenCoverNote.pdf"))
                {
                    //If file exist then we will delete it   
                    File.Delete(WazenDocumentsPath + "\\WazenCoverNote.pdf");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            var response = new Response<CoverNoteDetailVm>(null, "success");
            
            return response;
        }
    }
}
