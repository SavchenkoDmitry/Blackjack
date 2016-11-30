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

        public CardSuit suit;
        public CardValue value;
    }
}
