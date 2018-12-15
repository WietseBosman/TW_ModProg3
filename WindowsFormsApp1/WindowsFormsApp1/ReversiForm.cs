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
        static readonly int[, ] directions = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 0, -1 } };

        BoardSpace[][] board;
        public const int spaceSize = 80;
        //const int tokenSize = 30;
        const int boardX = 200;
        const int boardY = 200;

        const byte turnBlue = 0;
        const byte turnRed = 1;
        const byte victoryBlue = 2;
        const byte victoryRed = 3;

        byte gameState;

        bool boardInitialized = false;

        public ReversiGame()
        {
            InitializeComponent();

            this.Paint += draw;

            this.textBoxSizeX.Text = "6";
            this.textBoxSizeY.Text = "4";
            this.newGame();
            
                

        }

        

        //responsible for drawing the board, score and gamestate.
        private void draw(object obj, PaintEventArgs pea)
        {
            //need an exception for when no board exists yet
            if (boardInitialized)
            this.drawBoard(pea);
        }

        //draws the board, optionally including help indications
        private void drawBoard(PaintEventArgs pea)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j].Draw(pea);
                }
            }
        }

        //redraws the board when the help checkbox is changed 
        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        //resets the board- and gamestate and resizes the board
        private void newGame()
        {
            boardInitialized = false;
            board = new BoardSpace[int.Parse(this.textBoxSizeX.Text)][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new BoardSpace[int.Parse(this.textBoxSizeY.Text)];
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = new BoardSpace()
                    {
                        Location = new Point(boardX + i * spaceSize, boardY + j * spaceSize),
                        Size = new Size(spaceSize, spaceSize)
                    };
                    this.Controls.Add(board[i][j]);
                }
            }
            boardInitialized = true;
            this.Invalidate();
        }

        //calculates which moves are legal
        private void checkMoves()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j].LegalMove = checkMove(i, j);
                }
            }
        }

        //checks whether the current player can make a move onto this space
        private bool checkMove(int i, int j)
        {
            for (int k = 0; k < 8; k++)
                if (checkDirection(i, j, directions[k,0], directions[k,1]))
                    return true;
            return false;
        }

        private bool checkDirection(int i, int j, int dirX, int dirY)
        {
            byte activeColour = (gameState == 0) ? BoardSpace.blue : BoardSpace.red;
            bool adjacentEnemy = false;

            for (int x = i; x <= board.Length && x >= 0; x += dirX)
                for (int y = j; y <= board[i].Length && y >= 0; y += dirY)
                {
                    if (board[x][y].state == activeColour)
                        if (adjacentEnemy == true)
                            return true;
                        else
                            return false;
                    else if (board[x][y].state == BoardSpace.empty)
                        return false;
                }

                    
            return false;
        }

        //handles a player move
        private void makeMove()
        {

        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            this.newGame();
        }
    }

 }
