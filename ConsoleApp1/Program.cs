using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_GuessNumberSOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool anotherGame = false;
            int range, number;

            do
            {
                Random randomizer = new Random();
                UserData.GetAndCheckNumber(GamePart.Start, out range);
                number = randomizer.Next(range);
                UserData.GetAndCheckNumber(GamePart.Guessing, out int rightNumber, number, range);
                anotherGame = UserData.GetAnswerUserWantsContinue();
            } while (anotherGame);

            Console.ReadKey();
        }
    }
}
