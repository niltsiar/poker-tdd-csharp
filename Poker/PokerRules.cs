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
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush
        }

        public static PokerPlay CheckPlay(Hand hand)
        {
            if (5 > hand.Cards.Count())
                throw new NotEnoughCardsException();

            var play = PokerPlay.None;

            var countCardValues = GeneratePlayDictionary();
            foreach (var card in hand.Cards)
            {
                countCardValues[card.Value]++;
            }
            foreach (var source in countCardValues.Where(x => x.Value == 0).Select(x => x.Key).ToArray())
            {
                countCardValues.Remove(source);
            }

            if (IsStraightFlush(hand, countCardValues)) play = PokerPlay.StraightFlush;
            else if (IsFourOfAKind(countCardValues)) play = PokerPlay.FourOfAKind;
            else if (IsFullHouse(countCardValues)) play = PokerPlay.FullHouse;
            else if (IsFlush(hand)) play = PokerPlay.Flush;
            else if (IsStraight(countCardValues)) play = PokerPlay.Straight;
            else if (IsThreeOfAKind(countCardValues)) play = PokerPlay.ThreeOfAKind;
            else if (IsTwoPairs(countCardValues)) play = PokerPlay.TwoPair;
            else if (IsPair(countCardValues)) play = PokerPlay.Pair;

            return play;
        }

        private static Dictionary<CardValue, int> GeneratePlayDictionary()
        {
            var dictionary = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToDictionary(cardValue => cardValue, value => 0);
            return dictionary;
        }

        private static bool IsPair(Dictionary<CardValue, int> countCardValues)
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

        private static bool IsStraight(Dictionary<CardValue, int> countCardValues)
        {
            if (5 != countCardValues.Count) return false;

            var values = (from c in countCardValues.Keys
                          orderby c
                          select c).ToList();

            var straight = true;
            for (var i = 0; i < 4; i++)
            {
                if (values[i] + 1 == values[i + 1]) continue;
                straight = false;
                break;
            }

            if (!straight && countCardValues.ContainsKey(CardValue.Ace)) //Check for a low straight with an ace
            {
                straight = countCardValues.ContainsKey(CardValue.Ace) && countCardValues.ContainsKey(CardValue.Two)
                           && countCardValues.ContainsKey(CardValue.Three) && countCardValues.ContainsKey(CardValue.Four)
                           && countCardValues.ContainsKey(CardValue.Five);
            }

            return straight;
        }

        private static bool IsFullHouse(Dictionary<CardValue, int> countCardValues)
        {
            return IsThreeOfAKind(countCardValues) && IsPair(countCardValues);
        }

        private static bool IsFlush(Hand hand)
        {
            var kinds = (from c in hand.Cards
                         group c by c.Suit
                             into cs
                             select cs).Count();

            return 1 == kinds;
        }

        private static bool IsFourOfAKind(Dictionary<CardValue, int> countCardValues)
        {
            return countCardValues.Any(count => count.Value == 4);
        }

        private static bool IsStraightFlush(Hand hand, Dictionary<CardValue, int> countCardValues)
        {
            return IsFlush(hand) && IsStraight(countCardValues);
        }
    }
}
