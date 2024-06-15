using System;

namespace TicTacToeConsole
{
    class Program
    {
        static void DisplayBoard(string[] board, string playerHuman)
        {
            Console.Clear();
            if (CheckWin(board))
            {
                Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
                Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
                Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
                return;
            }

            System.Console.WriteLine($"You are {playerHuman}");
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]} 1|2|3");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]} 4|5|6");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]} 7|8|9");
        }
        static (string, string) SelectPlayer()
        {
            Console.WriteLine("Choose 'X' or 'O'");
            string playerHuman = "";
            string playerAi = "";
            while (true)
            {
                playerHuman = Console.ReadLine();

                switch (playerHuman)
                {
                    case "X":
                        playerHuman = "X";
                        playerAi = "O";
                        return (playerHuman, playerAi);
                    case "O":
                        playerHuman = "O";
                        playerAi = "X";
                        return (playerHuman, playerAi);
                    default:
                        Console.WriteLine("Wrong Command! Choose X or O");
                        break;
                }
            }
        }
        static string[] HumanTurn(string[] board, string playerHuman)
        {
            Console.WriteLine("Choose a cell 1-9");
            while (true)
            {
                int cell = int.Parse(Console.ReadLine());
                if (cell >= 1 && cell <= 9)
                {
                    if (board[cell - 1] == "-")
                    {
                        board[cell - 1] = playerHuman;
                        return board;
                    }
                    else
                    {
                        Console.WriteLine("That place is occupied");
                    }
                }
                else
                {
                    Console.WriteLine("Choose a number between 1-c9");
                }

            }
        }
        static string[] AiTurn(string[] board, string playerAi)
        {
            Random random = new Random();
            while (true)
            {
                int cell = random.Next(1, 10);

                if (board[cell - 1] == "-")
                {
                    board[cell - 1] = playerAi;
                    return board;
                }
            }
        }
        static bool CheckWin(string[] board)
        {
            /*Check Rows*/
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == board[i + 1] && board[i] == board[i + 2] && board[i] != "-")
                {
                    Console.WriteLine($"'{board[i]}' wins!");
                    return true;
                }
            }
            /*Check Columns*/
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i] == board[i + 6] && board[i] != "-")
                {
                    Console.WriteLine($"'{board[i]}' wins!");
                    return true;
                }
            }
            /*Check Diagonals*/
            if (board[0] == board[4] && board[0] == board[8] && board[0] != "-")
            {
                Console.WriteLine($"'{board[0]}' wins!");
                return true;
            }
            else if (board[2] == board[4] && board[2] == board[6] && board[2] != "-")
            {
                Console.WriteLine($"'{board[2]}' wins!");
                return true;
            }
            else if (!board.Contains("-"))
            {
                Console.WriteLine("It's a tie!");
                return true;
            }

            return false;
        }
        static void Main()
        {
            string[] board = {"-","-","-",
            "-","-","-",
            "-","-","-",};
            (string playerHuman, string playerAi) = SelectPlayer();

            while (true)
            {
                if (playerHuman == "X")
                {
                    DisplayBoard(board, playerHuman);

                    if (CheckWin(board))
                    {
                        break;
                    }
                    board = HumanTurn(board, playerHuman);

                    if (CheckWin(board))
                    {
                        break;
                    }
                    board = AiTurn(board, playerAi);
                }
                else if (playerHuman == "O")
                {
                    if (CheckWin(board))
                    {
                        break;
                    }
                    board = AiTurn(board, playerAi);

                    DisplayBoard(board, playerHuman);

                    if (CheckWin(board))
                    {
                        break;
                    }
                    board = HumanTurn(board, playerHuman);
                }
            }
            DisplayBoard(board, playerHuman);
        }
    }
}