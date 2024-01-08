using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabinet_try1.Classes
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck() // Pachetul de carti
        {
            cards = new List<Card>();
            random = new Random();

            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks = { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
        public Deck(List<Card> initialCards)
        {
            cards = initialCards;
        }

        public int CardsCount()
        {
            return cards.Count;
        }
        public void Shuffle() // Metoda de shuffle 
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card DrawCard() // Metoda de a extrage o carte din pachet.
        {
            if (cards.Count == 0) // Verificam cazul in care pachetul de carti este gol.
            {
                Console.WriteLine("Pachetul este gol.");
                return null;
            }

            Card drawnCard = cards[cards.Count - 1]; // Extragem cartea de deasupra pachetului.
            cards.RemoveAt(cards.Count - 1); // O scoatem din pachet.
            return drawnCard;
        }

    }
}
