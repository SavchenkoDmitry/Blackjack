using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class Player
    {
        BlackjackDealer dealer;

        public Player()
        {
            dealer = new BlackjackDealer();
        }

        private int PlaceTheBet()
        {
            int bet;
            while (true)
            {
                System.Console.WriteLine("Place the bet");
                if (Int32.TryParse(System.Console.ReadLine(), out bet))
                    break;
            }
            dealer.RoundStart(bet);
            return bet;
        }

        public void PrintCards(List<Card> hand)
        {
            foreach (Card c in hand)
                System.Console.WriteLine(c.ToString());
            System.Console.WriteLine(dealer.CalculatePoints(hand) + " points");
        }

        private void DrowCards()
        {
            if (IsEnough())
                System.Console.WriteLine("____Blackjack!____");
            else
            {
                bool enough = false;
                while (!enough)
                {
                    while (true)
                    {
                        System.Console.WriteLine("\n1 - take card; 2 - enough");
                        char key = System.Console.ReadKey().KeyChar;
                        if (key == '1')
                        {
                            DrowCard();
                            enough = IsEnough();
                            break;
                        }
                        else if (key == '2')
                        {
                            System.Console.WriteLine();
                            enough = true;
                            break;
                        }
                        else
                            System.Console.WriteLine("Wrong key");
                    }
                }
            }
        }
        private bool IsEnough()
        {
            return dealer.CalculatePoints(dealer.playerHand) >= 21;
        }

        private void DrowCard()
        {
            dealer.DrowMoreForPlayer();
            System.Console.WriteLine("\nDrowed: ");
            System.Console.WriteLine(dealer.playerHand[dealer.playerHand.Count - 1].ToString());
        }

        public void PrintBoard()
        {
            System.Console.WriteLine("\nDealer cards : ");
            PrintCards(dealer.dealerHand);

            System.Console.WriteLine("\nYour cards : ");
            PrintCards(dealer.playerHand);
        }

        public void PlayTheGame()
        {
            int bet = PlaceTheBet();
            PrintBoard();
            DrowCards();
            
            int prize = dealer.RoundEnd();
            System.Console.WriteLine();
            PrintBoard();

            System.Console.WriteLine();
            if (prize == 0)
                System.Console.WriteLine("Loose");
            else if (prize == bet)
                System.Console.WriteLine("Draw. Take " + prize + " back");
            else
                System.Console.WriteLine("Win. Take " + prize);
        }
    }
}
