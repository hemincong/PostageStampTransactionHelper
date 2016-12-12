namespace PostageStampTransactionHelper.Opeartions
{
    internal class DmHelper
    {
        private static DmHelper _instance;

        private DmHelper()
        {
            Dm = new Dm.dmsoft();
        }

        public Dm.dmsoft Dm { get; }

        public static DmHelper Instance => _instance ?? (_instance = new DmHelper());
    }
}