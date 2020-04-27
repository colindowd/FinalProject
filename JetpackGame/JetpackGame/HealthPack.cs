using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public class HealthPack : PictureBox       //Colin Dowd
    {
        public static Random randomGenerator { get; set; }
        public HealthPack()       //Sets attributes for the HealthPack class
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 900);
            Left = 2000;
            Image = Properties.Resources.HealthPack;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(50, 50);
        }
        public void MoveHealthPack()      //Moves the HealthPack left across the screen (5 pixels per tick)
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)       //Tests if it touched the player
        {
            return Bounds.IntersectsWith(bounds);
        }
        public void ResetHealth()       //Resets the HealthPack to the right side of the screen at a random vertical position
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 800);
            Left = 1500;
            Show();
        }

    }
}
