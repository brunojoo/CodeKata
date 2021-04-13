using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal class HighCard : PokerHand
    {

        public bool HasHand(List<Card> hand)
        {
            return true;
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
            return 0;
        }

        public bool Equals(List<Card> a, List<Card> b)
        {
            var orderedListA = a.OrderByDescending(card => card.Value).ToList();
            var orderedListB = b.OrderByDescending(card => card.Value).ToList();
            for (int i = 0; i < orderedListA.Count(); i++)
            {
                if (orderedListA[i].Value != orderedListB[i].Value) return false;
            }
            return true;
        }
    }
}
