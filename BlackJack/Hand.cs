using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Hand
    {
        List<Cards> hand = new List<Cards>();
        Deck deck;

        public Hand()
        {
         
        }

        public void ResetHand()
        {
            hand.Clear();
        }

        public bool Hit()
        {
            char response;
            bool _hit=false;
            do
            {
                Console.WriteLine();
                Console.Write("Do you Hit?: (Y or N)");
                response = (char)Console.Read();
                Console.ReadLine();
                response = char.ToUpper(response);

                if (response == 'Y')
                {
                    _hit = true;
                }
                else if (response == 'N')
                    _hit = false;
                else
                    Console.WriteLine("You must respond Y or N!");

            } while (response != 'Y' && response != 'N');

            if (_hit == true)
                return true;
            else
                return false;
        }
        public void addCardtoHand(Cards card)
        {
            hand.Add(card);
        }
        public int handValue()
        {
            int totalValue = 0;
            for (int i = 0; i < hand.Count; i++)
            {
               totalValue += hand[i].getPointvalue();
                if (totalValue > 21 && hand[i].getFacevalue() == "A♥")
                    totalValue = totalValue - 10;
                else if (totalValue > 21 && hand[i].getFacevalue() == "A♦")
                    totalValue = totalValue - 10;
                else if (totalValue > 21 && hand[i].getFacevalue() == "A♣")
                    totalValue = totalValue - 10;
                else if (totalValue > 21 && hand[i].getFacevalue() == "A♠")
                    totalValue = totalValue - 10;
            }
            return totalValue;
        }

        public void Display()
        {
            foreach (Cards c in hand)
            {
                c.Dislay();
            }
        }
    }
}


