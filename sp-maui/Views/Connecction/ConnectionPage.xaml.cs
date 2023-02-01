using System;
using System.Collections.Generic;
using sp_mobile.Models;

using Xamarin.Forms;

namespace sp_mobile.Views
{
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage()
        {
            InitializeComponent();

        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.collectionView.SelectedItem = null;
            if (e.CurrentSelection.Count == 0)
                return;
            var current = e.CurrentSelection; 
            ContactsModel nm = (ContactsModel)current[0];
            
            Application.Current.Properties["ProfileID"] = nm.connectionID;
            Application.Current.Properties["ProfileName"] = nm.friendName;
            Application.Current.Properties["ProfileTitle"] = nm.titleDesc;
            Application.Current.Properties["ProfileImage"] = nm.picturePath;
           
            await Shell.Current.GoToAsync("profile");
        }
    }

    
}
