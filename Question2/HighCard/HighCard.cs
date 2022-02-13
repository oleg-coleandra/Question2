using CardGames.Enums;
using CardGames.Models;
using System;
using System.Linq;

namespace CardGames.HighCard
{
    public class HighCard : ICardGame
    {
        private ICardDeck _cardDeck;
        private GameConfiguration _config;

        public HighCard(ICardDeck cardDeck, GameConfiguration config)
        {
            _config = config;
            _cardDeck = cardDeck;
            if (_config.WildCard != null)
            {
                var card = _cardDeck.Cards.FirstOrDefault(p => p.Value == config.WildCard.Value &&
                                                    p.Suite == config.WildCard.Suite);
                if (card != null)
                {
                    card.IsWildCard = true;
                }
            }
        }

        public GameResult Play()
        {
            GameResult result;
            do
            {
                result = PlayTie(_cardDeck.Pop(), _cardDeck.Pop());
            }
            while (!_config.IsTieAllowed && result == GameResult.Tie);
            return result;
        }

        public GameResult PlayTie(Card systemCard, Card playerCard)
        {
            if (_config.SuitePrecedence != null)
            {

            }
            return systemCard < playerCard ? GameResult.Win : systemCard > playerCard ? GameResult.Lose : 
                _config.SuitePrecedence != null ? resolveTieBySuitePrecedence(systemCard, playerCard) : GameResult.Tie;
        }

        private GameResult resolveTieBySuitePrecedence(Card systemCard, Card playerCard)
        {
            if (systemCard.Suite == playerCard.Suite)
                return GameResult.Tie;
            return Array.IndexOf(_config.SuitePrecedence, systemCard.Suite) > Array.IndexOf(_config.SuitePrecedence, playerCard.Suite) ? GameResult.Lose : GameResult.Win;
        }
    }
}
