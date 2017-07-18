using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Cards
    {
        string face;
        bool faceup = true;
        int value;
        
        public bool Faceup
        {
            get
            {
                return faceup;
            }

            set
            {
                faceup = value;
            }
        }

        public Cards(string face,int value)
        {
            this.face = face;
            this.value = value;

        }

        public void Dislay()
        {
            if (Faceup) //Do I need to include a  ==true?
                Console.Write("[" + face + "]");
            else
                Console.Write("[//]");
        }

        public int getPointvalue()
        {
            return value;
        }

        public string getFacevalue()
        {
            return face;
        }

    }
}
