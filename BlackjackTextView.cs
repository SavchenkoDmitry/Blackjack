using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Blackjack_Game
{
    class BlackjackTextView : BlackjackViewInterface
    {
        TextReader input;
        TextWriter output;
        public BlackjackTextView(TextReader _input, TextWriter _output)
        {
            input = _input;
            output = _output;
        }
    
        #region output metods
        public void DrawCard(Card card)
        {
            output.WriteLine(card.value.ToString() + " of " +card.suit.ToString().ToLower());
        }

        public void DrawHand(List<Card> hand, int points)
        {
            foreach (Card c in hand)
                DrawCard(c);
            DrawPoints(points);
        }

        public void DrawPoints(int points)
        {
            output.WriteLine(points + " points");
        }

        public void DrawBoard(List<Card> dealerHand, int dealerPoints, List<Card> playerHand, int playerPoints)
        {
            output.WriteLine("\nDealer cards: ");
            DrawHand(dealerHand, dealerPoints);

            output.WriteLine("\nYour cards: ");
            DrawHand(playerHand, playerPoints);
        }

        public void GameResultLose()
        {
            output.WriteLine("Lose...");
        }

        public void GameResultWin(int sum)
        {
            output.WriteLine("Win! Your Prize is " + sum);
        }

        public void GameResultEqualPoints()
        {
            output.WriteLine("Drow.");
        }

        public void DrawBlackjack()
        {
            output.WriteLine("!!!_BLACKJACK_!!!.");
        }

        public void DrawDrowedCard(Card card)
        {
            output.WriteLine("\nDrowed: ");
            DrawCard(card);
        }
        public void DrawEndRound()
        {
            output.WriteLine("________________________________________________________\n");
        }
        #endregion


        #region input metods

        public int AskBet()
        {
            int bet;
            while (true)
            {
                output.WriteLine("Place the bet");
                if (Int32.TryParse(input.ReadLine(), out bet) && bet > 0)
                    break;
                output.WriteLine("Your bet is NaN. Try again.\n");
            }
            return bet;
        }

        public bool AskDrowMore()
        {
            while (true)
            {
                output.WriteLine("\n1 - take card; 2 - enough");
                string key = input.ReadLine();
                if (key == "1")
                {
                    return true;
                }
                if (key == "2")
                {
                    return false;
                }
                System.Console.WriteLine("Wrong key");
            }
        }

       
        #endregion
    }
}
