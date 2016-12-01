using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class GameSession
    {
        BlackjackDealer dealer;
        BlackjackViewInterface textVeiw;

        public GameSession(BlackjackViewInterface tv)
        {
            dealer = new BlackjackDealer();
            textVeiw = tv;
        }

        public void RunGameLoop()
        {
            while (true)
            {
                PlayTheGame();
                textVeiw.DrawEndRound();
            }
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
                textVeiw.GameResultLose();
            if (prize == bet)
                textVeiw.GameResultEqualPoints();
            if (prize > bet)
                textVeiw.GameResultWin(prize);
        }

        private int PlaceTheBet()
        {
            int bet = textVeiw.AskBet();
            dealer.RoundStart(bet);
            return bet;
        }

        private void DrowCards()
        {
            if (dealer.IsEnoughForPlayer())
            {
                textVeiw.DrawBlackjack();
                return;
            }
            while (true)
            {
                if (!textVeiw.AskDrowMore())
                    break;
                DrowCard();
                if (dealer.IsEnoughForPlayer())
                    break;

            }
        }

        private void DrowCard()
        {
            dealer.DrowForPlayer();
            textVeiw.DrawDrowedCard(dealer.playerHand[dealer.playerHand.Count - 1]);
        }

        public void PrintBoard()
        {
            textVeiw.DrawBoard(dealer.dealerHand, dealer.GetDealerPoints(), dealer.playerHand, dealer.GetPlayerPoints());
        }
        
    }
}
