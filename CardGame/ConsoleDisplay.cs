using CardGame.GameLogic;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class ConsoleDisplay : IDisplay
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public void DisplayBoard(Player player1, Player player2)
        {
            ShowPlayerCards(player1);
            Console.WriteLine();

            ShowActiveCardsWithNullObjects(player1);

            Console.WriteLine();

            ShowActiveCardsWithNullObjects(player2);

            Console.WriteLine();

            ShowPlayerCards(player2);
        }
        private void ShowActiveCardsWithNullObjects(Player player1)
        {
            foreach (var card in player1.ActiveCards)
            {
                Console.Write(card.Name);
                Console.Write("\t");
            }
        }
        private void ShowPlayerCards(Player player)
        {
            Console.WriteLine($"Карты игрока : {player.Name}");
            foreach (var card in player.CardsInHand)
            {
                Console.Write(card.Name);
                Console.Write("\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
