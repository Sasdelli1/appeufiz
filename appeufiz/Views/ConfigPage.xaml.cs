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
    public partial class ConfigPage : ContentPage
    {
        public ConfigPage()
        {
            InitializeComponent();
        }

        async private void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        async private void btnBackup_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("BackupPage");
        }

        async private void btnConta_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AccountPage");
        }
    }
}
