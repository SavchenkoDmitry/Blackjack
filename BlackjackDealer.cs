using System;
using System.Collections.Generic;

namespace Blackjack_Game
{
    class BlackjackDealer
    {
        const int standartDeckAmount = 2;

        private BlackJackRules rules;
        private Deck deck;
        private int bet;
        public List<Card> playerHand { get; private set; }
        public List<Card> dealerHand { get; private set; }

        public BlackjackDealer(int deckAmount = standartDeckAmount)
        {
            deck = new Deck(deckAmount);
            rules = new BlackJackRules();
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            deck.Shaffle();
        }
        

        private void ClearBoard()
        {
            playerHand.Clear();
            dealerHand.Clear();
            if (rules.IsTimeToShuffle(deck.deckMarker, deck.CardsInDeck()))
            {
                deck.Shaffle();
            }
        }

        public bool IsEnoughForPlayer()
        {
            return rules.IsEnoughForPlayer(playerHand);
        }

        public void RoundStart(int _bet)
        {
            ClearBoard();
            bet = _bet;
            DrowForDealer();
            DrowForPlayer();
            DrowForPlayer();
        }

        public void DrowForPlayer()
        {
            playerHand.Add(deck.DrowCard());
        }
        public void DrowForDealer()
        {
            dealerHand.Add(deck.DrowCard());
        }

        private void DrowMoreForDealer()
        {
            do
            {
                DrowForDealer();
            }
            while (!rules.IsEnoughForDealer(dealerHand));
        }

        public int GetPlayerPoints()
        {
            return rules.CalculatePoints(playerHand);
        }
        public int GetDealerPoints()
        {
            return rules.CalculatePoints(dealerHand);
        }

        private int CalculatePrize()
        {
            return (int) rules.CalculatePrizeMultiplier(dealerHand, playerHand) * bet;
        }

        public int RoundEnd()
        {
            DrowMoreForDealer();
            int prize = CalculatePrize();
            return prize;
        }
    }
}