using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public class PlayGame : IPlayGame
    {
        private int TriesCount;
        private IValidator Validator;
        private INotificationService ConsoleWriter;

        public PlayGame(IValidator validator, INotificationService notificationService)
        {
            Validator = validator;
            ConsoleWriter = notificationService;
        }

        public void PlaySettings(out int validRange)
        {
            validRange = -1;
            GamePart gamePart;
            bool waitRightAnswer = true;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    ConsoleWriter.PrintStartQuestion();
                    gamePart = GamePart.Start;
                }
                else
                {
                    ConsoleWriter.PrintTriesQuantityQuestion();
                    gamePart = GamePart.Settings;
                    waitRightAnswer = true;
                }

                while (waitRightAnswer)
                {
                    string userAnswer = Console.ReadLine();
                    if (Validator.CheckIsNumber(userAnswer, out int checkedUserNumber))
                    {
                        waitRightAnswer = GenerateAnswer(gamePart, checkedUserNumber);
                        if (gamePart.Equals(GamePart.Start))
                        {
                            validRange = checkedUserNumber;
                        }
                        else
                        {
                            TriesCount = checkedUserNumber;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Взаимодействие с пользователем во время игры, пока он не отгадает число.
        /// </summary>
        public void MainPlay(GamePart gamePart, int number = 0, int range = 0)
        {
            bool stillGuessing = true;

            while (stillGuessing)
            {
                string userAnswer = Console.ReadLine();
                if (Validator.CheckIsNumber(userAnswer, out int checkedUserNumber))
                {
                    if (!Validator.CheckIsInRange(gamePart, checkedUserNumber, range))
                    {
                        continue;
                    }
                    TriesCount--;
                    stillGuessing = GenerateAnswer(gamePart, checkedUserNumber, number);
                }
            }
        }

        /// <summary>
        /// Генерация ответа на ввод пользователя.
        /// </summary>
        /// <param name="gamePart">какая часть игры в данный момент</param>
        /// <param name="checkedUserNumber">проверенный ввод пользователя</param>
        /// <param name="RightNumber">загаданное число</param>
        /// <returns></returns>
        public bool GenerateAnswer(GamePart gamePart, int checkedUserNumber, int RightNumber = 0)
        {
            switch (gamePart)
            {
                case GamePart.Start:
                    ConsoleWriter.PrintAnswer(Answer.Ready, checkedUserNumber);
                    return false;
                case GamePart.Guessing:
                    if (CheckRightAnswer(checkedUserNumber, RightNumber))
                    {
                        return false;
                    }
                    return CheckTriesQuantity();
                case GamePart.Settings:
                    ConsoleWriter.PrintAnswer(Answer.HaveTries, checkedUserNumber);
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Запрос на новую игру.
        /// </summary>
        /// <returns>true - если еще раз сыграть</returns>
        public bool GetAnswerUserWantsContinue()
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
        public bool CheckRightAnswer(int checkedUserNumber, int number)
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

        /// <summary>
        /// Проверка количества использованных попыток.
        /// </summary>
        /// <returns>true если еще есть попытки</returns>
        public bool CheckTriesQuantity()
        {
            switch (TriesCount)
            {
                case 0:
                    ConsoleWriter.PrintError(ErrorType.OutOfTries);
                    return false;
                case 1:
                    ConsoleWriter.PrintError(ErrorType.LastTry);
                    return true;
                default:
                    return true;
            }
        }
    }
}
