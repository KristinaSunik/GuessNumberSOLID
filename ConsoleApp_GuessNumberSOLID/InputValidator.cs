
using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public class InputValidator: IValidator
    {
        private INotificationService ConsoleWriter;

        public InputValidator(INotificationService notificationService) 
        {
            ConsoleWriter = notificationService;
        }

        /// <summary>
        /// Проверяет вводимое пользователем число, что это числительное.
        /// </summary>
        public bool CheckIsNumber(string userAnswer, out int checkedUserNumber)
        {
            if (int.TryParse(userAnswer, out checkedUserNumber))
            {
                return true;
            }

            ConsoleWriter.PrintError(ErrorType.NotInt);

            return false;
        }


        /// <summary>
        /// Проверяет вводимое пользователем число, что оно в заданном диапазоне.
        /// </summary>
        public bool CheckIsInRange(GamePart gamePart, int checkedUserNumber, int range)
        {
            if (!gamePart.Equals(GamePart.Start) && (checkedUserNumber <= 0 || checkedUserNumber > range))
            {
                ConsoleWriter.PrintError(ErrorType.OutOfRange, range);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка ответа пользователя на запрос о новой игре.
        /// </summary>
        /// <returns>true - если ответ валидный </returns>
        public bool CheckContinueAnswer(string userAnswer, out bool checkedAnswer)
        {
            checkedAnswer = false;

            if (!string.IsNullOrEmpty(userAnswer) &&
                    (userAnswer.StartsWith("y") || userAnswer.StartsWith("n")))
            {
                checkedAnswer = userAnswer.StartsWith("y");
                return true;
            }

            return false;
        }
    }
}
