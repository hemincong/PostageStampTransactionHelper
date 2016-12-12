using PostageStampTransactionHelper.ViewController;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Interop;
using PostageStampTransactionHelper.Utils;

namespace PostageStampTransactionHelper.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private MainWindowController mc;

        public MainWindow()
        {
            InitializeComponent();
            mc = new MainWindowController();
            SaleList.ItemsSource = mc.SaleItems;
            BuyList.ItemsSource = mc.BuyItems;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null) mc.OnRecvKey((uint)btn.Tag);
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private IntPtr _windowHandle;
        private HwndSource _source;

        private void MainWindow_OnSourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source?.AddHook(HwndHook);

            mc.Shortcuts().ToList().ForEach(k => RegisterHotKey(_windowHandle, VirtualKeyCodes.HOTKEY_ID, VirtualKeyCodes.MOD_NONE, k));
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg != VirtualKeyCodes.WM_HOTKEY) return IntPtr.Zero;

            var wp = wParam.ToInt32();
            if (wp != VirtualKeyCodes.HOTKEY_ID) return IntPtr.Zero;
            handled = true;

            var vkey = ((int) lParam >> 16) & 0xFFFF;
            mc.OnRecvKey((uint)vkey);
            return IntPtr.Zero;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            UnregisterHotKey(_windowHandle, VirtualKeyCodes.HOTKEY_ID);
        }
    }
}