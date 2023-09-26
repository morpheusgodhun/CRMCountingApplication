using EasyTracking.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace EasyTracking.Views {
    public partial class SelectionPage : ContentPage {
        public SelectionPage() {
            InitializeComponent();
            viewModel = new SelectionViewModel();
            BindingContext = viewModel;
        }

        ZXingScannerPage scanPage;
        SelectionViewModel viewModel;


        private void ButtonScanDefault_Clicked(object sender, EventArgs e) {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "Ok");
                    BarcodeLabel.Text = "Okunan Barkod: " + result.Text;
                    viewModel.Count++;
                    //her okutulduğunda +1 sayılan barkoda yani count'a yazılacak
                });
            };
            Navigation.PushAsync(scanPage);
        }
    }
}
