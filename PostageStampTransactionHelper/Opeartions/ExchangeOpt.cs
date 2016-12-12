using System;
using System.Threading;
using PostageStampTransactionHelper.Utils;

namespace PostageStampTransactionHelper.Opeartions
{
    internal abstract class ExchangeOptBase : IExchangeInterface
    {
        private const string WindowTitle = "河北滨海大宗商品交易市场";

        // Item1 : 区域左相对Window左位置
        // Item2 : 区域顶部相对Window底部位置
        // Item3 : 区域右相对Window左位置
        // Item4 : 区域底部相对Window底部位置
        protected abstract Tuple<int, int, int, int> FindWordOffest { get; }
        protected abstract Tuple<int, int, int, int> FindInputOffest { get; }

        protected abstract string BaseWord();
        protected abstract string InputBaseWord();

        public void ExchangeOpt()
        {
            var dm = DmHelper.Instance.Dm;
            var hWnd = dm.FindWindow(null, WindowTitle);

            dm.SetWindowState(hWnd, 7);
            dm.SetWindowState(hWnd, 12);

            Thread.Sleep(300);
            object x1, x2, y1, y2;
            if (dm.GetClientRect(hWnd, out x1, out y1, out x2, out y2) <= 0)
            {
                MessageUtils.ShowError("请先打开交易客户端");
                return;
            }

            // ReSharper disable once InconsistentNaming
            dm.KeyPress((int) VirtualKeyCodes.VF_F12);

            dm.SetDict(0, "words.txt");

            object sale1PosX, sale1PosY;
            var o = FindWordOffest;
            dm.FindStr((int) x1 + o.Item1, (int) y2 + o.Item2, (int) x1 + o.Item3, (int) y2 + o.Item4, BaseWord(),
                "000000-000000", 1.0,
                out sale1PosX, out sale1PosY);

            var ocrRet = dm.Ocr((int) sale1PosX + 30, (int) sale1PosY, (int) sale1PosX + 90, (int) sale1PosY + 20,
                "008000-008000|ff0000-ff0000|000000-000000", 1.0);

            float currPrice;
            float.TryParse(ocrRet, out currPrice);
            currPrice += 0.01f;
            var s = currPrice.ToString("0.00");
            object salePricePosX, salePricePosY;

            var o2 = FindWordOffest;
            dm.FindStr((int) x1 + o2.Item1, (int) y2 + o2.Item2, 
                (int) x1 + o2.Item3, (int) y2 + o2.Item4, InputBaseWord(), "0000ff-0000ff", 1.0,
                out salePricePosX, out salePricePosY);
            dm.MoveTo((int) salePricePosX + 130, (int) salePricePosY + 10);
            dm.LeftClick();
            foreach (var c in s.ToCharArray())
                dm.KeyPressChar(c.ToString());
        }
    }
}