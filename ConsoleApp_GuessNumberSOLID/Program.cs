using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool anotherGame;
            int range, number;

            Random randomizer = new Random();

            INotificationService notificationService = new ConsoleWriter();
            IValidator validator = new InputValidator(notificationService);
            IPlayGame playGame = new PlayGame(validator, notificationService);

            do
            {
                playGame.PlaySettings(out range);
                number = randomizer.Next(range);
                playGame.MainPlay(GamePart.Guessing, number, range);

                anotherGame = playGame.GetAnswerUserWantsContinue();

            } while (anotherGame);

            Console.ReadKey();
        }
    }
}
