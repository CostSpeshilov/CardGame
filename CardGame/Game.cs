using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    /// <summary>
    /// Представляет собой одну партию в игре
    /// </summary>
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

        public bool GameOver
        {
            get
            {
                return Player1.Life <= 0 || Player2.Life <= 0;
            }
        }

        public Player CurrentPlayer { get; private set; }

        private readonly Field field;
        public Field Field => field;

        public void StartGameProcess()
        {
            CurrentPlayer = Player1;
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
