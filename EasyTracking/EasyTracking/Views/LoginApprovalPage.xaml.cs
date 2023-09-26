using EasyTracking.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginApprovalPage : ContentPage {
        public LoginApprovalPage() {
            InitializeComponent();
            BindingContext = new LoginApprovalViewModel();
        }
    }
}