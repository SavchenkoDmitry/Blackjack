using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    
    class Card
    {
        public enum CardSuit { Diamonds, Spades, Clubs, Hearts };

        public enum CardValue {Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}

        public readonly CardSuit suit;
        public readonly CardValue value;

        public Card (CardSuit _s, CardValue _v)
        {
            suit = _s;
            value = _v;
        }
        public Card(int _s, int _v)
        {
            suit = (CardSuit)_s;
            value = (CardValue)_v;
        }

        public override string ToString()
        {
            return value.ToString() + " of " + suit.ToString().ToLower();
        }
    }
}
