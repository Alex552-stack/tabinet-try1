using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;

namespace tabinet_try1.Classes
{
    public class Board
    {
        public List<Card> Tabla { get; set; }
        public Board()
        {
            Tabla = new List<Card>();
        }
        public void AddCardToBoard(Card card)
        {
            Tabla.Add(card);
        }
       /* public Card SelectCard(int index)
        {
            if (index >= 0 && index < Tabla.Count)
            {
                Card selectedCard = Tabla[index];
                return selectedCard;
            }
            else
            {
                return null;
            }
        }*/
    }
}
