using System;
using System.Linq;

namespace LiveStandup.Shared.Models
{
    public class Show
    {
        // Pa6qtu1wIs8
        public string Id { get; set; }

        //Format: ".NET Community Standup - Monday, Day Year - Topic
        public string Title { get; set; }

        string shortTitle;
        public string ShortTitle
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(shortTitle))
                    return shortTitle;

                var pieces = Title?.Split('-');
                if (pieces?.Count() > 2)
                    shortTitle = pieces.Last();

                return shortTitle;
            }
            set => shortTitle = value;
        }

        public bool HasTitle => !string.IsNullOrEmpty(ShortTitle);

        public string DisplayTitle => HasTitle ? ShortTitle : Title;

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
        string category;
        public string Category
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(category))
                    return category;

                if (Title.StartsWith("ASP.NET"))
                    category = "ASP.NET";

                if (Title.StartsWith("Visual Studio") || Title.StartsWith("Tooling"))
                    category = "Visual Studio";

                if (Title.StartsWith("Xamarin") || Title.StartsWith("Mobile"))
                    category = "Xamarin";

                if (Title.StartsWith("Languages"))
                    category = "Languages & Runtime";

                if (Title.StartsWith("Windows Desktop") || Title.StartsWith("Desktop"))
                    category = "Desktop";

                if (Title.StartsWith("Cloud"))
                    category = "Cloud";

                return category;
            }
            set => category = value;
        }
    }
}
