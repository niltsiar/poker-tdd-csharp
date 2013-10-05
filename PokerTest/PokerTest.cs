using NUnit.Framework;
using Poker;

namespace PokerTest
{
    [TestFixture]
    public class PokerTest
    {
        private Hand _hand;

        [SetUp]
        public void InitTests()
        {
            _hand = new Hand();
        }

        [Test(Description = "This test fails when trying to check a play and there is no cards in the hand")]
        [ExpectedException("Poker.Exceptions.NotEnoughCardsException")]
        public void LaunchExceptionWhenNotEnoughCardsToPlay()
        {
            PokerRules.CheckPlay(_hand);
        }

        [Test(Description = "This test checks a hand for pair")]
        public void TestHandForAPair()
        {
            var card1 = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card1);
            var card2 = new Card(CardValue.Ace, CardSuit.Hearts);
            _hand.AddCard(card2);
            var card3 = new Card(CardValue.King, CardSuit.Hearts);
            _hand.AddCard(card3);
            var card4 = new Card(CardValue.Queen, CardSuit.Hearts);
            _hand.AddCard(card4);
            var card5 = new Card(CardValue.Jack, CardSuit.Hearts);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.Pair, play);
        }

        [Test(Description = "This test checks a hand for two pair")]
        public void TestHandForTwoPair()
        {
            var card1 = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card1);
            var card2 = new Card(CardValue.Ace, CardSuit.Hearts);
            _hand.AddCard(card2);
            var card3 = new Card(CardValue.King, CardSuit.Spades);
            _hand.AddCard(card3);
            var card4 = new Card(CardValue.King, CardSuit.Hearts);
            _hand.AddCard(card4);
            var card5 = new Card(CardValue.Jack, CardSuit.Hearts);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.TwoPair, play);
        }

        [Test(Description = "This test checks a hand for a three of a kind")]
        public void TestHandForThreeOfAKind()
        {
            var card1 = new Card(CardValue.Ace, CardSuit.Spades);
            _hand.AddCard(card1);
            var card2 = new Card(CardValue.Ace, CardSuit.Hearts);
            _hand.AddCard(card2);
            var card3 = new Card(CardValue.Ace, CardSuit.Diamonds);
            _hand.AddCard(card3);
            var card4 = new Card(CardValue.King, CardSuit.Hearts);
            _hand.AddCard(card4);
            var card5 = new Card(CardValue.Jack, CardSuit.Hearts);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.ThreeOfAKind, play);
        }

        [Test(Description = "This test checks a hand for a straight")]
        public void TestHandForAStraight()
        {
            var card1 = new Card(CardValue.Two, CardSuit.Spades);
            _hand.AddCard(card1);
            var card2 = new Card(CardValue.Three, CardSuit.Hearts);
            _hand.AddCard(card2);
            var card3 = new Card(CardValue.Four, CardSuit.Diamonds);
            _hand.AddCard(card3);
            var card4 = new Card(CardValue.Five, CardSuit.Hearts);
            _hand.AddCard(card4);
            var card5 = new Card(CardValue.Six, CardSuit.Hearts);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.Straight, play);
        }
    }
}
