using CardGames.Enums;

namespace CardGames.Models
{
    public class Card
    {
        public Card(short value, Suite suite)
        {
            Value = value;
            Suite = suite;
        }

        public short Value { get; set; }
        public Suite Suite { get; set; }
        public bool IsWildCard { get; set; }

        public static bool operator <(Card left, Card right)
        {
            if (left.IsWildCard)
            {
                return false;
            }
            else if (right.IsWildCard)
            {
                return true;
            }
            return left.Value < right.Value;
        }
        public static bool operator >(Card left, Card right)
        {
            if (left.IsWildCard)
            {
                return true;
            }
            else if (right.IsWildCard)
            {
                return false;
            }
            return left.Value > right.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Value == card.Value &&
                   Suite == card.Suite &&
                   IsWildCard == card.IsWildCard;
        }

        public override int GetHashCode()
        {
            int hashCode = -95761440;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Suite.GetHashCode();
            hashCode = hashCode * -1521134295 + IsWildCard.GetHashCode();
            return hashCode;
        }
    }
}
