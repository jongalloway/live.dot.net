using LiveStandup.Shared.Models;
using LiveStandup.Shared.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LiveStandup.Mobile.Services
{
    class YouTubeDataStore : IYouTubeShowsService
    {
        HttpClient httpClient;
        string url;
        public YouTubeDataStore()
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                "10.0.2.2" : "localhost";
            url = $"http://{baseUrl}:7071/api/GetShows";
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Show>> GetShows(int numberOfShows = 25)
        {
            var shows = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Show>>(shows);
        }
    }
}
