using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckOfCards
{
    public class Deck
    {
        private List<string> FaceCards = new List<string> { "Jack", "Queen", "King" };
        private ICardFactory _cardFactory { get; set; }
        public List<Card> Cards { get; set; }
        public Deck(ICardFactory factory)
        {
            _cardFactory = factory;
            Init();
        }
        private void Init()
        {
            if (_cardFactory != null)
            {
                try
                {
                    Cards = _cardFactory.getCards() ?? new List<Card>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Cards = new List<Card>();//default
                }
            }

        }
       public int GetCardCount()
        {
            return Cards.Count;
        }
        public List<string> GetSuites()
        {
            return Cards.Select(c => c.suite)?.Distinct()?.ToList();
        }
        public List<Card> getCards(string suite)
        {
            return Cards?.Where(c => c.suite.Equals(suite)).ToList();
        }
        public List<Card> GetFacedCards()
        {
            var retVal = from card in Cards
                         where FaceCards.Contains(card.faceValue)
                         let facerank = FaceCards.FindIndex(x => x.Equals(card.faceValue))
                         let suiterank = Card.Suites.FindIndex( y => y.Equals(card.suite))
                         orderby suiterank ascending, facerank ascending
                         select card;
            return retVal?.ToList();
        }
        public void ReadDeck()
        {

        }

        public void Shuffle()
        {

        }
    }
}
