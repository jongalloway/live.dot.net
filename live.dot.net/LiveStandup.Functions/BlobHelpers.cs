using System.IO;
using System.Net.Http;
using System.Net;
using System.Text;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LiveStandup.Functions
{
    internal class BlobHelpers
    {
        internal async static Task<HttpResponseMessage> BlobToHttpResponseMessageAsync(Stream inBlob, ILogger log, string name)
        {
            try
            {
                log.LogInformation($"Reading feed to {name}.");
                var json = string.Empty;
                using (var reader = new StreamReader(inBlob))
                {
                    json = await reader.ReadToEndAsync();
                }

                log.LogInformation($"Finished reading {name} feed from stream.");

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Unable to get {name} feed");
            }

            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}