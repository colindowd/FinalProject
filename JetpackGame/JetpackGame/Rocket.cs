using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public partial class Rocket : PictureBox //Logan Cole
    {
        public int DamageDealt { get; set; }
        public bool IsVisible { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        public Rocket(int top, int left)
        {
            Top = randomGenerator.Next(0, 1000); //Max value of form height needed
            Left = 0; //Max value of form width
            Image = Properties.Resources.Rocket;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(300, 50);
        }
        public void Shoot()
        {
            Task.Delay(3000); //Not sure if this works, should delay this method 3 seconds. 
            Controls.Add(this);
            Show();
            Top = randomGenerator.Next(0, 1000); //Max value of form height needed
            Left = 0; //Max value of form width
        }

        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
