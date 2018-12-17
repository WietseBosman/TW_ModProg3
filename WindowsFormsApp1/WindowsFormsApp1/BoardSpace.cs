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
        public const int empty = 2;
        public const int blue = 0;
        public const int red = 1;

        public int turnChanged;
        public int lastState;
        
        public bool[] legalDirection = new bool[8];
        public bool LegalMove;
        public int state;

        public int x, y;

        

        

        public BoardSpace()
        {
            InitializeComponent();
            
        }

        //draws the BoardSpace
        public void Draw(PaintEventArgs pea, bool showHelp)
        {
            pea.Graphics.DrawRectangle(Pens.Black, this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            if (this.state == blue)
                pea.Graphics.FillEllipse(Brushes.Blue, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
            else if (this.state == red)
                pea.Graphics.FillEllipse(Brushes.Red, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
            else if (showHelp && LegalMove)
                pea.Graphics.FillEllipse(Brushes.Green, this.Location.X + 8, this.Location.Y + 8, this.Size.Width - 16, this.Size.Height - 16);

        }

        
    }
}
