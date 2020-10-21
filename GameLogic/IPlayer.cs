using System.Collections.Generic;

namespace CardGame.GameLogic
{
    public interface IPlayer
    {
        IList<Card> ActiveCards { get; }
        IList<Card> CardsInHand { get; }
        int Life { get; }
        string Name { get; }

        void ApplyCard(Card card);
        void ChangeCard(int cardNumber, int placeNumber);
    }
}