using EasyTracking.Views;
using System;
using Xamarin.Forms;

namespace EasyTracking.ViewModels {
    public class MainViewModel : BaseViewModel {

        #region Constructors
        public MainViewModel() {
            Title = "Barkod Anasayfa";

            isLoginVehicle = GlobalModule.MainMenu.IsLoginVehicle;
            isExitVehicle = GlobalModule.MainMenu.IsExitVehicle;
            fullName = GlobalModule.MainMenu.FullName;
            appMessage = GlobalModule.MainMenu.AppMessage;

            MessagingCenter.Subscribe<LoginViewModel, bool>(this, message: "islogin", (sender, arg)
                => { IsLoginVehicle = arg; });

            MessagingCenter.Subscribe<LoginViewModel, bool>(this, message: "isexit", (sender, arg)
                => { IsExitVehicle = arg; });

            MessagingCenter.Subscribe<LoginViewModel, string>(this, message: "fullname", (sender, arg)
                => { FullName = arg; });

            MessagingCenter.Subscribe<LoginViewModel, string>(this, message: "appmessage", (sender, arg)
                => { AppMessage = arg; });

            LoginVehicleCommand = new Command(OnLoginVehiclesClicked);
            ExitVehicleCommand = new Command(OnExitVehiclesClicked);

            var emptyData = new EmptyData();
            CustomerName = emptyData.CustomerName;
            LoaderName = emptyData.LoaderName;
            RegisterDate = emptyData.RegisterDate;
            SummaryStatementNumber = emptyData.SummaryStatementNumber;
            AntrepoNumber = emptyData.AntrepoNumber;
            ContainerNumber = emptyData.ContainerNumber;
            GoodsNumber = emptyData.GoodsNumber;
            Genus = emptyData.Genus;
            Weight = emptyData.Weight;
            RequiredCount = emptyData.RequiredCount;
            Count = emptyData.Count;

        }
        #endregion

        #region Variables
        private bool isLoginVehicle = false;
        private bool isExitVehicle = false;
        private string fullName;
        private string appMessage;
        #endregion

        #region Properties
        public Command LoginVehicleCommand {
            get;
        }

        public Command ExitVehicleCommand {
            get;
        }

        public bool IsLoginVehicle {
            get {
                return isLoginVehicle;
            }
            set {
                SetProperty(ref isLoginVehicle, value);
            }
        }

        public bool IsExitVehicle {
            get {
                return isExitVehicle;
            }
            set {
                SetProperty(ref isExitVehicle, value);
            }
        }

        public string FullName {
            get {
                return fullName;
            }
            set {
                SetProperty(ref fullName, value);
            }
        }

        public string AppMessage {
            get => appMessage;
            set => SetProperty(ref appMessage, value);
        }

        public void UpdateData() {
            CustomerName = "Varmat Makine";
            LoaderName = "Printing Graphic Machinery";
            RegisterDate = DateTime.Now;
            SummaryStatementNumber = "TESTSTATEMANETNUMBER";
            AntrepoNumber = 23823829138129;
            ContainerNumber = "TEST Konteyner No";
            GoodsNumber = "TEST YENI Mallar ";
            Genus = "TEST Yeni Cins MAKINA";
            Weight = 40;

            // Verileri güncelledikten sonra PropertyChanged olayını tetikleyin
            OnPropertyChanged(nameof(CustomerName));
            OnPropertyChanged(nameof(LoaderName));
            OnPropertyChanged(nameof(RegisterDate));
            OnPropertyChanged(nameof(SummaryStatementNumber));
            OnPropertyChanged(nameof(AntrepoNumber));
            OnPropertyChanged(nameof(ContainerNumber));
            OnPropertyChanged(nameof(GoodsNumber));
            OnPropertyChanged(nameof(Genus));
            OnPropertyChanged(nameof(RequiredCount));
            OnPropertyChanged(nameof(Count));
        }


        public string CustomerName { get; set; }
        public string LoaderName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string SummaryStatementNumber { get; set; }
        public long AntrepoNumber { get; set; }
        public string ContainerNumber { get; set; }
        public string GoodsNumber { get; set; }
        public string Genus { get; set; }
        public int Weight { get; set; }
        public int RequiredCount { get; set; }
        public int Count { get; set; }
        #endregion

        #region CommandMethods
        private async void OnLoginVehiclesClicked(object obj) {
            await Shell.Current.Navigation.PushAsync(new LoginApprovalsPage());
        }

        private async void OnExitVehiclesClicked(object obj) {
            await Shell.Current.Navigation.PushAsync(new ExitApprovalsPage());
        }
    }
    #endregion

}
