using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using MEFRecipes.Contracts;
using MEFRecipes.Model;

namespace MEFRecipes.Process
{
    [ExportMetadata("Mode","Live")]
    [Export(typeof(IFetchData))]
    public class LiveProcessor : IFetchData 
    {
        [Import(AllowDefault = true,AllowRecomposition = true)]
        public IConfiguration Config { get; set; }

        public void FetchData(Action<IEnumerable> list, Action<string> data)
        {
            var request = new WebClient();

            request.DownloadStringCompleted += (o, e) =>
                                                   {
                                                       var items = new List<FeedItem>();
                                                       data(e.Result);
                using (var reader = new StringReader(e.Result))
                {
                    using (var xmlReader = XmlReader.Create(reader))
                    {
                        var feed = SyndicationFeed.Load(xmlReader);
                        items.AddRange(feed.Items.Select(item => item.AsFeedItem()));
                        list(items);
                    }
                }
            };
            request.DownloadStringAsync(Config.FeedUri);
        }
    }
}