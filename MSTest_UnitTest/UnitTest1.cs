using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DeckOfCards;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsTest
{
    [TestClass]
    public class UnitTest1
    {
        public static List<string> expected = new List<string>  {
            "Clubs",
            "Spades",
            "Hearts",
            "Diamonds"};
        public Deck deck = new Deck(new CardFactory());

        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var exprected = 52;
            var count = deck.GetCardCount();
            Console.WriteLine($"1. Scenario: The deck has {count} cards");
            //Assert
            Assert.AreEqual(count, exprected);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Act
            var actual = deck.GetSuites();
            IEnumerable<string> inFirstOnly = expected.Except(actual);
            IEnumerable<string> inSecondOnly = actual.Except(expected);
            bool allInBoth = !inFirstOnly.Any() && !inSecondOnly.Any();
            Console.WriteLine($"2. Scenario:The deck has '{string.Join(",", actual)}'suits");
            //Assert
            Assert.AreEqual(allInBoth, true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine($"3. Scenario: Each suite has 13 cards:");
            //Act
            var actual = deck.getCards("Clubs");
            //print
            actual.ForEach(c => Console.WriteLine(c.DisplayCard()));

            //Assert
            Assert.AreEqual(actual.Count, 13);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //arrange
            var expected = new Dictionary<string, int>
                {
                    { "Ace", 1 },{ "2", 2 },{ "3", 3 },{ "4", 4 },{ "5", 5 },{ "6", 6 },{ "7", 7 },{ "8", 8 },{ "9", 9 },{ "10", 10 },{ "Jack", 10 },{ "Queen", 10 },{ "King", 10 }
                };

            Console.WriteLine($"4. Scenario Outline: Card values");

            foreach (var suite in Card.Suites)
            {
                Console.WriteLine($"|faceValue|pointValue|");
                deck.getCards(suite).ForEach(c => Console.WriteLine(c.DisplayCardWithValues()));
                Console.WriteLine("---------------------------------------------------");
            }

        //Assert
            Assert.AreEqual(deck.getCards("Spades").All( card => expected[card.faceValue]==card.PointValue), true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Console.WriteLine($"5. Scenario Outline: Face Cards are ordered");
            var facedCards = deck.GetFacedCards();
            Console.WriteLine($"FacedCardsCount={facedCards?.Count}");
            Assert.AreEqual(facedCards?.Count, 12);
            facedCards.ForEach(c => Console.WriteLine(c.DisplayCard()));
        }
    }
}
