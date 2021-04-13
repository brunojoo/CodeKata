using System.Collections.Generic;

namespace PokerHands
{
    public class PokerRules
    {
        public static List<char> CardOrder = new ()
        {
            '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'
        };
    }

    public enum PokerHandsCombos : ushort
    {
        HIGHCARD = 0,
        PAIR = 1,
        TWO_PAIRS = 2,
        THREE_OF_A_KIND = 3,
        STRAIGHT = 4,
        FLUSH = 5,
        FULL_HOUSE = 6,
        FOUR_OF_A_KIND = 7,
        STRAIGHT_FLUSH = 8
    }
}