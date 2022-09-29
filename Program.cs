using System;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PrintStartMessage();
                ConsoleCommandLogic(ReadLine(), false);
                PrintCondition(true);
                ConsoleCommandLogic(ReadLine(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static string ReadLine()
        {
            return Console.ReadLine() ?? "";
        }
        static void PrintStartMessage()
        {
            Console.WriteLine("Homework number 3 consists of 3 tasks.");
            Console.WriteLine("During execution, the number of available commands changes.");
            Console.WriteLine("Enter \"Help\" for more help, " +
                "\"Exit\" to exit the program. \nPress\"Enter\" to continued...");
            Console.WriteLine();
        }
        static void ConsoleCommandLogic(string console_command, bool enable_tasks)
        {
            switch (console_command.ToUpper())
            {
                case "HELP":
                    PrintAllCommands(enable_tasks);
                    ConsoleCommandLogic(ReadLine(), enable_tasks);
                    break;

                case "AUTHOR":
                    PrintAuthor();
                    ConsoleCommandLogic(ReadLine(), enable_tasks);
                    break;

                case "CONDITION":
                    PrintCondition(false);
                    ConsoleCommandLogic(ReadLine(), enable_tasks);
                    break;

                case "EXIT":
                    throw new Exception("Thank you for using my program.\nExit from the program");

                case "":
                    if (enable_tasks)
                    {
                        goto default;
                    }
                    break;

                default:
                    ChoiseHomework(console_command, enable_tasks);
                    ConsoleCommandLogic(ReadLine(), enable_tasks);
                    break;
            }
        }
        static void PrintCondition(bool data_entry_message)
        {
            Console.WriteLine();
            Console.WriteLine("Task 1:");
            Console.WriteLine("Using a loop with a postcondition, " +
                "display a sequence of numbers on the screen in a column: -20, -40, ..., -100.");
            Console.WriteLine("Task 2:");
            Console.WriteLine("Using a loop with a counter, " +
                "display all two-digit numbers that are multiples of 5 on one line.");
            Console.WriteLine("Task 3:");
            Console.WriteLine("Find the arithmetic mean and the sum of all integers from a to b inclusive.\n");
            if (data_entry_message)
            {
                Console.WriteLine("Enter the number of the task \"1\", \"2\" or \"3\" you want to view: ");
            }
            Console.WriteLine();
        }
        static void ChoiseHomework(string num_task, bool enable_tasks)
        {
            Console.WriteLine();

            if (enable_tasks)
            {
                switch (num_task)
                {
                    case "1":
                        Task_1();
                        break;
                    case "2":
                        Task_2();
                        break;
                    case "3":
                        Task_3();
                        break;
                    default:
                        Console.WriteLine("Unknown command entered, type \"help\" to see commands");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Unknown command entered, type \"help\" to see commands");
            }

            Console.WriteLine();

        }
        static void PrintAllCommands(bool enable_tasks)
        {
            Console.WriteLine();
            Console.WriteLine("\"Author\" - find out whose work");
            Console.WriteLine("\"Condition\" - show task condition");
            Console.WriteLine("\"Exit\" - exit from the program");
            if (enable_tasks)
            {
                Console.WriteLine("\"1\" - viev task 1");
                Console.WriteLine("\"2\" - viev task 2");
                Console.WriteLine("\"3\" - viev task 3");
            }
            else
            {
                Console.WriteLine("Press \"Enter\" - to continued...");
            }
            Console.WriteLine();
        }
        static void PrintAuthor()
        {
            Console.WriteLine();
            Console.WriteLine("Author - Mosolevski Andrey");
            Console.WriteLine();
        }
        static void Task_1()
        {
            Console.WriteLine();
            Console.WriteLine("Task 1:");
            sbyte number = -20;
            do
            {
                Console.WriteLine(number);
                number -= 20;
            }
            while (number >= -100);
            Console.WriteLine();
        }
        static void Task_2()
        {
            Console.WriteLine();
            Console.WriteLine("Task 2:");

            for (int number = -95; number < 100; number++)
            {
                int convert = number;
                if (number < 0)
                {
                    convert = number * -1;
                }
                if (number % 5 == 0 && (convert / 10) > 0)
                {
                    
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }
        static void Task_3()
        {
            Console.WriteLine();
            Console.WriteLine("Task 3:");

            ConsoleDataConverter consoleData = new();

            int number_1, number_2, number_3;
            int count = 0;
            int sum = 0;
            double mid;

            try
            {
                number_1 = consoleData.ConversionToInt();
                number_2 = consoleData.ConversionToInt();

                if (number_1 > number_2)
                {
                    number_3 = number_1;
                    number_1 = number_2;
                    number_2 = number_3;
                }

                for (int i = number_1; i <= number_2; i++, count++)
                {
                    checked { sum += i; }
                }

                mid = (double)sum / count;

                Console.WriteLine($"The sum of all integers in the range " +
                    $"from {number_1} to {number_2}: {sum}");
                Console.WriteLine($"Arithmetical mean: {mid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

        }
        class ConsoleDataConverter
        {
            int count_number = 0;
            public int ConversionToInt()
            {
                int verified_number = 0;
                bool isNumber = false;
                count_number++;

                while (!isNumber)
                {
                    Console.WriteLine($"Enter the number \"{count_number}\": ");
                    isNumber = int.TryParse(Console.ReadLine(), out verified_number);
                    if (!isNumber)
                    {
                        Console.WriteLine("Invalid data, you need to enter a number");
                    }
                }
                Console.WriteLine($"Number \"{count_number}\": {verified_number}\n");

                return verified_number;
            }
        }
    }
}
