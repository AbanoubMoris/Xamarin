using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace PlayerTabbsManager
{
    class PLAYER_TABBS_MANAGER
    {

        //the wins indecies
        private int[,] wins = new int[,]
        {
            {3 , 4 , 5 },
            {6 , 7 , 8 },
            {0 , 4 , 8 },
            {2 , 4 , 6 },
            {0 , 3 , 6 },
            {1 , 4 , 7 },
            {2 , 5 , 8 },
            {0 , 1 , 2 }

        };

        //make the controler
        private bool playerTurn = true;

        //counter
        private int i;

        public string Winner = "";

        public bool checkWinner(Button[] button)
        {
            bool gameOver = false;

            for (int i = 0; i < 8; i++)
            {
                int a = wins[i, 0], b = wins[i, 1], c = wins[i, 2];

                //check if the button not pressed 
                if (button[a].Text == "" || button[b].Text == "" || button[c].Text == "")
                    continue;

                //check if there is 3 x or 3 o is connected together 
                if (button[a].Text == button[b].Text && button[b].Text == button[c].Text)
                {
                    Winner = button[a].Text;

                    button[a].BackgroundColor = button[b].BackgroundColor = button[c].BackgroundColor = Color.Red;
                    gameOver = true;
                    break;
                }
                bool full = true;
                if (!gameOver)
                {
                    foreach (Button but in button)
                    {
                        if (but.Text == "")
                        {
                            full = false;
                            break;
                        }
                    }
                }
                if (full)
                    gameOver = true;

            }
            return gameOver;
        }

        public void setBut(Button button)
        {
            if (button.Text == "")
            {
                if (playerTurn == true)
                {
                    button.Text = "X";
                }
                else
                    button.Text = "O";
                playerTurn = !playerTurn;
            }

        }
        public void rester(Button[] buttons)
        {
            playerTurn = true;
            foreach (Button but in buttons)
            {
                but.Text = "";
                but.BackgroundColor = Color.Gray;
            }
        }
    }
}