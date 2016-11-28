using System;
using System.Collections.Generic;

namespace Blackjack_Game
{
    class BlackjackDealer
    {
        private Card[] entireDeck;
        private int deckMarker;
        private int bet;
        public List<Card> playerHand { get; private set; }
        public List<Card> dealerHand { get; private set; }

        public BlackjackDealer(int deckAmount = 2)
        {
            DeckInit(deckAmount);
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            Shaffle();
        }

        private void DeckInit(int deckAmount)
        {
            entireDeck = new Card[52 * deckAmount];
            for (int i = 0; i < 52 * deckAmount; i++)
            {
                int suit = (i / 13) % 4;
                int value = i % 13 + 1;
                entireDeck[i] = new Card(suit, value);
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
            if (deckMarker > entireDeck.Length / 3)
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

        public int CalculatePoints(List<Card> hand)
        {
            int points = 0;
            int aces = 0;
            foreach (Card c in hand)
            {
                int value = (int)c.value;
                if (value > 10) points += 10;
                else if (value == 1) { points += 11; aces++; }
                else points += value;
            }
            while (aces > 0 && points > 21)
            {
                aces--;
                points -= 10;
            }
            return points;
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
            while (CalculatePoints(dealerHand) < 17);
        }

        public int CalculatePrize()
        {
            int playerPoints = CalculatePoints(playerHand);
            int dealerPoints = CalculatePoints(dealerHand);
            if (playerPoints == dealerPoints || (playerPoints > 21 && dealerPoints > 21))
                return bet;
            else if (playerPoints > 21 || (playerPoints < dealerPoints && dealerPoints <= 21))
                return 0;
            else if (playerPoints == 21 && playerHand.Count == 2)
                return bet * 3;
            else
                return bet * 2;
        }

        public int RoundEnd()
        {
            DrowMoreForDealer();
            int prize = CalculatePrize();
            return prize;
        }
    }
}