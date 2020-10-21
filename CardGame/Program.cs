using System;
using CardGame.GameLogic;
using System.Linq;
using GameLogic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IDisplay display = new ConsoleDisplay();
            Game Game = new Game(display);
            Game.StartGameProcess();
        }
    }
}
