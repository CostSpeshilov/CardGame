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

            Game.StartGameProcess();

            while (!Game.GameOver)
            {
                DisplayBoard(player1, player2);
                Console.WriteLine($"Ходит игрок {Game.CurrentPlayer.Name}, {Game.CurrentPlayer.Life}");

                Console.WriteLine("Введите номер карты, которой хотите походить");
                if (int.TryParse(Console.ReadLine(), out int cardNumber))
                {
                    Console.WriteLine("Введите номер места, на которое хотите походить");
                    if (int.TryParse(Console.ReadLine(), out int placeNumber))
                    {
                        Game.MakeMove(cardNumber, placeNumber);
                    }
                }
            }
            
        }

        private static void DisplayBoard(Player player1, Player player2)
        {
            ShowPlayerCards(player1);
            Console.WriteLine();

            ShowActiveCardsWithNullObjects(player1);

            Console.WriteLine();

            ShowActiveCardsWithNullObjects(player2);

            Console.WriteLine();

            ShowPlayerCards(player2);
        }

        private static void ShowActiveCardsWithNullObjects(Player player1)
        {
            foreach (var card in player1.ActiveCards)
            {
                Console.Write(card.Name);
                Console.Write("\t");
            }
        }

        private static void ShowActiveCardsWithoutNullObjects(Player player1)
        {
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
