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
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamLeague = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamPlayer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamPlayer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamPlayer3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamPlayer4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.lblLeague = new System.Windows.Forms.Label();
            this.txtLeague = new System.Windows.Forms.TextBox();
            this.dgvTime = new System.Windows.Forms.DataGridView();
            this.League = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblLeagueTeam = new System.Windows.Forms.Label();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayer4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlayer3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.dgvSched = new System.Windows.Forms.DataGridView();
            this.scheduleTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleAway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleLeague = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLeague = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmbScheduleLeague = new System.Windows.Forms.ComboBox();
            this.cmbTeamLeague = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSched)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.TeamLeague,
            this.TeamPlayer1,
            this.TeamPlayer2,
            this.TeamPlayer3,
            this.TeamPlayer4});
            this.dgvTeams.Location = new System.Drawing.Point(489, 99);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.Size = new System.Drawing.Size(663, 416);
            this.dgvTeams.TabIndex = 0;
            // 
            // TeamName
            // 
            this.TeamName.HeaderText = "TeamName";
            this.TeamName.Name = "TeamName";
            // 
            // TeamLeague
            // 
            this.TeamLeague.HeaderText = "TeamLeague";
            this.TeamLeague.Name = "TeamLeague";
            // 
            // TeamPlayer1
            // 
            this.TeamPlayer1.HeaderText = "Player1";
            this.TeamPlayer1.Name = "TeamPlayer1";
            // 
            // TeamPlayer2
            // 
            this.TeamPlayer2.HeaderText = "Player2";
            this.TeamPlayer2.Name = "TeamPlayer2";
            // 
            // TeamPlayer3
            // 
            this.TeamPlayer3.HeaderText = "Player3";
            this.TeamPlayer3.Name = "TeamPlayer3";
            // 
            // TeamPlayer4
            // 
            this.TeamPlayer4.HeaderText = "Player4";
            this.TeamPlayer4.Name = "TeamPlayer4";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(38, 144);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(193, 23);
            this.dtpDate.TabIndex = 4;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(303, 144);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(111, 23);
            this.dtpStartTime.TabIndex = 5;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(303, 173);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(111, 23);
            this.dtpEndTime.TabIndex = 6;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(237, 150);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(60, 15);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(241, 179);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(56, 15);
            this.lblEndTime.TabIndex = 8;
            this.lblEndTime.Text = "End Time";
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(182, 202);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddTime.TabIndex = 9;
            this.btnAddTime.Text = "Add Time";
            this.btnAddTime.UseVisualStyleBackColor = false;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // lblLeague
            // 
            this.lblLeague.AutoSize = true;
            this.lblLeague.Location = new System.Drawing.Point(48, 50);
            this.lblLeague.Name = "lblLeague";
            this.lblLeague.Size = new System.Drawing.Size(45, 15);
            this.lblLeague.TabIndex = 10;
            this.lblLeague.Text = "League";
            // 
            // txtLeague
            // 
            this.txtLeague.Location = new System.Drawing.Point(99, 43);
            this.txtLeague.Name = "txtLeague";
            this.txtLeague.Size = new System.Drawing.Size(111, 23);
            this.txtLeague.TabIndex = 11;
            // 
            // dgvTime
            // 
            this.dgvTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.League,
            this.Day,
            this.StartTime,
            this.EndTime});
            this.dgvTime.Location = new System.Drawing.Point(4, 231);
            this.dgvTime.Name = "dgvTime";
            this.dgvTime.Size = new System.Drawing.Size(482, 416);
            this.dgvTime.TabIndex = 12;
            // 
            // League
            // 
            this.League.HeaderText = "League";
            this.League.Name = "League";
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(546, 17);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(111, 23);
            this.txtTeamName.TabIndex = 14;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(470, 21);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(70, 15);
            this.lblTeam.TabIndex = 13;
            this.lblTeam.Text = "Team Name";
            // 
            // lblLeagueTeam
            // 
            this.lblLeagueTeam.AutoSize = true;
            this.lblLeagueTeam.Location = new System.Drawing.Point(470, 51);
            this.lblLeagueTeam.Name = "lblLeagueTeam";
            this.lblLeagueTeam.Size = new System.Drawing.Size(76, 15);
            this.lblLeagueTeam.TabIndex = 15;
            this.lblLeagueTeam.Text = "Team League";
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.Location = new System.Drawing.Point(717, 48);
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(111, 23);
            this.txtPlayer2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Player 2";
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.Location = new System.Drawing.Point(717, 18);
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(111, 23);
            this.txtPlayer1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Player 1";
            // 
            // txtPlayer4
            // 
            this.txtPlayer4.Location = new System.Drawing.Point(888, 48);
            this.txtPlayer4.Name = "txtPlayer4";
            this.txtPlayer4.Size = new System.Drawing.Size(111, 23);
            this.txtPlayer4.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(834, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Player 4";
            // 
            // txtPlayer3
            // 
            this.txtPlayer3.Location = new System.Drawing.Point(888, 18);
            this.txtPlayer3.Name = "txtPlayer3";
            this.txtPlayer3.Size = new System.Drawing.Size(111, 23);
            this.txtPlayer3.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(834, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Player 3";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Location = new System.Drawing.Point(1028, 17);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(124, 23);
            this.btnAddTeam.TabIndex = 25;
            this.btnAddTeam.Text = "Generate Teamset1";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(408, 715);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 26;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // dgvSched
            // 
            this.dgvSched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSched.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduleTeam,
            this.scheduleAway,
            this.scheduleDay,
            this.scheduleStart,
            this.scheduleEnd,
            this.scheduleLeague});
            this.dgvSched.Location = new System.Drawing.Point(489, 521);
            this.dgvSched.Name = "dgvSched";
            this.dgvSched.Size = new System.Drawing.Size(663, 383);
            this.dgvSched.TabIndex = 27;
            // 
            // scheduleTeam
            // 
            this.scheduleTeam.HeaderText = "Home Team";
            this.scheduleTeam.Name = "scheduleTeam";
            // 
            // scheduleAway
            // 
            this.scheduleAway.HeaderText = "Away Team";
            this.scheduleAway.Name = "scheduleAway";
            // 
            // scheduleDay
            // 
            this.scheduleDay.HeaderText = "Day";
            this.scheduleDay.Name = "scheduleDay";
            // 
            // scheduleStart
            // 
            this.scheduleStart.HeaderText = "Start Time";
            this.scheduleStart.Name = "scheduleStart";
            // 
            // scheduleEnd
            // 
            this.scheduleEnd.HeaderText = "End Time";
            this.scheduleEnd.Name = "scheduleEnd";
            // 
            // scheduleLeague
            // 
            this.scheduleLeague.HeaderText = "League";
            this.scheduleLeague.Name = "scheduleLeague";
            // 
            // btnAddLeague
            // 
            this.btnAddLeague.Location = new System.Drawing.Point(99, 73);
            this.btnAddLeague.Name = "btnAddLeague";
            this.btnAddLeague.Size = new System.Drawing.Size(83, 23);
            this.btnAddLeague.TabIndex = 28;
            this.btnAddLeague.Text = "Add League";
            this.btnAddLeague.UseVisualStyleBackColor = false;
            this.btnAddLeague.Click += new System.EventHandler(this.btnAddLeague_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "League";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(237, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(146, 124);
            this.listBox1.TabIndex = 30;
            // 
            // cmbScheduleLeague
            // 
            this.cmbScheduleLeague.FormattingEnabled = true;
            this.cmbScheduleLeague.Location = new System.Drawing.Point(109, 176);
            this.cmbScheduleLeague.Name = "cmbScheduleLeague";
            this.cmbScheduleLeague.Size = new System.Drawing.Size(121, 23);
            this.cmbScheduleLeague.TabIndex = 31;
            // 
            // cmbTeamLeague
            // 
            this.cmbTeamLeague.FormattingEnabled = true;
            this.cmbTeamLeague.Location = new System.Drawing.Point(546, 47);
            this.cmbTeamLeague.Name = "cmbTeamLeague";
            this.cmbTeamLeague.Size = new System.Drawing.Size(111, 23);
            this.cmbTeamLeague.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 938);
            this.Controls.Add(this.cmbTeamLeague);
            this.Controls.Add(this.cmbScheduleLeague);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddLeague);
            this.Controls.Add(this.dgvSched);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnAddTeam);
            this.Controls.Add(this.txtPlayer4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlayer3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLeagueTeam);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.dgvTime);
            this.Controls.Add(this.txtLeague);
            this.Controls.Add(this.lblLeague);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dgvTeams);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSched)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
