namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;  

    public class Program 
    {
        public static int InputCheck(string input)
        {
            bool success = int.TryParse(input, out int taskNumber);

            while (!success)
            {
                Console.WriteLine("Ошибка. Введите числовое значение");                success = int.TryParse(Console.ReadLine(), out taskNumber);
            }

            if (success)
            {
                while ((taskNumber > 13) || (taskNumber < 1))//todo pn хардкод (если количество заданий изменится?)
                {
                    Console.WriteLine("Error. Please enter a value from 1 to 13:");
                    success = int.TryParse(Console.ReadLine(), out taskNumber);

                    while (!success)
                    {
                        Console.WriteLine("Error. Please enter a numeric value:");
                        success = int.TryParse(Console.ReadLine(), out taskNumber);
                    }
                }
            }

            return taskNumber;
        }

        public static void SelectOfTheNextAction()
        {
            Console.WriteLine("\nPress the key 'Space' to repeat the task " +
                "\nPress the key 'Enter' to select another task" +
                "\nPress the key 'Esc' to exit the application");
        }
        
        public static void TaskSelection()
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("Enter the task number from 1 to 13: ");
            int taskNumber = InputCheck(Console.ReadLine());
            switch (taskNumber)
            {
                case 1:
                    {
                        do
                        {
                            Task1.RectAreaCalc();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 2:
                    {
                        do
                        {
                            Task2.DrawImg();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 3:
                    {
                        do
                        {
                            Task3.DrawImg();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 4:
                    {
                        do
                        {
                            Task4.DrawImg();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 5:
                    {
                        do
                        {
                            Task5.CalcTheSum();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 6:
                    {
                        do
                        {
                            Task6.TextLabelSelect();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 7:
                    {
                        do
                        {
                            Task7.SortArr();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 8:
                    {
                        do
                        {
                            Task8.SortArr();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 9:
                    {
                        do
                        {
                            Task9.CalcSumElement();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 10:
                    {
                        do
                        {
                            Task10.CalcTheSumOfEvenElements();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 11:
                    {
                        do
                        {
                            Task11.DetermineAverageWordLength();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 12:
                    {
                        do
                        {
                            Task12.DoubleCharacters();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }

                case 13:
                    {
                        do
                        {
                            Task13.ComparativeAnalysis();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                TaskSelection();
                            }
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }
            }
        }
        
        public static void Log(Exception ex)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(pathToLog))
            {
                Directory.CreateDirectory(pathToLog);
            }

            writer.WriteLine("{0}: {1}\n {2}", DateTime.Now, message, stackTrace);            writer.Close();
        }
        
        public static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            try
            {               
                do
                {
                    TaskSelection();
                    cki = Console.ReadKey();
                }
                while (cki.Key == ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an error occurred.");
                Log(ex);
                throw;
            }
        }
    }
}
