using System;
using System.Numerics;

namespace tickTackToe
{
    public static class Storage
    {
        public static int roundNum = 1;

  
    }

    class Program
    {    
        static string CheckWin(string[][] args)
        {
            Storage.roundNum++;
            foreach(string[] arg in args)
            {
                if (arg[0] == arg[1] && arg[0] == arg[2] && arg[0] != "-")
                {
                    return arg[0];
                }
            }
     
            for(int i = 0; i < 3;i++)
            {
                if (args[0][i] == args[1][i] && args[1][i] == args[2][i] && args[0][i] != "-")
                {
                    return args[0][i];
                }
            }
            if ((args[0][0] == args[1][1] && args[0][0] == args[2][2]) && args[1][1] != "-" || (args[0][2] == args[1][1] && args[0][2] == args[2][0]) && args[1][1] != "-")
            {
                return args[1][1];
            }
            else
            {
                return null;
            }


        }

        static int[] CheckAlmostWin(string[][] args, string playerType)
        {
            for (int y = 0; y < args.Length; y++)
            {
                string[] row = args[y];
                int count = 0;
                int[] pos = { 0, 0 };
                if (!row.Contains("-"))
                {
                    continue;
                }
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] == playerType)
                    {
                        count++;
                    }
                    else if (row[i] == "-")
                    {
                        pos[0] = i;
                        pos[1] = y;
                    }    
                    if (count == 2 && i == 2)
                    {
                        return pos;
                    }

                }
            }

            for (int x = 0; x < 3; x++)
            {
                int count = 0;
                int[] pos = {0, 0};
                for (int y = 0; y < 3; y++)
                {
                    if (args[y][x] == playerType)
                    {
                        count++;
                    }
                    else if (args[y][x] == "-")
                    {
                        pos[0] = x;
                        pos[1] = y;

                    }
                    if (count == 2 && y == 2)
                    {
                        return pos;

                    }


                }
            }
            int count2 = 0;
            int[] pos3 = { 0, 0 };
                for (int i = 0; i < 3; i++)
            {
                
                if (args[i][i] == playerType)
                {
                    count2++;
                }
                else if (args[i][i] == "-")
                {
                    pos3[0] = i;
                    pos3[1] = i;

                }
                if (count2 == 2 && i == 2)
                {
                    return pos3;
 
                }

            }
            int count3 = 0;
            int[] pos2 = { 0, 0 };
                for (int i = 0;i < 3;i++)
            {
                
                if (args[i][2-i] == playerType)
                {
                    count3++;
                }
                else if (args[i][2-i] == "-")
                {
                    pos2[0] = 2-i;
                    pos2[1] = i;

                }
                if (count3 == 2 && i == 2)
                {
                    return pos2;
                    Console.WriteLine(count3);
                }

            } 
            int[] test = { 3, 3 };
            return test;
        }

        static void Showboard(string[][] args)
        {
            foreach (string[] rows in args)
            {
                Console.WriteLine(rows[0] + " | " + rows[1] + " | " + rows[2]);
                Console.WriteLine("----------");
            }
        }

        static void FakeAI(string[][] board)
        {
            if (Storage.roundNum == 1)
            {
                if (board[1][0] == "X" || board[0][1] == "X" || board[2][1] == "X" || board[1][2])
                {
                    if()
                    int en = 2;
                    // Starts strategi
                    
                }
                
            }
            else
            {
                int[] attack = CheckAlmostWin(board, "O");

                Console.WriteLine(attack[0] == attack[1] && attack[0] == 3);

                if (!(attack[0] == attack[1] && attack[0] == 3))
                {
                    board[attack[1]][attack[0]] = "O";
                }
                else
                {
                    int[] defence = CheckAlmostWin(board, "X");
                    if (!(defence[0] == defence[1] && defence[0] == 3))
                    {
                        board[defence[1]][defence[0]] = "O";


                    }
                    else
                    {
                        int tre = 4;
                        //gjør algoritme
                    }
                }
            }
            /*
            1 Sjekke om den kan vinne
            2 Forsvare motstander akkurat nå
            3 Strategi

            Strategi:

            - Starter i midten
            Da velger vi et tilfeldig hjørne
            Hvis spiller plasserer på siden utløses 2 || Hvis spiller plassere i hjørnet som ikke er motsatt av vårt hjørne, plasser der    


            - Starter i hjørnet
            Må plassrere i midten og så side || side rett ved siden av X-en og så videre...
            
            - Starter på siden
            Setter på den motsatte siden
            Pass på hest-movement



            */
        }

        static void Main()
        {
            string[][] board =
            {
                new string[] {"-", "-", "-"},
                new string[] {"-", "-", "-"},
                new string[] {"-", "-", "-"}

            };

            bool done = false;

            Console.WriteLine("Ta utgangspunkt i at venstre hjørne er 0, 0. Skriv koordinatene på formen \"x, x\"");
            while (!done)
            {
                Showboard(board);
                Console.WriteLine("Hvor vil du plassere brikken?");
                string input = Console.ReadLine();
                string[] splitInput = input.Split(",", 2);
                int pos1 = int.Parse(splitInput[1]);
                int pos2 = int.Parse(splitInput[0]);

                board[pos1][pos2] = "X";

                FakeAI(board);



                Console.WriteLine(Storage.roundNum);

                if (CheckWin(board) != null)
                {
                    done = true;
                }

            }

            
        }
    }
}




/*
Må gjøres:
- Spiller kan ikke plassere der det allerede er brikker 
- Algoritmen
-
-
 */
