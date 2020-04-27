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
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.ScoreTextLabel = new System.Windows.Forms.Label();
            this.HealthTextLabel = new System.Windows.Forms.Label();
            this.FuelTextLabel = new System.Windows.Forms.Label();
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
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(186, 15);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(25, 25);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "0";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLabel.Location = new System.Drawing.Point(186, 50);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(25, 25);
            this.HealthLabel.TabIndex = 2;
            this.HealthLabel.Text = "0";
            // 
            // FuelLabel
            // 
            this.FuelLabel.AutoSize = true;
            this.FuelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuelLabel.Location = new System.Drawing.Point(186, 84);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(25, 25);
            this.FuelLabel.TabIndex = 3;
            this.FuelLabel.Text = "0";
            // 
            // ScoreTextLabel
            // 
            this.ScoreTextLabel.AutoSize = true;
            this.ScoreTextLabel.Location = new System.Drawing.Point(143, 15);
            this.ScoreTextLabel.Name = "ScoreTextLabel";
            this.ScoreTextLabel.Size = new System.Drawing.Size(74, 25);
            this.ScoreTextLabel.TabIndex = 4;
            this.ScoreTextLabel.Text = "Score:";
            // 
            // HealthTextLabel
            // 
            this.HealthTextLabel.AutoSize = true;
            this.HealthTextLabel.Location = new System.Drawing.Point(137, 50);
            this.HealthTextLabel.Name = "HealthTextLabel";
            this.HealthTextLabel.Size = new System.Drawing.Size(80, 25);
            this.HealthTextLabel.TabIndex = 5;
            this.HealthTextLabel.Text = "Health:";
            // 
            // FuelTextLabel
            // 
            this.FuelTextLabel.AutoSize = true;
            this.FuelTextLabel.Location = new System.Drawing.Point(94, 84);
            this.FuelTextLabel.Name = "FuelTextLabel";
            this.FuelTextLabel.Size = new System.Drawing.Size(168, 25);
            this.FuelTextLabel.TabIndex = 6;
            this.FuelTextLabel.Text = "Fuel Remaining:";
            // 
            // Game
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.FuelTextLabel);
            this.Controls.Add(this.HealthTextLabel);
            this.Controls.Add(this.ScoreTextLabel);
            this.Controls.Add(this.FuelLabel);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.ScoreLabel);
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
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label FuelLabel;
        private System.Windows.Forms.Label ScoreTextLabel;
        private System.Windows.Forms.Label HealthTextLabel;
        private System.Windows.Forms.Label FuelTextLabel;
    }
}