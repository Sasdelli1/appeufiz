using appeufiz.Data;
using appeufiz.Models;
using appeufiz.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace appeufiz.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        async protected void RegisterLembrete()
        {

            Lembrete olembrete = new Lembrete();

            olembrete.Id = Guid.NewGuid().ToString();
            olembrete.Nome = nome.Text;


            using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
            {
                conexao.Insert(olembrete);
            }

            await DisplayAlert("", "Lembrete salvo com sucesso!", "Ok");
            await Shell.Current.GoToAsync("//LoginPage");
        }

        protected void LoadNote(string itemId)
        {

            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
                {

                    List<Lembrete> lembretes = conexao.Table<Lembrete>().ToList();

                }
            
            }
            catch (Exception)
            {
                Console.WriteLine("Falha ao carregar lembrete.");
            }
        }


        async private void btnNovo_Clicked(object sender, System.EventArgs e)
        {
            string result = await DisplayPromptAsync("Novo lembrete", " ");
            lblLembrete1.Text = result;
            // inserir no banco de dados

        }

    }
}