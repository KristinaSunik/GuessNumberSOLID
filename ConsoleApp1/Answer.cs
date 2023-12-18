using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_GuessNumberSOLID
{
    public enum Answer
    {
        Less,
        Bigger,
        Equal,
        Ready
    }

    public enum GamePart
    {
        Start,
        Guessing
    }

    public enum ErrorType
    {
        NotInt,
        OutOfRange,
        WrongAnswer
    }
}
