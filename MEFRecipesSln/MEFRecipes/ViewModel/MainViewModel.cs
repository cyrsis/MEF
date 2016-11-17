using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using MEFRecipes.Contracts;
using MEFRecipes.Model;

namespace MEFRecipes.ViewModel
{
    [Export]
    public class MainViewModel : IPartImportsSatisfiedNotification, INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<FeedItem>();

            if (!DesignerProperties.IsInDesignTool)
            {
                return;
            }

            for (var x = 0; x < 20; x++)
            {
                var item = new SyndicationItem(string.Format("Sample item {0}", x + 1),
                                               "This is some sample feed content",
                                               new Uri("http://feeds.feedburner.com/CsharperImage", UriKind.Absolute))
                               {
                                   PublishDate = DateTime.Now.AddMinutes(-1*x)
                               };
                item.Links.Add(new SyndicationLink(new Uri("http://feeds.feedburner.com/CsharperImage", UriKind.Absolute)));
                Items.Add(item.AsFeedItem());
            }
        }

        [ImportMany]
        public Lazy<IFetchData, IDictionary<string, object>>[] Processors { get; set; }

        private IFetchData Processor
        {
            get
            {
                var processorMef = (from p in Processors
                                    where p.Metadata.ContainsKey("Mode") &&
                                          p.Metadata["Mode"].Equals(Config.Mode) 
                                    select p).FirstOrDefault();
                return processorMef.Value;
            }
        }

        [Export("Xml")]
        public string Xml { get; private set; }

        public ObservableCollection<FeedItem> Items { get; private set; }

        [Import]
        public IDetailWindow DetailWindow { get; set; }

        private FeedItem _selectedFeedItem;
        public FeedItem SelectedFeedItem
        {
            get { return _selectedFeedItem; }
            set
            {
                if (ReferenceEquals(_selectedFeedItem, value)) return;

                _selectedFeedItem = value;

                var handler = PropertyChanged;

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("SelectedFeedItem"));
                }

                if (value != null)
                {
                    DetailWindow.Open();
                }
            }
        }


        [Import(AllowDefault=true,AllowRecomposition = true)]
        public IConfiguration Config { get; set; }

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            if (Items.Count > 0 || Config == null)
            {
                return;
            }

            Processor.FetchData(list=>
                                    {
                                        var listToProcess = (IEnumerable<FeedItem>) list;
                                        foreach(var item in listToProcess)
                                        {
                                            Items.Add(item);
                                        }
                                    },
                                    data=>Xml=data);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}