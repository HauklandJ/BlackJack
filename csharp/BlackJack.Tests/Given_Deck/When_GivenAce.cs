using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_GivenAce : Scenario
    {
        private List<Card> _hand;
        public override void When()
        {
            _hand = new List<Card>
            {
                new Card() { Rank = 1, Suit = Suit.Clubs }
            };
        }
        [Test]
        public void Should_have_11_total_with_only_ace()
        {
            var total = Program.CalculateHandTotal(_hand);
            Assert.AreEqual(11, total);
        }
        [Test]
        public void Should_have_12_total_with_only_two_aces()
        {
            var secondAce = new Card() {Rank = 1, Suit = Suit.Diamonds};
            _hand.Add(secondAce);
            var total = Program.CalculateHandTotal(_hand);
            Assert.AreEqual(12, total);
        }
        [Test]
        public void Should_get_plus_1_when_total_is_over_10()
        {
            Should_have_12_total_with_only_two_aces();
        }
    }
}
