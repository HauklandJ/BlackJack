using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_FinishedDealing : Scenario
    {
        private List<Card> _playerHand;
        private List<Card> _dealerHand;
        public override void When()
        {
            _playerHand = new List<Card>();
            _dealerHand = new List<Card>();
        }

        [Test]
        public void Dealer_should_win_when_equal()
        {
            var dealerTotal = 21;
            var playerTotal = 21;
            Assert.False(Program.CalculateWinner(dealerTotal, playerTotal));
        }
        [Test]
        public void Player_should_win_when_dealer_over_21()
        {
            var dealerTotal = 23;
            var playerTotal = 1;
            Assert.True(Program.CalculateWinner(dealerTotal, playerTotal));
        }
        [Test]
        public void Player_should_win_when_player_has_better_hand()
        {
            var dealerTotal = 18;
            var playerTotal = 19;
            Assert.True(Program.CalculateWinner(dealerTotal, playerTotal));
        }
    }
}
