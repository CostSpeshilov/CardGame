using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    /// <summary>
    /// Представляет собой одну партию в игре
    /// </summary>
    public class Game
    {
        IDisplay display;
        public Game(IDisplay display)
        {
            this.display = display;
            field = new Field();
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public bool GameOver
        {
            get
            {
                return Player1.Life <= 0 || Player2.Life <= 0;
            }
        }

        public Player CurrentPlayer { get; private set; }

        private readonly Field field;
        Field Field => field;

        public void StartGameProcess()
        {
            Player player1 = new Player("Первый игрок");
            Player player2 = new Player("Второй игрок");

            CurrentPlayer = Player1;

            while (!GameOver)
            {
                display.DisplayBoard(Player1, Player2);
                display.WriteLine($"Ходит игрок {CurrentPlayer.Name}, {CurrentPlayer.Life}");

                display.WriteLine("Введите номер карты, которой хотите походить");
                if (int.TryParse(display.ReadLine(), out int cardNumber))
                {
                    display.WriteLine("Введите номер места, на которое хотите походить");
                    if (int.TryParse(display.ReadLine(), out int placeNumber))
                    {
                        MakeMove(cardNumber, placeNumber);
                    }
                }
            }
        }

        Random random = new Random();
        private void GetNewCard()
        {
            CardType type;
            if (random.NextDouble() > 0.5)
            {
                type = CardType.Attack;
            }
            else
            {
                type = CardType.Defence;
            }
            var attVal = random.Next(0, 10);
            Card newCard = new Card() { Type = type, AttackValue = attVal, Name = $"{type}:{attVal}"};

            CurrentPlayer.CardsInHand.Add(newCard);
        }

        internal void MakeMove(int cardNumber, int placeNumber)
        {
            ChangeCard(cardNumber, placeNumber);
            ApplyCardEffects();
            GetNewCard();
            ChangePlayer();
        }

        private void ChangeCard(int cardNumber, int placeNumber)
        {
            CurrentPlayer.ChangeCard(cardNumber, placeNumber);
        }

        private void ApplyCardEffects()
        {
            ApplyCardsToPlayer(Player1, Player2);
            ApplyCardsToPlayer(Player2, Player1);
        }

        private void ApplyCardsToPlayer(Player first, Player second)
        {
            foreach (var card in first.ActiveCards.Where(x => x.Type == CardType.Attack))
            {
                second.ApplyCard(card);
            }
            foreach (var card in first.ActiveCards.Where(x => x.Type == CardType.Defence))
            {
                first.ApplyCard(card);
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Player1)
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
        }
    }
}
