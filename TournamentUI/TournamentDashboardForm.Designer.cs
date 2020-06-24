namespace TournamentUI
{
    partial class TournamentDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.LoadDropDownValue = new System.Windows.Forms.ComboBox();
            this.ChooseTournamentLabel = new System.Windows.Forms.Label();
            this.LoadTournamentButton = new System.Windows.Forms.Button();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Bahnschrift", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.HeaderLabel.Location = new System.Drawing.Point(177, 58);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(442, 46);
            this.HeaderLabel.TabIndex = 13;
            this.HeaderLabel.Text = "-Tournament dashboard-";
            // 
            // LoadDropDownValue
            // 
            this.LoadDropDownValue.FormattingEnabled = true;
            this.LoadDropDownValue.Location = new System.Drawing.Point(146, 219);
            this.LoadDropDownValue.Name = "LoadDropDownValue";
            this.LoadDropDownValue.Size = new System.Drawing.Size(387, 36);
            this.LoadDropDownValue.TabIndex = 20;
            // 
            // ChooseTournamentLabel
            // 
            this.ChooseTournamentLabel.AutoSize = true;
            this.ChooseTournamentLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseTournamentLabel.Location = new System.Drawing.Point(229, 180);
            this.ChooseTournamentLabel.Name = "ChooseTournamentLabel";
            this.ChooseTournamentLabel.Size = new System.Drawing.Size(278, 36);
            this.ChooseTournamentLabel.TabIndex = 19;
            this.ChooseTournamentLabel.Text = "Choose tournament";
            // 
            // LoadTournamentButton
            // 
            this.LoadTournamentButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LoadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.LoadTournamentButton.FlatAppearance.BorderSize = 2;
            this.LoadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.LoadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.LoadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadTournamentButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadTournamentButton.Location = new System.Drawing.Point(221, 277);
            this.LoadTournamentButton.Name = "LoadTournamentButton";
            this.LoadTournamentButton.Size = new System.Drawing.Size(236, 71);
            this.LoadTournamentButton.TabIndex = 21;
            this.LoadTournamentButton.Text = "Load tournament";
            this.LoadTournamentButton.UseVisualStyleBackColor = false;
            this.LoadTournamentButton.Click += new System.EventHandler(this.LoadTournamentButton_Click);
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CreateTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.CreateTournamentButton.FlatAppearance.BorderSize = 2;
            this.CreateTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.CreateTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.CreateTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTournamentButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTournamentButton.Location = new System.Drawing.Point(136, 404);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(406, 71);
            this.CreateTournamentButton.TabIndex = 33;
            this.CreateTournamentButton.Text = "Create tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = false;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(679, 527);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.LoadTournamentButton);
            this.Controls.Add(this.LoadDropDownValue);
            this.Controls.Add(this.ChooseTournamentLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TournamentDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TournamentDashboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.ComboBox LoadDropDownValue;
        private System.Windows.Forms.Label ChooseTournamentLabel;
        private System.Windows.Forms.Button LoadTournamentButton;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}