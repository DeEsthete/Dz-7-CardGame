using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Game
    {
        public List<Player> Player { get; set; }
        public List<Card> Card { get; set; }

        #region ctor
        public Game(List<Player> player, List<Card> card)
        {
            Player = player;
        }

        public Game()
        {
            Player = new List<Player>();
            Card = new List<Card>();
        }
        #endregion
        #region method
        public void MixCard()
        {
            Random random = new Random();
            for (int i = Card.Count - 1; i >= 1; i--)
{
                int j = random.Next(i + 1);
                // обменять значения Card[j] и Card[i]
                var temp = Card[j];
                Card[j] = Card[i];
                Card[i] = temp;
            }
        }

        public void Distribution()
        {
            int CountCardOfPerson = Card.Count / Player.Count;
            for (int i = 0; i < Player.Count; i++)
            {
                for (int j = 0; j < CountCardOfPerson; j++)
                {
                    Player[i].Card.Enqueue(Card[(i + 1) * j]);
                }
            }
        }

        public bool CompareCard(Card oneObject, Card secondObject)
        {
            if (oneObject.CardType > secondObject.CardType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPlayer(Player player)
        {
            Player.Add(player);
        }
        #endregion
    }
}
