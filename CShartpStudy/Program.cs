using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CShartpStudy
{
    internal class Program
    {
        
        class Knight
        {

            public int HP
            {
                get;
                set;
            } = 200;
        }
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Console.WriteLine(knight.HP);
        }
    }
}