using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public static class PlayGame
    {
        /// <summary>
        /// Взаимодействие с пользователем во время игры, пока он не отгадает число.
        /// </summary>
        public static void MainPlay(GamePart gamePart, out int checkedUserNumber, int number = 0, int range = 0)
        {
            bool stillGuessing = true;
            checkedUserNumber = -1;

            if (gamePart.Equals(GamePart.Start))
            {
                ConsoleWriter.PrintStartQuestion();
            }

            while (stillGuessing)
            {
                string userAnswer = Console.ReadLine();
                if (Validator.CheckIsNumber(userAnswer, out checkedUserNumber))
                {
                    if (!Validator.CheckIsInRange(gamePart, checkedUserNumber, range))
                    {
                        continue;
                    }                    

                    stillGuessing = GenerateAnswer(gamePart, checkedUserNumber, number);
                }
            }
        }

        /// <summary>
        /// Генерация ответа на ввод пользователя.
        /// </summary>
        /// <param name="gamePart">какая часть игры в данный момент</param>
        /// <param name="checkedUserNumber">проверенный ввод пользователя</param>
        /// <param name="number">загаданное число</param>
        /// <returns></returns>
        private static bool GenerateAnswer(GamePart gamePart, int checkedUserNumber, int number)
        {
            switch (gamePart)
            {
                case GamePart.Start:
                    ConsoleWriter.PrintAnswer(Answer.Ready, checkedUserNumber);
                    return false;
                case GamePart.Guessing:
                    if (CheckRightAnswer(checkedUserNumber, number))
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Запрос на новую игру.
        /// </summary>
        /// <returns>true - если еще раз сыграть</returns>
        public static bool GetAnswerUserWantsContinue()
        {
            ConsoleWriter.PrintTheReplayQuestion();

            while (true)
            {
                string userAnswer = Console.ReadLine().ToLower().Trim();
                if (Validator.CheckContinueAnswer(userAnswer, out bool checkedAnswer))
                {
                    return checkedAnswer;
                }

                ConsoleWriter.PrintError(ErrorType.WrongAnswer);
            }
        }

        /// <summary>
        /// Проверяет угадал ли пользователь число.
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
