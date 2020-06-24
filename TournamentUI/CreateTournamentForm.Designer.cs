namespace TournamentUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentNameValue = new System.Windows.Forms.TextBox();
            this.TeamOneScoreLabel = new System.Windows.Forms.Label();
            this.EntryFeeValue = new System.Windows.Forms.TextBox();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.SelectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.CreateNewTeamLink = new System.Windows.Forms.LinkLabel();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.TournamentTeamListbox = new System.Windows.Forms.ListBox();
            this.TournamentPlayerLabel = new System.Windows.Forms.Label();
            this.RemovePlayersButton = new System.Windows.Forms.Button();
            this.RemovePrizeButton = new System.Windows.Forms.Button();
            this.PrizesLabel = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Bahnschrift", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.HeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(461, 46);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Create Tournament Pannel";
            // 
            // TournamentNameValue
            // 
            this.TournamentNameValue.Location = new System.Drawing.Point(18, 115);
            this.TournamentNameValue.Name = "TournamentNameValue";
            this.TournamentNameValue.Size = new System.Drawing.Size(370, 40);
            this.TournamentNameValue.TabIndex = 10;
            // 
            // TeamOneScoreLabel
            // 
            this.TeamOneScoreLabel.AutoSize = true;
            this.TeamOneScoreLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamOneScoreLabel.Location = new System.Drawing.Point(12, 76);
            this.TeamOneScoreLabel.Name = "TeamOneScoreLabel";
            this.TeamOneScoreLabel.Size = new System.Drawing.Size(259, 36);
            this.TeamOneScoreLabel.TabIndex = 9;
            this.TeamOneScoreLabel.Text = "Tournament Name";
            // 
            // EntryFeeValue
            // 
            this.EntryFeeValue.Location = new System.Drawing.Point(159, 196);
            this.EntryFeeValue.Name = "EntryFeeValue";
            this.EntryFeeValue.Size = new System.Drawing.Size(183, 40);
            this.EntryFeeValue.TabIndex = 12;
            this.EntryFeeValue.Text = "0";
            // 
            // EntryFeeLabel
            // 
            this.EntryFeeLabel.AutoSize = true;
            this.EntryFeeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EntryFeeLabel.Location = new System.Drawing.Point(12, 196);
            this.EntryFeeLabel.Name = "EntryFeeLabel";
            this.EntryFeeLabel.Size = new System.Drawing.Size(141, 36);
            this.EntryFeeLabel.TabIndex = 11;
            this.EntryFeeLabel.Text = "Entry Fee";
            // 
            // SelectTeamDropDown
            // 
            this.SelectTeamDropDown.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTeamDropDown.FormattingEnabled = true;
            this.SelectTeamDropDown.Location = new System.Drawing.Point(20, 354);
            this.SelectTeamDropDown.Name = "SelectTeamDropDown";
            this.SelectTeamDropDown.Size = new System.Drawing.Size(370, 36);
            this.SelectTeamDropDown.TabIndex = 14;
            // 
            // SelectTeamLabel
            // 
            this.SelectTeamLabel.AutoSize = true;
            this.SelectTeamLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTeamLabel.Location = new System.Drawing.Point(14, 314);
            this.SelectTeamLabel.Name = "SelectTeamLabel";
            this.SelectTeamLabel.Size = new System.Drawing.Size(174, 36);
            this.SelectTeamLabel.TabIndex = 13;
            this.SelectTeamLabel.Text = "Select Team";
            // 
            // CreateNewTeamLink
            // 
            this.CreateNewTeamLink.AutoSize = true;
            this.CreateNewTeamLink.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateNewTeamLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.CreateNewTeamLink.LinkColor = System.Drawing.Color.Green;
            this.CreateNewTeamLink.Location = new System.Drawing.Point(256, 322);
            this.CreateNewTeamLink.Name = "CreateNewTeamLink";
            this.CreateNewTeamLink.Size = new System.Drawing.Size(134, 29);
            this.CreateNewTeamLink.TabIndex = 15;
            this.CreateNewTeamLink.TabStop = true;
            this.CreateNewTeamLink.Text = "Create new";
            this.CreateNewTeamLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewTeamLink_LinkClicked);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AddTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.AddTeamButton.FlatAppearance.BorderSize = 2;
            this.AddTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.AddTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.AddTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTeamButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTeamButton.Location = new System.Drawing.Point(20, 401);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(174, 48);
            this.AddTeamButton.TabIndex = 16;
            this.AddTeamButton.Text = "Add Team";
            this.AddTeamButton.UseVisualStyleBackColor = false;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrizeButton
            // 
            this.CreatePrizeButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.CreatePrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.CreatePrizeButton.FlatAppearance.BorderSize = 2;
            this.CreatePrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.CreatePrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.CreatePrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePrizeButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreatePrizeButton.Location = new System.Drawing.Point(216, 401);
            this.CreatePrizeButton.Name = "CreatePrizeButton";
            this.CreatePrizeButton.Size = new System.Drawing.Size(174, 48);
            this.CreatePrizeButton.TabIndex = 17;
            this.CreatePrizeButton.Text = "Create Prize";
            this.CreatePrizeButton.UseVisualStyleBackColor = false;
            this.CreatePrizeButton.Click += new System.EventHandler(this.CreatePrizeButton_Click);
            // 
            // TournamentTeamListbox
            // 
            this.TournamentTeamListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TournamentTeamListbox.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TournamentTeamListbox.FormattingEnabled = true;
            this.TournamentTeamListbox.ItemHeight = 24;
            this.TournamentTeamListbox.Location = new System.Drawing.Point(412, 78);
            this.TournamentTeamListbox.Name = "TournamentTeamListbox";
            this.TournamentTeamListbox.Size = new System.Drawing.Size(361, 194);
            this.TournamentTeamListbox.TabIndex = 18;
            // 
            // TournamentPlayerLabel
            // 
            this.TournamentPlayerLabel.AutoSize = true;
            this.TournamentPlayerLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TournamentPlayerLabel.Location = new System.Drawing.Point(491, 39);
            this.TournamentPlayerLabel.Name = "TournamentPlayerLabel";
            this.TournamentPlayerLabel.Size = new System.Drawing.Size(193, 36);
            this.TournamentPlayerLabel.TabIndex = 19;
            this.TournamentPlayerLabel.Text = "Team / Player";
            // 
            // RemovePlayersButton
            // 
            this.RemovePlayersButton.BackColor = System.Drawing.Color.MistyRose;
            this.RemovePlayersButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.RemovePlayersButton.FlatAppearance.BorderSize = 2;
            this.RemovePlayersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.RemovePlayersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.RemovePlayersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemovePlayersButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemovePlayersButton.Location = new System.Drawing.Point(779, 138);
            this.RemovePlayersButton.Name = "RemovePlayersButton";
            this.RemovePlayersButton.Size = new System.Drawing.Size(133, 71);
            this.RemovePlayersButton.TabIndex = 20;
            this.RemovePlayersButton.Text = "Remove";
            this.RemovePlayersButton.UseVisualStyleBackColor = false;
            this.RemovePlayersButton.Click += new System.EventHandler(this.RemovePlayersButton_Click);
            // 
            // RemovePrizeButton
            // 
            this.RemovePrizeButton.BackColor = System.Drawing.Color.MistyRose;
            this.RemovePrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.RemovePrizeButton.FlatAppearance.BorderSize = 2;
            this.RemovePrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.RemovePrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.RemovePrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemovePrizeButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemovePrizeButton.Location = new System.Drawing.Point(779, 361);
            this.RemovePrizeButton.Name = "RemovePrizeButton";
            this.RemovePrizeButton.Size = new System.Drawing.Size(133, 71);
            this.RemovePrizeButton.TabIndex = 23;
            this.RemovePrizeButton.Text = "Remove";
            this.RemovePrizeButton.UseVisualStyleBackColor = false;
            this.RemovePrizeButton.Click += new System.EventHandler(this.RemovePrizeButton_Click);
            // 
            // PrizesLabel
            // 
            this.PrizesLabel.AutoSize = true;
            this.PrizesLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrizesLabel.Location = new System.Drawing.Point(539, 275);
            this.PrizesLabel.Name = "PrizesLabel";
            this.PrizesLabel.Size = new System.Drawing.Size(101, 36);
            this.PrizesLabel.TabIndex = 22;
            this.PrizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrizesListBox.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrizesListBox.FormattingEnabled = true;
            this.PrizesListBox.ItemHeight = 24;
            this.PrizesListBox.Location = new System.Drawing.Point(414, 314);
            this.PrizesListBox.Name = "PrizesListBox";
            this.PrizesListBox.Size = new System.Drawing.Size(361, 194);
            this.PrizesListBox.TabIndex = 21;
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
            this.CreateTournamentButton.Location = new System.Drawing.Point(289, 515);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(338, 61);
            this.CreateTournamentButton.TabIndex = 24;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = false;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(926, 587);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.RemovePrizeButton);
            this.Controls.Add(this.PrizesLabel);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.RemovePlayersButton);
            this.Controls.Add(this.TournamentPlayerLabel);
            this.Controls.Add(this.TournamentTeamListbox);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.CreateNewTeamLink);
            this.Controls.Add(this.SelectTeamDropDown);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EntryFeeValue);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.TournamentNameValue);
            this.Controls.Add(this.TeamOneScoreLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreateTournamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox TournamentNameValue;
        private System.Windows.Forms.Label TeamOneScoreLabel;
        private System.Windows.Forms.TextBox EntryFeeValue;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.ComboBox SelectTeamDropDown;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.LinkLabel CreateNewTeamLink;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.ListBox TournamentTeamListbox;
        private System.Windows.Forms.Label TournamentPlayerLabel;
        private System.Windows.Forms.Button RemovePlayersButton;
        private System.Windows.Forms.Button RemovePrizeButton;
        private System.Windows.Forms.Label PrizesLabel;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}