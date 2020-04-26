using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public partial class Spike : PictureBox //Logan Cole
    {
        public int DamageDealt { get; set; }
        public bool IsVisible { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        public Spike(int top, int left)
        {
            int topOrBottom = randomGenerator.Next(1, 2);
            Image = Properties.Resources.Spike;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(randomGenerator.Next(100, 300), 50); //Randomly decides what the height of the spike is. 
            if (topOrBottom == 1) //Does this need added to the ActivateSpike Method?
            {
                Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Top = 0;
                Left = randomGenerator.Next(0,0); //Need values
            }
            else if (topOrBottom == 2)
            {
                Top = 0; //Need height of form
                Left = randomGenerator.Next(0,0); //Need values
            }
        }

        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
