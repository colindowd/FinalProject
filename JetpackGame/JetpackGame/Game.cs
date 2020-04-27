using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetpackGame
{
    public partial class Game : Form //Logan Cole & Colin Dowd
    {
        private int score { get; set; }
        private int health { get; set; }
        private int fuel { get; set; }

        private Character Player { get; set; }
        private List<Spike> Spikes { get; set; }
        private List<Token> Tokens { get; set; }
        private List<HealthPack> HealthPacks { get; set; }
        private List<FuelTank> FuelTanks { get; set; }
        private Rocket Rocket { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        private bool isFlying = false;

        public Game()
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {
            Player = new Character();
            Spikes = new List<Spike>();
            Tokens = new List<Token>();
            HealthPacks = new List<HealthPack>();
            FuelTanks = new List<FuelTank>();
            Rocket = new Rocket(Height, Width);
            Controls.Add(Player);
            Controls.Add(Rocket);
            score = 0;
            health = 100;
            fuel = 100;
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
            if (Rocket.Left <= -100) //If the rocket reaches the side of the form:
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
                if (Spikes[i].HitTest(Player.Bounds)) //If any spike hits the Enemy, the score goes up, enemy is reset and the spike is removed.
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[i]);
                    Spikes.Remove(Spikes[i]);
                    Player.DamageBySpike();
                }
                if (Spikes[i].Left <= -100)
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[i]);
                    Spikes.Remove(Spikes[i]);
                }
            }
            //Player
            if (!isFlying)
            {
                Player.Fall();
            }
            isFlying = false;
            //HealthPack
            int healthRand = randomGenerator.Next(1, 1000);
            if (healthRand == 1)
            {
                ActivateHealth();
            }
            for (int i = 0; i < HealthPacks.Count; i++)
            {
                HealthPacks[i].MoveHealthPack();
                if (HealthPacks[i].HitTest(Player.Bounds) && HealthPacks[i].Visible)
                {
                    HealthPacks[i].Hide();
                    Controls.Remove(HealthPacks[i]);
                    HealthPacks.Remove(HealthPacks[i]);
                    health = 100;
                }
                if (HealthPacks[i].Left <= -100 && HealthPacks[i] != null)
                {
                    HealthPacks[i].Hide();
                    Controls.Remove(HealthPacks[i]);
                    HealthPacks.Remove(HealthPacks[i]);
                }
            }
            //FuelTank
            FuelLevelLabel.Text = fuel.ToString();
            int fuelRand = randomGenerator.Next(1, 1000);
            if (fuelRand == 1)
            {
                ActivateFuel();
            }
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                FuelTanks[i].MoveFuelTank();
                if (FuelTanks[i].HitTest(Player.Bounds) && FuelTanks[i].Visible)
                {
                    FuelTanks[i].Hide();
                    FuelTanks.Remove(FuelTanks[i]);
                    Controls.Remove(FuelTanks[i]);
                    fuel = 100;
                }
                if (FuelTanks[i].Left <= -100)
                {
                    FuelTanks[i].Hide();
                    Controls.Remove(FuelTanks[i]);
                    FuelTanks.Remove(FuelTanks[i]);
                }
            }
            //Token
            ScoreLevelLabel.Text = score.ToString();
            int tokenRand = randomGenerator.Next(1, 100);
            if (tokenRand == 1)
            {
                ActivateToken();
            }
            for (int i = 0; i < Tokens.Count; i++)
            {
                Tokens[i].MoveToken();
                if (Tokens[i].HitTest(Player.Bounds) && FuelTanks[i].Visible)
                {
                    Tokens[i].Hide();
                    Tokens.Remove(Tokens[i]);
                    Controls.Remove(Tokens[i]);
                    score++;
                }
                if (Tokens[i].Left <= -100 && HealthPacks[i] != null)
                {
                    Tokens[i].Hide();
                    Controls.Remove(Tokens[i]);
                    Tokens.Remove(Tokens[i]);
                }
            }

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GameTimer.Enabled == true) //The keys only do anything if the GameTimer is enabled (i.e., if the Start Button has been pushed).
            {
                switch (keyData)
                {
                    case Keys.Space:
                        if (fuel > 0)
                        {
                            Player.Jump();
                            isFlying = true;
                            Player.Fly();
                            fuel--;
                        }
                        else
                        {
                            Player.Jump();
                        }
                        return true;
                    default:
                        return true;
                }
            }
            else
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
        public void ActivateToken()
        {
            Token token1 = new Token();
            Tokens.Add(token1);
            Controls.Add(token1);
            Tokens[Tokens.Count - 1].ResetToken();
        }
        public void ActivateHealth()
        {
            HealthPack health1 = new HealthPack();
            HealthPacks.Add(health1);
            Controls.Add(health1);
            HealthPacks[HealthPacks.Count - 1].ResetHealth();
        }
        public void ActivateFuel()
        {
            FuelTank fuel1 = new FuelTank();
            FuelTanks.Add(fuel1);
            Controls.Add(fuel1);
            FuelTanks[FuelTanks.Count - 1].ResetFuel();
        }
    }
}
