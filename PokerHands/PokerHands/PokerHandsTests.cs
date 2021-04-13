using NUnit.Framework;

namespace PokerHands
{
    public class PokerHandsTests
    {
        [Test]
        public void White_wins_with_high_card()
        {
            var pokerCalculator = new PokerCalculator("Black: 2H 3D 5S 9C KH White: 2C 3H 4S 8C AH");

            Assert.AreEqual("White", pokerCalculator.CalculateWinner());
        }

        [Test]
        public void Black_wins_with_high_card()
        {
            var pokerCalculator = new PokerCalculator("Black: 2H 3D 5S 9C AH White: 2C 3H 4S 8C KH");

            Assert.AreEqual("Black", pokerCalculator.CalculateWinner());
        }

        [Test]
        public void Draw_of_high_card()
        {
            var pokerCalculator = new PokerCalculator("Black: 2H 3D 5S 9C AH White: 2D 3H 5D 9H AC");

            Assert.AreEqual("Draw", pokerCalculator.CalculateWinner());
        }

        //TODO: fix after refactor [Test]
        public void Draw_of_high_card_but_black_wins_on_tiebreaker()
        {
            var pokerCalculator = new PokerCalculator("Black: 4H 3D 5S 9C AH White: 2D 3H 5D 9H AC");

            Assert.AreEqual("Black", pokerCalculator.CalculateWinner());
        }

        [Test]
        public void Black_wins_with_pair()
        {
            var pokerCalculator = new PokerCalculator("Black: 2H 2D 5S 9C AH White: 2D 3H 5D 9H AC");

            Assert.AreEqual("Black", pokerCalculator.CalculateWinner());
        }

        [Test]
        public void White_wins_with_best_pair()
        {
            var pokerCalculator = new PokerCalculator("Black: 2H 2D 5S 9C AH White: 3H 3D 5S 9C KH");

            Assert.AreEqual("White", pokerCalculator.CalculateWinner());
        }

        // [Test]
        // public void Draw_with_pair_but_Black_wins_on_tiebreaker_with_highcard()
        // {
        //     var pokerCalculator = new PokerCalculator("Black: 2H 2D 5S 9C AH White: 2S 2C 5S 9C KH");
        //
        //     Assert.AreEqual("Black", pokerCalculator.CalculateWinner());
        // }
    }
}
