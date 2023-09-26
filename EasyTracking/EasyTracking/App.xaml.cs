using EasyTracking.Services;
using Xamarin.Forms;

namespace EasyTracking {
    public partial class App : Application {

        public App() {
            InitializeComponent();
            DependencyService.Register<LoginApprovalStore>();
            DependencyService.Register<LoginApprovalConfirmStore>();
            DependencyService.Register<ExitApprovalStore>();
            DependencyService.Register<ExitApprovalConfirmStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}