using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace appeufiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLembretePage : ContentPage
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";

        public NewLembretePage()
        {
            InitializeComponent();
        }

        async protected void RegisterLembrete()
        {

            Lembrete olembrete = new Lembrete();

            olembrete.Id = Guid.NewGuid().ToString();
            olembrete.Nome = entryLembrete.Text;


            using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
            {
                conexao.Insert(olembrete);
            }

            await DisplayAlert("", "Lembrete salvo com sucesso!", "Ok");
            await Shell.Current.GoToAsync("//main");
        }

        //protected void LoadNote(string itemId)
        //{

        //    try
        //    {
        //        using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
        //        {

        //            List<Lembrete> lembretes = conexao.Table<Lembrete>().ToList();

        //        }

        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Falha ao carregar lembrete.");
        //    }
        //}

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            RegisterLembrete();
        }
    }
}