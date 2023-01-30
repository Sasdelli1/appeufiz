using appeufiz.Models;
using appeufiz.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace appeufiz.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        async private void btnNovo_Clicked(object sender, System.EventArgs e)
        {
            string result = await DisplayPromptAsync("Novo lembrete", " ");
            lblLembrete1.Text = result;
            // inserir no banco de dados

        }

    }
}