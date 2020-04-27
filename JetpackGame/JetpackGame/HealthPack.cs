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
        public HealthPack()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 900);
            Left = 2000;
            Image = Properties.Resources.HealthPack;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, 100);
        }
        public void MoveHealthPack()
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
        public void ResetHealth()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 800);
            Left = 1500;
            Show();
        }

    }
}
