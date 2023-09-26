using EasyTracking.Models;
using EasyTracking.Services;
using EasyTracking.Views;
using System;
using Xamarin.Forms;

namespace EasyTracking.ViewModels {
    public class LoginViewModel : BaseViewModel<UserItem> {

        #region Constructors
        public LoginViewModel() {
            LoginCommand = new Command(OnLogin, ValidateLogin);
            PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }
        #endregion

        #region Varibales
        private string userName;
        private string password;
        private string description;
        private IUserService service;
        #endregion

        #region Properties
        public string UserName {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password {
            get => password;
            set => SetProperty(ref password, value);
        }

        private bool ValidateLogin() {
            return !string.IsNullOrWhiteSpace(userName)
                && !string.IsNullOrWhiteSpace(password);
        }

        public Command LoginCommand {
            get;
        }

        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }
        #endregion

        #region Command Methods
        private async void OnPage() {
            service = new UserService(GlobalModule.User.Token);
            var mainMenu = await service.GetMainMenu(GlobalModule.User.Id);
            service.Dispose();
            service = null;

            if (mainMenu != null) {
                mainMenu.FullName = GlobalModule.User.FullName;

                if (!mainMenu.IsLoginVehicle && !mainMenu.IsExitVehicle)
                    if (string.IsNullOrEmpty(mainMenu.AppMessage))
                        mainMenu.AppMessage = "sistemi kullanma yetkiniz bulunmuyor.";

                GlobalModule.MainMenu = mainMenu;

                MessagingCenter.Send(this, "login", mainMenu.IsLoginVehicle);
                MessagingCenter.Send(this, "exit", mainMenu.IsExitVehicle);

                MessagingCenter.Send(this, "islogin", mainMenu.IsLoginVehicle);
                MessagingCenter.Send(this, "isexit", mainMenu.IsExitVehicle);

                MessagingCenter.Send(this, "fullname", GlobalModule.User.FullName);
                MessagingCenter.Send(this, "appmessage", mainMenu.AppMessage);

                await Shell.Current.GoToAsync($"//{nameof(SelectionPage)}");
            }
        }

        private async void OnLogin() {
            try {
                service = new UserService();
                var user = await service.GetUser(UserName, Password);
                service.Dispose();
                service = null;

                if (user != null) {
                    if (user.Id > 0) {
                        GlobalModule.User = user;
                        OnPage();
                    }
                    else {
                        Description = user.Description;
                    }
                }
                else {
                    Description = "Hata oluştu.";
                }
            } catch (Exception ex) {
                Description = ex.Message;
            }
        }
        #endregion

    }
}