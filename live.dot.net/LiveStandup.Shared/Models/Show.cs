using System;

namespace LiveStandup.Shared.Models
{
    public class Show
    {
        // Pa6qtu1wIs8
        public string Id { get; set; }

        public string Title { get; set; }

        public bool HasTitle => !string.IsNullOrEmpty(Title);

        public string Description { get; set; }

        public DateTimeOffset ShowDate { get; set; }

        public bool IsNew => !IsInFuture && (DateTimeOffset.Now - ShowDate).TotalDays <= 14;

        public bool IsInFuture => ShowDate > DateTimeOffset.Now;

        // https://www.youtube.com/watch?v=Pa6qtu1wIs8&list=PL1rZQsJPBU2StolNg0aqvQswETPcYnNKL&index=0
        public string Url { get; set; }

        //https://i.ytimg.com/vi/Pa6qtu1wIs8/hqdefault_live.jpg
        public string ThumbnailUrl { get; set; }

        // ASP.NET, Xamarin, Desktop, Visual Studio
        public string Topic { get; set; }
    }
}
