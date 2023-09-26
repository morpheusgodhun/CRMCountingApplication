using System;
using Xamarin.Forms;
using EasyTracking.Views;

namespace EasyTracking {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginApprovalPage), typeof(LoginApprovalPage));
            Routing.RegisterRoute(nameof(ExitApprovalPage), typeof(ExitApprovalPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e) {
            await Current.GoToAsync("//LoginPage");
        }
    }
}