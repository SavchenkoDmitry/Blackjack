using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class BlackJackRules
    {
        #region const
        const float partOfCardsAfterSuffleCard = 1 / 3;
        const int picturesPrice = 10;
        const int aceAlternativeValue = 11;
        const int maxPointsToWin = 21;
        const int minDealerHand = 17;
        const int picturesAfterValue = 10;
        const int minCardsInHand = 2;
        const float priceForBlackjackMultiplier = 2.5f;
        const float winPriceMulriplier = 2;
        const float drawPriceMulriplier = 1;
        const float losePriceMulriplier = 0;
        #endregion

        public bool IsTimeToShuffle(int marker, int nCards)
        {
            return marker > nCards * partOfCardsAfterSuffleCard;
        }

        public int GetCardValue(Card card)
        {
            if ((int)card.value > picturesAfterValue)
            {
                return picturesPrice;
            }
            return (int)card.value;
        }

        public int CalculatePoints(List<Card> hand)
        {
            int points = 0;
            int alternativeAces = 0;
            foreach (Card c in hand)
            {
                if (c.value == Card.CardValue.Ace)
                {
                    points += aceAlternativeValue;
                    alternativeAces++;
                    continue;
                }
                points += GetCardValue(c);
            }
            while (alternativeAces > 0 && points > maxPointsToWin)
            {
                points += (int)Card.CardValue.Ace - aceAlternativeValue;
                alternativeAces--;
            }
            return points;
        }

        public bool IsEnoughForDealer(List<Card> hand)
        {
            return CalculatePoints(hand) >= minDealerHand;
        }
        public bool IsEnoughForPlayer(List<Card> hand)
        {
            return CalculatePoints(hand) >= maxPointsToWin;
        }
        public bool IsDraw(int dealerPoints, int playerPoints)
        {
            return (dealerPoints == playerPoints) || (playerPoints > maxPointsToWin && dealerPoints > maxPointsToWin);
        }
        public bool IsLose(int dealerPoints, int playerPoints)
        {
            return dealerPoints <= maxPointsToWin &&(playerPoints > maxPointsToWin  || playerPoints < dealerPoints);
        }
        public bool IsBlackjack(int points, int cards)
        {
            return points == maxPointsToWin && cards == minCardsInHand;
        }

        public float CalculatePrizeMultiplier(List<Card> dealerHand, List<Card> playerHand)
        {
            int dealerPoints = CalculatePoints(dealerHand);
            int playerPoints = CalculatePoints(playerHand);
            if (IsBlackjack(playerPoints, playerHand.Count) && !IsBlackjack(dealerPoints, dealerHand.Count))
                return priceForBlackjackMultiplier;
            if (IsLose(dealerPoints, playerPoints) || (IsBlackjack(dealerPoints, dealerHand.Count) && !IsBlackjack(playerPoints, playerHand.Count)))
                return losePriceMulriplier;
            if (IsDraw(dealerPoints, playerPoints))
                return drawPriceMulriplier;

            return winPriceMulriplier;
        }
    }
}
