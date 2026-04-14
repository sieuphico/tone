using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TabViewApp.Views
{
    public class TabItemModel
    {
        public string HeaderText { get; set; }
        public string ContentText { get; set; }
    }

    public partial class MainPage : Page
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            Tabs = new ObservableCollection<TabItemModel>
            {
                new TabItemModel { HeaderText = "Tab 1", ContentText = "tab 1" },
                new TabItemModel { HeaderText = "Tab 2", ContentText = "tab 2" },
                new TabItemModel { HeaderText = "Tab 3 Long Text", ContentText = "tab 3" },
                new TabItemModel { HeaderText = "Tab 4 Needs Ellipsis Very Long Text To Test", ContentText = "tab 4" },
                new TabItemModel { HeaderText = "Tab 5", ContentText = "tab 5" }
            };
        }

        private void OnStyleRadioChecked(object sender, RoutedEventArgs e)
        {
            if (MyTabView == null) return;

            var radio = sender as RadioButton;
            var tag = radio?.Tag?.ToString();

            if (tag == "FullStyle")
            {
                MyTabView.TabWidthMode = TabViewWidthMode.Equal;
                MyTabView.TabItemTemplate = (DataTemplate)Resources["TabTemplateWithBadge"];
            }
            else if (tag == "FlexStyle")
            {
                MyTabView.TabWidthMode = TabViewWidthMode.SizeToContent;
                MyTabView.TabItemTemplate = (DataTemplate)Resources["TabTemplateWithBadge"];
            }
            else if (tag == "NoBadge")
            {
                MyTabView.TabWidthMode = TabViewWidthMode.Equal;
                MyTabView.TabItemTemplate = (DataTemplate)Resources["TabTemplateNoBadge"];
            }
        }
        
        private void MyTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyTabView.SelectedItem is TabItemModel selectedTab)
            {
                MainContentText.Text = selectedTab.ContentText;
            }
        }
    }
}
