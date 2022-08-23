using CsvHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WazenAdmin.Application.Contracts.Infrastructure;

namespace WazenAdmin.Application.UnitTests.Mocks
{
    public class CsvExporterMocks
    {
        public static Mock<ICsvExporter> GetCsvExporter()
        {
            var mockCsvExporter = new Mock<ICsvExporter>();
            
            return mockCsvExporter;
        }
    }
}
