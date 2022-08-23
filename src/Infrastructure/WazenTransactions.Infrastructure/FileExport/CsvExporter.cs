using CsvHelper;
using System.Collections.Generic;
using System.IO;
using WazenTransactions.Application.Contracts.Infrastructure;
//using WazenTransactions.Application.Features.Events.Queries.GetEventsExport;

namespace WazenTransactions.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        //public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter);
        //        csvWriter.WriteRecords(eventExportDtos);
        //    }

        //    return memoryStream.ToArray();
        //}
    }
}
