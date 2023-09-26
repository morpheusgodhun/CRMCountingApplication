using EasyTracking.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using EasyTracking.Views;

namespace EasyTracking.ViewModels {

    public class ExitApprovalsViewModel : BaseViewModel<ExitApproval> {

        #region Constructors
        public ExitApprovalsViewModel() {
            Title = "Tesisten Çıkış";
            Items = new ObservableCollection<ExitApproval>();

            LoadItemsCommnad = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemCommand = new Command<ExitApproval>(OnUpdate);
        }
        #endregion

        #region Properties
        public ObservableCollection<ExitApproval> Items { get; }

        public Command LoadItemsCommnad { get; }

        public Command<ExitApproval> LoadItemCommand { get; }
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

        private async void OnUpdate(ExitApproval item) {
            if (item == null) return;
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ExitApprovalPage)}?{nameof(ExitApprovalViewModel.ItemId)}={item.Id}");
        }

        public void OnAppearing() {
            IsBusy = true;
        }
        #endregion

    }
}