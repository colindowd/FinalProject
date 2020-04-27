using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{

    public class Token : PictureBox        //Colin Dowd
    {
        public static Random randomGenerator { get; set; }
        public Token(int top, int left)
        {
            top = Top;
            left = Left;
            randomGenerator = new Random();
            Image = Properties.Resources.Token;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(50, 5);
        }
        public void MoveToken()
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
        public void ResetToken()
        {
            randomGenerator = new Random();
            Show();
            Top = randomGenerator.Next(0, 1000);
            Left = 1500;
        }
    }
}
