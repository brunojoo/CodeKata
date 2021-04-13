using System.Collections.Generic;

namespace PokerHands
{
    internal interface PokerHand
    {
        bool HasHand(List<Card> hand);
        int CompareTo(PokerHand opponentBestHand);
        int GetWeight();
        bool Equals(List<Card> a, List<Card> b);
    }
}
