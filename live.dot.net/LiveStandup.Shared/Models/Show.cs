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

        public string Topic { get; set; }

        public bool HasDisplayTitle { get; set; }

        public string DisplayTitle { get; set; }

        public string CommunityLinksUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ScheduledStartTime { get; set; }

        public DateTime? ActualStartTime { get; set; }

        public DateTime? ActualEndTime { get; set; }

        public bool HasLinks { get; set; }

        // https://www.youtube.com/watch?v=Pa6qtu1wIs8&list=PL1rZQsJPBU2StolNg0aqvQswETPcYnNKL&index=0
        public string Url { get; set; }

        //https://i.ytimg.com/vi/Pa6qtu1wIs8/hqdefault_live.jpg
        public string ThumbnailUrl { get; set; }

        // ASP.NET, Xamarin, Desktop, Visual Studio
        public string Category { get; set; }

        [JsonIgnore]
        public string ScheduledStartTimeHumanized
        {
            get
            {
                if ((DateTime.UtcNow - ScheduledStartTime.Value).TotalDays <= 7)
                    return ScheduledStartTime.Humanize();

                var culture = CultureInfo.CurrentCulture;
                var regex = new Regex("dddd[,]{0,1}");
                var shortDatePattern = regex.Replace(culture.DateTimeFormat.LongDatePattern.Replace("MMMM", "MMM"), string.Empty).Trim();
                return ScheduledStartTime.Value.ToString($"{shortDatePattern}", culture);               
            }
        }

        [JsonIgnore]
        public bool IsNew => !IsInFuture &&
                     !IsOnAir &&
                     (DateTime.UtcNow - ScheduledStartTime.Value).TotalDays <= 14;

        [JsonIgnore]
        public bool IsInFuture => ScheduledStartTime.Value > DateTime.UtcNow;

        [JsonIgnore]
        public bool IsOnAir
        {
            get
            {
                // if we have started and ended then not on air.
                if (ActualStartTime.HasValue && ActualEndTime.HasValue)
                    return false;

                //if we have the real data from YouTube that we have started and not ended then return it.
                if (ActualStartTime.HasValue && !ActualEndTime.HasValue)
                    return true;

                // else the data may not be fresh, so use schedule time.
                // if it is 5 minutes until schedule and has been less than 2 hours then do it
                var scheduled = ScheduledStartTime.Value;
                return CheckHasStarted(DateTime.UtcNow, scheduled);
            }
        }

        public static bool CheckHasStarted(DateTime dateTimeNow, DateTime scheduled)
        {
            return dateTimeNow > scheduled.AddMinutes(-5) && dateTimeNow < scheduled.AddHours(2);
        }
    }
}
