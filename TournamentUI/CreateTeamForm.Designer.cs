namespace TournamentUI
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            this.TeamNameValue = new System.Windows.Forms.TextBox();
            this.TeamNameLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.AddTeamMemberButton = new System.Windows.Forms.Button();
            this.SelectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamMemberLabel = new System.Windows.Forms.Label();
            this.AddNewMemberBox = new System.Windows.Forms.GroupBox();
            this.CreateNewMemberButton = new System.Windows.Forms.Button();
            this.PhoneNumberValue = new System.Windows.Forms.TextBox();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.EmailValue = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameValue = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameValue = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.TeamMembersListbox = new System.Windows.Forms.ListBox();
            this.RemoveMembersButton = new System.Windows.Forms.Button();
            this.CreateTeamButton = new System.Windows.Forms.Button();
            this.AddNewMemberBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamNameValue
            // 
            this.TeamNameValue.Location = new System.Drawing.Point(18, 117);
            this.TeamNameValue.Name = "TeamNameValue";
            this.TeamNameValue.Size = new System.Drawing.Size(387, 35);
            this.TeamNameValue.TabIndex = 13;
            // 
            // TeamNameLabel
            // 
            this.TeamNameLabel.AutoSize = true;
            this.TeamNameLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamNameLabel.Location = new System.Drawing.Point(12, 78);
            this.TeamNameLabel.Name = "TeamNameLabel";
            this.TeamNameLabel.Size = new System.Drawing.Size(165, 36);
            this.TeamNameLabel.TabIndex = 12;
            this.TeamNameLabel.Text = "Team name";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Bahnschrift", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 19);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(227, 46);
            this.HeaderLabel.TabIndex = 11;
            this.HeaderLabel.Text = "Create Team";
            // 
            // AddTeamMemberButton
            // 
            this.AddTeamMemberButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AddTeamMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.AddTeamMemberButton.FlatAppearance.BorderSize = 2;
            this.AddTeamMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.AddTeamMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.AddTeamMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTeamMemberButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTeamMemberButton.Location = new System.Drawing.Point(18, 249);
            this.AddTeamMemberButton.Name = "AddTeamMemberButton";
            this.AddTeamMemberButton.Size = new System.Drawing.Size(221, 59);
            this.AddTeamMemberButton.TabIndex = 19;
            this.AddTeamMemberButton.Text = "Add team member";
            this.AddTeamMemberButton.UseVisualStyleBackColor = false;
            this.AddTeamMemberButton.Click += new System.EventHandler(this.AddTeamMemberButton_Click);
            // 
            // SelectTeamMemberDropDown
            // 
            this.SelectTeamMemberDropDown.FormattingEnabled = true;
            this.SelectTeamMemberDropDown.Location = new System.Drawing.Point(18, 207);
            this.SelectTeamMemberDropDown.Name = "SelectTeamMemberDropDown";
            this.SelectTeamMemberDropDown.Size = new System.Drawing.Size(387, 36);
            this.SelectTeamMemberDropDown.TabIndex = 18;
            // 
            // SelectTeamMemberLabel
            // 
            this.SelectTeamMemberLabel.AutoSize = true;
            this.SelectTeamMemberLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTeamMemberLabel.Location = new System.Drawing.Point(12, 168);
            this.SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            this.SelectTeamMemberLabel.Size = new System.Drawing.Size(290, 36);
            this.SelectTeamMemberLabel.TabIndex = 17;
            this.SelectTeamMemberLabel.Text = "Select team member";
            // 
            // AddNewMemberBox
            // 
            this.AddNewMemberBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.AddNewMemberBox.Controls.Add(this.CreateNewMemberButton);
            this.AddNewMemberBox.Controls.Add(this.PhoneNumberValue);
            this.AddNewMemberBox.Controls.Add(this.PhoneNumberLabel);
            this.AddNewMemberBox.Controls.Add(this.EmailValue);
            this.AddNewMemberBox.Controls.Add(this.EmailLabel);
            this.AddNewMemberBox.Controls.Add(this.LastNameValue);
            this.AddNewMemberBox.Controls.Add(this.LastNameLabel);
            this.AddNewMemberBox.Controls.Add(this.FirstNameValue);
            this.AddNewMemberBox.Controls.Add(this.FirstNameLabel);
            this.AddNewMemberBox.Location = new System.Drawing.Point(18, 335);
            this.AddNewMemberBox.Name = "AddNewMemberBox";
            this.AddNewMemberBox.Size = new System.Drawing.Size(393, 288);
            this.AddNewMemberBox.TabIndex = 20;
            this.AddNewMemberBox.TabStop = false;
            this.AddNewMemberBox.Text = "Add new member";
            // 
            // CreateNewMemberButton
            // 
            this.CreateNewMemberButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CreateNewMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.CreateNewMemberButton.FlatAppearance.BorderSize = 2;
            this.CreateNewMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.CreateNewMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.CreateNewMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewMemberButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateNewMemberButton.Location = new System.Drawing.Point(91, 202);
            this.CreateNewMemberButton.Name = "CreateNewMemberButton";
            this.CreateNewMemberButton.Size = new System.Drawing.Size(193, 49);
            this.CreateNewMemberButton.TabIndex = 21;
            this.CreateNewMemberButton.Text = "Create member";
            this.CreateNewMemberButton.UseVisualStyleBackColor = false;
            this.CreateNewMemberButton.Click += new System.EventHandler(this.CreateNewMemberButton_Click);
            // 
            // PhoneNumberValue
            // 
            this.PhoneNumberValue.Location = new System.Drawing.Point(183, 161);
            this.PhoneNumberValue.Name = "PhoneNumberValue";
            this.PhoneNumberValue.Size = new System.Drawing.Size(204, 35);
            this.PhoneNumberValue.TabIndex = 28;
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberLabel.Location = new System.Drawing.Point(14, 164);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(167, 29);
            this.PhoneNumberLabel.TabIndex = 27;
            this.PhoneNumberLabel.Text = "PhoneNumber";
            // 
            // EmailValue
            // 
            this.EmailValue.Location = new System.Drawing.Point(183, 122);
            this.EmailValue.Name = "EmailValue";
            this.EmailValue.Size = new System.Drawing.Size(204, 35);
            this.EmailValue.TabIndex = 26;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLabel.Location = new System.Drawing.Point(14, 125);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(74, 29);
            this.EmailLabel.TabIndex = 25;
            this.EmailLabel.Text = "Email";
            // 
            // LastNameValue
            // 
            this.LastNameValue.Location = new System.Drawing.Point(183, 83);
            this.LastNameValue.Name = "LastNameValue";
            this.LastNameValue.Size = new System.Drawing.Size(204, 35);
            this.LastNameValue.TabIndex = 24;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameLabel.Location = new System.Drawing.Point(14, 86);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(124, 29);
            this.LastNameLabel.TabIndex = 23;
            this.LastNameLabel.Text = "Last name";
            // 
            // FirstNameValue
            // 
            this.FirstNameValue.Location = new System.Drawing.Point(183, 44);
            this.FirstNameValue.Name = "FirstNameValue";
            this.FirstNameValue.Size = new System.Drawing.Size(204, 35);
            this.FirstNameValue.TabIndex = 22;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameLabel.Location = new System.Drawing.Point(14, 47);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(126, 29);
            this.FirstNameLabel.TabIndex = 21;
            this.FirstNameLabel.Text = "First name";
            // 
            // TeamMembersListbox
            // 
            this.TeamMembersListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamMembersListbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TeamMembersListbox.FormattingEnabled = true;
            this.TeamMembersListbox.ItemHeight = 28;
            this.TeamMembersListbox.Location = new System.Drawing.Point(432, 117);
            this.TeamMembersListbox.Name = "TeamMembersListbox";
            this.TeamMembersListbox.Size = new System.Drawing.Size(375, 506);
            this.TeamMembersListbox.TabIndex = 21;
            // 
            // RemoveMembersButton
            // 
            this.RemoveMembersButton.BackColor = System.Drawing.Color.MistyRose;
            this.RemoveMembersButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.RemoveMembersButton.FlatAppearance.BorderSize = 2;
            this.RemoveMembersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.RemoveMembersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.RemoveMembersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveMembersButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveMembersButton.Location = new System.Drawing.Point(813, 340);
            this.RemoveMembersButton.Name = "RemoveMembersButton";
            this.RemoveMembersButton.Size = new System.Drawing.Size(152, 71);
            this.RemoveMembersButton.TabIndex = 22;
            this.RemoveMembersButton.Text = "Remove";
            this.RemoveMembersButton.UseVisualStyleBackColor = false;
            this.RemoveMembersButton.Click += new System.EventHandler(this.RemoveMembersButton_Click);
            // 
            // CreateTeamButton
            // 
            this.CreateTeamButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CreateTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.CreateTeamButton.FlatAppearance.BorderSize = 2;
            this.CreateTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.CreateTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.CreateTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTeamButton.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTeamButton.Location = new System.Drawing.Point(432, 629);
            this.CreateTeamButton.Name = "CreateTeamButton";
            this.CreateTeamButton.Size = new System.Drawing.Size(375, 54);
            this.CreateTeamButton.TabIndex = 25;
            this.CreateTeamButton.Text = "Create Team";
            this.CreateTeamButton.UseVisualStyleBackColor = false;
            this.CreateTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(973, 707);
            this.Controls.Add(this.CreateTeamButton);
            this.Controls.Add(this.RemoveMembersButton);
            this.Controls.Add(this.TeamMembersListbox);
            this.Controls.Add(this.AddNewMemberBox);
            this.Controls.Add(this.AddTeamMemberButton);
            this.Controls.Add(this.SelectTeamMemberDropDown);
            this.Controls.Add(this.SelectTeamMemberLabel);
            this.Controls.Add(this.TeamNameValue);
            this.Controls.Add(this.TeamNameLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CreateTeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateTeamForm";
            this.AddNewMemberBox.ResumeLayout(false);
            this.AddNewMemberBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TeamNameValue;
        private System.Windows.Forms.Label TeamNameLabel;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button AddTeamMemberButton;
        private System.Windows.Forms.ComboBox SelectTeamMemberDropDown;
        private System.Windows.Forms.Label SelectTeamMemberLabel;
        private System.Windows.Forms.GroupBox AddNewMemberBox;
        private System.Windows.Forms.TextBox PhoneNumberValue;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.TextBox EmailValue;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox LastNameValue;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox FirstNameValue;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Button CreateNewMemberButton;
        private System.Windows.Forms.ListBox TeamMembersListbox;
        private System.Windows.Forms.Button RemoveMembersButton;
        private System.Windows.Forms.Button CreateTeamButton;
    }
}