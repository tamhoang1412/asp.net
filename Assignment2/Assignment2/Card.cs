using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Card
    {
        private int rank;
        public int Rank
        {
            get { return rank; }
            set
            {
                if ((value > 0) && (value < 14))
                {
                    this.rank = value;
                }
                else
                {
                    this.rank = 2;
                }
            }
        }

        private string suit;
        public string Suit
        {
            get { return suit; }
            set
            {
                if (value.Equals("HEART") || value.Equals("CLUB") || value.Equals("DIAMOND") || value.Equals("SPADE"))
                {
                    this.suit = value;
                }
                else
                {
                    this.suit = "CLUB";
                }
            }
        }

        public Card()
        {
            this.Rank = 2;
            this.Suit = "CLUB";
        }

        public Card(int rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}
