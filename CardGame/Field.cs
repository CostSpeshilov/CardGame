using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Field
    {
        IEnumerable<Card> Player1ActiveCards { get; }
        IEnumerable<Card> Player2ActiveCards { get; }
    }
}
