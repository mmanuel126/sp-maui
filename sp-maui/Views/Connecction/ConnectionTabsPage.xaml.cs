

using sp_mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace sp_mobile.Views
{
    public partial class ConnectionTabsPage : ContentPage
    {
        ConnectionTabsViewModel model = new ConnectionTabsViewModel();
        public ConnectionTabsPage()
        {
            InitializeComponent();
            this.BindingContext = model;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

        }

    }

    
}
