using System;
using EasyTracking.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace EasyTracking.ViewModels {

    public class BaseViewModel : INotifyPropertyChanged {

        #region Variables
        private bool isBusy = false;
        private string title = string.Empty;
        private int userId;
        private string token;
        #endregion

        #region Properties
        public bool IsBusy {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Title {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public int UserId {
            get {
                return userId;
            }
            set {
                SetProperty(ref userId, value);
            }
        }

        public string Token {
            get => token;
            set => SetProperty(ref token, value);
        }
        #endregion

        #region SetPropertyMethods
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null) {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    public class BaseViewModel<T> : BaseViewModel {
        public IDataStore<T> DataStore
            => DependencyService.Get<IDataStore<T>>();
    }

    public class BaseDetailModel<T> : BaseViewModel {
        public IDetailStore<T> DetailStore 
            => DependencyService.Get<IDetailStore<T>>();
    }
}