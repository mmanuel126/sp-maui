

using Microsoft.Maui.Controls.PlatformConfiguration;
using sp_maui.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace sp_maui.Views.Connection
{
    public partial class ConnectionTabsPage : ContentPage
    {
        ConnectionTabsViewModel model = new ConnectionTabsViewModel();

        public ConnectionTabsPage()
        {
            InitializeComponent();
            this.BindingContext = model;
            On<iOS>().SetUseSafeArea(true);

        }

    }

    
}
