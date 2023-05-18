using System.Diagnostics;

namespace CShartpStudy
{
    internal class Program
    {

        static void Main(string[] args)
        {

            for (int i = 2; i <= 9; ++i)
            {
                for (int j = 1; j <= 9; ++j)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
            }
        }
    }
} 