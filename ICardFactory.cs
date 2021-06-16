using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
   public interface ICardFactory
    {
        public List<Card> getCards();
    }
}
