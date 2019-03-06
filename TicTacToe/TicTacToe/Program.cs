using System;

namespace TicTacToe
{
    class Program
    {
        // Create an arry with 0-9 where no use of zero.
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //By default player 1 is set.
        static int player = 1;

        // Holds the choice which position the user want to mark.
        static int choice;

        // Checks who has won if the value is 1 some one has won the game, if it's -1 the game is a draw, if 0 the game is still running.
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                // Clears the console when the loop starts
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");

                // Checks the chance of the player
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }

                Console.WriteLine("\n");

                // Calling the GameBoard function.
                GameBoard();

                // Taking the users choice.
                choice = int.Parse(Console.ReadLine());

                // Checks if the position is marked (with X or O) or not.
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    // If chance is of player 2 then mark with O else mark with X.
                    if (player % 2 == 0) 
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else 
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds, board is loading again...");
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin();
            }

            // This loop will run until all cells in the grid is not marked with a X or an O or some player is not win.
            while (flag != 1 && flag != -1);

            // Clears the console.
            Console.Clear();

            // Fills the gameboard again.
            GameBoard();

            // If flag value is 1, the player who marked laste time has won.
            if(flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            // If flag value is -1, there is a draw and no one winns.
            else
            {
                Console.WriteLine("You are both losers");
            }

            Console.ReadLine();
        }

        // Creates the gameboard.
        private static void GameBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ",arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |     ");
        }

        // Checks if a player has won or not.
        private static int CheckWin()
        {
            #region Horizontal Winning Condition

            // Winning condition for first row.
            if(arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            // Winning condition for second row.
            else if(arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            // Winning condition for third row.
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }

            #endregion

            #region Vertical Winning Condition

            // Winning condition for first column.
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            // Winning condition for second column.
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            // Winning condition for third column.
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            #endregion

            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            // Winning condition for third column.
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            #endregion

            #region Check For Draw

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            #endregion

            else
            {
                return 0;
            }

        }
    }
}
