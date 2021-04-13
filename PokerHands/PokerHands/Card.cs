using System;

namespace PokerHands
{
    public class Card : IComparable<Card>
    {
        public char Value { get; }
        public string Suit { get; }

        public Card(string s)
        {
            Value = s[0];
            Suit = s[1].ToString();
        }

        public int CompareTo(Card card)
        {
            var myWeight = GetValueWeight(Value);
            var otherWeight = GetValueWeight(card.Value);
            return myWeight - otherWeight;
        }

        private int GetValueWeight(char value)
        {
            return PokerRules.CardOrder.IndexOf(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return Value == ((Card)obj).Value;
        }
    }
}
