namespace ConsoleApp_GuessNumberSOLID
{
    public interface IPlayGame
    {
        void MainPlay(GamePart gamePart, out int checkedUserNumber, int number = 0, int range = 0);

        bool GenerateAnswer(GamePart gamePart, int checkedUserNumber, int number);

        bool GetAnswerUserWantsContinue();

        bool CheckRightAnswer(int checkedUserNumber, int number);
    }
}