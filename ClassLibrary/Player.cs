using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Card { get; set; }
        public Player(Queue<Card> card)
        {
            Card = card;
        }

        public Player()
        {
            //
        }
    }
}
