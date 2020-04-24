﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    class HealthPack : PictureBox       //Colin Dowd
    {
        public static Random randomGenerator { get; set; }
        public HealthPack()
        {
            randomGenerator = new Random();
            Top = randomGenerator.Next(0, 661);
            Left = 1450;
        }
        public void MoveHealthPack()
        {
            Left -= 5;
        }
        public bool HitTest(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }
    }
}