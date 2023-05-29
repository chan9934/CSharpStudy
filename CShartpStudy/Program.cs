using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CShartpStudy
{
    internal class Program
    {
        static public void Test2()
        {
            Console.WriteLine("a");
        }
        static void Main(string[] args)
        {
            InputManager inputmanager = new InputManager();
            inputmanager.InputKey += Test2;
            while(true)
            {
                inputmanager.Update();
            }
        }
    }
}