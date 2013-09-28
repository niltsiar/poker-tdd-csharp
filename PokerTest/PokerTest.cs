using System.Linq;
using NUnit.Framework;
using Poker;

namespace PokerTest
{
    [TestFixture]
    public class PokerTest
    {
        private Hand _hand;

        [SetUp]
        public void TestInit()
        {
            _hand = new Hand();
        }

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
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card);
            Assert.AreEqual(1, _hand.Cards.Count());
        }

        [Test(Description = "This test fails when adding more than 5 cards to a hand")]
        [ExpectedException("Poker.Exceptions.TooManyCardsException")]
        public void LaunchExceptionWhenAddingMoreThanFiveCards()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card);
            card = new Card(CardValue.Eight, CardSuit.Diamonds);
            _hand.AddCard(card);
            card = new Card(CardValue.Five, CardSuit.Hearts);
            _hand.AddCard(card);
            card = new Card(CardValue.Jack, CardSuit.Clubs);
            _hand.AddCard(card);
            card = new Card(CardValue.King, CardSuit.Clubs);
            _hand.AddCard(card);
            card = new Card(CardValue.Queen, CardSuit.Spades);
            _hand.AddCard(card);
        }

        [Test(Description = "This test fails when adding a duplicate card to a hand")]
        [ExpectedException("Poker.Exceptions.DuplicatedCardException")]
        public void LaunchExcentionWhenAddingDuplicatedCard()
        {
            var card1 = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card1);
            var card2 = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card2);
        }
    }
}
