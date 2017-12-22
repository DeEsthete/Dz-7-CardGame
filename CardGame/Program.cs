using ClassLibrary;
using MenuLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int COUNTCARD = 36;

            List<Card> card = new List<Card>();
            Game game = new Game();
            Card cardTemp = new Card();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cardTemp.CardLear = (CardLear)i;
                    cardTemp.CardType = (CardType)j;
                    card.Add(cardTemp);
                }
            }

            #region Menu
            string[] stringsMainMenu = { "Добавить игроков", "Начать игру", "Правила", "Выход" };

            ConsoleMenu mainMenu = new ConsoleMenu(stringsMainMenu);
            int mainMenuResult;
            do
            {
                mainMenuResult = mainMenu.PrintMenu();
                mainMenuResult++;

                switch (mainMenuResult)
                {
                    case 1:
                        Console.WriteLine("Введите имя игрока");
                        Player playerTmp = new Player();
                        playerTmp.Name = Console.ReadLine();
                        game.AddPlayer(playerTmp);
                        Console.WriteLine("Игрок успешно добавлен!");
                        break;
                    case 2:
                        if (game.Player.Count >= 2)
                        {
                            int countCardOfPlayer = COUNTCARD / game.Player.Count;
                            int countLayer = 0;
                            Card cardTmp;

                            for (int i = 0; i < game.Player.Count; i++)
                            {
                                Queue<Card> cardTmpQueue = new Queue<Card>();
                                for (int j = 0; j < countCardOfPlayer; j++)
                                {
                                    countLayer++;
                                    cardTmp = new Card((CardLear)(countLayer), (CardType)((i + 1) * j));
                                    cardTmpQueue.Enqueue(cardTmp);
                                }
                                game.Player[i].Card = cardTmpQueue;
                            }

                            Console.WriteLine("Игра началась!");

                            bool switchForWhile = true;
                            Card maxCard = new Card(0, 0);
                            int positionMaxCard = 0;
                            for (int i = 0; i < game.Player.Count; i++)
                            {
                                Card cardtmp = game.Player[i].Card.Dequeue();
                                if ((int)cardtmp.CardType > (int)maxCard.CardType)
                                {
                                    maxCard = cardtmp;
                                    positionMaxCard = i;
                                }
                            }
                            game.Player[positionMaxCard].Card.Enqueue(maxCard);
                            int countCardInPlayer = 0;
                            int positionCountCardInPlayer = -1;
                            for (int i = 0; i < game.Player.Count; i++)
                            {
                                if (game.Player[i].Card.Count >= countCardInPlayer)
                                {
                                    countCardInPlayer = game.Player[i].Card.Count;
                                    positionCountCardInPlayer = i;
                                }
                            }
                            Console.WriteLine("Победил; " + game.Player[positionCountCardInPlayer].Name);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно игроков!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("        Игровой процесс.\n" +
                            "Принцип: Игроки кладут по одной карте. У кого карта больше, то тот игрок забирает все карты и кладет их в конец своей колоды.\n" +
                            "Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает туза. Выигрывает игрок, который забрал все карты.\n");
                        Console.WriteLine("        Управление.\n" +
                            "По нажатию 'пробела' ход переходит другому игроку");
                        break;
                }
            } while (mainMenuResult != stringsMainMenu.Length);
            #endregion
        }
    }
}
