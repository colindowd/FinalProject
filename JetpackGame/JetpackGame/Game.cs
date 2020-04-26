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
        private int score = 0;
        private Character Player { get; set; }
        private List<Spike> Spikes { get; set; }
        private List<Token> Tokens { get; set; }
        private HealthPack HealthPack { get; set; }
        private FuelTank FuelTank { get; set; }
        private Rocket Rocket { get; set; }
        private Token Token { get; set; }
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.

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
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Rocket
            Rocket.Left -= 20; //Moves the Rocket every tick.
            if (Rocket.HitTest(Player.Bounds) == true) //If the rocket hits the Player:
            {
                Player.DamageByRocket();
                Rocket.Hide();
                Controls.Remove(Rocket);
                System.Threading.Thread.Sleep(3000); ; //Not sure if this works, I'm trying to delay this 3 seconds. 
                Controls.Add(Rocket);
                Rocket.Shoot();
            }
            if (Rocket.Left <= 1) //If the rocket reaches the side of the form:
            {
                Rocket.Hide();
                Controls.Remove(Rocket);
                System.Threading.Thread.Sleep(3000); ; //Not sure if this works, I'm trying to delay this 3 seconds. 
                Controls.Add(Rocket);
                Rocket.Shoot();
            }
            //Spikes
            int useSpike = randomGenerator.Next(1, 200);
            if (useSpike == 1) //This should activate a spike randomly, but average one every 2 seconds. 
            {
                ActivateSpike();
            }
            for (int i = 0; i < Spikes.Count; i++)
            {
                if (Spikes[i].HitTest(Player.Bounds) == true) //If any laser hits the Enemy, the score goes up, enemy is reset and the laser is removed.
                {
                    Spikes[i].Hide();
                    Spikes.Remove(Spikes[i]);
                    Player.DamageBySpike();
                }
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
                HealthPack.MoveHealthPack();
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
                FuelTank.Hide();
            }
            else if (fuelRand == 1)
            {
                FuelTank.ResetFuel();
            }
            else
            {
                HealthPack.MoveHealthPack();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GameTimer.Enabled == true) //The keys only do anything if the GameTimer is enabled (i.e., if the Start Button has been pushed).
            {
                switch (keyData)
                {
                    case Keys.Left: 
                        return true;
                    case Keys.Right:
                        return true;
                    case Keys.Up:
                        return true;
                    case Keys.Down:
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
        private void StartButton_Click(object sender, EventArgs e)
        {
            GameTimer.Enabled = true;
        }
        public void RenderOutput() //Is this necessary?
        {

        }

        public void ActivateSpike()
        {
            Spike spike = new Spike(Height, Width);
            Spikes.Add(spike);
            Controls.Add(spike);
            Spikes[Spikes.Count - 1].Show();
        }
    }
}
