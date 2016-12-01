using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class Deck
    {
        #region const
        const int cardsInDeck = 52;
        const int suitAmount = 4;
        const int cardValuesAmount = 13;
        const int valueEnumFirstNumber = 1;
        #endregion

        private Card[] entireDeck;
        public int deckMarker { get; private set; }

        public Deck(int deckAmount)
        {
            entireDeck = new Card[cardsInDeck * deckAmount];
            for (int i = 0; i < entireDeck.Length; i++)
            {
                int suit = (i / cardValuesAmount) % suitAmount;
                int value = i % cardValuesAmount + valueEnumFirstNumber;
                entireDeck[i] = new Card() { suit = (Card.CardSuit)suit, value = (Card.CardValue)value };
            }
            deckMarker = 0;
        }

        public int CardsInDeck()
        {
            return entireDeck.Length;
        } 

        public void Shaffle()
        {
            Card tmp;
            Random rand = new Random();
            for (int i = 0; i < entireDeck.Length - 1; i++)
            {
                int j = rand.Next(i, entireDeck.Length - 1);
                if (i != j)
                {
                    tmp = entireDeck[i];
                    entireDeck[i] = entireDeck[j];
                    entireDeck[j] = tmp;
                }
            }
            deckMarker = 0;
        }
        public Card DrowCard()
        {
            Card card = entireDeck[deckMarker];
            deckMarker++;
            return card;
        }

    }
}
