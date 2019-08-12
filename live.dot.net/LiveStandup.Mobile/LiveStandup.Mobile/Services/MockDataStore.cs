using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStandup.Mobile.Models;
using LiveStandup.Shared.Models;
using LiveStandup.Shared.Services;

namespace LiveStandup.Mobile.Services
{
    public class MockDataStore : IYouTubeShowsService
    {
        List<Show> items;

        public MockDataStore()
        {
            items = new List<Show>();
            var mockItems = new List<Show>
            {
                new Show {
                        Id = "hPjsCrUKumo",
                        Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!",
                        Description = "Join members from the ASP.NET teams for our community standup covering great community contributions for ASP.NET, ASP.NET Core, and more.\n\nCommunity links for this week: https://www.theurlist.com/aspnet-standup-2019-07-02",
                        ScheduledStartTime =  DateTime.UtcNow,
                        ActualStartTime =  DateTime.UtcNow,
                        ActualEndTime =  null,
                        Url =  "https://www.youtube.com/watch?v=hPjsCrUKumo&list=PL1rZQsJPBU2St9-Mz1Kaa7rofciyrwWVx&index=0",
                        ThumbnailUrl =  "https://i.ytimg.com/vi/hPjsCrUKumo/mqdefault.jpg",
                        Category = "ASP.NET"
                    }
                };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }


        public Task<IEnumerable<Show>> GetShows(int numberOfShows = 25)
        {
            return Task.FromResult((IEnumerable<Show>)items);
        }
    }
}