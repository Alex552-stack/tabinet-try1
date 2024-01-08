using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabinet_try1.Classes
{
	public class TabinetGame
	{
		public Player player1;
		public Player player2;
		public Player currentPlayer;
		Deck deck = new Deck();
		public Board board;
		public int selectedCard = -1;
		List<Card> BoardSelectedCards = new List<Card>();
		public TabinetGame()
		{
			Initialization();
		}

		public void Initialization()
		{
			player1 = new Player("P1");
			player2 = new Player("P2");
			board = new Board();
			currentPlayer = player1;
			deck.Shuffle();
			DealCards();
			for (int i = 0; i < 4; i++)
			{
				Card cardboard = deck.DrawCard();
				board.AddCardToBoard(cardboard);
			}
		}

		private void DealCards()
		{
			for (int i = 0; i < 6; i++)
			{
				Card cardP1 = deck.DrawCard();
				player1.AddCardToHand(cardP1);
				Card cardP2 = deck.DrawCard();
				player2.AddCardToHand(cardP2);
			}
		}

		private int SumOfSelTableCards()
		{
			int sum = 0;
			foreach(Card card in BoardSelectedCards)
			{
				sum += card.Valoare();
			}
			return sum;
		}

		public bool VerifCardEqual()
		{
			if (selectedCard>0 && currentPlayer.Hand[selectedCard].Valoare() == SumOfSelTableCards())
			{
				if (currentPlayer.Hand[selectedCard].Valoare() >= 11)
					currentPlayer.Points++;

				//P1Points.Text = player1.Points.ToString(); //de sters
				currentPlayer.Hand.RemoveAt(selectedCard);
				foreach(Card card in BoardSelectedCards)
					board.Tabla.Remove(card);
				//UpdateInterface();
				NextTurn();
				return true;
				
			}
			return false;
		}

		private void NextTurn()
		{
			DealNextHand();
			BoardSelectedCards.Clear(); //Sterge tot continutul listei
			selectedCard = -1;
			currentPlayer = Opponent(currentPlayer);
		}

		private Player Opponent(Player player)
		{
			if (player == player1)
				return player2;
			else return player1;
		}

		public void BoardCardSelected(int Index)
		{
			if (BoardSelectedCards.Contains(board.Tabla[Index]))
			{
				RemoveBoardCardSelected(board.Tabla[Index]);
			}
			else
			{
				AddBoardCardSelected(board.Tabla[Index]);
			}
		}

		private bool DealNextHand()
		{
			if(Opponent(currentPlayer).Hand.Count == 0)
			{
				DealCards();
				return true;
			}
			return false;
		}

		public void PutCardDown()
		{
			if (selectedCard < 0)
				return;

			Card card = currentPlayer.Hand[selectedCard];
			currentPlayer.Hand.RemoveAt(selectedCard);
			board.Tabla.Add(card);
			NextTurn();
		}

		private void AddBoardCardSelected(Card card)
		{
			BoardSelectedCards.Add(card);
		}
		private void RemoveBoardCardSelected(Card card)
		{
			BoardSelectedCards.Remove(card);
		}


		public List<Card> GetP1Cards()
		{
			return player1.Hand;
		}
		public List<Card> GetP2Cards()
		{
			return player2.Hand;
		}
		public List<Card> GetBoard()
		{
			return board.Tabla;
		}
	}
}
