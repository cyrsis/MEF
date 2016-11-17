using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;

namespace SilverlightMEF
{
    public partial class Body : IPartImportsSatisfiedNotification
    {
        [ImportMany("ListItem",AllowRecomposition = true)]
        public ObservableCollection<string> ListItems { get; set; }

        [Import]
        public ILaunchInterface LaunchInterface { get; set; }

        public Body()
        {
            InitializeComponent();
            if (DesignerProperties.IsInDesignTool)
            {
                ListItems = new ObservableCollection<string> {"Design Property 1", "Design Property 2"};
            }
            else
            {
                CompositionInitializer.SatisfyImports(this);
            }
            MainListBox.ItemsSource = ListItems;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LaunchInterface.Launch();
        }

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            MessageBox.Show("Imports Changed.");
        }
    }
}
