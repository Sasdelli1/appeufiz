using appeufiz.Models;
using appeufiz.Services;
using appeufiz.ViewModels;
using appeufiz.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appeufiz.Views
{
    public partial class ItemsPage : ContentPage
    {
 

        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

    

            BindingContext = _viewModel = new ItemsViewModel();


            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        
        }

    }
}