using Xamarin.Forms;

namespace EasyTracking.ViewModels {
    public class AppShellViewModel : BaseViewModel {


        #region Constructors
        public AppShellViewModel() {
            MessagingCenter.Subscribe<LoginViewModel, bool>(this, message: "login", (sender, arg) => {
                IsLoginVehicle = arg;
            });

            MessagingCenter.Subscribe<LoginViewModel, bool>(this, message: "exit", (sender, arg) => {
                IsExitVehicle = arg;
            });
        }
        #endregion

        #region Variables
        private bool isLoginVehicle;
        private bool isExitVehicle;
        #endregion

        #region Properties
        public bool IsLoginVehicle {
            get => isLoginVehicle;
            set => SetProperty(ref isLoginVehicle, value);
        }

        public bool IsExitVehicle {
            get => isExitVehicle;
            set => SetProperty(ref isExitVehicle, value);
        }
        #endregion

    }
}