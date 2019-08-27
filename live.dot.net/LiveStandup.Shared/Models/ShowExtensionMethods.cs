using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LiveStandup.Shared.Models
{
    public static class ShowExtensionMethods
    {
        public static void SetCalculateShowFields(this Show item)
        {
            // Calculating topic
            var pieces = item.Title?.Split('-');
            if (pieces?.Count() > 2)
                item.Topic = pieces.Last().Trim();

            item.CommunityLinksUrl = GetCommunityLinksUrl(item.Description);
            item.DisplayTitle = string.IsNullOrEmpty(item.Topic) ? item.Title : item.Topic;
            item.HasDisplayTitle = !string.IsNullOrEmpty(item.DisplayTitle);
            item.HasLinks = !string.IsNullOrWhiteSpace(item.CommunityLinksUrl);
            item.Category = GetCategory(item.Title);
        }

        private static string GetCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return null;

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

            return null;
        }

        private static string GetCommunityLinksUrl(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return null;

            var match = Regex.Match(description,
                @"https:\/\/www\.theurlist\.com\/[a-zA-Z0-9\/-]*",
                RegexOptions.Multiline);
            if (match.Success)
                return match.Value;

            match = Regex.Match(description,
                @"https:\/\/www\.one-tab\.com\/[a-zA-Z0-9\/-]*",
                RegexOptions.Multiline);
            if (match.Success)
                return match.Value;

            return null;
        }
    }
}
