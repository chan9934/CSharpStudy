using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CShartpStudy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string name = "Harry Porter";

            bool bIsContained = name.Contains("Harry");
            if(bIsContained)
            {
                Console.WriteLine("OK");
            }
            int index = name.IndexOf(" ");
            Console.WriteLine(index);

            name = name + "Junior";
            Console.WriteLine(name.ToLower());
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.Replace('r', 'l'));

            string[] sname = name.Split(new char[] {' '});
            string substringname = name.Substring(5);

        }
    }
}