using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var playerHand = new List<Card>();
            var dealerHand = new List<Card>();

            var playerTotal = 0;
            var dealerTotal = 0;
            var random = new Random();

            var initialCard = GetRandomCard(deck, random);
            dealerHand.Add(initialCard);
            Console.WriteLine("Dealer starts with {0} {1}", initialCard.Suit, GetStringValueForCard(initialCard.Rank));
            while (true)
            {
                Console.WriteLine("Stand, Hit");
                var read = Console.ReadLine();
                var loweredRead = string.IsNullOrEmpty(read) ? "" : read.ToLower();
                if (loweredRead == "hit")
                {
                    var card = GetRandomCard(deck, random);
                    playerHand.Add(card);
                    playerTotal = CalculateHandTotal(playerHand);
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, GetStringValueForCard(card.Rank), playerTotal);
                    if (playerTotal > 21)
                    {
                        WriteColoredLine("You lose!", ConsoleColor.Red);
                        Console.Read();
                        break;
                    }
                }
                else if (loweredRead == "stand")
                {
                    dealerTotal = CalculateHandTotal(dealerHand);
                    dealerTotal = DealerTotal(dealerTotal, deck, random, dealerHand);
                    CalculateWinner(dealerTotal, playerTotal);
                    Console.Read();
                    break;
                }
                else
                {
                    WriteColoredLine("Please enter a valid command", ConsoleColor.Blue);
                }
            }
        }

        public static int DealerTotal(int dealerTotal, Deck deck, Random random, List<Card> dealerHand)
        {
            while (dealerTotal < 17)
            {
                var card = GetRandomCard(deck, random);
                dealerHand.Add(card);
                dealerTotal = CalculateHandTotal(dealerHand);
                Console.WriteLine("Dealer hit with {0} {1}. Total is {2}", card.Suit, GetStringValueForCard(card.Rank),
                    dealerTotal);
            }

            return dealerTotal;
        }

        public static bool CalculateWinner(int dealerTotal, int playerTotal)
        {
            if (dealerTotal > 21 || (playerTotal > dealerTotal))
            {
                WriteColoredLine("You win!", ConsoleColor.Green);
                return true;
            }
            else
            {
                WriteColoredLine("You lose!", ConsoleColor.Red);
            }
            return false;
        }

        private static void WriteColoredLine(string buffer, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.WriteLine(buffer);
            Console.ResetColor();
        }

        public static string GetStringValueForCard(int cardRank)
        {
            switch (cardRank)
            {
                case 1:
                    return "A";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return cardRank.ToString();
            }
        }

        public static int CalculateHandTotal(List<Card> hand)
        {
            var handTotal = hand.Sum(x => Math.Min(x.Rank, 10));
            var aces = hand.FindAll(x => x.Rank == 1);
            if (handTotal < 11 && aces.Count > 0)
            {
                handTotal += 10;
            }

            return handTotal;
        }

        private static Card GetRandomCard(Deck deck, Random random)
        {
            return deck.Cards[random.Next(deck.Cards.Count)];
        }
    }
}
