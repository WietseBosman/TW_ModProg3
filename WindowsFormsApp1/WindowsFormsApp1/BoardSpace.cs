using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversiGame
{
    public partial class BoardSpace : UserControl
    {
        //location of the boardSpace on the board
        public int x, y;

        //variables to describe the state of the boardSpace
        public int state = BoardSpace.empty;
        public const int blue = 0, red = 1, empty = 2;
        
        //variables used in the undo function
        public int turnChanged, lastState;
        
        //variables used to determine whether the active player can make a move onto this boardSpace
        public bool LegalMove;
        public bool[] legalDirection = new bool[8];

        //constants used for display settings               
        const double tokenSize = 0.8, helpSize = 0.6;
                
        //constructor
        public BoardSpace()
        {
            InitializeComponent();
        }

        //draws the BoardSpace
        public void DrawBoardSpace(Graphics gr, bool showHelp)
        {
            gr.DrawRectangle(Pens.Black, this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            if (this.state == blue)
            {
                gr.FillEllipse(Brushes.Blue, 
                    this.Location.X + (int)(this.Size.Width * (1 - BoardSpace.tokenSize) / 2), 
                    this.Location.Y + (int)(this.Size.Width * (1 - BoardSpace.tokenSize) / 2), 
                    (int)(this.Size.Width * BoardSpace.tokenSize), 
                    (int)(this.Size.Width * BoardSpace.tokenSize));
            }
            else if (this.state == red)
            {
                gr.FillEllipse(Brushes.Red, 
                    this.Location.X + (int)(this.Size.Width * (1 - BoardSpace.tokenSize) / 2), 
                    this.Location.Y + (int)(this.Size.Width * (1 - BoardSpace.tokenSize) / 2), 
                    (int)(this.Size.Width * BoardSpace.tokenSize), 
                    (int)(this.Size.Width * BoardSpace.tokenSize));
                
            }
            else if (this.LegalMove && showHelp)
            {
                gr.DrawEllipse(Pens.Black, 
                    this.Location.X + (int)(this.Size.Width * (1 - BoardSpace.helpSize) / 2), 
                    this.Location.Y + (int)(this.Size.Width * (1 - BoardSpace.helpSize) / 2), 
                    (int)(this.Size.Width * BoardSpace.helpSize), 
                    (int)(this.Size.Width * BoardSpace.helpSize));
                
            }

        }

       
        
    }
}
