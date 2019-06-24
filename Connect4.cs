using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Connect4
{
    class Program
    {
        class Board
        {
            public void DropToken(string[,] board, int chip)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i < 6)
                    {
                        if (board[i + 1, chip] == "|___|")
                        {

                        }
                        else
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (j == chip)
                                {
                                    board[i, j] = "| X |";
                                }
                            }
                            break;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == chip)
                            {
                                board[i, j] = "| X |";
                            }
                        }
                    }
                }
            }

            public void EnemyDropToken(string[,] board, int enemy)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i < 6)
                    {
                        if (board[i + 1, enemy] == "|___|")
                        {

                        }
                        else
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (j == enemy)
                                {
                                    board[i, j] = "| 0 |";

                                }

                            }
                            break;
                        }

                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (j == enemy)
                            {
                                board[i, j] = "| 0 |";
                            }
                        }
                    }
                }
            }

            public void PrintBoard(string[,] board)
            {
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.Write(board[i, j]);
                    }
                }
            }

            public bool CheckVictory(string[,] board)
            {
                int count = 0;

                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (board[i, j] == "| X |")
                        {
                            count++;

                            if (count == 4)
                            {
                                return false;
                            }

                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            bool GameRun = true;

            string[,] board = new string[7, 7];

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = "|___|";
                }
            }

            Board token = new Board();

            token.PrintBoard(board);

            Console.WriteLine();

            Console.WriteLine("Enter 0 - 6 to drop your chip");

            while (GameRun == true)
            {
                Console.WriteLine();

                Console.WriteLine();

                GameRun = token.CheckVictory(board);

                if (GameRun == false)
                {
                    break;
                }
                else
                {
                    TextReader In = Console.In;

                    Console.WriteLine("Player 1 drop your chip (0-6)");

                    var chip = In.ReadLine();

                    token.DropToken(board, Convert.ToInt32(chip));

                    token.PrintBoard(board);

                    Console.WriteLine();

                    Console.WriteLine();

                    Console.WriteLine("Player 2 drop your chip (0-6)");

                    var enemy = In.ReadLine();

                    token.EnemyDropToken(board, Convert.ToInt32(enemy));

                    token.PrintBoard(board);
                }

            }

            Console.WriteLine("You won!");

            Console.Read();
        }
    }
}