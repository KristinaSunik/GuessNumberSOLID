using System;

namespace ConsoleApp_GuessNumberSOLID
{
    /// <summary>
    /// Вывод сообщений на консоль
    /// </summary>
    public class ConsoleWriter : INotificationService
    {
        public void PrintStartQuestion()
        {
            Console.WriteLine("Привет, поиграем?!" + Environment.NewLine + 
                "Угадай число, что я тебе загадаю!" + Environment.NewLine + 
                "В каком диапазоне загадать число, от нуля до скольки?");
        }

        public void PrintAnswer(Answer answer, int number) 
        {
            switch (answer)
            {
                case Answer.Less:
                    Console.WriteLine($"Нет, загаданное чилсло меньше {number}.");
                    break;
                case Answer.Bigger:
                    Console.WriteLine($"Нет, загаданное чилсло больше {number}.");
                    break;
                case Answer.Equal:
                    Console.WriteLine($"Поздравляю! Загаданное чилсло {number}.");
                    break;
                case Answer.Ready:
                    Console.WriteLine($"Я загадала число от 0 до {number}, попробуй угадай его.");
                    break;
                default:
                    Console.WriteLine("Что-то пошло не так... Я больше не могу с вами играть.");
                    break;
            }
        }


        public void PrintError(ErrorType errorType, int number = 0)
        {
            switch (errorType)
            {
                case ErrorType.NotInt:
                    Console.WriteLine("Можно вводить только числа.");
                    break;
                case ErrorType.OutOfRange:
                    Console.WriteLine($"Числа должны быть от 0 до {number}");
                    break;
                case ErrorType.WrongAnswer:
                    Console.WriteLine($"Ответ должен быть : y (yes) или n (no)");
                    break;
                default:
                    Console.WriteLine("Что - то пошло не так... Я больше не могу с вами играть.");
                    break;
            }
        }

        public void PrintTheReplayQuestion()
        {
            Console.WriteLine("Повторим? Y/N");
        }
    }
}
