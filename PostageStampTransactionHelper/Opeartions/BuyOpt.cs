using System;
using PostageStampTransactionHelper.Utils;

namespace PostageStampTransactionHelper.Opeartions
{
    internal class BuyOpt : ExchangeOptBase
    {
        protected override Tuple<int, int, int, int> FindWordOffest
            => new Tuple<int, int, int, int>(300, -300, 600, -50);

        protected override Tuple<int, int, int, int> FindInputOffest
            => new Tuple<int, int, int, int>(130, -200, 270, -180);

        protected override Tuple<int, int, int, int> ButtonOffest 
            => new Tuple<int, int, int, int>(197, -150, 245, -130);

        protected override string BaseWord()
        {
            return "买一";
        }

        protected override string InputBaseWord()
        {
            return "买入价格";
        }

        protected override string ButtonName()
        {
            return "买入";
        }

        protected override int StateKey()
        {
            return (int)VirtualKeyCodes.VF_F1;
        }
    }
}