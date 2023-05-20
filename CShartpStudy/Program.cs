using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CShartpStudy
{

    enum ClassType
    {
        None = 0,
        Knight = 1,
        Archer,
        Mage
    }

    enum MonsterType
    {
        None = 0,
        Slime,
        Ork,
        Skeleton
    }

    struct Player
    {
        public int m_Hp;
        public int m_Attack;
    }

    struct Monster
    {
        public int m_Hp;
        public int m_Attack;
    }
    internal class Program
    {
        static void Print(string Str)
        {
            Console.WriteLine(Str);
        }

        static ClassType ChooseClass()
        {

            ClassType Choice = ClassType.None;

            Print("직업을 선택하세요!");
            Print("[1]기사");
            Print("[2]궁수");
            Print("[3]법사");

            int input = Convert.ToInt32(Console.ReadLine());


            switch (input)
            {
                case (int)ClassType.Knight:
                    Choice = ClassType.Knight;
                    Print("기사를 선택하였습니다.");
                    break;
                case (int)ClassType.Archer:
                    Choice = ClassType.Archer;
                    Print("궁수를 선택하였습니다.");
                    break;
                case (int)ClassType.Mage:
                    Choice = ClassType.Mage;
                    Print("법사를 선택하였습니다.");
                    break;
                default:
                    break;

            }

            return Choice;
        }

        static void CreatePlayer(ClassType _Select, out Player player)
        {
            switch (_Select)
            {
                case ClassType.Knight:
                    player.m_Hp = 100;
                    player.m_Attack = 10;
                    break;
                case ClassType.Archer:
                    player.m_Hp = 75;
                    player.m_Attack = 12;
                    break;
                case ClassType.Mage:
                    player.m_Hp = 50;
                    player.m_Attack = 15;
                    break;
                default:
                    player.m_Hp = 0;
                    player.m_Attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random random = new Random();
            
            int randomMonster = random.Next(1, 4);

            switch(randomMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 나타났습니다!");
                    monster.m_Hp = 20;
                    monster.m_Attack = 2;
                    break;
                case (int)MonsterType.Ork:
                    Console.WriteLine("오크가 나타났습니다!");
                    monster.m_Hp = 40;
                    monster.m_Attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 나타났습니다!");
                    monster.m_Hp = 30;
                    monster.m_Attack = 3;
                    break;

                default:
                    monster.m_Hp = 0;
                    monster.m_Attack = 0;  
                    break;
            }
        }
        static void Fight(ref Monster monster, ref Player player)
        {
            while (true)
            {
                monster.m_Hp -= player.m_Attack;
                if(monster.m_Hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력 {player.m_Hp}");
                    break;
                }

                player.m_Hp -= monster.m_Attack;
                if(player.m_Hp <= 0)
                {
                    Console.WriteLine("패배했습니다!");
                    break;
                }
            }

        }
        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다");
                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine("[1] 전투 모드로 돌입!");
                Console.WriteLine("[2] 일정 확률로 마을로 도망");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref monster, ref player);
                }
                else if (input == "2")
                {
                    Random random = new Random();
                    int randValue = random.Next(0, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다!");
                        Fight(ref monster, ref player);
                    }
                }
            }
        }
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다!");
                Console.WriteLine("[2] 로비로 돌아가기!");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    EnterField(ref player);
                }

                else if (input == "2") { break; }
            }
        }
        static void Main(string[] args)
        {
            ClassType Choice = ClassType.Knight;
            switch (Choice)
            {
                case ClassType.Knight:
                    break;
            }
            while (true)
            {
                ClassType Select = ChooseClass();

                if (Select != ClassType.None)
                {
                    Player player;

                    CreatePlayer(Select, out player);

                    Console.WriteLine($"HP : {player.m_Hp}, Attack : {player.m_Attack}");

                    EnterGame(ref player);

                }


            }
        }
    }
}