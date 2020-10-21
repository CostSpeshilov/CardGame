using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.GameLogic
{
    public class Player : IPlayer
    {
        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
            GenerateRandomCards();
        }

        private void GenerateRandomCards()
        {
            for (int i = 0; i < 10; i++)
            {
                CardsInHand.Add(new Card() { Name = i.ToString(), AttackValue = 10, Type = CardType.Attack });
            }
            for (int i = 0; i < 5; i++)
            {
                ActiveCards.Add(new EmptyCard());
            }
        }

        public string Name { get; }
        public int Life { get; private set; } = 100;

        public IList<Card> CardsInHand { get; } = new List<Card>();
        public IList<Card> ActiveCards { get; } = new List<Card>();

        public void ApplyCard(Card card)
        {
            if (card.Type == CardType.Attack)
            {
                Life -= card.AttackValue;
            }
            else
            {
                Life += card.AttackValue;
            }
        }

        public void ChangeCard(int cardNumber, int placeNumber)
        {
            Card card = CardsInHand[cardNumber];
            ActiveCards[placeNumber] = card;
            CardsInHand.Remove(card);
        }
    }
}
