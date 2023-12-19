namespace ConsoleApp_GuessNumberSOLID
{
    public interface IValidator
    {
        bool CheckIsNumber(string userAnswer, out int checkedUserNumber);

        bool CheckContinueAnswer(string userAnswer, out bool checkedAnswer);

        bool CheckIsInRange(GamePart gamePart, int checkedUserNumber, int range);
    }
}