using System;
using System.Linq;

namespace LiveStandup.Shared.Models
{
    public class Show
    {
        // Pa6qtu1wIs8
        public string Id { get; set; }

        public string Title { get; set; }

        public string ShortTitle { get; set; }

        public bool HasTitle => !string.IsNullOrEmpty(Title);

        public string Description { get; set; }
        public DateTime ScheduledStartTime { get; set; }

        public DateTime? ActualStartTime { get; set; }

        public DateTime? ActualEndTime { get; set; }

        public string ShowDateString { get; set; }

        public bool IsNew => !IsInFuture &&
                             !IsOnAir &&
                             (DateTime.UtcNow - ScheduledStartTime).TotalDays <= 14;

        public bool IsInFuture => ScheduledStartTime > DateTime.UtcNow;

        public bool IsOnAir =>
            ActualStartTime.HasValue &&
            !ActualEndTime.HasValue;

        // https://www.youtube.com/watch?v=Pa6qtu1wIs8&list=PL1rZQsJPBU2StolNg0aqvQswETPcYnNKL&index=0
        public string Url { get; set; }

        //https://i.ytimg.com/vi/Pa6qtu1wIs8/hqdefault_live.jpg
        public string ThumbnailUrl { get; set; }

        // ASP.NET, Xamarin, Desktop, Visual Studio
        public string Topic { get; set; }
    }

    public static class ShowHelpers
    {
        public static string GetShortTitle(this string title)
        {
            return title.Split('-').LastOrDefault();
        }
        public static string GetTopic(this string title)
        {
            if (title.StartsWith("ASP.NET"))
                return "ASP.NET";

            if (title.StartsWith("Visual Studio") || title.StartsWith("Tooling"))
                return "Visual Studio";

            if (title.StartsWith("Xamarin") || title.StartsWith("Mobile"))
                return "Xamarin";

            if (title.StartsWith("Languages"))
                return "Languages & Runtime";

            if (title.StartsWith("Windows Desktop") || title.StartsWith("Desktop"))
                return "Desktop";

            if (title.StartsWith("Cloud"))
                return "Cloud";

            return string.Empty;
        }
    }
}
