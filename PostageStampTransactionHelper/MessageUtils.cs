using System.Windows;

namespace PostageStampTransactionHelper
{
    internal class MessageUtils
    {
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, msg, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
