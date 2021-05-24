using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_displayingSpecialCards : Scenario
    {
        private Card _jack;
        private Card _queen;
        private Card _king;
        private Card _ace;

        public override void When()
        {
            _jack = new Card() { Rank = 11, Suit = Suit.Clubs };
            _queen = new Card() { Rank = 12, Suit = Suit.Clubs };
            _king = new Card() { Rank = 13, Suit = Suit.Clubs };
            _ace = new Card() { Rank = 1, Suit = Suit.Clubs };
        }
        [Test]
        public void Should_display_jack_as_J()
        {
            var jackString = Program.GetStringValueForCard(_jack.Rank);
            Assert.AreEqual("J", jackString);
        }
        [Test]
        public void Should_display_queen_as_Q()
        {
            var queenString = Program.GetStringValueForCard(_queen.Rank);
            Assert.AreEqual("Q", queenString);
        }
        [Test]
        public void Should_display_king_as_K()
        {
            var kingString = Program.GetStringValueForCard(_king.Rank);
            Assert.AreEqual("K", kingString);
        }
        [Test]
        public void Should_display_ace_as_A()
        {
            var aceString = Program.GetStringValueForCard(_ace.Rank);
            Assert.AreEqual("A", aceString);
        }
    }
}
