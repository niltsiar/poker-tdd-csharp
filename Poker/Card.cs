using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum CardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    };

    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    };

    public class Card
    {
        public CardValue Value { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
