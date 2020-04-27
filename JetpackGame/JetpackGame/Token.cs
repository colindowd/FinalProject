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
        public Token()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 900);
            Left = 2000;
            Image = Properties.Resources.Token;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(40, 40);
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
            Top = randomGenerator.Next(0, 800);
            Left = 1500;
            Show();
        }
    }
}
