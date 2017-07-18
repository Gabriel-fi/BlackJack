using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        int money;
        Hand hand;

        public Player()
        {
            money = 1000;
        }

        public int Bet(int bet) //bool? (no return tupe)
        {
            try
            {
                if (money > 0 && money >= bet && bet >= 0)
                    money -= bet;
                return money;
            }
            catch (Exception)
            {
                Console.Write("Can't bet with that amount. Game Over!!");
                throw;
            }
        }

        public int getMoney()
        {
            return money;
        }
        public void setMoney(int money)
        {
            this.money = money;
        }


    }
}
