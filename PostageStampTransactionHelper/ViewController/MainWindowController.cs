using System.Collections.Generic;
using PostageStampTransactionHelper.ViewModel;
using System.Runtime.InteropServices;
using System;
using System.Linq;

namespace PostageStampTransactionHelper.ViewController
{
    internal class MainWindowController
    {
        public MainWindowController()
        {
            SaleItems = new List<TradingItem>
            {
                new TradingItem(VirtualKeyCodes.X_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem(VirtualKeyCodes.Y_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem(VirtualKeyCodes.Z_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
            BuyItems = new List<TradingItem>
            {
                new TradingItem(VirtualKeyCodes.I_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem(VirtualKeyCodes.J_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem(VirtualKeyCodes.K_KEY) {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
        }

        public List<TradingItem> BuyItems { get; }
        public List<TradingItem> SaleItems { get; }

        public IEnumerable<uint> Shortcuts()
        {
            return SaleItems.ToArray().Select(i => i.ShortCutKey);
        }
    }
}