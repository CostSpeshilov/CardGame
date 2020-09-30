using System;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static Game Game;
        static void Main(string[] args)
        {
            Player player1 = new Player("Первый игрок");
            Player player2 = new Player("Второй игрок");
            Game = new Game(player1, player2);

            ShowPlayerCards(player1);

            for (int i = 0; i < 4; i++)
            {
                player1.ActiveCards.Add(new EmptyCard()); 
            }
            player1.ActiveCards.Add(new Card() { Name = "10" });

            Console.WriteLine($"Разыгранные карты: {player1}");
            foreach (var card in player1.ActiveCards)
            {
                Console.Write(card.Name);
                Console.Write("\t");
            }
            //for (int i = player1.ActiveCards.Count(); i < 5; i++)
            //{
            //    Console.Write("ПК");
            //    Console.Write("\t");
            //}
            Console.WriteLine();
            Console.WriteLine();

            ShowPlayerCards(player2);
        }

        private static void ShowPlayerCards(Player player)
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
