using System;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;

namespace LiveStandup.Web.Services
{
    public class YouTubeServiceFactory : IYouTubeServiceFactory
    {
        private readonly string YouTubeApiKey;
        private readonly string YouTubeAppName;
        private YouTubeService _service;

        public YouTubeServiceFactory(IConfiguration configuration)
        {
            YouTubeApiKey = configuration["YouTube:Key"];
            YouTubeAppName = configuration["YouTube:AppName"];
        }

        public YouTubeService GetService()
        {
            if(_service != null)
            {
                return _service;
            }

            _service = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YouTubeApiKey,
                ApplicationName = YouTubeAppName
            });

            return _service;
        }
    }
}
