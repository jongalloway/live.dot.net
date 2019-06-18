using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStandup.Shared.Models;
using LiveStandup.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LiveStandup.Web.Pages
{
    public class YouTubeHealthModel : PageModel
    {
        public string Status { get; private set;  }

        IYouTubeShowsService youTubeService;
        public YouTubeHealthModel(IYouTubeShowsService youTubeService)
        {
            this.youTubeService = youTubeService;
        }

        public async Task OnGet()
        {
            Status = "Unhealthy";
            try
            {
                var shows = await youTubeService.GetShows();
                if(shows.Any())
                    Status = "Healthy";
            }
            catch (Exception ex)
            {
                //TODO: Log this exception
            }
        }
    }
}
