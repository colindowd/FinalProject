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

        public Character()       //Sets attributes for the Character class
        {
            MaxHealth = 100;
            FuelCapacity = 100;
            Top = 800;
            Left = 100;
            Image = Properties.Resources.Character;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new System.Drawing.Size(100, 100);
        }
        public void Jump()      //Jumps up 250 pixels if on the ground
        {
            if(Top >= 795)
            {
                Top -= 250;
            }
        }
        public void Fly()       //Moves up 25 pixels per tick
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
        public void Fall()      //Moves down 3 pixels per tick
        {
            if(Top <= 795)
            {
                Top += 3;
            }
        }
        public void IncreaseHealth(int healthChange)        //Resets health back to max health
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
        public void IncreaseFuel(int fuelChange)        //Resets fuel back to max fuel
        {
            if(Fuel > 50)
            {
                Fuel = FuelCapacity + fuelChange;
            } else
            {
                Fuel += 50;
            }
        }
        public void DamageByRocket()        //Takes 75 damage when hit by rocket
        {
            if(Health < 75)
            {
                Health = 0;
            } else
            {
                Health -= 75;
            }
        }
        public void DamageBySpike()     //Takes 25 damage when hit by spike
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
