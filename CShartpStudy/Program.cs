namespace CShartpStudy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; ++i)
            {
                if (i % 3 != 0)
                {
                    continue;
                }
                Console.WriteLine($"무엇이냐면 {i}"); ;
            }
        }
    }
} 