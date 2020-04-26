using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public partial class Game : Form //Logan Cole
    {
        private Character Player { get; set; }
        private List<Spike> Spikes { get; set; }
        private HealthPack HealthPack { get; set; }
        private FuelTank FuelTank { get; set; }
        private Rocket Rocket { get; set; }
        private Token Token { get; set; }

        public Game()
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {
            Player = new Character();
            Spikes = new List<Spike>();
            HealthPack = new HealthPack();
            FuelTank = new FuelTank();
            Rocket = new Rocket(Height, Width);
            Token = new Token();
            Controls.Add(Player);
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Rocket
            Rocket.Left -= 20; //Moves the Rocket every tick.
            if (Rocket.Left <= 1)
            {
                Rocket.Hide();
                Rocket.Shoot();
                Controls.Remove(Rocket);
            }
            //Spikes

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GameTimer.Enabled == true) //The keys only do anything if the GameTimer is enabled (i.e., if the Start Button has been pushed).
            {
                switch (keyData)
                {
                    case Keys.Left: //I.e., if the left arrow is pressed, then do this:
                        return true;
                    case Keys.Right:
                        return true;
                    case Keys.Space:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void RenderOutput() //Is this necessary?
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameTimer.Enabled = true;
        }
    }
}
