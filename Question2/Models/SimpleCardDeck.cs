using CardGames.Enums;
using CardGames.Exceptions;
using CardGames.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Models
{
    public class SimpleCardDeck : ICardDeck
    {
        public SimpleCardDeck(short maxCardValue = 13)
        {
            MaxCardValue = maxCardValue;
            var cards = new List<Card>();
            for (short i = 0; i < MaxCardValue; i++)
            {
                for (short j = 1; j <= 4; j++)
                {
                    cards.Add(new Card(i, (Suite)j));
                }
            }
            cards.Shuffle();
            Cards = new Stack<Card>(cards);
        }
        public SimpleCardDeck(Stack<Card> cards)
        {
            if (!cards.Any())
                throw new EmptyCardDeckException();
            Cards = cards;
            MaxCardValue = Cards.Max(p => p.Value);
        }

        private short _maxCardValue;
        public short MaxCardValue { 
            get
            {
                return _maxCardValue;
            }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException($"Max card value should be greater than 0");
                else
                    _maxCardValue = value;
            }
        }

        private Stack<Card> _cards = new Stack<Card>();
        public Stack<Card> Cards
        {
            get
            {
                return _cards;
            }
            protected set
            {
                if (value.Count < 1)
                    throw new EmptyCardDeckException();
                else
                    _cards = value;
            }
        } 
        public Stack<Card> PrecedingCards { get; protected set; } = new Stack<Card>();
        public Card Pop()
        {
            try
            {
                var card = Cards.Pop();
                PrecedingCards.Push(card);
                return card;
            }
            catch
            {
                throw new EmptyCardDeckException();
            }
        }
    }
}
