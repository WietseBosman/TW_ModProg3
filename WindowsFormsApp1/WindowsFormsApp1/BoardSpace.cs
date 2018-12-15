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
        const byte empty = 0;
        const byte blue = 1;
        const byte red = 2;


        byte state;

        public BoardSpace()
        {
            InitializeComponent();
            
        }

        //draws the BoardSpace
        public void Draw(PaintEventArgs pea)
        {
            pea.Graphics.DrawRectangle(Pens.Black, this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            if (this.state == blue)
                pea.Graphics.FillEllipse(Brushes.Blue, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);
            if (this.state == red)
                pea.Graphics.FillEllipse(Brushes.Red, this.Location.X + 5, this.Location.Y + 5, this.Size.Width - 10, this.Size.Height - 10);


        }


    }
}
