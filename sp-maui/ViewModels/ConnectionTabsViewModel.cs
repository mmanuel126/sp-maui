﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using sp_mobile.Views;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;


namespace sp_mobile.ViewModels
{
    public class ConnectionTabsViewModel : INotifyPropertyChanged
    {
        private TabItemCollection items;
        public event PropertyChangedEventHandler PropertyChanged;
        public TabItemCollection Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ConnectionTabsViewModel()
        {
            SetItems();

        }
        internal void SetItems()
        {
            Items = new TabItemCollection();
            ConnectionPage page1 = new ConnectionPage();
            ConnectionRequestPage page2 = new ConnectionRequestPage();
           // TabViewItemPage3 page3 = new TabViewItemPage3();
           // TabViewItemPage4 page4 = new TabViewItemPage4();
            Items.Add(new SfTabItem { Content = page1.Content, Title = "My Connections" });
            Items.Add(new SfTabItem { Content = page2.Content, Title = "Requests" });
          //  Items.Add(new SfTabItem { Content = page3.Content, Title = "Page3" });
          //  Items.Add(new SfTabItem { Content = page4.Content, Title = "Page4" });

        }


    }
}
