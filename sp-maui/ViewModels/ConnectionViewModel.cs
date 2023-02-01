
using System;
using sp_mobile.Services;
using sp_mobile.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using sp_mobile;

namespace sp_mobile.ViewModels
{
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        public ICommand RefreshCommand { get; set; }
        public Command <ContactsModel> DropCommand { get; set; }

        async private void OnRefreshCommandExecuted() => await DoRefresh();
        
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;

            set
            {
                isRefreshing = value;

                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        List<ContactsModel> _Connections;
        public List<ContactsModel> Connections
        {
            get
            {
                return _Connections;
            }
            set
            {
                _Connections = value;
                OnPropertyChanged();
            }
        }

        async Task DoRefresh()
        {
            Connections.Clear();
            Connections = new List<ContactsModel>();
            IsRefreshing = true;
            this.Connections = await this.GetMyConnections();
            IsRefreshing = false;
        }

        private ContactsModel _connectionsSvc;

        public ConnectionViewModel()
        {
            DropCommand = new  Xamarin.Forms.Command<ContactsModel>  (OnDropConnection);
            RefreshCommand = new Xamarin.Forms.Command (OnRefreshCommandExecuted);
            _connectionsSvc = new ContactsModel();
            Connections = new List<ContactsModel>();
            GetConnectionsAsync();
            
        }

        async void OnDropConnection(ContactsModel contacts)
        {
            await DeleteConnection(contacts.connectionID);
            await DoRefresh();
        }


        async Task GetConnectionsAsync()
        {
            string jwtToken = Application.Current.Properties["AccessToken"].ToString();
            List<ContactsModel> rn = await GetMyConnections();
            Connections = rn;
        }

        public async Task DeleteConnection(string connectionID)
        {
            Connections svc = new Connections();
            string jwtToken = Application.Current.Properties["AccessToken"].ToString();
            int memberID = 0;
            if (Application.Current.Properties["UserID"].ToString() != null)
                memberID = Convert.ToInt32(Application.Current.Properties["UserID"].ToString());

            await svc.DeleteConnection (memberID.ToString(),connectionID, jwtToken);

        }

        public async Task<List<ContactsModel>> GetMyConnections()
        {
            Connections svc = new Connections();
            string jwtToken = Application.Current.Properties["AccessToken"].ToString();
            int memberID = 0;
            if (Application.Current.Properties["UserID"].ToString() != null)
                memberID = Convert.ToInt32(Application.Current.Properties["UserID"].ToString());

            List<ContactsModel> result = await svc.GetMyConnections (memberID.ToString(), jwtToken);


            var myConnectionList = new ObservableCollection<Conversation>();

            if (result != null)
            {
                //Conversation conv = new Conversation();
                int  i = 0;
                foreach (var r in result)
                {
                    string img = App.AppSettings.AppImagesURL + "images/members/default.png";
                    if (r.picturePath != null || r.picturePath != "")
                    {
                        img = App.AppSettings.AppImagesURL + "images/members/" + r.picturePath;
                    }
                    result[i].picturePath = img;

                    if (r.titleDesc == null || r.titleDesc=="")
                    {
                        result[i].titleDesc = "Unknown Title";
                    }

                    i++;
                }
            }

            return result;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
