using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HarryPotter
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Book_1_Has_A_Fixed_Cost()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1()
            };

            Assert.AreEqual(8, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Book_2_Has_A_Fixed_Cost()
        {
            var shoppingCart = new List<Book>()
            {
                new Book2()
            };

            Assert.AreEqual(8, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_Book1_and_Book2_Get_5_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2()
            };
            const double total = 16 * 0.95;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_Book1_and_Book1_Get_No_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book1()
            };
            const double total = 16;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_Book2_and_Book2_Get_No_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book2(),
                new Book2()
            };
            const double total = 16;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_3_Different_Books_Get_10_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2(),
                new Book3(),
            };
            const double total = 24 * 0.9;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_2_Same_Books_And_1_Different_Get_5_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book1(),
                new Book3(),
            };
            const double total = 16 * 0.95 + 8;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_3_Same_Books_Price_Is_24()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book1(),
                new Book1(),
            };
            const double total = 24;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }


        [Test]
        public void Buy_4_Different_Books_Get_20_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2(),
                new Book3(),
                new Book4(),
            };
            const double total = 32 * 0.8;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_5_Different_Books_Get_25_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2(),
                new Book3(),
                new Book4(),
                new Book5(),
            };
            const double total = 40 * 0.75;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_3_Different_1_Same_Books_Get_10_Percent_Discount()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2(),
                new Book3(),
                new Book3(),
            };
            const double total = (24 * 0.90) + 8;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }

        [Test]
        public void Buy_2_Book1_2_Book2_2_Book3_1_Book4_1_Book5_Totals_51_20()
        {
            var shoppingCart = new List<Book>()
            {
                new Book1(),
                new Book2(),
                new Book3(),
                new Book4(),
                new Book5(),
                
                new Book1(),
                new Book2(),
                new Book3(),
            };
            const double total = 54;

            Assert.AreEqual(total, ShoppingCart.Price(shoppingCart));
        }
    }


    public static class ShoppingCart
    {
        public static double Price(List<Book> shoppingCart)
        {
            var howManyDifferent = shoppingCart.GroupBy(book => book.GetType()).Distinct().Count();
            return GetTotalOfBooksWithDiscount(shoppingCart, howManyDifferent) +
                   GetTotalOfBooksWithoutDiscount(shoppingCart, howManyDifferent);
        }

        private static double GetTotalOfBooksWithDiscount(IEnumerable<Book> shoppingCart, int howManyDifferent)
        {
            var discount = howManyDifferent switch
            {
                2 => 0.05,
                3 => 0.1,
                4 => 0.2,
                5 => 0.25,
                _ => 0
            };
            return shoppingCart.Take(howManyDifferent).Sum(book => book.Price()) * (1 - discount);
        }

        private static double GetTotalOfBooksWithoutDiscount(IEnumerable<Book> shoppingCart, int howManyDifferent)
        {
            return shoppingCart.Take(shoppingCart.Count() - howManyDifferent).Sum(book => book.Price());
        }
    }

    public abstract class Book
    {
        public int Price() => 8;
    }

    public class Book1 : Book
    {
    }

    public class Book2 : Book
    {
    }

    public class Book3 : Book
    {
    }

    public class Book4 : Book
    {
    }

    public class Book5 : Book
    {
    }
}