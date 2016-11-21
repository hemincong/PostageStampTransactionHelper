using System.Collections.Generic;
using PostageStampTransactionHelper.ViewModel;

namespace PostageStampTransactionHelper.ViewController
{
    internal class MainWindowController
    {
        public MainWindowController()
        {
            SaleItems = new List<TradingItem>
            {
                new TradingItem("X") {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem("Y") {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem("Z") {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
            BuyItems = new List<TradingItem>
            {
                new TradingItem("I") {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem("J") {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem("K") {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
        }

        public List<TradingItem> BuyItems { get; }
        public List<TradingItem> SaleItems { get; }
    }
}