using System;
using System.Linq;

namespace xo
{
    class Program
    {
        static string player1;
        static string player2;
        public class player
        {
            public player()
            {
                Console.Write("enter your name of player 1");
                player1 = Console.ReadLine();
                Console.Write("enter your name of player 2");
                player2 = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("player1 name is {0} .", player1);
                Console.WriteLine("player2 name is {0} .", player2);
            }
        }
        public class display
        {
            public string[,] arr = new string[3, 3];
            public void fill()
            {
                int count = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        arr[i, j] = count.ToString();
                        count++;
                    }
                }
            }
            public void disbord()
            {
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(" {0} ", arr[i, j]);
                        if (j == 0 || j == 1)
                        {
                            Console.Write("|");
                        }
                        if (j == 2)
                        {
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public class game : display
        {
            public void gameloop()
            {
                int[] choice = new int[9];
                for (int i = 0; i < 9; i++)
                {

                    bool con = true;
                    while (con)
                    {

                        try
                        {

                            if (i % 2 == 0)
                            {
                                Console.Write("enter your choice {0} ", player1);
                            }
                            else
                            {
                                Console.Write("enter your choice {0} ", player2);
                            }
                            int temp = Convert.ToInt32(Console.ReadLine());
                            if (choice.Contains(temp))
                            {
                                Console.WriteLine("{0} is already in selected", temp);
                            }
                            else
                            {
                                if (temp >= 10 || temp <= 0)
                                {
                                    Console.WriteLine("Enter only 1 to 9 number");
                                }
                                else
                                {
                                    choice[i] = temp;
                                    string symbol = (i % 2 == 0) ? "X" : "O";
                                    switch (temp)
                                    {
                                        case 1: arr[0, 0] = symbol; break;
                                        case 2: arr[0, 1] = symbol; break;
                                        case 3: arr[0, 2] = symbol; break;
                                        case 4: arr[1, 0] = symbol; break;
                                        case 5: arr[1, 1] = symbol; break;
                                        case 6: arr[1, 2] = symbol; break;
                                        case 7: arr[2, 0] = symbol; break;
                                        case 8: arr[2, 1] = symbol; break;
                                        case 9: arr[2, 2] = symbol; break;
                                    }

                                    con = false;
                                }
                            }

                        }
                        catch
                        {
                            Console.WriteLine("enter only number");
                        }
                        disbord();
                    }
                    bool owin = win("O");
                    bool xwin = win("X");
                    if (owin)
                    {
                        Console.WriteLine("{0} wins!", player2);
                    }
                    else if (xwin)
                    {
                        Console.WriteLine("{0} wins!", player1);
                    }

                    if (i == 8)
                    {
                        if (!owin && !xwin)
                        {
                            Console.WriteLine("game is drow");
                            Console.WriteLine("enter to end game");
                            Console.ReadLine();
                            break;
                        }
                    }

                }

            }

            public bool win(string XO)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (arr[i, 0] == XO && arr[i, 1] == XO && arr[i, 2] == XO) return true;
                    if (arr[0, i] == XO && arr[1, i] == XO && arr[2, i] == XO) return true;
                }
                if (arr[0, 0] == XO && arr[1, 1] == XO && arr[2, 2] == XO) return true;
                if (arr[0, 2] == XO && arr[1, 1] == XO && arr[2, 0] == XO) return true;
                return false;
            }






            static void Main(string[] args)
            {
                player players = new player();
                game game = new game();
                game.fill();
                game.disbord();
                game.gameloop();

                Console.ReadLine();
            }

        }
    }
}