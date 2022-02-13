using System.Collections.Generic;

namespace CardGames.Models
{
    public class CompoundCardDeck : SimpleCardDeck
    {
        public CompoundCardDeck(int nrOfDecks, short maxCardValue = 13)
        {
            var cards = new List<Card>();
            for (int i = 0; i < nrOfDecks; i++)
            {
                cards.AddRange(new SimpleCardDeck(maxCardValue).Cards);
            }
            Cards = new Stack<Card>(cards);
        }

        public CompoundCardDeck(IList<ICardDeck> cardDecks)
        {
            var cards = new List<Card>();
            foreach (var cardDeck in cardDecks)
            {
                if (cardDeck.MaxCardValue > MaxCardValue)
                {
                    MaxCardValue = cardDeck.MaxCardValue;
                }
                cards.AddRange(cardDeck.Cards);
            }
            Cards = new Stack<Card>(cards);
        }
    }
}
