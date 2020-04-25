﻿using System;
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
            Top = 0;
            Left = 0;
            Image = Properties.Resources.Spike;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(300, 50);
        }
        public void Activate()
        {

        }
        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}
