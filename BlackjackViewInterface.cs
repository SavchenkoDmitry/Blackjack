using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    interface BlackjackViewInterface
    {
        void DrawCard(Card card);
        void DrawPoints(int points);
        void DrawHand(List<Card> hand, int points);
        void DrawBoard(List<Card> dealerHand, int dealerPoints, List<Card> playerHand, int playerPoints);
        void GameResultLose();
        void GameResultWin(int sum);
        void GameResultEqualPoints();
        void DrawBlackjack();
        void DrawDrowedCard(Card card);
        void DrawEndRound();


        int AskBet();
        bool AskDrowMore();

    }
}
