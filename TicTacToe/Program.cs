using TicTacToe;

namespace TicTacToe
{
    
    public class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1;
        static int moveCount = 0;

        public static void Main()
        {
            Console.Title = "Крестики-Нолики";
            Console.WriteLine("КРЕСТИКИ-НОЛИКИ");
            Console.WriteLine("\nИгрок 1: X | Игрок 2: O\n");
            Console.WriteLine("Для хода введите номер клетки (1-9)");
            Console.WriteLine("Нажмите любую клавишу для начала...");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                DrawBoard();
                GetPlayerMove();
                CheckGameStatus();
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" Крестики-Нолики\n");
            
            // Показываем, кто ходит
            if (currentPlayer == 1)
            {
                Console.WriteLine("Игрок 1 (X) ходит");
            }
            else
            {
                Console.WriteLine("Игрок 2 (O) ходит");
            }


            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine("     |     |     ");

                for (int col = 0; col < 3; col++)
                {
                    int index = row * 3 + col;
                    char cell = board[index];

                    if (col == 0)
                    {
                        Console.Write($"  {cell}  ");
                    }
                    else
                    {
                        Console.Write($"|  {cell}  ");
                    }
                }
                Console.WriteLine();

                if (row < 2)
                {
                    Console.WriteLine("_____|_____|_____");
                }
            }
            Console.WriteLine("     |     |     ");

        }

        static void GetPlayerMove()
        {
            int choice;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                if (currentPlayer == 1)
                {
                    Console.Write("\nИгрок 1 (X), выберите клетку (1-9): ");
                }
                else
                {
                    Console.Write("\nИгрок 2 (O), выберите клетку (1-9): ");
                }
                Console.ResetColor();

                string input = Console.ReadLine();

                // Проверяем, что введено число
                bool isNumber = int.TryParse(input, out choice);

                if (isNumber == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: введите число!");
                    Console.ResetColor();
                    continue;
                }

                // Проверяем, что число в диапазоне 1-9
                if (choice < 1 || choice > 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: введите число от 1 до 9!");
                    Console.ResetColor();
                    continue;
                }

                // Проверяем, что клетка не занята
                int index = choice - 1;
                if (board[index] == 'X' || board[index] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: эта клетка уже занята!");
                    Console.ResetColor();
                    continue;
                }

                // Если все проверки пройдены, делаем ход
                isValidInput = true;

                if (currentPlayer == 1)
                {
                    board[index] = 'X';
                }
                else
                {
                    board[index] = 'O';
                }

                moveCount = moveCount + 1;

                // Меняем игрока
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                }
                else
                {
                    currentPlayer = 1;
                }
            }
        }

        static void CheckGameStatus()
        {
            int winner = CheckWinner();

            if (winner == 1)
            {
                Console.Clear();
                DrawBoard();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n==============================");
                Console.WriteLine("   ПОЗДРАВЛЯЕМ! Игрок 1 ПОБЕДИЛ!");
                Console.WriteLine("==============================");
                Console.ResetColor();
                PlayAgain();
                return;
            }

            if (winner == 2)
            {
                Console.Clear();
                DrawBoard();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n==============================");
                Console.WriteLine("   ПОЗДРАВЛЯЕМ! Игрок 2 ПОБЕДИЛ!");
                Console.WriteLine("==============================");
                Console.ResetColor();
                PlayAgain();
                return;
            }

            if (moveCount == 9)
            {
                Console.Clear();
                DrawBoard();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n==============================");
                Console.WriteLine("        НИЧЬЯ!");
                Console.WriteLine("==============================");
                Console.ResetColor();
                PlayAgain();
            }
        }
        static int CheckWinner()
        {
            // Проверка горизонталей
            if (board[0] == board[1] && board[1] == board[2])
            {
                if (board[0] == 'X') return 1;
                if (board[0] == 'O') return 2;
            }
            if (board[3] == board[4] && board[4] == board[5])
            {
                if (board[3] == 'X') return 1;
                if (board[3] == 'O') return 2;
            }
            if (board[6] == board[7] && board[7] == board[8])
            {
                if (board[6] == 'X') return 1;
                if (board[6] == 'O') return 2;
            }

            // Проверка вертикалей
            if (board[0] == board[3] && board[3] == board[6])
            {
                if (board[0] == 'X') return 1;
                if (board[0] == 'O') return 2;
            }
            if (board[1] == board[4] && board[4] == board[7])
            {
                if (board[1] == 'X') return 1;
                if (board[1] == 'O') return 2;
            }
            if (board[2] == board[5] && board[5] == board[8])
            {
                if (board[2] == 'X') return 1;
                if (board[2] == 'O') return 2;
            }

            // Проверка диагоналей
            if (board[0] == board[4] && board[4] == board[8])
            {
                if (board[0] == 'X') return 1;
                if (board[0] == 'O') return 2;
            }
            if (board[2] == board[4] && board[4] == board[6])
            {
                if (board[2] == 'X') return 1;
                if (board[2] == 'O') return 2;
            }

            return 0;
        }
        
        static void PlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nХотите сыграть ещё? (y/n): ");
            Console.ResetColor();

            string answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")
            {
                // Сброс игры
                board[0] = '1';
                board[1] = '2';
                board[2] = '3';
                board[3] = '4';
                board[4] = '5';
                board[5] = '6';
                board[6] = '7';
                board[7] = '8';
                board[8] = '9';

                currentPlayer = 1;
                moveCount = 0;

                Console.Clear();
                DrawBoard();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nСпасибо за игру! До свидания!");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }
    }
}
    

