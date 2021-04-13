using NUnit.Framework;

namespace PokerHands
{
    public class PairTests
    {
        [Test]
        public void Compare_2H_2S_to_2H_2S_returns_0()
        {
            var cards1 = new[] {new Card("2S"), new Card("2H")};
            var pair = new Pair();
            Assert.That(pair.ComparePairs(cards1,cards1), Is.EqualTo(0));
        }
        
        [Test]
        public void Compare_2H_2S_to_3H_3S_returns_negative()
        {
            var cards1 = new[] {new Card("2S"), new Card("2H")};
            var cards2 = new[] {new Card("3S"), new Card("3H")};
            var pair = new Pair();
            Assert.That(pair.ComparePairs(cards1,cards2), Is.Negative);
        }
        
        [Test]
        public void Compare_3H_3S_to_2H_2S_returns_positive()
        {
            var cards2 = new[] {new Card("2S"), new Card("2H")};
            var cards1 = new[] {new Card("3S"), new Card("3H")};
            var pair = new Pair();
            Assert.That(pair.ComparePairs(cards1,cards2), Is.Positive);
        }
        
        [Test]
        public void Compare_AH_3H_3S_to_KH_2H_2S_returns_positive()
        {
            var cards2 = new[] {new Card("AH"),new Card("2S"), new Card("2H")};
            var cards1 = new[] {new Card("KH"),new Card("3S"), new Card("3H")};
            var pair = new Pair();
            Assert.That(pair.ComparePairs(cards1,cards2), Is.Positive);
        }
    }
}