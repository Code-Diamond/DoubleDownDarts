﻿using System;

namespace DoubleDownDarts
{
    class Program
    {
        public static string input;
        public static int numberOfDoublesAchieved = 0, round = 1, number;
        public static Random rand = new Random();
        public static int[] cricketArray = {3,3,3,3,3,3};
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to double down cricket.");
            Console.WriteLine("To play, aim at the designated area on the board and type in your result.");
            
            
            while(round < 35)
            {
                number = rand.Next(20)+1;

                for (int i = 1; i <= 3; i++)
                {
                    Console.Write("\nRound " + round + " | Dart " + i + "\n\n");
                    if (checkDart())
                    {
                        i = 3;
                    }
                }
                round++;
            }

        }
        
        static Boolean checkDart()
        {
            if (cricketArray[0] <= 0 && cricketArray[1] <= 0 && cricketArray[2] <= 0 && cricketArray[3] <= 0 && cricketArray[4] <= 0 && cricketArray[5] <= 0)
            {
                Console.WriteLine("Hit the double 1.");
                input = Console.ReadLine();
                int dart = Convert.ToInt32(input);
                if (dart == 1)
                {
                    Console.WriteLine("Congrats you win!");
                    System.Environment.Exit(0);
                    return true;
                }
                else
                {
                    //return true if busting on last dart to increment round and adjust dart to being 1
                    Console.WriteLine("Bust!");
                    return true;
                }
            }
            else
            {
                try
                {
                    if (numberOfDoublesAchieved != 2)
                    {
                        Console.WriteLine("Hit the double " + number);
                        input = Console.ReadLine();
                        int dart = Convert.ToInt32(input);
                        if (dart == number)
                        {
                            numberOfDoublesAchieved++;
                            number = rand.Next(20);
                        }
                    }
                    else
                    {
                        Console.WriteLine(" 20   19   18   17   16   15                |Location on board");
                        Console.WriteLine("[{0}]  [{1}]  [{2}]  [{3}]  [{4}]  [{5}]                |Left to hit",
                            cricketArray[0],
                            cricketArray[1],
                            cricketArray[2],
                            cricketArray[3],
                            cricketArray[4],
                            cricketArray[5]
                            );
                        input = Console.ReadLine();
                        int dart = Convert.ToInt32(input);
                        switch (dart)
                        {
                            case 20:
                                cricketArray[0]--;
                                break;
                            case 19:
                                cricketArray[1]--;
                                break;
                            case 18:
                                cricketArray[2]--;
                                break;
                            case 17:
                                cricketArray[3]--;
                                break;
                            case 16:
                                cricketArray[4]--;
                                break;
                            case 15:
                                cricketArray[5]--;
                                break;
                        }


                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Counted as a miss");
                    return false;
                }

            }
        }


    }



}
