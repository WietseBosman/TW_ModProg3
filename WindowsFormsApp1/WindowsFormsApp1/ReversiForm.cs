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


        const int maxSpaceSize = 140;
        const int minSpaceSize = 30;
        public int spaceSize = 60;
        
        int boardX = 200;
        int boardY = 200;

        const byte turnBlue = 0;
        const byte turnRed = 1;
        const byte victoryBlue = 2;
        const byte victoryRed = 3;

        byte gameState;

        bool boardInitialized = false;

        public ReversiGame()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += draw;
            this.SizeChanged += sizeChanged;

            this.textBoxSizeX.Text = "6";
            this.textBoxSizeY.Text = "4";
            this.newGame();
            
                

        }

        //updates location of buttons and board when the size of the form gets changed
        private void sizeChanged(object obj, EventArgs e)
        {
            this.buttonNewGame.Location = new Point(this.ClientSize.Width / 2, 30);
            this.buttonUndo.Location = new Point(this.ClientSize.Width / 2, 60);

            //tekstvakken, labels, checkbox, board
              
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
                    board[i][j].Draw(pea, this.checkBoxHelp.Checked);
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

            board[board.Length / 2 - 1][board[0].Length / 2 - 1].state = BoardSpace.red;
            board[board.Length / 2 - 1][board[0].Length / 2    ].state = BoardSpace.blue;
            board[board.Length / 2    ][board[0].Length / 2 - 1].state = BoardSpace.blue;
            board[board.Length / 2    ][board[0].Length / 2    ].state = BoardSpace.red;

            switch (this.gameState)
            {
                case turnBlue:
                    this.labelGameState.Text = "Blue player's turn";
                    break;
                case turnRed:
                    this.labelGameState.Text = "Red player's turn";
                    break;
                case victoryBlue:
                    this.labelGameState.Text = "Blue is victorious!";
                    break;
                case victoryRed:
                    this.labelGameState.Text = "Red is victorious!";
                    break;
            }
            //this.checkMoves();
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
