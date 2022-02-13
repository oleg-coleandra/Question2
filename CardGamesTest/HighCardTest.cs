using CardGames.Enums;
using CardGames.HighCard;
using CardGames.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardGamesTest
{
    [TestClass]
    public class HighCardTest
    {
        [TestMethod]
        public void WildCardBeatsBiggerCardTest()
        {
            var cards = new Stack<Card>();
            cards.Push(new Card(1, Suite.Pikes));
            cards.Push(new Card(2, Suite.Pikes));

            var cardDeck = new SimpleCardDeck(cards);

            var config = new GameConfiguration()
            {
                IsTieAllowed = true,
                WildCard = new Card(1, Suite.Pikes),
            };

            ICardGame game = new HighCard(cardDeck, config);
            Assert.AreEqual(GameResult.Win,  game.Play());
        }

        [TestMethod]
        public void TieTest()
        {
            var cards = new Stack<Card>();
            cards.Push(new Card(1, Suite.Pikes));
            cards.Push(new Card(1, Suite.Pikes));

            var cardDeck = new SimpleCardDeck(cards);

            var config = new GameConfiguration()
            {
                IsTieAllowed = true,
            };

            ICardGame game = new HighCard(cardDeck, config);
            Assert.AreEqual(GameResult.Tie, game.Play());
        }

        [TestMethod]
        public void TieNotAllowedTest()
        {
            var cards = new Stack<Card>();
            cards.Push(new Card(1, Suite.Clovers));
            cards.Push(new Card(4, Suite.Pikes));
            cards.Push(new Card(1, Suite.Pikes));
            cards.Push(new Card(1, Suite.Pikes));

            var cardDeck = new SimpleCardDeck(cards);

            var config = new GameConfiguration()
            {
                IsTieAllowed = false
            };

            ICardGame game = new HighCard(cardDeck, config);
            Assert.AreNotEqual(GameResult.Tie, game.Play());
        }

        [TestMethod]
        public void SuitePrecedenceTest()
        {
            var cards = new Stack<Card>();
            cards.Push(new Card(1, Suite.Clovers));
            cards.Push(new Card(1, Suite.Pikes));

            var cardDeck = new SimpleCardDeck(cards);

            var config = new GameConfiguration()
            {
                SuitePrecedence = new Suite[] { Suite.Clovers, Suite.Hearts, Suite.Pikes, Suite.Tiles },
                IsTieAllowed = false
            };

            ICardGame game = new HighCard(cardDeck, config);
            Assert.AreEqual(GameResult.Lose, game.Play());
        }
    }
}
