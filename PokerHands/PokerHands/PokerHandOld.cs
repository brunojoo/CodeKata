using System;
using System.Linq;

namespace PokerHands
{
    internal class PokerHandOld : IComparable<PokerHandOld>
    {
        public readonly string bestHand;
        public readonly PokerHandsCombos bestPokerHandCombo;

        public PokerHandOld(PokerHandsCombos bestPokerHandCombo, string bestHand)
        {
            this.bestPokerHandCombo = bestPokerHandCombo;
            this.bestHand = bestHand;
        }

        public int CompareTo(PokerHandOld other)
        {
            if (bestPokerHandCombo < other.bestPokerHandCombo) return -1;

            if (bestPokerHandCombo > other.bestPokerHandCombo) return 1;

            return HandsComboTieBreaker(other);
        }

        private int HandsComboTieBreaker(PokerHandOld opponentBestHandOld)
        {
            var myPoints = PokerRules.CardOrder.IndexOf(bestHand.First());
            var opponentPoints = PokerRules.CardOrder.IndexOf(opponentBestHandOld.bestHand.First());


            if (myPoints < opponentPoints) return -1;

            if (myPoints > opponentPoints) return 1;

            return 0;
        }
    }
}