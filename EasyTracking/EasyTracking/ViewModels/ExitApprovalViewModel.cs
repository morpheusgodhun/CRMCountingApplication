using EasyTracking.Models;
using EasyTracking.Services;
using System.Diagnostics;
using System;
using Xamarin.Forms;

namespace EasyTracking.ViewModels {

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ExitApprovalViewModel : BaseDetailModel<ExitApprovalConfirm> {

        #region Constructors
        public ExitApprovalViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        #endregion

        #region Variables
        private IConstantService constantService;
        private DateTime date;
        private long itemId;
        private string text;
        private string description;
        private string processTypeName;
        private string sealNumber;
        private DateTime confirmDate;
        private TimeSpan confirmTime;
        #endregion

        #region Properties
        private long Id { get; set; }

        public long ItemId {
            get {
                return itemId;
            }
            set {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        public DateTime ConfirmDate {
            get => confirmDate;
            set => SetProperty(ref confirmDate, value);
        }

        public TimeSpan ConfirmTime {
            get => confirmTime;
            set => SetProperty(ref confirmTime, value);
        }

        public string Text {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ProcessTypeName {
            get => processTypeName;
            set => SetProperty(ref processTypeName, value);
        }

        public string SealNumber {
            get => sealNumber;
            set => SetProperty(ref sealNumber, value);
        }
        #endregion

        #region Methods
        private async void GetServeDateTime() {
            constantService = new ConstantService(GlobalModule.User.Token);
            date = await constantService.GetDateTime();
            constantService.Dispose();
            constantService = null;
            ConfirmDate = date;
            ConfirmTime = new TimeSpan(date.Hour, date.Minute, date.Second);
        }
        #endregion

        #region UserMethods
        public async void LoadItemId(long itemId) {
            try {
                Id = itemId;
                GetServeDateTime();
                var item = await DetailStore.GetItemAsync(itemId);
                if (item != null) {
                    Text = item.Text;
                    Description = item.Description;
                    ProcessTypeName = item.ProcessTypeName;
                    SealNumber = item.SealNumber;
                }
            } catch (Exception) {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private bool ValidateSave() {
            return !string.IsNullOrWhiteSpace(text)
                && !string.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel() {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave() {
            try {
                date = new DateTime(ConfirmDate.Date.Year, ConfirmDate.Date.Month, ConfirmDate.Date.Day, ConfirmTime.Hours, ConfirmTime.Minutes, ConfirmTime.Seconds);
                var result = await DetailStore.UpdateItemAsync(Id, date, GlobalModule.User.Id);
                if (result)
                    await Shell.Current.GoToAsync("..");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

    }
}