using System.Collections.Generic;
using System.Linq;
using Poker.Exceptions;

namespace Poker
{
    public class Hand
    {
        private readonly List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public IEnumerable<Card> Cards { get { return _cards; } }

        public void AddCard(Card card)
        {
            if (5 == _cards.Count)
                throw new TooManyCardsException();

            if (Cards.Any(tempCard => tempCard.Suit == card.Suit && tempCard.Value == card.Value))
            {
                throw  new DuplicatedCardException();
            }

            _cards.Add(card);
        }
    }
}
