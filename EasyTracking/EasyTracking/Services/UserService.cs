using System;
using EasyTracking.Models;
using System.Threading.Tasks;
using EasyTracking.Datas.Users;

namespace EasyTracking.Services {
    public class UserService : IUserService {

        #region Constructors
        public UserService(string token = "") {
            service = new HttpApiService(token);
        }
        #endregion

        #region Variables
        private bool _disposed;
        private IHttpApiService service;
        #endregion

        #region Public Methods
        public async Task<User> GetUser(string userName, string password) {
            var user = new User();
            try {
                var request = new UserRequest(userName, password);
                var response = await service.PostAsync<UserRequest, UserResponse>("Authentication/Login", request);
                if (response != null) {
                    if (response.Success) {
                        var getUser = response?.Data?.Token?.User;
                        if (getUser != null) {
                            user.AddUser(getUser.Id, string.Concat(getUser.FirstName, " ", getUser.LastName), response.Data.Token.AccessToken);
                        }
                        getUser = null;
                    }
                    else {
                        user.SetDescription(response.Message);
                    }
                    response = null;
                }
                request = null;
            } catch (Exception ex) {
                user.SetDescription(ex.Message);
            }

            return user;
        }

        public async Task<MainMenu> GetMainMenu(int userId) {
            var mainMenu = new MainMenu();
            try {
                service.AddHeader("x-requestuserid", userId.ToString());
                var response = await service.GetAsync<UserMainMenuResponse>("AdminAuth/AdminMainMenu");
                if (response != null) {
                    if (response.Success) {
                        if (response.UserMainMenus != null) {
                            var mainItem = response.UserMainMenus.Find(f => f.Id == 3002);
                            if (mainItem != null) {
                                mainMenu.IsLoginVehicle = mainItem.IsUpdate;
                            }

                            mainItem = response.UserMainMenus.Find(f => f.Id == 3006);
                            if (mainItem != null) {
                                mainMenu.IsExitVehicle = mainItem.IsUpdate;
                            }
                            mainItem = null;
                        }
                    }
                    else {
                        mainMenu.AppMessage = response.Message;
                    }
                    response = null;
                }
            } catch (Exception ex) {
                mainMenu.AppMessage = ex.Message;
            }
            return mainMenu;
        }
        #endregion

        #region IDisposable Support
        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    service?.Dispose();
                    service = null;
                }
                _disposed = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~UserService() {
            Dispose(disposing: false);
        }
        #endregion

    }
}