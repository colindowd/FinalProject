namespace JetpackGame
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.FuelLevelLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ScoreLevelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(1350, 850);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 50);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FuelLabel
            // 
            this.FuelLabel.AutoSize = true;
            this.FuelLabel.Location = new System.Drawing.Point(454, 22);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(30, 13);
            this.FuelLabel.TabIndex = 1;
            this.FuelLabel.Text = "Fuel:";
            // 
            // FuelLevelLabel
            // 
            this.FuelLevelLabel.AutoSize = true;
            this.FuelLevelLabel.Location = new System.Drawing.Point(490, 22);
            this.FuelLevelLabel.Name = "FuelLevelLabel";
            this.FuelLevelLabel.Size = new System.Drawing.Size(25, 13);
            this.FuelLevelLabel.TabIndex = 2;
            this.FuelLevelLabel.Text = "100";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(570, 24);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.ScoreLabel.TabIndex = 3;
            this.ScoreLabel.Text = "Score";
            // 
            // ScoreLevelLabel
            // 
            this.ScoreLevelLabel.AutoSize = true;
            this.ScoreLevelLabel.Location = new System.Drawing.Point(611, 24);
            this.ScoreLevelLabel.Name = "ScoreLevelLabel";
            this.ScoreLevelLabel.Size = new System.Drawing.Size(13, 13);
            this.ScoreLevelLabel.TabIndex = 4;
            this.ScoreLevelLabel.Text = "0";
            // 
            // Game
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.ScoreLevelLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.FuelLevelLabel);
            this.Controls.Add(this.FuelLabel);
            this.Controls.Add(this.StartButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label FuelLabel;
        private System.Windows.Forms.Label FuelLevelLabel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label ScoreLevelLabel;
    }
}