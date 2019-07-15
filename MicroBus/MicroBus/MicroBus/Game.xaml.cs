using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlayerTabbsManager;
namespace MicroBus
{
    class AIMoves
    {
        public AIMoves() { }
        public AIMoves(int score) { AI_Score = score; }
        public int AI_Score;
        public int AI_pos;

    }

    public partial class Game : ContentPage
    {
        PLAYER_TABBS_MANAGER ptm = new PLAYER_TABBS_MANAGER();
        Button[] buttons = new Button[9];
        bool twoPlayers;
        public Game()
        {
            InitializeComponent();


            buttons[0] = (Button)b1;
            buttons[1] = (Button)b2;
            buttons[2] = (Button)b3;
            buttons[3] = (Button)b4;
            buttons[4] = (Button)b5;
            buttons[5] = (Button)b6;
            buttons[6] = (Button)b7;
            buttons[7] = (Button)b8;
            buttons[8] = (Button)b9;

        }

        public Game(bool TwoPlayer)
        {
            InitializeComponent();

            buttons[0] = (Button)b1;
            buttons[1] = (Button)b2;
            buttons[2] = (Button)b3;
            buttons[3] = (Button)b4;
            buttons[4] = (Button)b5;
            buttons[5] = (Button)b6;
            buttons[6] = (Button)b7;
            buttons[7] = (Button)b8;
            buttons[8] = (Button)b9;

            this.twoPlayers = TwoPlayer;
        }
        string[] AIBTN = new string[9];
        void Aibtn()
        {
            for (int i = 0; i < 9; i++) AIBTN[i] = buttons[i].Text;
        }


        bool isMoveLeft()
        {
            for (int i = 0; i < 9; i++)
            {
                if (AIBTN[i] == "") return true;
            }
            return false;
        }

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
        public int checkWinner(string[] button)
        {
            bool gameOver = false;

            for (int i = 0; i < 8; i++)
            {
                int a = wins[i, 0], b = wins[i, 1], c = wins[i, 2];

                //check if the button not pressed 
                if (button[a] == "" || button[b] == "" || button[c] == "")
                    continue;

                //check if there is 3 x or 3 o is connected together 
                if (button[a] == button[b] && button[b] == button[c] && button[c] == "O") return 1;
                else if (button[a] == button[b] && button[b] == button[c] && button[c] == "X") return 0;
            }
            return 5;
        }
        class AIMoves
        {
            public AIMoves() { }
            public AIMoves(int score) { AI_Score = score; }
            public int AI_Score;
            public int AI_pos;

        }
        // 1 --> AI
        // 2 --> Player
        AIMoves BestMove(string[] btn, int Player, int depth)
        {
            int winner = checkWinner(btn);


            if (winner == 1) return new AIMoves(10);
            else if (winner == 0) return new AIMoves(-10);
            else if (!isMoveLeft()) return new AIMoves(0);
            if (depth == 9) return new AIMoves(0);

            List<AIMoves> moves = new List<AIMoves>();
            for (int i = 0; i < 9; i++)
            {
                if (btn[i] == "")
                {
                    AIMoves m = new AIMoves();

                    m.AI_pos = i;

                    if (Player == 1)
                        btn[i] = "O";

                    else
                        btn[i] = "X";

                    if (Player == 1) m.AI_Score = BestMove(btn, 0, depth + 1).AI_Score;

                    else m.AI_Score = BestMove(btn, 1, depth + 1).AI_Score;


                    moves.Add(m);
                    btn[i] = "";



                }
            }
            int bestMove = 0;
            if (Player == 1)
            {
                int score = -1000000;
                for (int i = 0; i < moves.Count(); i++)
                {
                    if (moves[i].AI_Score > score)
                    {
                        bestMove = i;
                        score = moves[i].AI_Score;
                    }
                }
                return moves[bestMove];
            }
            else
            {
                int score = 1000000;
                for (int i = 0; i < moves.Count(); i++)
                {
                    if (moves[i].AI_Score < score)
                    {
                        bestMove = i;
                        score = moves[i].AI_Score;
                    }
                }
                return moves[bestMove];
            }

        }

        private void Clicked(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "" && !ptm.checkWinner(buttons))
            {
                ptm.setBut((Button)sender);

                if (!twoPlayers)
                {
                    Aibtn();

                    ptm.setBut(buttons[BestMove(AIBTN, 1, 0).AI_pos]);
                }
                if (ptm.checkWinner(buttons))
                {
                    playAgain.IsVisible = true;
                    int o = Int32.Parse(OScore.Text);
                    if (ptm.Winner == "O") OScore.Text = (((Int32.Parse(OScore.Text))) + 1).ToString();
                    else if (ptm.Winner == "X") XScore.Text = (((Int32.Parse(XScore.Text))) + 1).ToString();
                    ptm.Winner = "";
                }
            }
        }

        private void PlayAgain_Clicked(object sender, EventArgs e)
        {
            ptm.rester(buttons);
            playAgain.IsVisible = false;
        }
    }
}