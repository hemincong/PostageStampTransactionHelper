using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable InconsistentNaming

namespace PostageStampTransactionHelper.Utils
{
    public class VirtualKeyCodes
    {
        public const int WM_HOTKEY = 0x0312;
        public const int HOTKEY_ID = 9000;

        //Modifiers:
        public const uint MOD_NONE = 0x0000; //(none)
        public const uint MOD_ALT = 0x0001; //ALT
        public const uint MOD_CONTROL = 0x0002; //CTRL
        public const uint MOD_SHIFT = 0x0004; //SHIFT
        public const uint MOD_WIN = 0x0008; //WINDOWS

        public const uint VK_CAPITAL = 0x14;
        public const uint VK_TAB = 0x09;
        public const uint VK_RETURN = 0x0D;
        public const uint VF_F12 = 0x71;

        public const uint A_KEY = 0x41;
        public const uint B_KEY = 0x42;
        public const uint I_KEY = 0x49;
        public const uint J_KEY = 0x4A;
        public const uint K_KEY = 0x4B;
        public const uint X_KEY = 0x58;
        public const uint Y_KEY = 0x59;
        public const uint Z_KEY = 0x5A;

        private static readonly Dictionary<uint, string> KeyNameMapper = new Dictionary<uint, string>
        {
            { A_KEY, "A" },
            { B_KEY, "B" },
            { I_KEY, "I" },
            { J_KEY, "J" },
            { K_KEY, "K" },
            { X_KEY, "X" },
            { Y_KEY, "Y" },
            { Z_KEY, "Z" },
        };

        public static string GetKeyName(uint virtualKey)
        {
            string name;
            KeyNameMapper.TryGetValue(virtualKey, out name);
            return name;
        }

        public static uint GetKeyCode(string s)
        {
            Debug.Assert(s.Length == 1);
            return (from p in KeyNameMapper where p.Value == s select p.Key).FirstOrDefault();
        }
    }

    [ValueConversion(typeof(uint), typeof(string))]
    public class KeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VirtualKeyCodes.GetKeyName((uint)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VirtualKeyCodes.GetKeyCode(value as string);
        }
    }
}