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
            int topOrBottom = randomGenerator.Next(1, 2);
            Image = Properties.Resources.Spike;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(200, 50); //Randomly decides what the height of the spike is? 
            if (topOrBottom == 1) //Does this need added to the ActivateSpike Method?
            {
                Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Top = 0;
                Left = 1500;
            }
            else if (topOrBottom == 2)
            {
                Top = 1000 - 200;
                Left = 1500; 
            }
        }

        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
