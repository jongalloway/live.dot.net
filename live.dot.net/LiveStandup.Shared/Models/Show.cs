using Humanizer;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

// ClintonRocksmith cheered 1500 on June 25th 2019
// h0usebesuch gifted 2 subs on June 25th 2019
// LotanB gifted 1 sub on June 25th 2019

namespace LiveStandup.Shared.Models
{
    public class Show
    {
        // Pa6qtu1wIs8
        public string Id { get; set; }

        //Format: ".NET Community Standup - Monday, Day Year - Topic
        public string Title { get; set; }

        string topic;
        [JsonIgnore]
        public string Topic
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(topic))
                    return topic;

                var pieces = Title?.Split('-');
                if (pieces?.Count() > 2)
                    topic = pieces.Last().Trim();

                return topic;
            }
            set => topic = value;
        }

        [JsonIgnore]
        public bool HasDisplayTitle => !string.IsNullOrEmpty(DisplayTitle);

        [JsonIgnore]
        public string DisplayTitle => string.IsNullOrEmpty(Topic) ? Title : Topic;

        public string Description { get; set; }
        public DateTime ScheduledStartTime { get; set; }

        public DateTime? ActualStartTime { get; set; }

        public DateTime? ActualEndTime { get; set; }

        [JsonIgnore]
        public bool IsNew => !IsInFuture &&
                             !IsOnAir &&
                             (DateTime.UtcNow - ScheduledStartTime).TotalDays <= 14;

        [JsonIgnore]
        public bool IsInFuture => ScheduledStartTime > DateTime.UtcNow;

        [JsonIgnore]
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

        [JsonIgnore]
        public string ScheduledStartTimeHumanized
        {
            get
            {
                if ((DateTime.UtcNow - ScheduledStartTime).TotalDays <= 7)
                    return ScheduledStartTime.Humanize();

                var culture = CultureInfo.CurrentCulture;
                var regex = new Regex("dddd[,]{0,1}");
                var shortDatePattern = regex.Replace(culture.DateTimeFormat.LongDatePattern.Replace("MMMM", "MMM"), string.Empty).Trim();
                return ScheduledStartTime.ToString($"{shortDatePattern}", culture);               
            }
        }
    }
}
