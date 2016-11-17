using System.Threading;

namespace PostageStampTransactionHelper
{
    internal class ExchangeOpt
    {
        public static void SaleOpt()
        {
            var dm = DmHelper.Instance.Dm;
            var hWnd = dm.FindWindow(null, "河北滨海大宗商品交易市场");

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
            const int VF_F12 = 0x71;
            dm.KeyPress(VF_F12);

            dm.SetDict(0, "words.txt");
            object sale1PosX, sale1PosY;
            dm.FindStr((int) x1 + 300, (int) y2 - 300, (int) x1 + 600, (int) y2 - 50, "卖一", "000000-000000", 1.0,
                out sale1PosX, out sale1PosY);

            var ocrRet = dm.Ocr((int) sale1PosX + 30, (int) sale1PosY, (int) sale1PosX + 90, (int) sale1PosY + 20,
                "008000-008000|ff0000-ff0000|000000-000000", 1.0);

            float currPrice;
            float.TryParse(ocrRet, out currPrice);
            currPrice += 0.01f;
            var s = currPrice.ToString("0.00");
            object salePricePosX, salePricePosY;
            dm.FindStr((int) x1 + 130, (int) y2 - 200, (int) x1 + 270, (int) y2 - 180, "卖出价格", "0000ff-0000ff", 1.0,
                out salePricePosX, out salePricePosY);
            dm.MoveTo((int) salePricePosX + 130, (int) salePricePosY + 10);
            dm.LeftClick();
            foreach (var c in s.ToCharArray())
                dm.KeyPressChar(c.ToString());
        }
    }
}
