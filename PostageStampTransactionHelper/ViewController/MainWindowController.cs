using System.ComponentModel;

namespace PostageStampTransactionHelper.ViewController
{
    internal class MainWindowController : INotifyPropertyChanged
    {
        public MainWindowController()
        {
            Sale1Price = 0.01f;
            SaleCount = 1;
            SalePriceDelta = 0.01f;
        }

        private float _sale1Price;

        public float Sale1Price
        {
            get { return _sale1Price; }
            set
            {
                _sale1Price = value;
                OnPropertyChanged(nameof(Sale1Price));
            }
        }

        private float _salePriceDelta;

        public float SalePriceDelta
        {
            get { return _salePriceDelta; }
            set
            {
                _salePriceDelta = value;
                SalePriceResult = _sale1Price + _salePriceDelta;
                OnPropertyChanged(nameof(SalePriceDelta));
            }
        }

        private float _salePriceResult;

        public float SalePriceResult
        {
            get { return _salePriceResult; }
            set
            {
                _salePriceResult = value;
                OnPropertyChanged(nameof(SalePriceResult));
            }
        }

        private int _saleCount;

        public int SaleCount
        {
            get { return _saleCount; }
            set
            {
                _saleCount = value;
                OnPropertyChanged(nameof(SaleCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
