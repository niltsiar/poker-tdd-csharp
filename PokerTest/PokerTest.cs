using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Poker;

namespace PokerTest
{
    [TestFixture]
    public class PokerTest
    {
        [Test(Description = "This test create a card and check its attributes")]
        public void CreateAndCheckACard()
        {
            var card = new Card(1, CardSuit.Spades);
            Assert.AreEqual(1, card.Value);
            Assert.AreEqual(CardSuit.Spades, card.Suit);
        }
    }
}
