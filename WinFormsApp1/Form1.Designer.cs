namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvTeams = new DataGridView();
            TeamName = new DataGridViewTextBoxColumn();
            TeamLeague = new DataGridViewTextBoxColumn();
            TeamPlayer1 = new DataGridViewTextBoxColumn();
            TeamPlayer2 = new DataGridViewTextBoxColumn();
            TeamPlayer3 = new DataGridViewTextBoxColumn();
            TeamPlayer4 = new DataGridViewTextBoxColumn();
            dtpDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            lblStartTime = new Label();
            lblEndTime = new Label();
            btnAddTime = new Button();
            lblLeague = new Label();
            txtLeague = new TextBox();
            dgvTime = new DataGridView();
            League = new DataGridViewTextBoxColumn();
            Day = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            EndTime = new DataGridViewTextBoxColumn();
            txtTeamName = new TextBox();
            lblTeam = new Label();
            lblLeagueTeam = new Label();
            txtPlayer2 = new TextBox();
            label1 = new Label();
            txtPlayer1 = new TextBox();
            label2 = new Label();
            txtPlayer4 = new TextBox();
            label3 = new Label();
            txtPlayer3 = new TextBox();
            label4 = new Label();
            btnAddTeam = new Button();
            btnRandomize = new Button();
            dgvSched = new DataGridView();
            scheduleTeam = new DataGridViewTextBoxColumn();
            scheduleAway = new DataGridViewTextBoxColumn();
            scheduleDay = new DataGridViewTextBoxColumn();
            scheduleStart = new DataGridViewTextBoxColumn();
            scheduleEnd = new DataGridViewTextBoxColumn();
            scheduleLeague = new DataGridViewTextBoxColumn();
            btnAddLeague = new Button();
            label5 = new Label();
            listBox1 = new ListBox();
            cmbScheduleLeague = new ComboBox();
            cmbTeamLeague = new ComboBox();
            btnAddTeam2 = new Button();
            chkIsConflict = new CheckBox();
            btnClearTeams = new Button();
            btnAddNewTeam = new Button();
            btnAddBye = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvTeams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSched).BeginInit();
            SuspendLayout();
            // 
            // dgvTeams
            // 
            dgvTeams.AllowUserToAddRows = false;
            dgvTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeams.Columns.AddRange(new DataGridViewColumn[] { TeamName, TeamLeague, TeamPlayer1, TeamPlayer2, TeamPlayer3, TeamPlayer4 });
            dgvTeams.Location = new Point(908, 211);
            dgvTeams.Margin = new Padding(6);
            dgvTeams.Name = "dgvTeams";
            dgvTeams.ReadOnly = true;
            dgvTeams.RowHeadersWidth = 82;
            dgvTeams.Size = new Size(1231, 887);
            dgvTeams.TabIndex = 0;
            // 
            // TeamName
            // 
            TeamName.HeaderText = "TeamName";
            TeamName.MinimumWidth = 10;
            TeamName.Name = "TeamName";
            TeamName.ReadOnly = true;
            TeamName.Width = 200;
            // 
            // TeamLeague
            // 
            TeamLeague.HeaderText = "TeamLeague";
            TeamLeague.MinimumWidth = 10;
            TeamLeague.Name = "TeamLeague";
            TeamLeague.ReadOnly = true;
            TeamLeague.Width = 200;
            // 
            // TeamPlayer1
            // 
            TeamPlayer1.HeaderText = "Player1";
            TeamPlayer1.MinimumWidth = 10;
            TeamPlayer1.Name = "TeamPlayer1";
            TeamPlayer1.ReadOnly = true;
            TeamPlayer1.Width = 200;
            // 
            // TeamPlayer2
            // 
            TeamPlayer2.HeaderText = "Player2";
            TeamPlayer2.MinimumWidth = 10;
            TeamPlayer2.Name = "TeamPlayer2";
            TeamPlayer2.ReadOnly = true;
            TeamPlayer2.Width = 200;
            // 
            // TeamPlayer3
            // 
            TeamPlayer3.HeaderText = "Player3";
            TeamPlayer3.MinimumWidth = 10;
            TeamPlayer3.Name = "TeamPlayer3";
            TeamPlayer3.ReadOnly = true;
            TeamPlayer3.Width = 200;
            // 
            // TeamPlayer4
            // 
            TeamPlayer4.HeaderText = "Player4";
            TeamPlayer4.MinimumWidth = 10;
            TeamPlayer4.Name = "TeamPlayer4";
            TeamPlayer4.ReadOnly = true;
            TeamPlayer4.Width = 200;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(71, 307);
            dtpDate.Margin = new Padding(6);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(355, 39);
            dtpDate.TabIndex = 4;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(563, 307);
            dtpStartTime.Margin = new Padding(6);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(203, 39);
            dtpStartTime.TabIndex = 5;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(563, 369);
            dtpEndTime.Margin = new Padding(6);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(203, 39);
            dtpEndTime.TabIndex = 6;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(440, 320);
            lblStartTime.Margin = new Padding(6, 0, 6, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(122, 32);
            lblStartTime.TabIndex = 7;
            lblStartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(448, 382);
            lblEndTime.Margin = new Padding(6, 0, 6, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(114, 32);
            lblEndTime.TabIndex = 8;
            lblEndTime.Text = "End Time";
            // 
            // btnAddTime
            // 
            btnAddTime.Location = new Point(338, 431);
            btnAddTime.Margin = new Padding(6);
            btnAddTime.Name = "btnAddTime";
            btnAddTime.Size = new Size(139, 49);
            btnAddTime.TabIndex = 9;
            btnAddTime.Text = "Add Time";
            btnAddTime.UseVisualStyleBackColor = false;
            btnAddTime.Click += btnAddTime_Click;
            // 
            // lblLeague
            // 
            lblLeague.AutoSize = true;
            lblLeague.Location = new Point(89, 107);
            lblLeague.Margin = new Padding(6, 0, 6, 0);
            lblLeague.Name = "lblLeague";
            lblLeague.Size = new Size(91, 32);
            lblLeague.TabIndex = 10;
            lblLeague.Text = "League";
            // 
            // txtLeague
            // 
            txtLeague.Location = new Point(184, 92);
            txtLeague.Margin = new Padding(6);
            txtLeague.Name = "txtLeague";
            txtLeague.Size = new Size(203, 39);
            txtLeague.TabIndex = 11;
            // 
            // dgvTime
            // 
            dgvTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTime.Columns.AddRange(new DataGridViewColumn[] { League, Day, StartTime, EndTime });
            dgvTime.Location = new Point(7, 493);
            dgvTime.Margin = new Padding(6);
            dgvTime.Name = "dgvTime";
            dgvTime.RowHeadersWidth = 82;
            dgvTime.Size = new Size(895, 887);
            dgvTime.TabIndex = 12;
            // 
            // League
            // 
            League.HeaderText = "League";
            League.MinimumWidth = 10;
            League.Name = "League";
            League.Width = 200;
            // 
            // Day
            // 
            Day.HeaderText = "Day";
            Day.MinimumWidth = 10;
            Day.Name = "Day";
            Day.Width = 200;
            // 
            // StartTime
            // 
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 10;
            StartTime.Name = "StartTime";
            StartTime.Width = 200;
            // 
            // EndTime
            // 
            EndTime.HeaderText = "End Time";
            EndTime.MinimumWidth = 10;
            EndTime.Name = "EndTime";
            EndTime.Width = 200;
            // 
            // txtTeamName
            // 
            txtTeamName.Location = new Point(1049, 29);
            txtTeamName.Margin = new Padding(6);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Size = new Size(203, 39);
            txtTeamName.TabIndex = 14;
            // 
            // lblTeam
            // 
            lblTeam.AutoSize = true;
            lblTeam.Location = new Point(908, 38);
            lblTeam.Margin = new Padding(6, 0, 6, 0);
            lblTeam.Name = "lblTeam";
            lblTeam.Size = new Size(142, 32);
            lblTeam.TabIndex = 13;
            lblTeam.Text = "Team Name";
            // 
            // lblLeagueTeam
            // 
            lblLeagueTeam.AutoSize = true;
            lblLeagueTeam.Location = new Point(908, 102);
            lblLeagueTeam.Margin = new Padding(6, 0, 6, 0);
            lblLeagueTeam.Name = "lblLeagueTeam";
            lblLeagueTeam.Size = new Size(155, 32);
            lblLeagueTeam.TabIndex = 15;
            lblLeagueTeam.Text = "Team League";
            // 
            // txtPlayer2
            // 
            txtPlayer2.Location = new Point(1367, 95);
            txtPlayer2.Margin = new Padding(6);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(203, 39);
            txtPlayer2.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1266, 108);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 32);
            label1.TabIndex = 19;
            label1.Text = "Player 2";
            // 
            // txtPlayer1
            // 
            txtPlayer1.Location = new Point(1367, 31);
            txtPlayer1.Margin = new Padding(6);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(203, 39);
            txtPlayer1.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1266, 44);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 32);
            label2.TabIndex = 17;
            label2.Text = "Player 1";
            // 
            // txtPlayer4
            // 
            txtPlayer4.Location = new Point(1684, 95);
            txtPlayer4.Margin = new Padding(6);
            txtPlayer4.Name = "txtPlayer4";
            txtPlayer4.Size = new Size(203, 39);
            txtPlayer4.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1584, 108);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 32);
            label3.TabIndex = 23;
            label3.Text = "Player 4";
            // 
            // txtPlayer3
            // 
            txtPlayer3.Location = new Point(1684, 31);
            txtPlayer3.Margin = new Padding(6);
            txtPlayer3.Name = "txtPlayer3";
            txtPlayer3.Size = new Size(203, 39);
            txtPlayer3.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1584, 44);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(98, 32);
            label4.TabIndex = 21;
            label4.Text = "Player 3";
            // 
            // btnAddTeam
            // 
            btnAddTeam.Location = new Point(1909, 26);
            btnAddTeam.Margin = new Padding(6);
            btnAddTeam.Name = "btnAddTeam";
            btnAddTeam.Size = new Size(230, 49);
            btnAddTeam.TabIndex = 25;
            btnAddTeam.Text = "Generate Teamset1";
            btnAddTeam.UseVisualStyleBackColor = true;
            btnAddTeam.Click += btnAddTeam_Click;
            // 
            // btnRandomize
            // 
            btnRandomize.Location = new Point(713, 1523);
            btnRandomize.Margin = new Padding(6);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(158, 52);
            btnRandomize.TabIndex = 26;
            btnRandomize.Text = "Randomize";
            btnRandomize.UseVisualStyleBackColor = true;
            btnRandomize.Click += btnRandomize_Click;
            // 
            // dgvSched
            // 
            dgvSched.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSched.Columns.AddRange(new DataGridViewColumn[] { scheduleTeam, scheduleAway, scheduleDay, scheduleStart, scheduleEnd, scheduleLeague });
            dgvSched.Location = new Point(908, 1111);
            dgvSched.Margin = new Padding(6);
            dgvSched.Name = "dgvSched";
            dgvSched.RowHeadersWidth = 82;
            dgvSched.Size = new Size(1231, 817);
            dgvSched.TabIndex = 27;
            // 
            // scheduleTeam
            // 
            scheduleTeam.HeaderText = "Home Team";
            scheduleTeam.MinimumWidth = 10;
            scheduleTeam.Name = "scheduleTeam";
            scheduleTeam.Width = 200;
            // 
            // scheduleAway
            // 
            scheduleAway.HeaderText = "Away Team";
            scheduleAway.MinimumWidth = 10;
            scheduleAway.Name = "scheduleAway";
            scheduleAway.Width = 200;
            // 
            // scheduleDay
            // 
            scheduleDay.HeaderText = "Day";
            scheduleDay.MinimumWidth = 10;
            scheduleDay.Name = "scheduleDay";
            scheduleDay.Width = 200;
            // 
            // scheduleStart
            // 
            scheduleStart.HeaderText = "Start Time";
            scheduleStart.MinimumWidth = 10;
            scheduleStart.Name = "scheduleStart";
            scheduleStart.Width = 200;
            // 
            // scheduleEnd
            // 
            scheduleEnd.HeaderText = "End Time";
            scheduleEnd.MinimumWidth = 10;
            scheduleEnd.Name = "scheduleEnd";
            scheduleEnd.Width = 200;
            // 
            // scheduleLeague
            // 
            scheduleLeague.HeaderText = "League";
            scheduleLeague.MinimumWidth = 10;
            scheduleLeague.Name = "scheduleLeague";
            scheduleLeague.Width = 200;
            // 
            // btnAddLeague
            // 
            btnAddLeague.Location = new Point(184, 156);
            btnAddLeague.Margin = new Padding(6);
            btnAddLeague.Name = "btnAddLeague";
            btnAddLeague.Size = new Size(154, 49);
            btnAddLeague.TabIndex = 28;
            btnAddLeague.Text = "Add League";
            btnAddLeague.UseVisualStyleBackColor = false;
            btnAddLeague.Click += btnAddLeague_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(108, 382);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 32);
            label5.TabIndex = 29;
            label5.Text = "League";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(440, 26);
            listBox1.Margin = new Padding(6);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(268, 260);
            listBox1.TabIndex = 30;
            // 
            // cmbScheduleLeague
            // 
            cmbScheduleLeague.FormattingEnabled = true;
            cmbScheduleLeague.Location = new Point(202, 375);
            cmbScheduleLeague.Margin = new Padding(6);
            cmbScheduleLeague.Name = "cmbScheduleLeague";
            cmbScheduleLeague.Size = new Size(221, 40);
            cmbScheduleLeague.TabIndex = 31;
            // 
            // cmbTeamLeague
            // 
            cmbTeamLeague.FormattingEnabled = true;
            cmbTeamLeague.Location = new Point(1049, 93);
            cmbTeamLeague.Margin = new Padding(6);
            cmbTeamLeague.Name = "cmbTeamLeague";
            cmbTeamLeague.Size = new Size(203, 40);
            cmbTeamLeague.TabIndex = 32;
            // 
            // btnAddTeam2
            // 
            btnAddTeam2.Location = new Point(1909, 87);
            btnAddTeam2.Margin = new Padding(6);
            btnAddTeam2.Name = "btnAddTeam2";
            btnAddTeam2.Size = new Size(230, 49);
            btnAddTeam2.TabIndex = 33;
            btnAddTeam2.Text = "Generate Teamset2";
            btnAddTeam2.UseVisualStyleBackColor = true;
            btnAddTeam2.Click += btnAddTeam2_Click;
            // 
            // chkIsConflict
            // 
            chkIsConflict.AutoSize = true;
            chkIsConflict.Location = new Point(1343, 163);
            chkIsConflict.Name = "chkIsConflict";
            chkIsConflict.Size = new Size(269, 36);
            chkIsConflict.TabIndex = 34;
            chkIsConflict.Text = "Don't Allow Conflicts";
            chkIsConflict.UseVisualStyleBackColor = true;
            chkIsConflict.CheckedChanged += chkIsConflict_CheckedChanged;
            // 
            // btnClearTeams
            // 
            btnClearTeams.Location = new Point(1909, 148);
            btnClearTeams.Margin = new Padding(6);
            btnClearTeams.Name = "btnClearTeams";
            btnClearTeams.Size = new Size(230, 49);
            btnClearTeams.TabIndex = 35;
            btnClearTeams.Text = "Clear Teams";
            btnClearTeams.UseVisualStyleBackColor = true;
            btnClearTeams.Click += btnClearTeams_Click;
            // 
            // btnAddNewTeam
            // 
            btnAddNewTeam.Location = new Point(1657, 146);
            btnAddNewTeam.Margin = new Padding(6);
            btnAddNewTeam.Name = "btnAddNewTeam";
            btnAddNewTeam.Size = new Size(230, 49);
            btnAddNewTeam.TabIndex = 36;
            btnAddNewTeam.Text = "Add Team";
            btnAddNewTeam.UseVisualStyleBackColor = true;
            btnAddNewTeam.Click += btnAddNewTeam_Click;
            // 
            // btnAddBye
            // 
            btnAddBye.AutoSize = true;
            btnAddBye.Location = new Point(908, 161);
            btnAddBye.Name = "btnAddBye";
            btnAddBye.Size = new Size(372, 36);
            btnAddBye.TabIndex = 37;
            btnAddBye.Text = "Add BYE Game If Odd # Teams";
            btnAddBye.UseVisualStyleBackColor = true;
            btnAddBye.CheckedChanged += btnAddBye_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2162, 1879);
            Controls.Add(btnAddBye);
            Controls.Add(btnAddNewTeam);
            Controls.Add(btnClearTeams);
            Controls.Add(chkIsConflict);
            Controls.Add(btnAddTeam2);
            Controls.Add(cmbTeamLeague);
            Controls.Add(cmbScheduleLeague);
            Controls.Add(listBox1);
            Controls.Add(label5);
            Controls.Add(btnAddLeague);
            Controls.Add(dgvSched);
            Controls.Add(btnRandomize);
            Controls.Add(btnAddTeam);
            Controls.Add(txtPlayer4);
            Controls.Add(label3);
            Controls.Add(txtPlayer3);
            Controls.Add(label4);
            Controls.Add(txtPlayer2);
            Controls.Add(label1);
            Controls.Add(txtPlayer1);
            Controls.Add(label2);
            Controls.Add(lblLeagueTeam);
            Controls.Add(txtTeamName);
            Controls.Add(lblTeam);
            Controls.Add(dgvTime);
            Controls.Add(txtLeague);
            Controls.Add(lblLeague);
            Controls.Add(btnAddTime);
            Controls.Add(lblEndTime);
            Controls.Add(lblStartTime);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpDate);
            Controls.Add(dgvTeams);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTeams).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSched).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTeams;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn TeamLeague;
        private DataGridViewTextBoxColumn TeamPlayer1;
        private DataGridViewTextBoxColumn TeamPlayer2;
        private DataGridViewTextBoxColumn TeamPlayer3;
        private DataGridViewTextBoxColumn TeamPlayer4;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label lblStartTime;
        private Label lblEndTime;
        private Button btnAddTime;
        private Label lblLeague;
        private TextBox txtLeague;
        private DataGridView dgvTime;
        private TextBox txtTeamName;
        private Label lblTeam;
        private Label lblLeagueTeam;
        private TextBox txtPlayer2;
        private Label label1;
        private TextBox txtPlayer1;
        private Label label2;
        private TextBox txtPlayer4;
        private Label label3;
        private TextBox txtPlayer3;
        private Label label4;
        private Button btnAddTeam;
        private Button btnRandomize;
        private DataGridViewTextBoxColumn League;
        private DataGridViewTextBoxColumn Day;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private DataGridView dgvSched;
        private Button btnAddLeague;
        private Label label5;
        private ListBox listBox1;
        private ComboBox cmbScheduleLeague;
        private ComboBox cmbTeamLeague;
        private DataGridViewTextBoxColumn scheduleTeam;
        private DataGridViewTextBoxColumn scheduleAway;
        private DataGridViewTextBoxColumn scheduleDay;
        private DataGridViewTextBoxColumn scheduleStart;
        private DataGridViewTextBoxColumn scheduleEnd;
        private DataGridViewTextBoxColumn scheduleLeague;
        private Button btnAddTeam2;
        private CheckBox chkIsConflict;
        private Button btnClearTeams;
        private Button btnAddNewTeam;
        private CheckBox btnAddBye;
    }
}
