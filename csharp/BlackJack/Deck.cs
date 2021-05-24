using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (var i = 1; i < 14; i++)
                {
                    Cards.Add(new Card() { Rank = i, Suit = suit });
                }
            }

        }
    }
}
