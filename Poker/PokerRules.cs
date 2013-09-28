using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Exceptions;

namespace Poker
{
    public static class PokerRules
    {
        public enum PokerPlay
        {
            None,
            Pair,
            TwoPair
        }

        public static PokerPlay CheckPlay(Hand hand)
        {
            if (5 > hand.Cards.Count())
                throw new NotEnoughCardsException();

            var countCardValues = GeneratePlayDictionary();
            foreach (var card in hand.Cards)
            {
                countCardValues[card.Value]++;
            }

            var pairs = countCardValues.Values.Count(value => 2 == value);

            var play = PokerPlay.None;
            switch (pairs)
            {
                case 2:
                    play = PokerPlay.TwoPair;
                    break;
                case 1:
                    play = PokerPlay.Pair;
                    break;
            }

            return play;
        }

        private static Dictionary<CardValue, int> GeneratePlayDictionary()
        {
            var dictionary = Enum.GetValues(typeof (CardValue)).Cast<CardValue>().ToDictionary(cardValue => cardValue, value => 0);
            return dictionary;
        }
    }
}
