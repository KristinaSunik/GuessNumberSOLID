using System;

namespace ConsoleApp_GuessNumberSOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool anotherGame;
            int range, number;

            do
            {
                Random randomizer = new Random();
                PlayGame.MainPlay(GamePart.Start, out range);
                number = randomizer.Next(range);
                PlayGame.MainPlay(GamePart.Guessing, out int rightNumber, number, range);

                anotherGame = PlayGame.GetAnswerUserWantsContinue();

            } while (anotherGame);

            Console.ReadKey();
        }
    }
}
