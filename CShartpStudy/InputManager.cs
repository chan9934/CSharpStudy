using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShartpStudy
{
    internal class InputManager
    {
        public delegate void OninputKey();
        public event OninputKey InputKey;


        public void Update()
        {
            if (Console.KeyAvailable == false)
            {
                return;
            }
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                InputKey();
            }
        }
    }
}
