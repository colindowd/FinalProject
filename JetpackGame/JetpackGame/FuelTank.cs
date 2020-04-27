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
        public FuelTank()       //Sets attributes for the FuelTank class
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 661);
            Left = 2000;
            Image = Properties.Resources.FuelTank;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(50, 50);
        }
        public void MoveFuelTank()      //Moves the FuelTank left across the screen (5 pixels per tick)
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)       //Tests if it touched the player
        {
            return Bounds.IntersectsWith(bounds);
        }
        public void ResetFuel()     //Resets the FuelTank to the right side of the screen at a random vertical position
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 1000);
            Left = 2000;
            Show();
        }
    }
}
