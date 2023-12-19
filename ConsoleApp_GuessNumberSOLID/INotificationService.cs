
namespace ConsoleApp_GuessNumberSOLID
{
    public interface INotificationService
    {
        void PrintStartQuestion();

        void PrintTriesQuantityQuestion();

        void PrintAnswer(Answer answer, int number);

        void PrintError(ErrorType errorType, int number = 0);

        void PrintTheReplayQuestion();
    }
}
