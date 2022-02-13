using System.Collections.Generic;

namespace CardGames.Models
{
    public interface ICardDeck
    {
        Stack<Card> Cards { get; }
        short MaxCardValue { get; }
        Card Pop();
    }
}
