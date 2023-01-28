using appeufiz.Data;
using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appeufiz.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";
        public RegisterPage ()
		{
			InitializeComponent ();
        }

		async protected void Register()
		{
            dbUser odbUser = new dbUser(); 
			Usuario oUsuario = new Usuario();

			oUsuario.Id = Guid.NewGuid().ToString();
			oUsuario.Nome = nome.Text;
            oUsuario.NomeUsuario = usuario.Text.ToUpper();
			oUsuario.Email = email.Text;
			oUsuario.Telefone = telefone.Text;
			oUsuario.Senha = senha.Text;
			oUsuario.Status = true;
			oUsuario.Messagem = "";

            using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
            {
                conexao.Insert(oUsuario);
            }

			await DisplayAlert("", "Usuario criado com sucesso!", "Ok");
            await Shell.Current.GoToAsync("//LoginPage");
        }

		private void RegisterUser(object sender, EventArgs e)
		{

			if (senha.Text == confSenha.Text)
			{
                Register();
            }
			else
			{
                DisplayAlert("Ops...", "As senhas digitadas estão diferentes", "Tentar novamente");
            }

        }
	}
}