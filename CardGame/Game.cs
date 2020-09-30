using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Game
    {
        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            field = new Field();
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player CurrentPlayer { get; }


        private readonly Field field;
        public Field Field { get => field; }
    }
}
