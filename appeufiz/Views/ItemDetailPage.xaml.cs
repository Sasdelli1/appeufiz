using appeufiz.Data;
using appeufiz.Models;
using appeufiz.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace appeufiz.Views
{
    public partial class ItemDetailPage : ContentPage
    {

        async private void btnNovo_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("NewLembretePage");
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}