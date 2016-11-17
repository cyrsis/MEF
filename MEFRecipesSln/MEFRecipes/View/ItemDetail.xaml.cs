using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using MEFRecipes.ViewModel;

namespace MEFRecipes.View
{
    [Export("Detail",typeof(ChildWindow))]
    public partial class ItemDetail
    {
        [Import]
        public MainViewModel ViewModel { get; set; }

        public ItemDetail()
        {
            InitializeComponent();

            if (!DesignerProperties.IsInDesignTool)
            {
                Loaded += new RoutedEventHandler(ItemDetail_Loaded);
            }
        }

        void ItemDetail_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModel.SelectedFeedItem;
            Title = ViewModel.SelectedFeedItem.PostedDate.ToString();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }      
    }
}

