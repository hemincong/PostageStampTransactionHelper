using System;

namespace PostageStampTransactionHelper.Opeartions
{
    internal class Sale1Opt : ExchangeOptBase
    {
        protected override Tuple<int, int, int, int> FindWordOffest
            => new Tuple<int, int, int, int>(300, -300, 600, -50);

        protected override Tuple<int, int, int, int> FindInputOffest
            => new Tuple<int, int, int, int>(130, -200, 270, -180);

        protected override string BaseWord()
        {
            return "卖一";
        }

        protected override string InputBaseWord()
        {
            return "卖出价格";
        }
    }
}