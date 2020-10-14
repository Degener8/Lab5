using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Lab5
{
    class Program
    {
        static void PrintTableRow(string x, int max_length)
        {
            int spaces_l_x, spaces_r_x;

            spaces_l_x = (max_length - x.Length) / 2;
            spaces_r_x = (max_length - x.Length) / 2;
            if ((max_length - x.Length) % 2 == 1)
                spaces_l_x++;

            Console.WriteLine($"{new string(' ', (Console.WindowWidth - max_length) / 2)}║{new string(' ', spaces_l_x)}{x}{new string(' ', spaces_r_x)}║");
        }

        static void PrintTable(List<string> numbers, int max_length)
        {
            Console.WriteLine($"{new string(' ', (Console.WindowWidth - max_length) / 2)}╔{new string('═', max_length)}╗");

            for (int i = 0; i < numbers.Count; i++)
                PrintTableRow(numbers[i], max_length);

            Console.WriteLine($"{new string(' ', (Console.WindowWidth - max_length) / 2)}╚{new string('═', max_length)}╝");
        }

        static int GetMaxLength(List<string> numbers)
        {
            int max_length = numbers[0].Length;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i].Length > max_length)
                    max_length = numbers[i].Length;
            }

            return max_length;
        }

        static int GetFactorial(int x)
        {
            int y = 1;

            for (int i = 2; i <= x; i++)
                y = y * i;

            if (x > 1)
                return y;
            else return x;
        }

        static List<string> GetInput()
        {
            List<string> numbers = new List<string>();
            string input;
            int number;
            ConsoleKeyInfo key_pressed;
            Console.WriteLine("Введите натуральные числа для вычисления их факториалов.");

            do
            {
                do
                {
                    Console.Write("Введите число: ");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out number) || Convert.ToInt32(input) < 0);
                numbers.Add(GetFactorial(number).ToString());
                Console.WriteLine("Чтобы ввести ещё одно число, нажмите пробел.");
                key_pressed = Console.ReadKey();
            }
            while (key_pressed.Key == ConsoleKey.Spacebar);


            return numbers;
        }

        static void Main(string[] args)
        {
            ConsoleColor[] colors = new ConsoleColor[16] {ConsoleColor.DarkBlue, ConsoleColor.Blue, ConsoleColor.Black, ConsoleColor.DarkGray,
                ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen, ConsoleColor.Green,
                ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.DarkCyan, ConsoleColor.Cyan};
            List<string> numbers = GetInput();
            
            for(int i = 0; i < colors.Length; i = (i + 1) % 16)
            {
                int g = (i + 4) % 16;
                Console.BackgroundColor = colors[i];
                Console.ForegroundColor = colors[g];
                Console.Clear();
                PrintTable(numbers, GetMaxLength(numbers));
                Thread.Sleep(125);
            }
        }
    }
}
