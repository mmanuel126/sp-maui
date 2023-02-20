using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using sp_maui.Models;
using sp_maui.ViewModels;

namespace sp_maui.Views.Connection
{
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage()
        {
            InitializeComponent(); 
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
/*            this.collectionView.SelectedItem = null;
            if (e.CurrentSelection.Count == 0)
                return;
            var current = e.CurrentSelection; 
            ContactsModel nm = (ContactsModel)current[0];
            
           Preferences.Set("ProfileID",nm.connectionID);
            Preferences.Set("ProfileName", nm.friendName);
            Preferences.Set("ProfileTitle", nm.titleDesc);
            Preferences.Set("ProfileImage", nm.picturePath);
           
            await Shell.Current.GoToAsync("profile"); */
        } 
    }

    
}
