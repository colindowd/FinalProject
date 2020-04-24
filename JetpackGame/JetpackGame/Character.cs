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
            MaxHealth = 100;
            FuelCapacity = 100;
            Top = 0;
            Left = 0;
            Image = Properties.Resources.Character;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, 100);
        }
        public void Fly()
        {
            Top += 3;
        }
        public void IncreaseHealth()
        {
            if(Health > 50)
            {
                Health = MaxHealth;
            } else
            {
                Health += 50;
            }
        }
        public void IncreaseFuel()
        {
            if(Fuel > 50)
            {
                Fuel = FuelCapacity;
            } else
            {
                Fuel += 50;
            }
        }
        public void DamageByRocket()
        {
            if(Health < 75)
            {
                Health = 0;
            } else
            {
                Health -= 75;
            }
        }
        public void DamageBySpike()
        {
            if (Health < 25)
            {
                Health = 0;
            }
            else
            {
                Health -= 25;
            }
        }
    }
}
