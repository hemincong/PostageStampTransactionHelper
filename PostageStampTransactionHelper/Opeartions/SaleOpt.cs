using System;
using PostageStampTransactionHelper.Utils;

namespace PostageStampTransactionHelper.Opeartions
{
    internal class SaleOpt : ExchangeOptBase
    {
        protected override Tuple<int, int, int, int> FindWordOffest
            => new Tuple<int, int, int, int>(320, -240, 420, -190);

        protected override Tuple<int, int, int, int> FindInputOffest
            => new Tuple<int, int, int, int>(130, -200, 270, -180);

        protected override Tuple<int, int, int, int> ButtonOffest 
            => new Tuple<int, int, int, int>(251, -120, 282, -102);

        protected override string BaseWord()
        {
            return "卖一";
        }

        protected override string InputBaseWord()
        {
            return "卖出价格";
        }

        protected override string ButtonName()
        {
            return "卖出";
        }

        protected override int StateKey()
        {
            return (int)VirtualKeyCodes.VF_F2;
        }
    }
}