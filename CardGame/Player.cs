using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            GenerateRandomCards();
        }

        private void GenerateRandomCards()
        {
            for (int i = 0; i < 10; i++)
            {
                CardsInHand.Add(new Card() { Name = i.ToString() });
            }
        }

        public string Name { get; }
        public int Life { get; }

        public ICollection<Card> CardsInHand { get; } = new List<Card>();
        public ICollection<Card> ActiveCards { get; } = new List<Card>();
    }
}
