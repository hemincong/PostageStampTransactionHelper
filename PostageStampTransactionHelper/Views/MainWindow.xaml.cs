using PostageStampTransactionHelper.ViewController;
using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using static PostageStampTransactionHelper.ExchangeOpt;

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
            SaleOpt();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private IntPtr _windowHandle;
        private HwndSource _source;

        private void MainWindow_OnSourceInitialized(object sender, EventArgs e)
        {
            //base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source?.AddHook(HwndHook);

            foreach ( var k in mc.Shortcuts())
            {
                  RegisterHotKey(_windowHandle, VirtualKeyCodes.HOTKEY_ID, VirtualKeyCodes.MOD_NONE, k);
            }
        }

        private static IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case VirtualKeyCodes.WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case VirtualKeyCodes.HOTKEY_ID:
                            int vkey = (((int) lParam >> 16) & 0xFFFF);
                            if (vkey == VirtualKeyCodes.VK_TAB)
                            {
                                //mc.SaleCount += 1;
                                //tblock.Text += "CapsLock was pressed" + Environment.NewLine;
                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            UnregisterHotKey(_windowHandle, VirtualKeyCodes.HOTKEY_ID);
        }
    }
}