using System;
using System.ComponentModel;
using System.ServiceModel.Syndication;

namespace MEFRecipes.Model
{
    public class FeedItem
    {
        public FeedItem()
        {
            if (!DesignerProperties.IsInDesignTool)
            {
                return;
            }

            Id = "123";
            Title = "Design Title Data";
            Description = "This is a design time description";
            Url = new Uri("http://feeds.feedburner.com/CSharperImage", UriKind.Absolute);
            PostedDate = DateTime.Now;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public DateTime PostedDate { get; set; }        
    }

    public static class FeedItemExtensions
    {
        public static FeedItem AsFeedItem(this SyndicationItem item)
        {
            var feedItem = new FeedItem
                               {
                                   Id = item.Id,
                                   Title = item.Title == null ? string.Empty : item.Title.Text,
                                   Description = ((TextSyndicationContent) item.Content).Text.TrimToLength(200),
                                   Url = item.Links.Count > 0 ? null : item.Links[0].BaseUri,
                                   PostedDate = item.PublishDate.Date
                               };
            return feedItem;
        }

        public static string TrimToLength(this string s, int length)
        {
            return s.Length <= length ? s : s.Substring(0, length);
        }
    }
}