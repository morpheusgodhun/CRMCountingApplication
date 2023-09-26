using Acr.UserDialogs;
using System.Threading.Tasks;
using System;
using EasyTracking.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        
        public LoginPage() {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }


        private async void Loading_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Lütfen Bekleyiniz...");
            await Navigation.PushAsync(new SelectionPage());

            await Task.Delay(2000);

            UserDialogs.Instance.HideLoading();
        }
    }
}