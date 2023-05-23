using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CShartpStudy
{
    internal class Program
    {
        static int getHighScore(int[] score)
        {
            int highScore = 0;
            foreach(int a in score)
            {
                if(highScore < a)
                {
                    highScore = a;
                }
            }
            return highScore;
        }
        static int getAverageScore(int[] score)
        {
            int sum = 0;
            for(int i = 0; i < score.Length; ++i)
            {
                sum += score[i];
            }

            return sum/score.Length;
        }
        static int genIndex(int[] score, int value)
        {
           for(int i = 0; i < score.Length; ++i)
            {
                if (score[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        static void sort(int[] score)
        {
            for(int i = 0; i < score.Length; ++i)
            {
                for(int j =  i; j < score.Length; ++j)
                {
                    if(j > i)
                    {
                       if( score[j] < score[j - 1])
                        {
                            int temp = score[j - 1];
                            score[j - 1] = score[j];
                            score[j] = temp;
                        }
                    }
                }
            }

        }


        static void Main(string[] args)
        {
            int[] arr = new int[5] { 10, 30, 40, 20, 50 };
            Console.WriteLine(getHighScore(arr)); 
            Console.WriteLine(getAverageScore(arr)); 
            Console.WriteLine(genIndex(arr, 30));
            sort(arr);
            foreach(int a in arr)
            {
                Console.WriteLine(a);
            }
        }
    }
}