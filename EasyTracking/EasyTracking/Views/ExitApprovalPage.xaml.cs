using EasyTracking.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTracking.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExitApprovalPage : ContentPage {
        public ExitApprovalPage() {
            InitializeComponent();
            BindingContext = new ExitApprovalViewModel();
        }
    }
}