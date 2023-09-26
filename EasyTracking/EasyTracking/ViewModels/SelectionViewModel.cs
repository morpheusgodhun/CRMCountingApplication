using System;
using System.Collections.Generic;

namespace EasyTracking.ViewModels {
    public class SelectionViewModel : BaseViewModel {
        public SelectionViewModel() {
            Title = "Ürün Seç";
            FirmaId = 1; //varsayılan seçim 1
            UpdateOtherFields();
        }
        public List<SelectionItemBase> MyItems { get; set; } = new List<SelectionItemBase>
       {
                 new SelectionItemBase { FirmId = 1, CustomerName = "Penta Teknoloji",RequiredCount=20, Count=0,AntrepoNumber=1233456, ContainerNumber=7839858, Genus="Kalemlik", GoodsNumber=3, LoaderName="Test Firm", RegisterDate=DateTime.Now, SummaryStatementNumber=234123, Weight=250 },
                 new SelectionItemBase { FirmId = 2, CustomerName = "Ekol Kırtasiye",RequiredCount=30,Count=0, AntrepoNumber=1234256, ContainerNumber=7892858, Genus="Kalemlik", GoodsNumber=3, LoaderName="Test Firm", RegisterDate=DateTime.Now, SummaryStatementNumber=234123, Weight=250 },
                 new SelectionItemBase { FirmId = 3, CustomerName = "Teknosa", RequiredCount=40,Count=0,AntrepoNumber=1253456, ContainerNumber=7819858, Genus="Kalemlik", GoodsNumber=3, LoaderName="Test Firm", RegisterDate=DateTime.Now, SummaryStatementNumber=234123, Weight=250 },
                 new SelectionItemBase { FirmId = 4, CustomerName = "A Firm", RequiredCount=50,Count=0, AntrepoNumber=1234656, ContainerNumber=7898568, Genus="Kalemlik", GoodsNumber=3, LoaderName="Test Firm", RegisterDate=DateTime.Now, SummaryStatementNumber=234123, Weight=250 },
                 new SelectionItemBase { FirmId = 5, CustomerName = "B Firm", RequiredCount=60,Count=0, AntrepoNumber=1237456, ContainerNumber=7898858, Genus="Kalemlik", GoodsNumber=3, LoaderName="Test Firm", RegisterDate=DateTime.Now, SummaryStatementNumber=234123, Weight=250 },
            };
        private int _firmaId;
        public int FirmaId {
            get { return _firmaId; }
            set {
                if (_firmaId != value) {
                    _firmaId = value;
                    OnPropertyChanged(nameof(FirmaId));
                    UpdateOtherFields();
                }
            }
        }

        private string _customerName;
        public string CustomerName {
            get { return _customerName; }
            set {
                if (_customerName != value) {
                    _customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }
        private int _requiredcount;
        public int RequiredCount {
            get { return _requiredcount; }
            set {
                if (_requiredcount != value) {
                    _requiredcount = value;
                    OnPropertyChanged(nameof(RequiredCount));
                }
            }
        }
        private int _count;
        public int Count {
            get { return _count; }
            set {

                if (_count != value) {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }




        private string _loaderName;
        public string LoaderName {
            get { return _loaderName; }
            set {
                if (_loaderName != value) {
                    _loaderName = value;
                    OnPropertyChanged(nameof(LoaderName));
                }
            }
        }

        private DateTime _registerDate;
        public DateTime RegisterDate {
            get { return _registerDate; }
            set {
                if (_registerDate != value) {
                    _registerDate = value;
                    OnPropertyChanged(nameof(RegisterDate));
                }
            }
        }

        private int _summaryStatementNumber;
        public int SummaryStatementNumber {
            get { return _summaryStatementNumber; }
            set {
                if (_summaryStatementNumber != value) {
                    _summaryStatementNumber = value;
                    OnPropertyChanged(nameof(SummaryStatementNumber));
                }
            }
        }

        private int _antrepoNumber;
        public int AntrepoNumber {
            get { return _antrepoNumber; }
            set {
                if (_antrepoNumber != value) {
                    _antrepoNumber = value;
                    OnPropertyChanged(nameof(AntrepoNumber));
                }
            }
        }

        private int _containerNumber;
        public int ContainerNumber {
            get { return _containerNumber; }
            set {
                if (_containerNumber != value) {
                    _containerNumber = value;
                    OnPropertyChanged(nameof(ContainerNumber));
                }
            }
        }

        private int _goodsNumber;
        public int GoodsNumber {
            get { return _goodsNumber; }
            set {
                if (_goodsNumber != value) {
                    _goodsNumber = value;
                    OnPropertyChanged(nameof(GoodsNumber));
                }
            }
        }

        private string _genus;
        public string Genus {
            get { return _genus; }
            set {
                if (_genus != value) {
                    _genus = value;
                    OnPropertyChanged(nameof(Genus));
                }
            }
        }

        private int _weight;
        public int Weight {
            get { return _weight; }
            set {
                if (_weight != value) {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }



        public void UpdateOtherFields() {
            // FirmaId'ye göre getirme güncelleme ilerde apiden gelcek
            if (FirmaId == 1) {
                CustomerName = "Penta Teknoloji";
                LoaderName = "Orhun Teknoloji";
                RequiredCount = 20;
                RegisterDate = DateTime.Now;
                SummaryStatementNumber = 234123;
                AntrepoNumber = 1233456;
                ContainerNumber = 7839858;
                GoodsNumber = 3;
                Genus = "Mouse";
                Weight = 100;
                Count = 0;
            }
            else if (FirmaId == 2) {
                CustomerName = "Ekol Kırtasiye";
                LoaderName = "Nail Teknoloji";
                RequiredCount = 30;
                RegisterDate = DateTime.Now;
                SummaryStatementNumber = 99999;
                AntrepoNumber = 88888;
                ContainerNumber = 66666;
                GoodsNumber = 3;
                Genus = "Ekran Kartı";
                Weight = 100;
                Count = 0;
            }
            else if (FirmaId == 3) {
                CustomerName = "Monoloji Teknoloji";
                LoaderName = "Ali Teknoloji";
                RequiredCount = 40;
                RegisterDate = DateTime.Now;
                SummaryStatementNumber = 99999;
                AntrepoNumber = 88888;
                ContainerNumber = 66666;
                GoodsNumber = 3;
                Genus = "Ekran Kartı";
                Weight = 120;
                Count = 0;
            }

        }
    }
}
