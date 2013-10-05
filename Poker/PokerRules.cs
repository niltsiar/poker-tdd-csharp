using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ThreeOfAKind,
            Straight
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
            if (IsAStraight(countCardValues)) play = PokerPlay.Straight;
            if (IsThreeOfAKind(countCardValues)) play = PokerPlay.ThreeOfAKind;
            else if (IsTwoPairs(countCardValues)) play = PokerPlay.TwoPair;
            else if (IsAPair(countCardValues)) play = PokerPlay.Pair;

            return play;
        }

        private static Dictionary<CardValue, int> GeneratePlayDictionary()
        {
            var dictionary = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToDictionary(cardValue => cardValue, value => 0);
            return dictionary;
        }

        private static bool IsAPair(Dictionary<CardValue, int> countCardValues)
        {
            return 1 == countCardValues.Values.Count(value => 2 == value);
        }

        private static bool IsTwoPairs(Dictionary<CardValue, int> countCardValues)
        {
            return 2 == countCardValues.Values.Count(value => 2 == value);
        }

        private static bool IsThreeOfAKind(Dictionary<CardValue, int> countCardValues)
        {
            return countCardValues.Any(count => count.Value == 3);
        }

        private static bool IsAStraight(Dictionary<CardValue, int> countCardValues)
        {
            if (5 != countCardValues.Count) return false;

            var values = (from c in countCardValues.Keys
                         orderby c
                         select c).ToArray();

            var straight = true;
            for (var i = 0; i < values.Count() - 1; i++)
            {
                if (values[i] + 1 == values[i + 1]) continue;
                straight = false;
                break;
            }

            return straight;
        }
    }
}
