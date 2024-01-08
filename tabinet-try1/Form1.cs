using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tabinet_try1.Classes;

namespace tabinet_try1
{
	public partial class Tabla : Form
	{
		/*Deck deck = new Deck();
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Player currentPlayer;
        List<PictureBox> TableCardsVisual = new List<PictureBox>();
        List<PictureBox> P1CardsVisual = new List<PictureBox>();
        List<PictureBox> P2CardsVisual = new List<PictureBox>();
        int selectedCard;
        int sum = 0;*/
		TabinetGame Game = new TabinetGame();
		List<PictureBox> TableCardsVisual = new List<PictureBox>();
		List<PictureBox> P1CardsVisual = new List<PictureBox>();
		List<PictureBox> P2CardsVisual = new List<PictureBox>();


		Board board = new Board();


		public string ImageString(Card card)
		{
			return card.Rank + "_of_" + card.Suit + ".png";
		}

		private void UpdateInterface()
		{
			UpdateHandP1();
			UpdateHandP2();
			UpdateBoard();
		}

		public void UpdateHandP1()
		{
			foreach (PictureBox pic in P1CardsVisual)
			{
				pic.BackgroundImage = null;
				pic.BackColor = Color.Transparent;
			}
			int i = 0;
			foreach (Card card in Game.player1.Hand)
			{
				P1CardsVisual[i++].BackgroundImage = Image.FromFile("../../Images/" + ImageString(card));
			}

		}
		public void UpdateHandP2()
		{
			foreach (PictureBox pic in P2CardsVisual)
			{
				pic.BackgroundImage = null;
				pic.BackColor = Color.Transparent;
			}
			int i = 0;
			foreach (Card card in Game.player2.Hand)
			{
				P2CardsVisual[i++].BackgroundImage = Image.FromFile("../../Images/" + ImageString(card));
			}
		}

		public void UpdateBoard()
		{
			foreach (PictureBox pic in TableCardsVisual)
			{
				pic.BackgroundImage = null;
				pic.BackColor = Color.Transparent;
			}
			int i = 0;
			foreach (Card card in Game.board.Tabla)
			{
				TableCardsVisual[i++].BackgroundImage = Image.FromFile("../../Images/" + ImageString(card));
			}

		}
		public Tabla()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			TableCardsVisual.Add(tabla_card1);
			TableCardsVisual.Add(tabla_card2);
			TableCardsVisual.Add(tabla_card3);
			TableCardsVisual.Add(tabla_card4);
			TableCardsVisual.Add(pictureBox1);
			TableCardsVisual.Add(pictureBox2);
			TableCardsVisual.Add(pictureBox3);

			P1CardsVisual.Add(p1_card1);
			P1CardsVisual.Add(p1_card2);
			P1CardsVisual.Add(p1_card3);
			P1CardsVisual.Add(p1_card4);
			P1CardsVisual.Add(p1_card5);
			P1CardsVisual.Add(p1_card6);

			P2CardsVisual.Add(p2_card1);
			P2CardsVisual.Add(p2_card2);
			P2CardsVisual.Add(p2_card3);
			P2CardsVisual.Add(p2_card4);
			P2CardsVisual.Add(p2_card5);
			P2CardsVisual.Add(p2_card6);

		}



		private void button1_Click(object sender, EventArgs e)
		{
			Game.Initialization();
			UpdateHandP1();
			UpdateHandP2();
			UpdateBoard();
			btnStart.Hide();
			picturedeck.Show();


		}
		private int ct = 0;
		private void picturedeck_Click(object sender, EventArgs e)
		{

			if (ct % 3 == 0)
			{
				foreach (PictureBox picture in P1CardsVisual)
				{
					picture.Show();
				}
				ct++;
			}

			else if (ct % 3 == 1)
			{
				foreach (PictureBox picture in P2CardsVisual)
				{
					picture.Show();
				}
				ct++;
			}

			else if (ct % 3 == 2)
			{
				foreach (PictureBox picture in TableCardsVisual)
				{
					picture.Show();
				}
				ct++;
			}
		}
		/*public void VerifCardEqual(Card cardboard)
        {

            if (currentPlayer.Hand[selectedCard].Valoare() == cardboard.Valoare())
            {
                if (currentPlayer.Hand[selectedCard].Valoare() >= 11)
                    currentPlayer.Points++;

                P1Points.Text = player1.Points.ToString(); //de sters
                currentPlayer.Hand.RemoveAt(selectedCard);
                board.Tabla.Remove(cardboard);
                UpdateInterface();

            }
        }*/

		/*public void VerifCardSum(Board board)
        {

            for (int i = 0; i < board.Tabla.Count; i++)
            {
                while (sum <= currentPlayer.Hand[selectedCard].Valoare())
                {
                    sum += board.Tabla[i].Valoare();
                    if (board.Tabla[i].Valoare() > 11) currentPlayer.Points++;
                    board.Tabla.RemoveAt(i);
                }
            }
            currentPlayer.Hand.RemoveAt(selectedCard);
            if(currentPlayer == player1)
            {
                P1CardsVisual[selectedCard].Image = null;
                P1CardsVisual.RemoveAt(selectedCard);
                currentPlayer = player2;
            }
            else
            {
                P2CardsVisual[selectedCard].Image = null;
                P2CardsVisual.RemoveAt(selectedCard);
                currentPlayer = player1;
            }



        }*/



		private void TableCardSelected(object sender, EventArgs e)
		{
			PictureBox pic = sender as PictureBox;
			SwitchColor(sender);
			if (pic.BackgroundImage != null)
				for (int i = 0; i < TableCardsVisual.Count; i++)
				{
					if (TableCardsVisual[i] == sender as PictureBox)
					{
						Game.BoardCardSelected(i);
						if (Game.VerifCardEqual())
						{
							UpdateInterface();
						}

					}
				}
		}

		private void SwitchColor(object obj)
		{
			PictureBox picture = obj as PictureBox;
			if (picture.BackColor == Color.Transparent)
			{
				picture.BackColor = Color.Purple;
			}
			else
			{
				picture.BackColor = Color.Transparent;
			}
		}

		private void PlayerCardSelect(object sender, EventArgs e)
		{
			PictureBox pic = sender as PictureBox;
			if (pic.BackgroundImage != null && Game.currentPlayer == Game.player1)
				for (int i = 0; i < P1CardsVisual.Count; i++)
				{
					P1CardsVisual[i].BackColor = Color.Transparent;
					if (P1CardsVisual[i] == sender as PictureBox)
					{
						Game.selectedCard = i;
						SwitchColor(sender);
					}
				}
			else if (pic.BackgroundImage != null)
				for (int i = 0; i < P2CardsVisual.Count; i++)
				{
					P2CardsVisual[i].BackColor = Color.Transparent;
					if (P2CardsVisual[i] == sender as PictureBox)
					{
						Game.selectedCard = i;
						SwitchColor(sender);
					}
				}

			/*for (int i = 0; i < P1CardsVisual.Count; i++)
			{
				if (Game.currentPlayer == Game.player1)
				{
					if (P1CardsVisual[i] == sender as PictureBox)
					{
						Game.selectedCard = i;
						return;
					}

				}
				else if (Game.currentPlayer == Game.player2)
				{
					if (P2CardsVisual[i] == sender as PictureBox)
					{
						Game.selectedCard = i;
						return;
					}
				}
			}*/



		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (Game.board.Tabla.Count < 7)
			{
				Game.PutCardDown();
				UpdateInterface();
			}
		}
	}
}
