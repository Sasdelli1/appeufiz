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

        [QueryProperty(nameof(Models.Lembrete), nameof(Models.Lembrete))]
        public partial class LembreteDetailPage : ContentPage
        {
            public string Lembrete
            {
                set
                {
          //          LoadLembrete(value);
                }
            }

            public LembreteDetailPage()
            {
//                InitializeComponent();

                // Set the BindingContext of the page to a new Note.
                BindingContext = new Lembrete();
            }
        

            async void OnSaveButtonClicked(object sender, EventArgs e)
            {
                var note = (Lembrete)BindingContext;
              //  note.Date = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(note.Nome))
                {
                //    await App.Database.SaveLembreteAsync(note);
                }

                // Navigate backwards
                await Shell.Current.GoToAsync("..");
            }

            async void OnDeleteButtonClicked(object sender, EventArgs e)
            {
                var note = (Lembrete)BindingContext;
               // await App.Database.DeleteLembreteAsync(note);

                // Navigate backwards
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}