using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStandup.Shared.Models;
using LiveStandup.Shared.Services;
using LiveStandup.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// r2_au cheered 100 bits June 25th, 2019
// r2_au cheered 100 bits June 25th, 2019
// r2_au cheered 200 bits June 25th, 2019
// clintonrocksmith cheered 200 bits June 25th, 2019
// lachlanwgordon cheered 100 bits June 25th, 2019
// ierazo_ cheered 100 bits June 25th, 2019
// ierazo_ cheered 100 bits June 25th, 2019

namespace LiveStandup.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Show> Shows { get; private set; }
        public Show UpcomingShow { get; private set; }
        public Show OnAirShow { get; private set; }
        public bool HasUpcomingShow => UpcomingShow != null;
        public bool IsOnAir => OnAirShow != null;

        IYouTubeShowsService youTubeService;
        public IndexModel(IYouTubeShowsService youTubeService)
        {
            this.youTubeService = youTubeService;
        }

        public async Task OnGet()
        {
            Shows = await youTubeService.GetShows();
            UpcomingShow = Shows.LastOrDefault(show => show.IsInFuture && !show.IsOnAir);
            OnAirShow = Shows.FirstOrDefault(show => show.IsOnAir);
        }
    }
}
