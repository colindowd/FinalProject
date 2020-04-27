using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public class Spike : PictureBox //Logan Cole
    {
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        public Spike(int top, int left) //Spike constructor
        {
            top = Top;
            left = Left;
            int spikeHeight = randomGenerator.Next(100, 250);
            Image = Properties.Resources.Spike;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, spikeHeight); //Randomly decides what the height of the spike is. 
        }
        public void TopSpike() //Displays a spike on the top of the screen when called.
        {
            Show();
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Top = 0;
            Left = 1500;
        }
        public void BottomSpike() //Displays a spike on the bottom of the screen when called. 
        {
            Show();
            Top = 1000 - Height;
            Left = 1500;
        }

        public bool HitTest(Rectangle bounds) //Tests if the spike is touching something.
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
