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
    public class IndexModel : PageModel
    {
        public IEnumerable<Show> Shows { get; private set; }

        IYouTubeShowsService youTubeService;
        public IndexModel(IYouTubeShowsService youTubeService)
        {
            this.youTubeService = youTubeService;
        }

        public async Task OnGet()
        {
            Shows = await youTubeService.GetShows();
        }
    }
}
