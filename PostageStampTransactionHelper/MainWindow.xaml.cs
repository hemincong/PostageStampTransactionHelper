using System.ComponentModel;

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

        private float _priceDelta;
        public float PriceDelta
        {
            get
            {
                return _priceDelta;
            }
            set
            {
                _priceDelta = value;
                OnPropertyChanged(nameof(PriceDelta));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ExchangeOpt.SaleOpt();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Sale1Price = 0.01f;
        }
    }
}