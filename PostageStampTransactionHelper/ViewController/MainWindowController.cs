using System.Collections.Generic;
using PostageStampTransactionHelper.ViewModel;
using System.Linq;
using PostageStampTransactionHelper.Opeartions;
using PostageStampTransactionHelper.Utils;

namespace PostageStampTransactionHelper.ViewController
{
    internal class MainWindowController
    {
        public MainWindowController()
        {
            SaleItems = new List<TradingItem>
            {
                new TradingItem(VirtualKeyCodes.A_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem(VirtualKeyCodes.B_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem(VirtualKeyCodes.C_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
            BuyItems = new List<TradingItem>
            {
                new TradingItem(VirtualKeyCodes.D_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.01f},
                new TradingItem(VirtualKeyCodes.E_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.02f},
                new TradingItem(VirtualKeyCodes.F_KEY, new SaleOpt()) {Price = 0.01f, Count = 1, PriceDelta = 0.03f}
            };
        }

        public List<TradingItem> BuyItems { get; }
        public List<TradingItem> SaleItems { get; }

        public IEnumerable<uint> Shortcuts()
        {
            return SaleItems.ToArray().Select(i => i.ShortCutKey);
        }

        public void OnRecvKey(uint vkey)
        {
            SaleItems.FindAll(i => i.ShortCutKey == vkey).ForEach(i => i.ExOpt());
        }
    }
}