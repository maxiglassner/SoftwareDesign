﻿using System;
using System.Collections.Generic;

namespace _9
{
    class Program
    {
        public static string [] GameData = new string [] {"1","2","3","4","5","6","7","8","9"};
        public static int counter = 0; 
        public static string turn = "O"; 
        static void Main(string[] args)
        {
            StartGame();           
        }
        public static void StartGame()
        {
            Console.WriteLine("Welcome to XOX! To set your mark, please just write the number of the field in the console. Player O will start. Please choose your field.");
            WriteGameData(); 
            RunningGame();
        }
        public static void RunningGame ()
        {
            for(;;)
            {
                //Player Input
                string PlayerInput =  Console.ReadLine();
                int Choosenfield = CorrectInput(PlayerInput);
               
                if (Choosenfield <= 9)   
                {

                    //Set Mark
                    if (counter%2 == 0)
                    {
                        GameData[Choosenfield-1] = "O";
                        counter++;
                        turn = "O";
                    } else
                    {
                        GameData[Choosenfield-1] = "X";
                        counter ++;
                        turn = "X";
                    }

                    //Check for a draw
                    if (counter > 8)
                    {
                        WriteGameData();
                        Console.WriteLine("Nobody won today. See you next time.");
                        break;
                    }

                    //Check for a winner
                    if(win())
                    {
                        WriteGameData();
                        Console.WriteLine("Winner Winner Chicken Dinner! Congratulations Player " + turn + ", you are the best!");
                        break;
                    } else
                    {
                        WriteGameData();
                    }
                }    

            }
        }

        public static int CorrectInput(string PlayerInput)
        {
            int Choosenfield = 0;
                if(Int32.TryParse(PlayerInput,out Choosenfield) == false)
                {
                    Console.WriteLine("Invalid Iput! Please try it again.");
                    return 10;
                }
                
                if(GameData[Choosenfield-1] != PlayerInput)
                {
                    Console.WriteLine("Field already taken. Please choose another on.");
                    return 10;
                } else
                {
                    return Choosenfield;
                }

        }

        public static Boolean win()
        {
            if (GameData[0]==GameData[1] & GameData[1] ==GameData[2])
            {
                return true;
            }
            if (GameData[0]==GameData[3] & GameData[3] ==GameData[6])
            {
                return true;
            }
            if (GameData[0]==GameData[4] & GameData[4] ==GameData[8])
            {
                return true;
            }
            if (GameData[1]==GameData[4] & GameData[4] ==GameData[7])
            {
                return true;
            }
            if (GameData[2]==GameData[5] & GameData[5] ==GameData[8])
            {
                return true;
            }
            if (GameData[3]==GameData[4] & GameData[4] ==GameData[5])
            {
                return true;
            }
            if (GameData[6]==GameData[7] & GameData[7] ==GameData[8])
            {
                return true;
            }
            if (GameData[2]==GameData[4] & GameData[4] ==GameData[6])
            {
                return true;
            } else
            {
                return false;
            }
        }

        
        public static void WriteGameData () 
        {
            Console.WriteLine("---------");
            Console.WriteLine("| "+ GameData[0] + " " + GameData[1] + " " + GameData[2] + " |");
            Console.WriteLine("| "+ GameData[3] + " " + GameData[4] + " " + GameData[5] + " |");
            Console.WriteLine("| "+ GameData[6] + " " + GameData[7] + " " + GameData[8] + " |");
            Console.WriteLine("---------"); 
        }

    }
}
