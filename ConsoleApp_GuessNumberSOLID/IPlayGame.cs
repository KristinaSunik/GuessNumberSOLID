namespace ConsoleApp_GuessNumberSOLID
{
    public interface IPlayGame
    {
        void PlaySettings(out int range);

        void MainPlay(GamePart gamePart, int number = 0, int range = 0);

        bool GenerateAnswer(GamePart gamePart, int checkedUserNumber, int number);

        bool GetAnswerUserWantsContinue();

        bool CheckRightAnswer(int checkedUserNumber, int number);

        bool CheckTriesQuantity();
    }
}