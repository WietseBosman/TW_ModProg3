using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversiGame
{
    public partial class ReversiGame : Form
    {
        BoardSpace[][] board;
        public const int spaceSize = 80;
        const int tokenSize = 30;
        const int boardX = 200;
        const int boardY = 200;

        public ReversiGame()
        {
            InitializeComponent();

            this.Paint += draw;
            board = new BoardSpace[3][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new BoardSpace[3];
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = new BoardSpace(spaceSize)
                    {
                        Location = new Point(boardX + i * spaceSize, boardY + j * spaceSize)
                    };
                    this.Controls.Add(board[i][j]);
                }
            }
            this.Invalidate();
                

        }

        //responsible for drawing the board, score and gamestate.
        private void draw(object obj, PaintEventArgs pea)
        {

        }

        //draws the board, optionally including help indications
        private void drawBoard()
        {

        }

        //redraws the board when the help checkbox is changed 
        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        //resets the board- and gamestate and resizes the board
        private void newGame()
        {

        }

        //checks whether the current player can make a move onto this space
        private void checkMove()
        {

        }

        //handles a player move
        private void makeMove()
        {

        }
    }

 }
