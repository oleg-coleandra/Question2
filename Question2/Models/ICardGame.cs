using CardGames.Enums;

namespace CardGames.Models
{
    public interface ICardGame
    {
        GameResult Play();
    }
}
