using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appeufiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        async private void btnAltSenha_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AccountPage/PasswordPage");
        }

        private void btnAltDados_Clicked(object sender, EventArgs e)
        {
            switch (btnAltDados.Text)
            {
                case "Salvar dados":
                    DBUsuario.IsEnabled = false;
                    DBNome.IsEnabled = false;
                    DBEmail.IsEnabled = false;
                    DBTelefone.IsEnabled = false;
                    btnAltDados.Text = "Alterar dados";
                    break;
                case "Alterar dados":
                    DBUsuario.IsEnabled = true;
                    DBNome.IsEnabled = true;
                    DBEmail.IsEnabled = true;
                    DBTelefone.IsEnabled = true;
                    btnAltDados.Text = "Salvar dados";
                    break;
                default:
                    DBUsuario.IsEnabled = false;
                    DBNome.IsEnabled = false;
                    DBEmail.IsEnabled = false;
                    DBTelefone.IsEnabled = false;
                    break;
            }
        }
    }
}