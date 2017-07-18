using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        List<Cards> deck;
        int face;

        public Deck()
        {
            deck = new List<Cards>();

        }

        public void CreateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                //if (i % 13 == 0)//testing
                //Console.WriteLine('\n'); //testing
                Cards card = new Cards(FaceValue(i)+symbol(i),Pointvalue(i));
                deck.Add(card);
                
                //card.Dislay();//For testing purposes


            }
        }
        
        public String symbol(int _val)
        {
            if (_val <= 12)
                return "♥";

            else if (_val >= 13&&_val<=25)
                return "♦";

            else if (_val >= 26 && _val <= 38)
                return "♠";

            else if (_val >= 39 && _val <= 52)
                return "♣";

            return "";
        }

        public String FaceValue(int face)
        {
            this.face = face;

            int modVal = face % 13;

            if (modVal == 0)
                return "K";

            else if (modVal == 1)
                return "A";

            else if (modVal == 11)
                return "J";

            else if (modVal == 12)
                return "Q";

            else
                return modVal.ToString();
        }
        public int Pointvalue(int _val)
        {
            int modVal = _val % 13;

            if (modVal == 0 || modVal == 11 || modVal == 12)
                return 10;

            else if (modVal == 1)
                return 11;
            else
                return modVal;
        }

        public Cards DrawCard()
        {
            Random rand = new Random((Guid.NewGuid().GetHashCode()));
            int index = rand.Next(0,deck.Count);
            Cards card;
            card = deck[index];
            deck.RemoveAt(index);
            return card;
        }


        //Val will be randomized to give me a value from 0 - 52

        /* 
        ♥ Hearts = 0-12
        ♦ Diamnons = 13-25
        ♠ Spades = 26-39
        ♣ Clubs = 40-52
        */

        //Then Val would be moded to give me a value from 0 - 12

        /* Val would work with mod (val % 13)
        0=K
        1=A
        2=2
        3=3
        4=4
        ...
        10=10
        11=J
        12=Q
        */
    }
    }
