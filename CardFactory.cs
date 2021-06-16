using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public class CardFactory : ICardFactory
    {        
        public List<Card> getCards()
        {
            List<Card> result = new List<Card>();
            try
            {
                foreach (string fValue in Card.faceCards)
                {
                    foreach (string suite in Card.Suites)
                    {
                        result.Add(createCard(fValue, suite,Card.faceCards.FindIndex(x => x.Equals(fValue))+1));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured while creating deck of cards! Error Details:{ex.Message}");
            }
            return result;
        }
        private Card createCard(string value, string suite, int pVal)
        {
            return new Card(value, suite, pVal);
        }
    }
}
