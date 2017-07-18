using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSPG; //to set window parameters

namespace BlackJack
{
    class Program
    {
        static Player player = new Player();
        static Deck deck = new Deck();
        static Hand hand = new Hand();
        static Dealer dealer = new Dealer();

        static void Main(string[] args)
        {


            Utility.SetupWindow("♣♥ BlackJack ♦♠", 70, 30, false);


            while (Gameover() == false)
            {
                //New Game \ Reset
                deck.CreateDeck();
                hand.ResetHand();
                dealer.ResetHand();

                //Beginning hand
                hand.addCardtoHand(deck.DrawCard());
                hand.addCardtoHand(deck.DrawCard());
                Cards card = deck.DrawCard();
                card.Faceup = false;
                dealer.addCardtoHand(card); //Needs to be faced down
                dealer.addCardtoHand(deck.DrawCard());
                Console.Clear();
                Render();

                //Bets
                int amt;
                do
                {
                    Console.Write("Bet ammount?");
                    amt = Utility.ReadInt();
                    Console.Clear();
                    Render();
                } while (Utility.IsReadGood() && player.getMoney() < amt || amt <= 0);
                player.Bet(amt);
                Console.Clear();
                Render();

                //Draws
                while (hand.Hit() == true)
                {
                    Console.Clear();
                    hand.addCardtoHand(deck.DrawCard());
                    Render();
                    if (hand.handValue() > 21)
                        break;
                }
                Console.Clear();
                Render();

                //Final hand
                if (hand.handValue() > 21)
                    Console.Write("Bust!");

                Console.WriteLine("Your total is " + hand.handValue());
                Console.WriteLine("----------------------------------------------------------------------");

                while (dealer.dealerHit())
                {
                    if (hand.handValue() > 21)
                        break;
                    dealer.addCardtoHand(deck.DrawCard());
                    Render();
                }

                //Determine winner & money distribution
                if (hand.handValue() < dealer.getHandValue() && dealer.getHandValue() <= 21 || hand.handValue() > 21)
                {
                    dealer.setMoney(dealer.getMoney() + amt);
                    Console.SetCursorPosition(0, 5);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You Lost $" + amt);
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 3);
                    Console.Write("Dealer had: " + dealer.getHandValue());
                }
                else if (hand.handValue() > dealer.getHandValue() && hand.handValue() <= 21 || dealer.getHandValue() > 21)
                {
                    dealer.setMoney(dealer.getMoney() - amt);
                    player.setMoney(player.getMoney() + amt + amt);
                    Console.SetCursorPosition(0, 5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You won $" + amt);
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 3);
                    Console.Write("Dealer had: " + dealer.getHandValue());
                }
                else
                {
                    Console.SetCursorPosition(35, 3);
                    Console.Write("Dealer had: " + dealer.getHandValue());
                    Console.SetCursorPosition(0, 5);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("A tie occured, money returned");
                    Console.ResetColor();
                    player.setMoney(player.getMoney() + amt);
                }
                if (dealer.getHandValue() > 21)
                {
                    Console.SetCursorPosition(35, 3);
                    Console.Write("The Dealer busted");
                }
                card.Faceup = true;
                Render();
                Console.SetCursorPosition(0, 6);
                /* Optional question
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Press ENTER to play the next round...");
                Console.ResetColor();
                */
                Console.Read();

                //End screen
                if (player.getMoney() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Utility.WriteCentered("You lost to the dealer. You are now homeless");
                    break;
                }
                if (dealer.getMoney() <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Utility.WriteCentered("You win! Now the Cassino kicks you out for \"cheating\"!");
                    break;
                }
                Console.Clear();
                Render();

            }
            Console.ResetColor();
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to exit...");
            Console.Read();
            Console.ReadLine();
        }

        static bool Gameover()
        {
            if (player.getMoney() <= 0)
                return true;
            else
                return false;
        }

        static void Render()
        {
            //Player
            Console.SetCursorPosition(0, 0);
            Console.Write("Player: ");
            hand.Display();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(0, 1);
            Console.Write("Money: $" + player.getMoney());
            Console.ResetColor();
            //Dealer
            Console.SetCursorPosition(35, 0);
            Console.Write("Dealer: ");
            dealer.DisplayHand();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(35, 1);
            Console.Write("Money: $" + dealer.getMoney());
            Console.ResetColor();

            Console.SetCursorPosition(0, 2);
            Console.Write("----------------------------------------------------------------------");
        }

    }
}