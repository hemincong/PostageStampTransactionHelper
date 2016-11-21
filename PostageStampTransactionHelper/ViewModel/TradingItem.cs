using System.ComponentModel;

namespace PostageStampTransactionHelper.ViewModel
{
    internal class TradingItem : INotifyPropertyChanged
    {
        private int _count;
        private float _price;
        private float _priceDelta;

        private float _tradingPrice;

        public TradingItem(string shutCutKey)
        {
            ShutCutKey = shutCutKey;
        }

        public float Price
        {
            get { return _price; }
            set
            {
                _price = value;
                TradingPrice = _price + _priceDelta;
                OnPropertyChanged(nameof(Price));
            }
        }

        public float PriceDelta
        {
            get { return _priceDelta; }
            set
            {
                _priceDelta = value;
                TradingPrice = _price + _priceDelta;
                OnPropertyChanged(nameof(PriceDelta));
            }
        }

        public float TradingPrice
        {
            get { return _tradingPrice; }
            set
            {
                _tradingPrice = value;
                OnPropertyChanged(nameof(TradingPrice));
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public string ShutCutKey { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}