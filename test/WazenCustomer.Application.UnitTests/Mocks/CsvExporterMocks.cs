using CsvHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WazenCustomer.Application.Contracts.Infrastructure;
//using WazenCustomer.Application.Features.Events.Queries.GetEventsExport;

namespace WazenCustomer.Application.UnitTests.Mocks
{
    public class CsvExporterMocks
    {
        //public static Mock<ICsvExporter> GetCsvExporter()
        //{
        //    var mockCsvExporter = new Mock<ICsvExporter>();
        //    mockCsvExporter.Setup(repo => repo.ExportEventsToCsv(It.IsAny<List<EventExportDto>>())).Returns(
        //        (List<EventExportDto> eventExportDtos) =>
        //        {
        //            using var memoryStream = new MemoryStream();
        //            using (var streamWriter = new StreamWriter(memoryStream))
        //            {
        //                using var csvWriter = new CsvWriter(streamWriter);
        //                csvWriter.WriteRecords(eventExportDtos);
        //            }

        //            return memoryStream.ToArray();
        //        });
        //    return mockCsvExporter;
        //}
    }
}
