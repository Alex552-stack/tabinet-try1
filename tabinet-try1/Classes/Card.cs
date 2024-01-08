using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabinet_try1.Classes
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public int Valoare()
        {
			switch (Rank)
			{
				case "ace":
					return 11;
				case "2":
					return 2;
				case "3":
					return 3;
				case "4":
					return 4;
				case "5":
					return 5;
				case "6":
					return 6;
				case "7":
					return 7;
				case "8":
					return 8;
				case "9":
					return 9;
				case "10":
					return 10;
				case "jack":
					return 12;
				case "queen":
					return 13;
				case "king":
					return 14;
				default:
					return 0;
			}
		}
    }
}
