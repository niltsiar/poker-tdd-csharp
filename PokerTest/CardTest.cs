using NUnit.Framework;
using Poker;

namespace PokerTest
{
    [TestFixture]
    public class CardTest
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
    }
}
