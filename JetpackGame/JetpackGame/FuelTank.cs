using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public class FuelTank : PictureBox     //Colin Dowd
    {
        public static Random randomGenerator { get; set; }
        public FuelTank()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 661);
            Left = 2000;
            Image = Properties.Resources.FuelTank;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(50, 50);
        }
        public void MoveFuelTank()
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
        public void ResetFuel()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 1000);
            Left = 2000;
            Show();
        }
    }
}
