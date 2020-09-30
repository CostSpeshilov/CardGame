using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Card
    {
        public CardType Type { get; set; }
        public virtual string Name { get; set; }

        public int AttackValue { get; set; }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
