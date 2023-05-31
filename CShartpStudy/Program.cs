using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace CShartpStudy
{
    class Mon
    {
        public int id { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            a = 3;
            if(a.HasValue)
            {
                int number = a.Value;
                Console.WriteLine(number);
            }
            int b = a ?? 0;

            Mon mon = new Mon();
            int? c = mon?.id;

        }
    }
}