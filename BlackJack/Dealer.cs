using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer
    {
        Hand hand = new Hand();
        Deck deck;
        int money;

        public Dealer()
        {
            money = 2000;
        }

        public void ResetHand()
        {
            hand.ResetHand();
        }

        public bool dealerHit()
        {
            if (hand.handValue() < 17)
                return true;
            else
                return false;
        }


        public void Bet(int bet) //Take money away from dealer's
        {
            if (money > 0 && money >= bet && bet >= 0)
                money -= bet;
        }

        public int getHandValue()
        {
            return hand.handValue();
        }

        public void addCardtoHand(Cards card)
        {
            hand.addCardtoHand(card);
        }

        public int getMoney()
        {
            return money;
        }

        public void setMoney(int money)
        {
            this.money = money;
        }

        public void DisplayHand()
        {
            hand.Display();
        }
    }
}
