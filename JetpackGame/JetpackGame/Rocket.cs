using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public class Rocket : PictureBox //Logan Cole
    {
        public int DamageDealt { get; set; }
        public bool IsVisible { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        public Rocket(int top, int left)
        {
            top = Top;
            left = Left;
            Top = randomGenerator.Next(0, 800); //Max value of form height needed
            Left = 1500;
            Image = Properties.Resources.Rocket;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(300, 50);
        }
        public void Shoot()
        {
            Show();
        }

        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
