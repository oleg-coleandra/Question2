using CardGames.Enums;
using CardGames.Models;

namespace CardGames.HighCard
{
    public class GameConfiguration
    {
        public Suite[] SuitePrecedence { get; set; }
        public Card WildCard { get; set; }
        public bool IsTieAllowed { get; set; }
    }
}
