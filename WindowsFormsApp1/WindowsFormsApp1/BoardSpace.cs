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
        
        public const int blue = 0;
        public const int red = 1;
        public const int empty = 2;
        public const int moveAble = 3;

        public int turnChanged;
        public int lastState;
        
        public bool[] legalDirection = new bool[8];
        public bool LegalMove;
        public int state;
        public int drawnAs;

        public int x, y;

        public bool updated;


        
        

        public BoardSpace()
        {
            InitializeComponent();
        }

        //draws the BoardSpace
        public void DrawFull(Graphics gr, bool showHelp)
        {
            gr.DrawRectangle(Pens.Black, this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            if (this.state == blue)
            {
                gr.FillEllipse(Brushes.Blue, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
                drawnAs = BoardSpace.blue;
            }
            else if (this.state == red)
            {
                gr.FillEllipse(Brushes.Red, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
                drawnAs = BoardSpace.red;
            }
            else if (this.LegalMove && showHelp)
            {
                gr.FillEllipse(Brushes.Green, this.Location.X + 12, this.Location.Y + 12, this.Size.Width - 24, this.Size.Height - 24);
                drawnAs = BoardSpace.moveAble;
            }

        }

        public void DrawUpdate(Graphics gr, bool showHelp)
        {
            //gr.DrawEllipse(Pens.Black, this.Location.X, this.Location.Y, 50, 50);
            if (this.state == blue)
                gr.FillEllipse(Brushes.Blue, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
            else if (this.state == red)
                gr.FillEllipse(Brushes.Red, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
            else if (this.LegalMove && showHelp)
                gr.FillEllipse(Brushes.Green, this.Location.X + 12, this.Location.Y + 12, this.Size.Width - 24, this.Size.Height - 24);

            this.updated = false;
        }
        
    }
}
