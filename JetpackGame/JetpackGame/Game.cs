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

        private void GameTimer_Tick(object sender, EventArgs e)
        {

        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public void RenderOutput() //Is this necessary?
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }
    }
}
