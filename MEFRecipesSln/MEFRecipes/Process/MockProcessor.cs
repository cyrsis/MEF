using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.Syndication;
using MEFRecipes.Contracts;
using MEFRecipes.Model;

namespace MEFRecipes.Process
{
    [ExportMetadata("Mode","Mock")]
    [Export(typeof(IFetchData))]
    public class MockProcessor : IFetchData 
    {
        public void FetchData(Action<IEnumerable> list, Action<string> data)
        {
            var items = new List<FeedItem>();
            for (var x = 0; x < 20; x++)
            {
                var item = new SyndicationItem(string.Format("Sample item {0}", x + 1),
                                               "This is some sample feed content",
                                               new Uri("http://feeds.feedburner.com/CsharperImage", UriKind.Absolute))
                {
                    PublishDate = DateTime.Now.AddMinutes(-1 * x)
                };
                item.Links.Add(new SyndicationLink(new Uri("http://feeds.feedburner.com/CsharperImage", UriKind.Absolute)));
                items.Add(item.AsFeedItem());
            }
            data("<xml/>");
            list(items);
        }
    }
}