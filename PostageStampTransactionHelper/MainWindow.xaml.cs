using System.ComponentModel;
using static PostageStampTransactionHelper.ExchangeOpt;

namespace PostageStampTransactionHelper
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private float _sale1Price;
        public float Sale1Price
        {
            get
            {
                return _sale1Price;
            }
            set
            {
                _sale1Price = value;
                OnPropertyChanged(nameof(Sale1Price));
            }
        }

        private float _salePriceDelta;
        public float SalePriceDelta
        {
            get
            {
                return _salePriceDelta;
            }
            set
            {
                _salePriceDelta = value;
                OnPropertyChanged(nameof(SalePriceDelta));
            }
        }

        private float _salePriceResult;
        public float SalePriceResult
        {
            get
            {
                return _salePriceResult;
            }
            set
            {
                _salePriceResult = value;
                OnPropertyChanged(nameof(SalePriceResult));
            }
        }

        private int _saleCount;
        public int SaleCount
        {
            get
            {
                return _saleCount;
            }
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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaleOpt();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Sale1Price = 0.01f;
            SalePriceDelta = 0.01f;
        }
    }
}