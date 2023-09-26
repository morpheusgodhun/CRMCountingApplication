using EasyTracking.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginApprovalsPage : ContentPage {
        public LoginApprovalsPage() {
            InitializeComponent();
            BindingContext = _viewModel = new LoginApprovalsViewModel();
        }

        readonly LoginApprovalsViewModel _viewModel;


        protected override void OnAppearing() {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}