using System.Linq;
using NUnit.Framework;

namespace PokerHands
{
    public class CardHandTests
    {
        [Test]
        public void Compare_same_cardHand_returns_zero()
        {
            CardHand cardHand = new CardHand(new []{"2H"});
            Assert.That(cardHand.CompareTo(cardHand), Is.EqualTo(0));
        }

        [Test]
        public void Compare_cardHand_2H_with_3H_returns_negative()
        {
            CardHand cardHandLeft = new CardHand(new []{"2H"});
            CardHand cardHandRight = new CardHand(new []{"3H"});
            Assert.That(cardHandLeft.CompareTo(cardHandRight), Is.Negative);
        }

        [Test]
        public void Compare_cardHand_3H_with_2H_returns_positive()
        {
            CardHand cardHandLeft = new CardHand(new []{"3H"});
            CardHand cardHandRight = new CardHand(new []{"2H"});
            Assert.That(cardHandLeft.CompareTo(cardHandRight), Is.Positive);
        }

        [Test]
        public void Compare_cardHand_3H_AH_with_2H_AH_returns_positive()
        {
            CardHand cardHandLeft = new CardHand(new []{"3H", "AH"});
            CardHand cardHandRight = new CardHand(new []{"2H", "AH"});
            Assert.That(cardHandLeft.CompareTo(cardHandRight), Is.Positive);
        }
    }
}
