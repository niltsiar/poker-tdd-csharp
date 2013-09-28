using System.Linq;
using NUnit.Framework;
using Poker;

namespace PokerTest
{
    [TestFixture]
    public class PokerTest
    {
        [Test(Description = "This test creates a card and checks its attributes")]
        public void CreateAndCheckACard(
            [Values(CardValue.Two, CardValue.Three, CardValue.Four, CardValue.Five, CardValue.Six,
                CardValue.Seven, CardValue.Eight, CardValue.Nine, CardValue.Ten,
                CardValue.Jack, CardValue.Queen, CardValue.King, CardValue.Ace)] CardValue value,
            [Values(CardSuit.Spades, CardSuit.Hearts, CardSuit.Diamonds, CardSuit.Clubs)] CardSuit suit)
        {
            var card = new Card(value, suit);
            Assert.AreEqual(value, card.Value);
            Assert.AreEqual(suit, card.Suit);
        }

        [Test(Description = "This test adds cards to a hand")]
        public void AddCardsToAHand()
        {
            var hand = new Hand();
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            hand.AddCard(card);
            Assert.AreEqual(1, hand.Cards.Count());
        }

        [Test(Description = "This test fails when adding more than 5 cards to a hand")]
        [ExpectedException("Poker.Exceptions.TooManyCardsException")]
        public void LaunchExceptionWhenAddingMoreThanFiveCards()
        {
            var hand = new Hand();
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            hand.AddCard(card);
            card = new Card(CardValue.Eight, CardSuit.Diamonds);
            hand.AddCard(card);
            card = new Card(CardValue.Five, CardSuit.Hearts);
            hand.AddCard(card);
            card = new Card(CardValue.Jack, CardSuit.Clubs);
            hand.AddCard(card);
            card = new Card(CardValue.King, CardSuit.Clubs);
            hand.AddCard(card);
            card = new Card(CardValue.Queen, CardSuit.Spades);
            hand.AddCard(card);
        }
    }
}
