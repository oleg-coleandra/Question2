using CardGames.HighCard;
using CardGames.Models;
using System;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardDeck = new CompoundCardDeck(2, 13);
            var config = new GameConfiguration()
            {
                IsTieAllowed = true,
                WildCard = new Card(5, Enums.Suite.Pikes),
            };

            ICardGame game = new HighCard.HighCard(cardDeck, config);

                Console.WriteLine(game.Play());
        }
    }
}
