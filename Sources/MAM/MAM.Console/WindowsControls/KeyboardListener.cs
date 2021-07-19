using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.Generic;

namespace MAM.Console.WindowsControls
{
    public enum Key
    {
        MOUSE_BUTTON_4 = 0x06,
        MOUSE_BUTTON_5 = 0x05
    }

    public class KeyboardListener
    {

        public static bool ButtonIsDown(Key key)
        {
            return (GetKeyState((int)key) & KEY_PRESSED) != 0;
        }

        private const int KEY_PRESSED = 0x8000;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern short GetKeyState(int key);
    }

}