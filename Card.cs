using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{  
    public class Card
    {
        public static List<string> faceCards = new List<string> { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        public static List<string> Suites = new List<string>        {
            "Clubs",
            "Spades",
            "Hearts",
            "Diamonds"
        };
       
        public string faceValue { get; set; }
        public string suite { get; set; }
        public int PointValue { get; set; }

        public Card(string faceVal, string ste, int pVal)
        {
            faceValue = faceVal;
            suite = ste;
            PointValue = pVal > 10 ? 10 : pVal;
        }
        public string  DisplayCard()
        {
           string retVal= $"suite ={ suite,8} => faceVlaue ={ faceValue,5}";
            //Console.WriteLine(retVal);
            return retVal;
        }
        public string DisplayCardWithValues()
        {
            string retVal = $"{faceValue,10} | {PointValue,2}";
           // Console.WriteLine(retVal);
            return retVal;
        }
    }
}