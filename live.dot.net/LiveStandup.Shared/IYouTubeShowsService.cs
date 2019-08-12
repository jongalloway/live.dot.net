using System.Collections.Generic;
using System.Threading.Tasks;
using LiveStandup.Shared.Models;

namespace LiveStandup.Shared.Services
{
    public interface IYouTubeShowsService
    {
        Task<IEnumerable<Show>> GetShows(int numberOfShows = 25);
    }
}