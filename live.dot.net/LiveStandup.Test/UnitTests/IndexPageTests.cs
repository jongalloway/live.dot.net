using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStandup.Shared.Models;
using LiveStandup.Web.Pages;
using LiveStandup.Web.Services;
using Moq;
using Xunit;

namespace LiveStandup.Tests.UnitTests
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGet_PopulatesThePageModel_WithAListOfShows()
        {
            // Arrange
            var youtubeService = Mock.Of<IYouTubeShowsService>();
            var youtubeServiceMock = Mock.Get(youtubeService);
            youtubeServiceMock.Setup(m => m.GetShows(25)).ReturnsAsync((new List<Show>
            {
                new Show
                {
                    Id = "hPjsCrUKumo",
                    Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!",
                    Description = "Join members from the ASP.NET teams for our community standup covering great community contributions for ASP.NET, ASP.NET Core, and more.\n\nCommunity links for this week: https://www.theurlist.com/aspnet-standup-2019-07-02",
                    ScheduledStartTime = DateTime.Parse("2019-07-16T22:45:00Z"),
                    ActualStartTime = DateTime.Parse("2019-07-16T22:45:00Z"),
                    ActualEndTime = DateTime.Now,
                    Url = "https://www.youtube.com/watch?v=hPjsCrUKumo&list=PL1rZQsJPBU2St9-Mz1Kaa7rofciyrwWVx&index=0",
                    ThumbnailUrl = "https://i.ytimg.com/vi/hPjsCrUKumo/mqdefault.jpg",
                    Category = "ASP.NET"
                }
            }));
            
            var pageModel = new IndexModel(youtubeServiceMock.Object);
            
            // Act
            await pageModel.OnGet();
            
            // Assert
            var actualShows = Assert.IsAssignableFrom<IEnumerable<Show>>(pageModel.Shows);
            var show = actualShows.FirstOrDefault();
            Assert.True(actualShows.Count() == 1);
            Assert.True(show.Title == "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!");
            Assert.True(show.ShortTitle == "Meet the ASP.NET Docs Team!");
            Assert.True(show.Category == "ASP.NET");
        }

        // https://andrewlock.net/creating-a-custom-xunit-theory-test-dataattribute-to-load-data-from-json-files/
        // https://ankursheel.com/blog/2019/02/load-test-data-from-a-json-file-for-xunit-tests/
        [Theory]
        [JsonFileData("sampleData.json", typeof(IEnumerable<Show>))]
        public async Task All_Shows_Have_Title(Show show)
        {
            Assert.True(show.HasTitle);
        }
    }
}