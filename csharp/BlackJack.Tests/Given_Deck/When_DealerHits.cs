using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_DealerHits : Scenario
    {
        private List<Card> _hand;
        private Deck _deck;
        private Random _random;
        public override void When()
        {
            _deck = new Deck();
            _hand = new List<Card>
            {
                new Card() { Rank = 10, Suit = Suit.Clubs },
                new Card() { Rank = 6, Suit = Suit.Diamonds }
            };
            _random = new Random();
        }
        [Test]
        public void Should_hit_when_under_17()
        {
            var inititalTotal = 16;
            var total = Program.DealerTotal(inititalTotal, _deck, _random, _hand);
            Assert.Greater(total, inititalTotal);
        }
        [Test]
        public void Should_not_hit_when_over_17()
        {
            _hand.Add(new Card() { Rank = 2, Suit = Suit.Diamonds });
            var inititalTotal = 18;
            var total = Program.DealerTotal(inititalTotal, _deck, _random, _hand);
            Assert.AreEqual(total, inititalTotal);
        }
    }
}
