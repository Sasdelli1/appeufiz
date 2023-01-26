using appeufiz.Data;
using appeufiz.ViewModels;
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
    public partial class LoginPage : ContentPage
    {

        Database database = new Database();
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            if (!database.ValidEufiz())
            {
                Shell.Current.GoToAsync("RegisterPage");
            }
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterPage");
        } 

        private async void Button_Clicked(object sender, EventArgs e)
        {

            dbUser dbuser = new dbUser();


            //if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            try
            {
                if (dbuser.Logon(txtUsername.Text, txtPassword.Text))
                {

                    await Shell.Current.GoToAsync("//main");
                }
                else
                {
                    await DisplayAlert("Ops...", "O usuario ou a senha está incorreta!", "Ok");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Ops...", "O usuario ou a senha está incorreta!" + ex.Message.ToString(), "Ok");
            }

        }
    }
}