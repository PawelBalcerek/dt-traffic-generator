using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Configuration;
using TestLibrary.Infrastructure.CsvConverting.Abstract;
using TestLibrary.Infrastructure.FileGenerating.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.FileGenerating.Concrete
{
    public class FileGenerator : IFileGenerator
    {
        private readonly ICsvConverter _csvConverter;

        public FileGenerator(ICsvConverter csvConverter)
        {
            _csvConverter = csvConverter;
        }

        public byte[] GenerateUserEndpointExecutionTimesZipFile(IEnumerable<UserEndpointExecutionTimes> data)
        {
            MemoryStream compressedFileStream = new MemoryStream();

            using (ZipArchive zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
            {
                foreach (UserEndpointExecutionTimes item in data)
                {
                    IEndpoint endpoint = item.Endpoint;
                    string fileName = $"endpoint-{endpoint.EndpointId}-{endpoint.EndpointName}({endpoint.HttpMethod})_user-{item.UserId}{Config.CsvExtension}";
                    ZipArchiveEntry zipEntry = zipArchive.CreateEntry(fileName);

                    using (MemoryStream originalFileStream = new MemoryStream(GenerateCsvFile(item.ExecutionTimesWithStamps)))
                    using (Stream zipEntryStream = zipEntry.Open())
                    {
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }
            }

            return compressedFileStream.ToArray();
        }

        public byte[] GenerateCsvFile(IEnumerable<IExecutionTimesWithStamp> data)
        {
            string csvContent = _csvConverter.ConvertToCsv(data);
            return Encoding.ASCII.GetBytes(csvContent);
        }

        public byte[] GenerateCsvFile(IEnumerable<AverageEndpointsExecutionTimes> data)
        {
            string csvContent = _csvConverter.ConvertToCsv(data);
            return Encoding.ASCII.GetBytes(csvContent);
        }
    }
}
