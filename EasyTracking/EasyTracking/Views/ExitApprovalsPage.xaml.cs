using EasyTracking.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExitApprovalsPage : ContentPage {
        public ExitApprovalsPage() {
            InitializeComponent();
            BindingContext = _viewModel = new ExitApprovalsViewModel();
        }

        private readonly ExitApprovalsViewModel _viewModel;

        protected override void OnAppearing() {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}