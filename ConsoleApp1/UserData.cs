using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_GuessNumberSOLID
{
    public class UserData
    {
        /// <summary>
        /// Проверяет задаваемый диапазон числа, что введено числительное.
        /// Повторяет запрос на ввод, пока данные не будут корректны.
        /// </summary>
        public static void GetAndCheckNumber(GamePart gamePart, out int checkedUserNumber, int number = 0, int range = 0)
        {
            bool stillGuessing = true;
            checkedUserNumber = 0;

            if (gamePart.Equals(GamePart.Start))
            {
                ConsoleWriter.PrintStartQuestion();
            }

            while (stillGuessing)
            {
                string userAnswer = Console.ReadLine();
                if (!int.TryParse(userAnswer, out checkedUserNumber))
                {
                    ConsoleWriter.PrintError(ErrorType.NotInt);
                }
                else
                {
                    if (!gamePart.Equals(GamePart.Start) && (checkedUserNumber <= 0 || checkedUserNumber > range))
                    {
                        ConsoleWriter.PrintError(ErrorType.OutOfRange, range);
                    }

                    switch (gamePart)
                    {
                        case GamePart.Start:
                            ConsoleWriter.PrintAnswer(Answer.Ready, checkedUserNumber);
                            stillGuessing = false;
                            break;
                        case GamePart.Guessing:
                            if (CheckRightAnswer(checkedUserNumber, number))
                            {
                                stillGuessing = false;
                                break;
                            }
                            continue;
                        default:
                            break;
                    }
                }
            }
        }

        public static bool GetAnswerUserWantsContinue()
        {
            ConsoleWriter.PrintTheReplayQuestion();

            while (true)
            {
                string userAnswer = Console.ReadLine().ToLower().Trim();
                if (!string.IsNullOrEmpty(userAnswer) && 
                    (userAnswer.StartsWith("y") || userAnswer.StartsWith("n")))
                {
                    return userAnswer.StartsWith("y");
                }

                ConsoleWriter.PrintError(ErrorType.WrongAnswer);
            }
        }

        /// <summary>
        /// Проверяет число пользоватля в допустимом диапазоне.
        /// Повторяет правильный ли ответ.
        /// </summary>
        /// <returns> Возвращает true - если ответ правильный </returns>
        private static bool CheckRightAnswer(int checkedUserNumber, int number)
        {
            int result = number - checkedUserNumber;
            if (result == 0)
            {
                ConsoleWriter.PrintAnswer(Answer.Equal, checkedUserNumber);
                return true;
            }
            if (result < 0)
            {
                ConsoleWriter.PrintAnswer(Answer.Less, checkedUserNumber);
            }
            else
            {
                ConsoleWriter.PrintAnswer(Answer.Bigger, checkedUserNumber);
            }
           
            return false;

        }
    }
}
