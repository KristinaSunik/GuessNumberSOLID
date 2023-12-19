using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool anotherGame;
            int range, number;
            INotificationService notificationService = new ConsoleWriter();
            IValidator validator = new InputValidator(notificationService);
            IPlayGame playGame = new PlayGame(validator, notificationService);
            Random randomizer = new Random();

            do
            {                
                playGame.MainPlay(GamePart.Start, out range);
                number = randomizer.Next(range);
                playGame.MainPlay(GamePart.Guessing, out int rightNumber, number, range);

                anotherGame = playGame.GetAnswerUserWantsContinue();

            } while (anotherGame);

            Console.ReadKey();
        }
    }
}
