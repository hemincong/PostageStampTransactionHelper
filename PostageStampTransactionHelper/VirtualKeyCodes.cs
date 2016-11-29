using System.Collections.Generic;

namespace PostageStampTransactionHelper
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

        public const uint A_KEY = 0x41;
        public const uint B_KEY = 0x42;
        public const uint I_KEY = 0x49;
        public const uint J_KEY = 0x4A;
        public const uint K_KEY = 0x4B;
        public const uint X_KEY = 0x58;
        public const uint Y_KEY = 0x59;
        public const uint Z_KEY = 0x5A;

        static private Dictionary<uint, string> key_name_mapper = new Dictionary<uint, string>
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

        static public string GetKeyName(uint virtualKey)
        {
            string name;
            key_name_mapper.TryGetValue(virtualKey, out name);
            return name;
        }
    }
}