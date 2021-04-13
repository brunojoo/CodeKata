using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal static class PokerHandFinder
    {
        public static PokerHand Get(List<Card> cards)
        {
            List<PokerHand> pokerHands = new()
            {
                new Pair(),
                new HighCard()
            };
            
            return pokerHands.First(e => e.HasHand(cards));
        }
    }
}