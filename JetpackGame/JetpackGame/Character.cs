using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public class Character : PictureBox
    {
        public int FuelCapacity { get; set; }
        public int Fuel { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public Character()
        {
            MaxHealth = 100;
            FuelCapacity = 100;
            Top = 800;
            Left = 100;
            Image = Properties.Resources.Character;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, 100);
        }
        public void Jump()
        {
            if(Top >= 795)
            {
                Top -= 250;
            }
        }
        public void Fly()
        {
            if (Fuel > 0)
            {
                if (Top > 0)
                {
                    Top -= 25;
                    Fuel--;
                }
            }
        }
        public void Fall()
        {
            if(Top <= 795)
            {
                Top += 3;
            }
        }
        public void IncreaseHealth(int healthChange)
        {
            if (Health > 50)
            {
                Health = MaxHealth + healthChange;
            }
            else
            {
                Health += 50;
            }
        }
        public void IncreaseFuel(int fuelChange)
        {
            if(Fuel > 50)
            {
                Fuel = FuelCapacity + fuelChange;
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
