using System;
using System.Collections.Generic;

namespace Blackjack_Game
{
    class BlackjackDealer
    {
        #region const
        const int standartDeckAmount = 2;
        const int cardsInDeck = 52;
        const int suitAmount = 4;
        const int cardValuesAmount = 13;
        const int valueEnumFirstNumber = 1;
        #endregion

        private BlackJackRules rules;
        private Card[] entireDeck;
        private int deckMarker;
        private int bet;
        public List<Card> playerHand { get; private set; }
        public List<Card> dealerHand { get; private set; }

        public BlackjackDealer(int deckAmount = standartDeckAmount)
        {
            DeckInit(deckAmount);
            rules = new BlackJackRules();
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            Shaffle();
        }

        private void DeckInit(int deckAmount)
        {
            entireDeck = new Card[cardsInDeck * deckAmount];
            for (int i = 0; i < entireDeck.Length; i++)
            {
                int suit = (i / cardValuesAmount) % suitAmount;
                int value = i % cardValuesAmount + valueEnumFirstNumber;
                entireDeck[i] = new Card() { suit = (Card.CardSuit)suit, value = (Card.CardValue)value };
            }
        }

        private void Shaffle()
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
        }

        private void ClearBoard()
        {
            playerHand.Clear();
            dealerHand.Clear();
            if (rules.IsTimeToShuffle(deckMarker, entireDeck.Length))
            {
                Shaffle();
                deckMarker = 0;
            }
        }

        private void DrowCard(List<Card> hand)
        {
            hand.Add(entireDeck[deckMarker]);
            deckMarker++;            
        }

        public bool IsEnoughForPlayer()
        {
            return rules.IsEnoughForPlayer(playerHand);
        }

        public void RoundStart(int _bet)
        {
            ClearBoard();
            bet = _bet;
            DrowCard(dealerHand);
            DrowCard(playerHand);
            DrowCard(playerHand);
        }

        public void DrowMoreForPlayer()
        {
            DrowCard(playerHand);
        }
        private void DrowMoreForDealer()
        {
            do
            {
                DrowCard(dealerHand);
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