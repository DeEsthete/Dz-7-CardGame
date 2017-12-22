using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Card
    {
        public CardLear CardLear { get; set; }
        public CardType CardType { get; set; }
        public Card(CardLear cardLear, CardType cardType)
        {
            CardLear = cardLear;
            CardType = CardType;
        }
        public Card()
        {
            //
        }
    }
}
