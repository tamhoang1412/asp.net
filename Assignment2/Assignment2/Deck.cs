using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Deck
    {
        private Card[] deck;
        private String[] suits = { "HEART", "DIAMOND", "SPADE", "CLUB" };

        public Deck()
        {
            deck = new Card[52];
            int cardIndex = -1;
            for (int rank = 1; rank <= 13; rank++)
            {
                for (int suit = 0; suit <= 3; suit++)
                {
                    deck[++cardIndex] = new Card(rank, suits[suit]);
                }
            }
        }

        public void display()
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(deck[i].Rank + " " + deck[i].Suit);
            }
        }
    }
}