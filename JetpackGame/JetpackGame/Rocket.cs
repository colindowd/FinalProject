using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    class Rocket : PictureBox //Logan Cole
    {
        public int DamageDealt { get; set; }
        public bool IsVisible { get; set; }
        public Rocket()
        {

        }
        public void Shoot()
        {
            
        }
        public bool HitTest()
        {
            return false;
        }
    }
}
