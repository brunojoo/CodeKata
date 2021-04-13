using System.Linq;
using NUnit.Framework;

namespace PokerHands
{
    public class CardTests
    {
        [Test]
        public void Compare_same_card_returns_zero()
        {
            Card card = new Card("2H");
            Assert.That(card.CompareTo(card), Is.EqualTo(0));
        }

        [Test]
        public void Compare_card_2H_to_5H_returns_negative_number()
        {
            Card card = new Card("2H");
            Card other = new Card("5H");
            Assert.That(card.CompareTo(other), Is.Negative);
        }

        [Test]
        public void Compare_card_5H_to_2H_returns_positive_number()
        {
            Card card = new Card("5H");
            Card other = new Card("2H");
            Assert.That(card.CompareTo(other), Is.Positive);
        }

        [Test]
        public void Compare_card_AH_to_AS_returns_zero()
        {
            Card card = new Card("AH");
            Card other = new Card("AS");
            Assert.That(card.CompareTo(other), Is.EqualTo(0));
        }

        [Test]
        public void Compare_card_AH_to_2H_returns_positive_number()
        {
            Card card = new Card("AH");
            Card other = new Card("2H");
            Assert.That(card.CompareTo(other), Is.Positive);
        }

        [Test]
        public void Order_AS_5H_6D_KS_TH()
        {
            var cards = new[]{new Card("AS"), new Card("5H"), new Card("6D"), new Card("KS"), new Card("TH")}.OrderByDescending(x=> x);
            Assert.That(cards, Is.EqualTo(new[]{new Card("AS"), new Card("KS"), new Card("TH"), new Card("6D"), new Card("5H")}));
        }

        [Test]
        public void Order_AS_5H_5S_TS_TH()
        {
            var cards = new[]{new Card("AS"), new Card("5H"), new Card("5S"), new Card("TS"), new Card("TH")}.OrderByDescending(x=> x);
            Assert.That(cards, Is.EqualTo(new[]{new Card("AS"), new Card("TS"), new Card("TH"), new Card("5S"), new Card("5H")}));
        }
    }
}
