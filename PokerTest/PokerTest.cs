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
        public void TestHandForPair()
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

        [Test(Description = "This test checks a hand for three of a kind")]
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

        [Test(Description = "This test checks a hand for straight")]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Three, CardSuit.Hearts, CardValue.Four, CardSuit.Diamonds,
            CardValue.Five, CardSuit.Hearts, CardValue.Six, CardSuit.Hearts)]
        [TestCase(CardValue.Four, CardSuit.Diamonds, CardValue.Three, CardSuit.Hearts, CardValue.Two, CardSuit.Spades,
            CardValue.Five, CardSuit.Hearts, CardValue.Six, CardSuit.Hearts)]
        [TestCase(CardValue.Ace, CardSuit.Spades, CardValue.King, CardSuit.Hearts, CardValue.Queen, CardSuit.Diamonds,
            CardValue.Jack, CardSuit.Hearts, CardValue.Ten, CardSuit.Hearts)]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Three, CardSuit.Hearts, CardValue.Four, CardSuit.Diamonds,
            CardValue.Five, CardSuit.Hearts, CardValue.Ace, CardSuit.Hearts)]
        public void TestHandForAStraight(CardValue cardValue1, CardSuit cardSuit1, CardValue cardValue2, CardSuit cardSuit2,
            CardValue cardValue3, CardSuit cardSuit3, CardValue cardValue4, CardSuit cardSuit4,
                CardValue cardValue5, CardSuit cardSuit5)
        {
            var card1 = new Card(cardValue1, cardSuit1);
            _hand.AddCard(card1);
            var card2 = new Card(cardValue2, cardSuit2);
            _hand.AddCard(card2);
            var card3 = new Card(cardValue3, cardSuit3);
            _hand.AddCard(card3);
            var card4 = new Card(cardValue4, cardSuit4);
            _hand.AddCard(card4);
            var card5 = new Card(cardValue5, cardSuit5);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.Straight, play);
        }

        [Test(Description = "This test checks a hand for flush")]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Eight, CardSuit.Spades, CardValue.Four, CardSuit.Spades,
            CardValue.Five, CardSuit.Spades, CardValue.Queen, CardSuit.Spades)]
        public void TestHandForFlush(CardValue cardValue1, CardSuit cardSuit1, CardValue cardValue2, CardSuit cardSuit2,
            CardValue cardValue3, CardSuit cardSuit3, CardValue cardValue4, CardSuit cardSuit4,
                CardValue cardValue5, CardSuit cardSuit5)
        {
            var card1 = new Card(cardValue1, cardSuit1);
            _hand.AddCard(card1);
            var card2 = new Card(cardValue2, cardSuit2);
            _hand.AddCard(card2);
            var card3 = new Card(cardValue3, cardSuit3);
            _hand.AddCard(card3);
            var card4 = new Card(cardValue4, cardSuit4);
            _hand.AddCard(card4);
            var card5 = new Card(cardValue5, cardSuit5);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.Flush, play);
        }

        [Test(Description = "This test checks a hand for full house")]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Two, CardSuit.Hearts, CardValue.Three, CardSuit.Spades,
            CardValue.Three, CardSuit.Hearts, CardValue.Three, CardSuit.Clubs)]
        public void TestHandForFullHouse(CardValue cardValue1, CardSuit cardSuit1, CardValue cardValue2, CardSuit cardSuit2,
            CardValue cardValue3, CardSuit cardSuit3, CardValue cardValue4, CardSuit cardSuit4,
                CardValue cardValue5, CardSuit cardSuit5)
        {
            var card1 = new Card(cardValue1, cardSuit1);
            _hand.AddCard(card1);
            var card2 = new Card(cardValue2, cardSuit2);
            _hand.AddCard(card2);
            var card3 = new Card(cardValue3, cardSuit3);
            _hand.AddCard(card3);
            var card4 = new Card(cardValue4, cardSuit4);
            _hand.AddCard(card4);
            var card5 = new Card(cardValue5, cardSuit5);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.FullHouse, play);
        }

        [Test(Description = "This test checks a hand for four of a kind")]
        [TestCase(CardValue.Ace, CardSuit.Spades, CardValue.Ace, CardSuit.Hearts, CardValue.Ace, CardSuit.Diamonds,
            CardValue.Ace, CardSuit.Clubs, CardValue.Three, CardSuit.Clubs)]
        public void TestHandForFourOfAKind(CardValue cardValue1, CardSuit cardSuit1, CardValue cardValue2, CardSuit cardSuit2,
            CardValue cardValue3, CardSuit cardSuit3, CardValue cardValue4, CardSuit cardSuit4,
                CardValue cardValue5, CardSuit cardSuit5)
        {
            var card1 = new Card(cardValue1, cardSuit1);
            _hand.AddCard(card1);
            var card2 = new Card(cardValue2, cardSuit2);
            _hand.AddCard(card2);
            var card3 = new Card(cardValue3, cardSuit3);
            _hand.AddCard(card3);
            var card4 = new Card(cardValue4, cardSuit4);
            _hand.AddCard(card4);
            var card5 = new Card(cardValue5, cardSuit5);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.FourOfAKind, play);
        }

        [Test(Description = "This test checks a hand for straight")]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Three, CardSuit.Spades, CardValue.Four, CardSuit.Spades,
            CardValue.Five, CardSuit.Spades, CardValue.Six, CardSuit.Spades)]
        [TestCase(CardValue.Four, CardSuit.Spades, CardValue.Three, CardSuit.Spades, CardValue.Two, CardSuit.Spades,
            CardValue.Five, CardSuit.Spades, CardValue.Six, CardSuit.Spades)]
        [TestCase(CardValue.Ace, CardSuit.Spades, CardValue.King, CardSuit.Spades, CardValue.Queen, CardSuit.Spades,
            CardValue.Jack, CardSuit.Spades, CardValue.Ten, CardSuit.Spades)]
        [TestCase(CardValue.Two, CardSuit.Spades, CardValue.Three, CardSuit.Spades, CardValue.Four, CardSuit.Spades,
            CardValue.Five, CardSuit.Spades, CardValue.Ace, CardSuit.Spades)]
        public void TestHandForAStraightFlush(CardValue cardValue1, CardSuit cardSuit1, CardValue cardValue2, CardSuit cardSuit2,
            CardValue cardValue3, CardSuit cardSuit3, CardValue cardValue4, CardSuit cardSuit4,
                CardValue cardValue5, CardSuit cardSuit5)
        {
            var card1 = new Card(cardValue1, cardSuit1);
            _hand.AddCard(card1);
            var card2 = new Card(cardValue2, cardSuit2);
            _hand.AddCard(card2);
            var card3 = new Card(cardValue3, cardSuit3);
            _hand.AddCard(card3);
            var card4 = new Card(cardValue4, cardSuit4);
            _hand.AddCard(card4);
            var card5 = new Card(cardValue5, cardSuit5);
            _hand.AddCard(card5);
            var play = PokerRules.CheckPlay(_hand);
            Assert.AreEqual(PokerRules.PokerPlay.StraightFlush, play);
        }
    }
}
