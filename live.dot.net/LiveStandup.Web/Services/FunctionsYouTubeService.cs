using LiveStandup.Shared.Models;
using LiveStandup.Shared.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveStandup.Web.Services
{
    public class FunctionsYouTubeService: IYouTubeShowsService
    {
        private HttpClient httpClient;
        private IConfiguration config;

        public FunctionsYouTubeService(IHttpClientFactory httpClient, IConfiguration config)
        {
            this.httpClient = httpClient.CreateClient();
            this.config = config;
        }

        public async Task<IEnumerable<Show>> GetShows(int numberOfShows = 25)
        {
            var shows = await httpClient.GetStringAsync(config["FunctionGetShowsUrl"]);
            return JsonConvert.DeserializeObject<IEnumerable<Show>>(shows);
        }
    }
}
