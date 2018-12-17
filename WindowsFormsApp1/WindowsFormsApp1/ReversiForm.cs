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
    public partial class ReversiForm : Form
    {
        static readonly int[, ] directions = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };

        BoardSpace[,] board;


        const int maxSpaceSize = 140;
        const int minSpaceSize = 30;
        public int spaceSize = 60;
        
        int boardX = 200;
        int boardY = 200;

        const int playerBlue = 0;
        const int playerRed = 1;
        const int victory = 2;

        int boardWidth;
        int boardHeight;

        int turn;

        
        public int gameState;

        bool boardInitialized;

        public ReversiForm()
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

            //tbd: tekstvakken, labels, checkbox, board
            //tbd: change boardspacesize
              
        }

        //responsible for drawing the board, score and gamestate.
        private void draw(object obj, PaintEventArgs pea)
        {
            //need an exception for when no board exists yet
            if (boardInitialized)
            this.drawBoard(pea);
            switch (this.gameState)
            {
                case playerBlue:
                    this.labelGameState.Text = "Blue player's turn";
                    break;
                case playerRed:
                    this.labelGameState.Text = "Red player's turn";
                    break;
                case victory:
                    this.labelGameState.Text = "Someone is victorious!";
                    break;


            }
        }

        //draws the board, optionally including help indications
        private void drawBoard(PaintEventArgs pea)
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    board[i,j].Draw(pea, this.checkBoxHelp.Checked);
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
            if (this.boardInitialized)
            {
                for (int i = 0; i < this.boardWidth; i++)
                    for (int j = 0; j < this.boardHeight; j++)
                        this.Controls.Remove(this.board[i, j]);
            }

            this.boardInitialized = false;
            this.boardWidth = int.Parse(this.textBoxSizeX.Text);
            this.boardHeight = int.Parse(this.textBoxSizeY.Text);
            this.board = new BoardSpace[this.boardWidth, this.boardHeight];
            //tbd: change boardspacesize

            for (int i = 0; i < this.boardWidth; i++)
            {
                
                for (int j = 0; j < this.boardHeight; j++)
                {
                    this.board[i,j] = new BoardSpace()
                    {
                        Location = new Point(this.boardX + i * this.spaceSize, this.boardY + j * this.spaceSize),
                        Size = new Size(spaceSize, spaceSize),
                        x = i, y = j,
                        state = BoardSpace.empty,
                    };
                this.board[i,j].Click += this.makeMove;
                this.Controls.Add(this.board[i,j]);
                }
            }

            this.board[boardWidth / 2 - 1, this.boardHeight / 2 - 1].state = BoardSpace.red;
            this.board[boardWidth / 2 - 1, this.boardHeight / 2    ].state = BoardSpace.blue;
            this.board[boardWidth / 2    , this.boardHeight / 2 - 1].state = BoardSpace.blue;
            this.board[boardWidth / 2    , this.boardHeight / 2    ].state = BoardSpace.red;

            this.turn = 0;
            this.gameState = playerBlue;
            this.checkMoves();
            boardInitialized = true;
            this.Invalidate();
        }

        //calculates who is victorious
        private void calculateVictor()
        {
            int score = 0;
            for (int i = 0; i < this.boardWidth; i++)
                for (int j = 0; j < this.boardHeight; j++)
                    score += this.board[i, j].state * 2 - 1;
            if (score == 0)
                this.labelGameState.Text = "It's a tie!";
            else if (score > 0)
                this.labelGameState.Text = "Red is victorious!";
            else
                this.labelGameState.Text = "Blue is victorious!";
        }

        //calculates which moves are legal
        private void checkMoves()
        {
            bool movesAvailable = false;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (checkMove(i, j))
                    {
                        board[i, j].LegalMove = true;
                        movesAvailable = true;
                    }
                    else
                        board[i, j].LegalMove = false;
                }
            }
            if (movesAvailable)
                return;
            this.gameState = 1 - this.gameState;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (checkMove(i, j))
                    {
                        board[i, j].LegalMove = true;
                        movesAvailable = true;
                    }
                    else
                        board[i, j].LegalMove = false;
                }
            }
            if (movesAvailable)
                return;
            this.labelGameState.Text = "test!"; 
                //this.calculateVictor();
        }

        

        //checks whether the current player can make a move onto this space
        private bool checkMove(int i, int j)
        {
            bool moveAble = false;
            if (this.board[i,j].state == BoardSpace.empty)
                for (int k = 0; k < 8; k++)
                {
                    if (checkDirection(i, j, directions[k, 0], directions[k, 1]))
                    {
                        this.board[i, j].legalDirection[k] = true;
                        moveAble = true;
                    }
                    else
                        this.board[i, j].legalDirection[k] = false;
                }
                    

            return moveAble;
        }

        private bool checkDirection(int i, int j, int dirX, int dirY)
        {
            bool adjacentEnemy = false;
            for (int x = i + dirX, y = j + dirY; ((x < this.boardWidth && x >= 0) && (y < this.boardHeight && y >= 0)); x += dirX, y += dirY)
            {
                if (this.board[x, y].state == gameState)
                {
                    if (adjacentEnemy == true)
                        return true;
                    else
                        return false;
                }

                else if (board[x, y].state == BoardSpace.empty)
                    return false;
                else
                    adjacentEnemy = true;
            }
                
            return false;
        }

        //handles a player move
        public void makeMove(object obj, EventArgs e)
        {
            BoardSpace clickedSpace = (BoardSpace)obj;
            if (clickedSpace.LegalMove)
            {
                int dirX, dirY;
                for (int k = 0; k < 8; k++)
                    if (clickedSpace.legalDirection[k])
                    {
                        dirX = ReversiForm.directions[k, 0];
                        dirY = ReversiForm.directions[k, 1];

                        for (int x = clickedSpace.x + dirX, y = clickedSpace.y + dirY;
                            ((x < boardWidth && x >= 0) && (y < boardHeight && y >= 0));
                            x += dirX, y += dirY)
                        {
                            if (board[x, y].state == this.gameState)
                                break;
                            board[x, y].lastState =     board[x, y].state;
                            board[x, y].turnChanged =   this.turn;
                            board[x, y].state =  this.gameState;
                        }
                    }
                clickedSpace.lastState = clickedSpace.state;
                clickedSpace.turnChanged = this.turn++;
                clickedSpace.state = this.gameState;

                this.gameState = 1 - this.gameState;
                this.checkMoves();
                this.Invalidate();
            }
                              
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            this.newGame();
        }
    }

 }
