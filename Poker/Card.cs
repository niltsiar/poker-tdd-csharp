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

    public class Card
    {
        public int Value { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(int value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
