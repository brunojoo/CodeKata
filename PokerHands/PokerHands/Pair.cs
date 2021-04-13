using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace PokerHands
{
    internal class Pair : PokerHand
    {
        public bool HasHand(List<Card> hand)
        {
            for (var i = 0; i < hand.Count; i++)
            {
                var current = hand[i].Value;
                for (var j = i + 1; j < hand.Count; j++)
                    if (current == hand[j].Value)
                        return true;
            }

            return false;
        }

        public int CompareTo(PokerHand opponentBestHand)
        {
            if (GetWeight() > opponentBestHand.GetWeight())
                return 1;
            if (GetWeight() < opponentBestHand.GetWeight())
                return -1;
            return 0;
        }

        public int GetWeight()
        {
            return 1;
        }

        public bool Equals(List<Card> a, List<Card> b)
        {
            return a.Equals(b);
        }

        public int ComparePairs(Card[] cards1, Card[] cards2)
        {
            var pairs1 = GetPair(cards1);
            var pairs2 = GetPair(cards2);
            return pairs1[0].CompareTo(pairs2[0]);
        }

        private Card[] GetPair(Card[] cards)
        {
            for (var i = 0; i < cards.Length; i++)
            {
                var current = cards[i].Value;
                for (var j = i + 1; j < cards.Length; j++)
                    if (current == cards[j].Value)
                        return new[] {cards[i], cards[j]};
            }

            return null;
        }
    }
}