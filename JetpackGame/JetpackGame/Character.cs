using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    class Character : PictureBox
    {
        public int FuelCapacity { get; set; }
        public int Fuel { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public bool IsEngineRunning { get; set; }
        public bool IsAlive { get; set; }

        public Character()
        {
            Top = 0;
            Left = 0;
            Image = Properties.Resources.Character;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, 100);
        }

    }
}
