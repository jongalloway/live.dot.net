using System;
using Google.Apis.YouTube.v3;

namespace LiveStandup.Web.Services
{
    public interface IYouTubeServiceFactory
    {
        YouTubeService GetService();
    }
}
