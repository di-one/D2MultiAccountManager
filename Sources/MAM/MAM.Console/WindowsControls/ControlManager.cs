using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.WindowsControls
{
    public class ControlManager
    {
        public Action<Key> OnKeyDown;

        private bool _keyDown;
        private Key _key;

        public void Start(Key key)
        {
            _key = key;

            Task.Factory.StartNew(() => Update(), TaskCreationOptions.LongRunning);
        }

        private void Update()
        {
            while (true)
            {
                if (_keyDown == false && KeyboardListener.ButtonIsDown(_key))
                {
                    OnKeyDown?.Invoke(_key);
                    System.Console.WriteLine("Key Down");
                    _keyDown = true;
                }
                else if (KeyboardListener.ButtonIsDown(_key) == false)
                {
                    _keyDown = false;
                }
            }
        }
    }
}
