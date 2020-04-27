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
        public int DamageDealt { get; set; }
        public bool IsVisible { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        public Spike(int top, int left)
        {
            top = Top;
            left = Left;
            int spikeHeight = randomGenerator.Next(100, 350);
            Image = Properties.Resources.Spike;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, spikeHeight); //Randomly decides what the height of the spike is. 
        }
        public void TopSpike()
        {
            Show();
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Top = 0;
            Left = 1500;
        }
        public void BottomSpike()
        {
            Show();
            Top = 1000 - Height;
            Left = 1500;
        }

        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
