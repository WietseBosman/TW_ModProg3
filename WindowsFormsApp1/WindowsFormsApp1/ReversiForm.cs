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
        
        //variables for board setup
        BoardSpace[,] board;
        int boardWidth, boardHeight;
        static readonly int[,] directions = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };

        //variables for the display-size of the board
        public int spaceSize;
        int boardX, boardY;
        const int headerSize = 80;
        const int margin = 60;

        //variables for the current gamestate, as well as player numbers
        int gameState;
        const int playerBlue = 0, playerRed = 1, victoryBlue = 2, victoryRed = 3, tie = 4;

        //variables for calculating score
        int turn;
        int[] score = new int[2], lastScore = new int[2];

        //other variables
        bool boardInitialized;
        bool canUndo;
        
        //costructor, executes when the game is opened.
        public ReversiForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += draw;
            this.SizeChanged += sizeChanged;

            this.textBoxBoardWidth.Text = "6";
            this.textBoxBoardHeight.Text = "4";
            this.newGame();

        }

        //responsible for drawing the screen
        private void draw(object obj, PaintEventArgs pea)
        {

            //displays the board
            if (boardInitialized)
            this.drawBoard(pea.Graphics);

            //displays gamestate
            switch (this.gameState)
            {
                case playerBlue:
                    this.labelGameState.Text = "Blue player's turn";
                    break;
                case playerRed:
                    this.labelGameState.Text = "Red player's turn";
                    break;
                case victoryBlue:
                    this.labelGameState.Text = "Blue is victorious!";
                    break;
                case victoryRed:
                    this.labelGameState.Text = "Red is victorious!";
                    break;
                case tie:
                    this.labelGameState.Text = "It's a draw!";
                    break;
            }

            //displays score
            this.labelScoreBlue.Text = $"Blue: {score[playerBlue]}";
            this.labelScoreRed.Text = $"Red: {score[playerRed]}";
        }

        //draws the board, optionally including help indications
        private void drawBoard(Graphics gr)
        {
            bool drawHelp = this.checkBoxHelp.Checked;
            foreach (BoardSpace bs in board)
                bs.DrawBoardSpace(gr, drawHelp);                
            
        }

        //updates location of buttons and board when the size of the form gets changed
        private void sizeChanged(object obj, EventArgs e)
        {
            this.labelBoardWidth.Location = new Point(this.ClientSize.Width / 2 - 205, 34);
            this.labelBoardHeight.Location = new Point(this.ClientSize.Width / 2 - 205, 64);

            this.textBoxBoardWidth.Location = new Point(this.ClientSize.Width / 2 - 130, 30);
            this.textBoxBoardHeight.Location = new Point(this.ClientSize.Width / 2 - 130, 60);

            this.buttonNewGame.Location = new Point(this.ClientSize.Width / 2 - 20, 29);
            this.buttonUndo.Location = new Point(this.ClientSize.Width / 2 - 20, 59);

            this.labelGameState.Location = new Point(this.ClientSize.Width / 2 + 60, 34);
            this.checkBoxHelp.Location = new Point(this.ClientSize.Width / 2 + 63, 64);

            this.labelScore.Location = new Point(this.ClientSize.Width / 2 + 180, 14);
            this.labelScoreBlue.Location = new Point(this.ClientSize.Width / 2 + 180, 34);
            this.labelScoreRed.Location = new Point(this.ClientSize.Width / 2 + 180, 64);

            this.updateBoardSize();

            this.Invalidate();

        }

        //updates the size and location of the board
        private void updateBoardSize()
        {
            this.spaceSize = Math.Min((this.ClientSize.Height - ReversiForm.headerSize - ReversiForm.margin) / this.boardHeight, (this.ClientSize.Width - ReversiForm.margin * 2) / this.boardWidth);
            this.boardX = (this.ClientSize.Width - this.spaceSize * this.boardWidth) / 2;
            this.boardY = (this.ClientSize.Height + ReversiForm.headerSize - this.spaceSize * this.boardHeight) / 2;

            foreach (BoardSpace bs in board)
            {
                bs.Location = new Point(this.boardX + bs.x * this.spaceSize, this.boardY + bs.y * this.spaceSize);
                bs.Size = new Size(spaceSize, spaceSize);
            }
        }
        
        //sets up a new game with size specified in the textboxes
        private void newGame()
        {
            
            //clears previous board
            if (this.boardInitialized)
            {
                foreach (BoardSpace bs in board)
                    this.Controls.Remove(bs);
            }

            this.boardInitialized = false;

            //creates new board
            this.boardWidth = int.Parse(this.textBoxBoardWidth.Text);
            this.boardHeight = int.Parse(this.textBoxBoardHeight.Text);
            this.board = new BoardSpace[this.boardWidth, this.boardHeight];
            for (int i = 0; i < this.boardWidth; i++)
            {
                
                for (int j = 0; j < this.boardHeight; j++)
                {
                    this.board[i,j] = new BoardSpace()
                    {
                        
                        x = i, y = j,
                    };
                this.board[i,j].Click += this.makeMove;
                this.Controls.Add(this.board[i,j]);
                }
            }

            //creates the first 4 tokens
            this.board[boardWidth / 2 - 1, this.boardHeight / 2 - 1].state = BoardSpace.blue;
            this.board[boardWidth / 2 - 1, this.boardHeight / 2    ].state = BoardSpace.red;
            this.board[boardWidth / 2    , this.boardHeight / 2 - 1].state = BoardSpace.red;
            this.board[boardWidth / 2    , this.boardHeight / 2    ].state = BoardSpace.blue;


            
            //resets basic variables
            this.score[0] = 2; this.score[1] = 2;
            this.canUndo = false;
            this.turn = 1;
            this.gameState = playerBlue;
            this.checkMoves();

            

            //displays the new board
            this.updateBoardSize();
            boardInitialized = true;
            this.Invalidate();
        }

        //handles a player move
        public void makeMove(object obj, EventArgs e)
        {
            BoardSpace clickedSpace = (BoardSpace)obj;
            if (clickedSpace.LegalMove)
            {
                //updates score used to undo this move
                this.lastScore[playerBlue] = this.score[playerBlue];
                this.lastScore[playerRed] = this.score[playerRed];

                //updates board
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
                            this.board[x, y].lastState = board[x, y].state;
                            this.board[x, y].turnChanged = this.turn;
                            this.board[x, y].state = this.gameState;
                            this.score[gameState]++;
                            this.score[1 - gameState]--;
                        }
                    }
                clickedSpace.lastState = clickedSpace.state;
                clickedSpace.turnChanged = this.turn;
                this.turn++;
                this.canUndo = true;
                clickedSpace.state = this.gameState;
                this.score[gameState]++;

                this.gameState = 1 - this.gameState;
                this.checkMoves();
                this.Invalidate();
            }

        }

        //calculates who is victorious
        private void calculateVictor()
        {

            int victor = score[0] - score[1];
            if (victor == 0)
                this.gameState = ReversiForm.tie;
            else if (victor > 0)
                this.gameState = ReversiForm.victoryBlue;
            else
                this.gameState = ReversiForm.victoryRed;
        }

        //calculates which moves are legal
        private void checkMoves()
        {

            bool movesAvailable = false;

            //calculates legal moves for active players
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

            //if no legal moves exist the turn goes to the other players
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

            //if still no legal moves exist the game ends
            this.calculateVictor();
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

        //checks whether there is a legal moves onto a space from a given direction
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
              
        //starts a new game
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.textBoxBoardHeight.Text) >= 2 && int.Parse(this.textBoxBoardWidth.Text) >= 2)
            this.newGame();
        }

        //undoes the last move
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (this.canUndo)
            {
                foreach (BoardSpace bs in board)
                {


                    if (bs.turnChanged == (this.turn - 1))
                    {
                        bs.state = bs.lastState;

                    }


                }
                this.turn--;
                this.gameState = 1 - this.gameState;
                this.score[playerBlue] = this.lastScore[playerBlue];
                this.score[playerRed] = this.lastScore[playerRed];
                this.canUndo = false;
                this.checkMoves();
                this.Invalidate();
            }

            

        }

        //redraws the board when the help checkbox is changed 
        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }

 }
