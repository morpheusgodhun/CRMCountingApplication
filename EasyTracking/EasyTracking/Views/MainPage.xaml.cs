using EasyTracking.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage {

        ZXingScannerPage scanPage;
        MainViewModel viewModel;

        public MainPage() {
            InitializeComponent();
            viewModel = new MainViewModel();
            BindingContext = viewModel;
        }

        private void ButtonScanDefault_Clicked(object sender, EventArgs e) {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "Ok");
                    BarcodeLabel.Text = "Okunan Barkod: " + result.Text;

                    viewModel.UpdateData();
                });
            };
            Navigation.PushAsync(scanPage);
        }
    }
}
