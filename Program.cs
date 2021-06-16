using System;
using System.Linq;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(new CardFactory());
            Console.WriteLine($"1. Scenario: The deck has {deck.GetCardCount()} cards");
            Console.WriteLine($"2. Scenario: The deck has '{string.Join(",", deck.GetSuites())}'suits");
            Console.WriteLine($"3. Scenario: Each suit has 13 cards:");
            foreach (var suite in Card.Suites)
            {
                deck.getCards(suite).ForEach(c => Console.WriteLine(c.DisplayCard()));
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine($"4. Scenario Outline: Card values");

            foreach (var suite in Card.Suites)
            {
                Console.WriteLine($"|faceValue|pointValue|");
                deck.getCards(suite).ForEach(c => Console.WriteLine(c.DisplayCardWithValues()));
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine($"5. Scenario Outline: Face Cards are ordered");
            var facedCards = deck.GetFacedCards();
            Console.WriteLine($"FacedCardsCount={facedCards?.Count}");           
            
            facedCards.ForEach(c => Console.WriteLine(c.DisplayCard()));
          
        }
    }
}
