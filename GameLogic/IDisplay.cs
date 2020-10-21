using CardGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public interface IDisplay
    {
        void WriteLine(string message);
        string ReadLine();
        void DisplayBoard(IPlayer player1, IPlayer player2);
    }
}
