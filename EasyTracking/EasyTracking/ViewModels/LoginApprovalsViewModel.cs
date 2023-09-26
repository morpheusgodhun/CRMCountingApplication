using EasyTracking.Models;
using EasyTracking.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyTracking.ViewModels {
    public class LoginApprovalsViewModel : BaseViewModel<LoginApproval> {

        #region Constructors
        public LoginApprovalsViewModel() {
            Title = "Test Menu";
            Items = new ObservableCollection<LoginApproval>();

            LoadItemsCommnad = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemCommand = new Command<LoginApproval>(OnUpdate);
        }
        #endregion

        #region Properties
        public ObservableCollection<LoginApproval> Items { get; }

        public Command LoadItemsCommnad { get; }

        public Command<LoginApproval> LoadItemCommand { get; }
        #endregion

        #region Methods
        private async Task ExecuteLoadItemsCommand() {

            IsBusy = true;
            try {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) {
                    Items.Add(item);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }

        private async void OnUpdate(LoginApproval item) {
            if (item == null) return;
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(LoginApprovalPage)}?{nameof(LoginApprovalViewModel.ItemId)}={item.Id}");
        }

        public void OnAppearing() {
            IsBusy = true;
        }
        #endregion

    }
}