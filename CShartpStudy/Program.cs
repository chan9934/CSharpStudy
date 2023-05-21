using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CShartpStudy
{
    class Knight
    {
        public int hp;
        public int attack;
        public Knight()
        {
            hp = 100;
            attack = 10;
            Console.WriteLine("Knight() 호출");
        }
        public Knight(int hp) : this()
        {
            this.hp = hp;
            Console.WriteLine("Knight(int, int) 호출");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight(500);
        }
    }
}