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
    public partial class Game : Form //Logan Cole & Colin Dowd
    {
        private Character Player { get; set; }
        private List<Spike> Spikes { get; set; }
        private List<Token> Tokens { get; set; }
        private HealthPack HealthPack { get; set; }
        private FuelTank FuelTank { get; set; }
        private Rocket Rocket { get; set; }
        private Token Token { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        private bool isFlying = false;
        private int score = 0;
        



        public Game()
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {
            Player = new Character();
            Spikes = new List<Spike>();
            Tokens = new List<Token>();
            HealthPack = new HealthPack();
            FuelTank = new FuelTank();
            Rocket = new Rocket(Height, Width);
            Token = new Token();
            Controls.Add(Player);
            Controls.Add(Rocket);
            Player.Fuel = 100;
            Player.Health = 100;
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Rocket
            Rocket.Left -= 10; //Moves the Rocket every tick.
            if (Rocket.HitTest(Player.Bounds) == true) //If the rocket hits the Player:
            {
                Player.DamageByRocket();
                Rocket.Hide();
                Rocket.Shoot();
            }
            if (Rocket.Left <= 1) //If the rocket reaches the side of the form:
            {
                Rocket.Hide();
                Rocket.Shoot();
            }
            //Spikes
            int spikeRand = randomGenerator.Next(1, 100);
            if (spikeRand == 1) 
            {
                ActivateTopSpike();
            }
            if (spikeRand == 2) 
            {
                ActivateBottomSpike();
            }
            for (int i = 0; i < Spikes.Count; i++) //Moves the spikes constantly to the left. 
            {
                Spikes[i].Left -= 5;
                //for (int j = 0; j < Spikes.Count; j++)
                //{
                //    if (Spikes[i].HitTest(Spikes[j].Bounds) == true)
                //    {
                //        Spikes[i].Hide();
                //    }
                //}
            }
            for (int i = 0; i < Spikes.Count; i++)
            {
                if (Spikes[i].HitTest(Player.Bounds) == true) 
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[i]);
                    Spikes.Remove(Spikes[i]);
                    Player.DamageBySpike();
                }
                if (Spikes[i].Left <=1) 
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[1]); //Why set to 1?
                    Spikes.Remove(Spikes[i]);
                }
            }
            //Player
            if (!isFlying)
            {
                Player.Fall();
            }
            isFlying = false;
            FuelLabel.Text = Player.Fuel.ToString();
            HealthLabel.Text = Player.Health.ToString();
            if (Player.Health == 0 || Player.Fuel == 0)
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Game Over!");
                Application.Exit();
            }

            //HealthPack
            int healthRand = randomGenerator.Next(1, 1000);
            if (HealthPack.HitTest(Player.Bounds) && HealthPack.Visible)
            {
                Player.IncreaseHealth();
                HealthPack.Hide();
            }
            else if (healthRand == 1)
            {
                HealthPack.ResetHealth();
            }
            else
            {
                HealthPack.MoveHealthPack();
            }
            //FuelTank
            int fuelRand = randomGenerator.Next(1, 1000);
            if (FuelTank.HitTest(Player.Bounds) && FuelTank.Visible)
            {
                Player.IncreaseFuel();
                FuelTank.Hide();
            }
            else if (fuelRand == 1)
            {
                FuelTank.ResetFuel();
            }
            else
            {
                FuelTank.MoveFuelTank();
            }
            //Token
            int tokenRand = randomGenerator.Next(1, 100);
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].HitTest(Player.Bounds) == true) //If any laser hits the Enemy, the score goes up, enemy is reset and the laser is removed.
                {
                    Tokens[i].Hide();
                    Tokens.Remove(Tokens[i]);
                    score++;
                }
            }
            if (Token.HitTest(Player.Bounds) && Token.Visible)
            {
                Player.IncreaseFuel();
                Token.Hide();
            }
            else if (fuelRand == 1)
            {
                Token.ResetToken();
            }
            else
            {
                Token.MoveToken();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GameTimer.Enabled == true) //The keys only do anything if the GameTimer is enabled (i.e., if the Start Button has been pushed).
            {
                switch (keyData)
                {
                    case Keys.W:
                        isFlying = true;
                        Player.Fly();
                        return true;
                    default:
                        Player.Fall();
                        return true;
                }
            } else
            {
                return false;
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            GameTimer.Enabled = true;
        }
        public void ActivateTopSpike()
        {
            Spike spike1 = new Spike(Height, Width);
            Spikes.Add(spike1);
            Controls.Add(spike1);
            Spikes[Spikes.Count - 1].TopSpike();
        }
        public void ActivateBottomSpike()
        {
            Spike spike2 = new Spike(Height, Width);
            Spikes.Add(spike2);
            Controls.Add(spike2);
            Spikes[Spikes.Count - 1].BottomSpike();
        }
    }
}
