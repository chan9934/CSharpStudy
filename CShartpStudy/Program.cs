namespace CShartpStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //카멜
            while (true)
            {
                Random rand = new Random();
                int aiChoice = rand.Next(0, 3);

                int Choice = Convert.ToInt32(Console.ReadLine());

                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("당신은 주먹을 냈습니다");
                        break;
                    case 1:
                        Console.WriteLine("당신은 가위을 냈습니다");
                        break;
                    case 2:
                        Console.WriteLine("당신은 보을 냈습니다");
                        break;
                }

                switch (aiChoice)
                {
                    case 0:
                        Console.WriteLine("컴퓨터는 주먹을 냈습니다");
                        break;
                    case 1:
                        Console.WriteLine("컴퓨터는 가위을 냈습니다");
                        break;
                    case 2:
                        Console.WriteLine("컴퓨터는 보을 냈습니다");
                        break;
                }


                switch (Choice)
                {
                    case 0:

                        switch (aiChoice)
                        {
                            case 0:
                                Console.WriteLine("비겼습니다.");
                                break;
                            case 1:
                                Console.WriteLine("이겼습니다");
                                break;
                            case 2:
                                Console.WriteLine("졌습니다");
                                break;
                        }
                        break;
                    case 1:

                        switch (aiChoice)
                        {
                            case 0:
                                Console.WriteLine("졌습니다.");
                                break;
                            case 1:
                                Console.WriteLine("비겼습니다");
                                break;
                            case 2:
                                Console.WriteLine("이겼습니다");
                                break;
                        }
                        break;
                    case 2:

                        switch (aiChoice)
                        {
                            case 0:
                                Console.WriteLine("이겼습니다.");
                                break;
                            case 1:
                                Console.WriteLine("졌습니다");
                                break;
                            case 2:
                                Console.WriteLine("비겼습니다");
                                break;
                        }
                        break;
                }
            }
        }
    }
} 