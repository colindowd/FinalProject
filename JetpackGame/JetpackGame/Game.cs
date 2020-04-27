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
    public partial class Game : Form //This class creates the Game form and runs the game and all of its mechanics. - Logan Cole & Colin Dowd
    {
        private Character Player { get; set; } //Creates the Player.
        private List<Spike> Spikes { get; set; } //Creates the list of Spikes.
        private List<Token> Tokens { get; set; } //Creates the list of Tokens.
        private HealthPack HealthPack { get; set; } //Creates the HealthPack.
        private FuelTank FuelTank { get; set; } //Creates the FuelTank.
        private Rocket Rocket { get; set; } //Creates the Rocket.
        private static Random randomGenerator = new Random(); //Declares and instantiates the random number generator.
        private bool isFlying = false; //Creates isFlying property.
        private int score = 0; //Creates score property.
        private int speedChange = 0; //Creates speedChange property.
        private int tokenChange = 0; //Creates tokenChange property.
        private int healthChange = 0; //Creates healthChange property.
        private int fuelChange = 0; //Creates fuelChange property.

        public Game() //Creates Game constructor. 
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e) //This all occurs when the game is loaded. This creates and adds objects to the game. 
        {
            Player = new Character();
            Spikes = new List<Spike>();
            Tokens = new List<Token>();
            HealthPack = new HealthPack();
            FuelTank = new FuelTank();
            Rocket = new Rocket(Height, Width);
            Controls.Add(Player);
            Controls.Add(Rocket);
            Controls.Add(HealthPack);
            Controls.Add(FuelTank);
            Player.Fuel = 100 + fuelChange;
            Player.Health = 100 + healthChange;
        }
        private void GameTimer_Tick(object sender, EventArgs e) //All of this happens every tick (10ms)
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
            int spikeRand = randomGenerator.Next(1, 100); //Should generate a spike approx twice a second.
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
                Spikes[i].Left -= 5 + speedChange;
            }
            for (int i = 0; i < Spikes.Count; i++)
            {
                if (Spikes[i].HitTest(Player.Bounds) == true) //If the spike hits the Player:
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[i]);
                    Spikes.Remove(Spikes[i]);
                    Player.DamageBySpike();
                }
                else if (Spikes[i].Left <=1) //If the spike reaches the side of the form:
                {
                    Spikes[i].Hide();
                    Controls.Remove(Spikes[i]); 
                    Spikes.Remove(Spikes[i]);
                }
            }
            //Player
            if (!isFlying) //Makes the player fall if it is not f;ying. 
            {
                Player.Fall();
            }
            isFlying = false;
            FuelLabel.Text = Player.Fuel.ToString(); //Makes the FuelLabel work.
            HealthLabel.Text = Player.Health.ToString(); //Makes the HealthLabel work.
            if (Player.Health == 0) //Ends the game if Health reaches zero. 
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Game Over!");
                Application.Exit();
            }
            //HealthPack
            HealthPack.MoveHealthPack(); //Moves the healthpack every tick. 
            if (HealthPack.HitTest(Player.Bounds) && HealthPack.Visible) //If the healthpack hits the player:
            {
                Player.IncreaseHealth(healthChange);
                HealthPack.ResetHealth();
            }
            else if (HealthPack.Left <=1) //If the healthpack reaches the side of the form:
            {
                HealthPack.ResetHealth();
            }
            //FuelTank
            FuelTank.MoveFuelTank(); //Moves the fueltank every tick.
            if (FuelTank.HitTest(Player.Bounds) && FuelTank.Visible) //If the fueltank hits the player:
            {
                Player.IncreaseFuel(fuelChange);
                FuelTank.ResetFuel();
            }
            else if (FuelTank.Left <= 1) //If the fueltank reaches the side of the form:
            {
                FuelTank.ResetFuel();
            }
            //Token
            int tokenRand = randomGenerator.Next(1, 100 - tokenChange);
            if (tokenRand == 1) //Should generate one token approx every second.
            {
                ActivateToken();
            }
            for (int i = 0; i < Tokens.Count; i++)
            {
                Tokens[i].MoveToken(); //Moves each token every tick.
                if (Tokens[i].HitTest(Player.Bounds) == true) //If a token hits the player:
                {
                    Tokens[i].Hide();
                    Controls.Remove(Tokens[i]);
                    Tokens.Remove(Tokens[i]);
                    score += 500;
                }
                else if (Tokens[i].Left <= 1) //If the token reaches the left side of the screen:
                {
                    Tokens[i].Hide();
                    Controls.Remove(Tokens[i]);
                    Tokens.Remove(Tokens[i]);
                }
            }
            //Misc
            ScoreLabel.Text = score.ToString(); //Makes the score label work. 
            score++; //Increases score every tick.
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (GameTimer.Enabled == true) //The keys only do anything if the GameTimer is enabled (i.e., if the Start Button has been pushed).
            {
                switch (keyData)
                {
                    case Keys.Space:
                        Player.Jump();
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
        private void StartButton_Click(object sender, EventArgs e)      //Reads any cheat code entered by user and starts timer
        {
            CheatCodeTextBox.Hide();
            CheatCodeLabel.Hide();
            GameTimer.Enabled = true;
            int codeIndex = CheatCodes(CheatCodeTextBox.Text);
            if(codeIndex == 0)
            {
                speedChange = 10;
            } else if(codeIndex == 1)
            {
                speedChange = -3;
            } else if(codeIndex == 2)
            {
                tokenChange = 95;
            } else if(codeIndex == 3)
            {
                healthChange = 900;
                fuelChange = 900;
            }
        }
        public void ActivateToken() //This activates a new token when called. 
        {
            Token token = new Token(Height, Width);
            Tokens.Add(token);
            Controls.Add(token);
            Tokens[Tokens.Count - 1].ResetToken();
        }
        public void ActivateTopSpike() //This activates a top spike when called.
        {
            Spike spike1 = new Spike(Height, Width);
            Spikes.Add(spike1);
            Controls.Add(spike1);
            Spikes[Spikes.Count - 1].TopSpike();
        }
        public void ActivateBottomSpike() //This activates a bottom spike when called.
        {
            Spike spike2 = new Spike(Height, Width);
            Spikes.Add(spike2);
            Controls.Add(spike2);
            Spikes[Spikes.Count - 1].BottomSpike();
        }
        public int CheatCodes(string userCode)      //Searches through array of valid cheat codes and returns the index of the code that was entered if any
        {
            String[] validCodes = { "Speed", "Slow", "Money", "Juggernaut" };
            for(int i = 0; i < validCodes.Length; i++)
            {
                if(userCode == validCodes[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
