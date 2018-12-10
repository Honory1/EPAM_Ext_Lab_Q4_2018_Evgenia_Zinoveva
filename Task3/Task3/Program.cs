namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;  

    /// <summary>
    ///general Program
    /// </summary>
    public class Program 
    {
        /// <summary>
        /// Input Check
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>string</returns>
        public static int InputCheck(string input)
        {
            bool success = int.TryParse(input, out int taskNumber);

            while (!success)
            {
                Console.WriteLine("Ошибка. Введите числовое значение");//todo pn сильная связность (везде где используешь реальный Console, а не собственную реализацию через IConsole).
                success = int.TryParse(Console.ReadLine(), out taskNumber);
            }

            if (success)
            {
                while ((taskNumber > 13) || (taskNumber < 1))//todo pn хардкод (если количество заданий изменится?)
                {
                    Console.WriteLine("Ошибка. Введите значение от 1 до 13");
                    success = int.TryParse(Console.ReadLine(), out taskNumber);

                    while (!success)
                    {
                        Console.WriteLine("Ошибка. Введите числовое значение");
                        success = int.TryParse(Console.ReadLine(), out taskNumber);
                    }
                }
            }

            return taskNumber;
        }

        /// <summary>
        /// Select of the next action
        /// </summary>
        public static void SelectOfTheNextAction()
        {
            Console.WriteLine("\nSpace - для повтора задания " +
                "\nEnter - для выбора другого задания" +
                "\nEsc - для выхода из приложения");
        }

        /// <summary>
        /// Task selection
        /// </summary>
        /// <param name="taskNumber">task number</param>
        public static void TaskSelection(int taskNumber)
        {
            ConsoleKeyInfo cki;
            switch (taskNumber)
            {
                case 1:
                    {
                        do
                        {
                            Task1.RectAreaCalc();
                            SelectOfTheNextAction();
                            cki = Console.ReadKey();
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
                        }
                        while (cki.Key == ConsoleKey.Spacebar);
                        break;
                    }
            }
        }

        /// <summary>
        /// write log
        /// </summary>
        /// <param name="stackTrace">stack trace</param>
        /// <param name="message">error message</param>
        public static void Log(string stackTrace, string message)
        {
            var writer = new StreamWriter(@"C:\Users\HP\Desktop\Task3\Log1.log", true);//todo pn абсолютные пути - зло. Используй относительные. Проверяй на существование файла перед чтением и создавай, если его не нашлось. Функциональность по логированию - в отдельный класс
            writer.WriteLine("{0}: {1}\n {2}", DateTime.Now, message, stackTrace);
            writer.Close();
        }

        /// <summary>
        /// general method
        /// </summary>
        /// <param name="args">arg</param>
        public static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            try
            {               
                do
                {
                    Console.WriteLine("Введите номер задания от 1 до 13: ");
                    int taskNumber = InputCheck(Console.ReadLine());

                    TaskSelection(taskNumber);
                    cki = Console.ReadKey();
                }
                while (cki.Key == ConsoleKey.Enter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Извините, произошла ошибка");
                Log(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
