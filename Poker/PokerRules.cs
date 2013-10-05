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
            TwoPair,
            ThreeOfAKind
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
            foreach (var source in countCardValues.Where(x => x.Value == 0).Select(x => x.Key).ToArray())
            {
                countCardValues.Remove(source);
            }

            var play = PokerPlay.None;
            if (isThreeOfAKind(countCardValues)) play = PokerPlay.ThreeOfAKind;
            else if (isTwoPairs(countCardValues)) play = PokerPlay.TwoPair;
            else if (isPair(countCardValues)) play = PokerPlay.Pair;

            return play;
        }

        private static Dictionary<CardValue, int> GeneratePlayDictionary()
        {
            var dictionary = Enum.GetValues(typeof (CardValue)).Cast<CardValue>().ToDictionary(cardValue => cardValue, value => 0);
            return dictionary;
        }

        private static bool isPair(Dictionary<CardValue, int> countCardValues)
        {
            return 1 == countCardValues.Values.Count(value => 2 == value);
        }

        private static bool isTwoPairs(Dictionary<CardValue, int> countCardValues)
        {
            return 2 == countCardValues.Values.Count(value => 2 == value);
        }

        private static bool isThreeOfAKind(Dictionary<CardValue, int> countCardValues)
        {
            return countCardValues.Any(count => count.Value == 3);
        }
    }
}
