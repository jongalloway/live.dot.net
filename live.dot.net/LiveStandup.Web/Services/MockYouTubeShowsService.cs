using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LiveStandup.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace LiveStandup.Web.Services
{
    public class MockYouTubeShowsService : IYouTubeShowsService
    {
        IFileInfo sampleData;
        public MockYouTubeShowsService(IHostingEnvironment hostingEnvironment)
        {
            sampleData = hostingEnvironment.ContentRootFileProvider.GetFileInfo("sampleData.json");
        }

        public Task<IEnumerable<Show>> GetShows(int numberOfShows = 25)
        {            
            return Task.FromResult(JsonConvert
                .DeserializeObject<IEnumerable<Show>>
                (File.ReadAllText(sampleData.PhysicalPath)));   
        }
    }
}
