namespace Ticker
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.radDesktopAlert1 = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.lvPlayListDetail = new Telerik.WinControls.UI.RadListView();
            this.lvNotes = new Telerik.WinControls.UI.RadListView();
            this.lvGames = new Telerik.WinControls.UI.RadListView();
            this.cboPlaylist = new Telerik.WinControls.UI.RadDropDownList();
            this.cboClient = new Telerik.WinControls.UI.RadDropDownList();
            this.tabPlayoutOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkGamesOnlyFinals = new System.Windows.Forms.CheckBox();
            this.chkGamesOnlySorted = new System.Windows.Forms.CheckBox();
            this.btnSponsorRefresh = new System.Windows.Forms.Button();
            this.cboSponsor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIntroRefresh = new System.Windows.Forms.Button();
            this.cboIntro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStartAt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkScoreAlerts = new System.Windows.Forms.CheckBox();
            this.chkTrackPlay = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCSSLog = new System.Windows.Forms.Label();
            this.lblCSSStatus = new System.Windows.Forms.Label();
            this.btnCSSConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.cmdStop = new System.Windows.Forms.PictureBox();
            this.cmdPlay = new System.Windows.Forms.PictureBox();
            this.cmdGamesToggle = new System.Windows.Forms.Button();
            this.cmdNotesToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvPlayListDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).BeginInit();
            this.tabPlayoutOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // radDesktopAlert1
            // 
            this.radDesktopAlert1.ContentText = "<html><p><span style=\"font-size: 24pt\">Local Scoring <strong>Alert</strong>!</spa" +
    "n></p><p><em>New Game Info ready!</em></p></html>";
            this.radDesktopAlert1.OptionItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "Game 1 Info";
            this.radMenuItem1.AccessibleName = "Game 1 Info";
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Game 1 Info";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.AccessibleDescription = "Game 2 Info";
            this.radMenuItem2.AccessibleName = "Game 2 Info";
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Game 2 Info";
            this.radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // lvPlayListDetail
            // 
            this.lvPlayListDetail.AllowEdit = false;
            this.lvPlayListDetail.AllowRemove = false;
            this.lvPlayListDetail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvPlayListDetail.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.lvPlayListDetail.Location = new System.Drawing.Point(13, 78);
            this.lvPlayListDetail.Name = "lvPlayListDetail";
            // 
            // 
            // 
            this.lvPlayListDetail.RootElement.ControlBounds = new System.Drawing.Rectangle(13, 78, 120, 95);
            this.lvPlayListDetail.ShowCheckBoxes = true;
            this.lvPlayListDetail.ShowColumnHeaders = false;
            this.lvPlayListDetail.Size = new System.Drawing.Size(262, 461);
            this.lvPlayListDetail.TabIndex = 5;
            this.lvPlayListDetail.Text = "lvPlaylistDetail";
            this.lvPlayListDetail.SelectedItemChanged += new System.EventHandler(this.lvPlayListDetail_SelectedItemChanged);
            this.lvPlayListDetail.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvPlayListDetail_ItemCheckedChanged);
            // 
            // lvNotes
            // 
            this.lvNotes.AllowEdit = false;
            this.lvNotes.AllowRemove = false;
            this.lvNotes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvNotes.ItemSpacing = -1;
            this.lvNotes.Location = new System.Drawing.Point(696, 77);
            this.lvNotes.Name = "lvNotes";
            // 
            // 
            // 
            this.lvNotes.RootElement.ControlBounds = new System.Drawing.Rectangle(696, 77, 120, 95);
            this.lvNotes.ShowCheckBoxes = true;
            this.lvNotes.ShowGridLines = true;
            this.lvNotes.Size = new System.Drawing.Size(426, 462);
            this.lvNotes.TabIndex = 6;
            this.lvNotes.Text = "lvPlaylistDetail";
            this.lvNotes.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvNotes.SelectedItemChanged += new System.EventHandler(this.lvNotes_SelectedItemChanged);
            this.lvNotes.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvNotes_ItemCheckedChanged);
            this.lvNotes.Click += new System.EventHandler(this.lvNotes_Click);
            // 
            // lvGames
            // 
            this.lvGames.AllowEdit = false;
            this.lvGames.AllowRemove = false;
            this.lvGames.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvGames.ItemSpacing = -1;
            this.lvGames.Location = new System.Drawing.Point(294, 79);
            this.lvGames.Name = "lvGames";
            // 
            // 
            // 
            this.lvGames.RootElement.ControlBounds = new System.Drawing.Rectangle(294, 79, 120, 95);
            this.lvGames.ShowCheckBoxes = true;
            this.lvGames.ShowGridLines = true;
            this.lvGames.Size = new System.Drawing.Size(380, 460);
            this.lvGames.TabIndex = 7;
            this.lvGames.Text = "lvPlaylistDetail";
            this.lvGames.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvGames.SelectedItemChanged += new System.EventHandler(this.lvGames_SelectedItemChanged);
            this.lvGames.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvGames_ItemCheckedChanged);
            this.lvGames.Click += new System.EventHandler(this.lvGames_Click);
            // 
            // cboPlaylist
            // 
            this.cboPlaylist.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboPlaylist.Location = new System.Drawing.Point(84, 52);
            this.cboPlaylist.Name = "cboPlaylist";
            // 
            // 
            // 
            this.cboPlaylist.RootElement.ControlBounds = new System.Drawing.Rectangle(84, 52, 125, 20);
            this.cboPlaylist.RootElement.StretchVertically = true;
            this.cboPlaylist.Size = new System.Drawing.Size(189, 20);
            this.cboPlaylist.TabIndex = 23;
            this.cboPlaylist.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboPlaylist_SelectedIndexChanged);
            // 
            // cboClient
            // 
            this.cboClient.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboClient.Location = new System.Drawing.Point(325, 14);
            this.cboClient.Name = "cboClient";
            // 
            // 
            // 
            this.cboClient.RootElement.ControlBounds = new System.Drawing.Rectangle(325, 14, 125, 20);
            this.cboClient.RootElement.StretchVertically = true;
            this.cboClient.Size = new System.Drawing.Size(262, 20);
            this.cboClient.TabIndex = 24;
            this.cboClient.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboClient_SelectedIndexChanged);
            // 
            // tabPlayoutOptions
            // 
            this.tabPlayoutOptions.Controls.Add(this.tabPage1);
            this.tabPlayoutOptions.Controls.Add(this.tabPage2);
            this.tabPlayoutOptions.Location = new System.Drawing.Point(13, 546);
            this.tabPlayoutOptions.Margin = new System.Windows.Forms.Padding(2);
            this.tabPlayoutOptions.Name = "tabPlayoutOptions";
            this.tabPlayoutOptions.SelectedIndex = 0;
            this.tabPlayoutOptions.Size = new System.Drawing.Size(1109, 116);
            this.tabPlayoutOptions.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkGamesOnlyFinals);
            this.tabPage1.Controls.Add(this.chkGamesOnlySorted);
            this.tabPage1.Controls.Add(this.btnSponsorRefresh);
            this.tabPage1.Controls.Add(this.cboSponsor);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnIntroRefresh);
            this.tabPage1.Controls.Add(this.cboIntro);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboStartAt);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkScoreAlerts);
            this.tabPage1.Controls.Add(this.chkTrackPlay);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1101, 90);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PLAYOUT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkGamesOnlyFinals
            // 
            this.chkGamesOnlyFinals.AutoSize = true;
            this.chkGamesOnlyFinals.Location = new System.Drawing.Point(531, 33);
            this.chkGamesOnlyFinals.Margin = new System.Windows.Forms.Padding(2);
            this.chkGamesOnlyFinals.Name = "chkGamesOnlyFinals";
            this.chkGamesOnlyFinals.Size = new System.Drawing.Size(116, 17);
            this.chkGamesOnlyFinals.TabIndex = 34;
            this.chkGamesOnlyFinals.Text = "Games: Only Finals";
            this.chkGamesOnlyFinals.UseVisualStyleBackColor = true;
            // 
            // chkGamesOnlySorted
            // 
            this.chkGamesOnlySorted.AutoSize = true;
            this.chkGamesOnlySorted.Location = new System.Drawing.Point(531, 12);
            this.chkGamesOnlySorted.Margin = new System.Windows.Forms.Padding(2);
            this.chkGamesOnlySorted.Name = "chkGamesOnlySorted";
            this.chkGamesOnlySorted.Size = new System.Drawing.Size(120, 17);
            this.chkGamesOnlySorted.TabIndex = 33;
            this.chkGamesOnlySorted.Text = "Games: Only Sorted";
            this.chkGamesOnlySorted.UseVisualStyleBackColor = true;
            // 
            // btnSponsorRefresh
            // 
            this.btnSponsorRefresh.Location = new System.Drawing.Point(295, 37);
            this.btnSponsorRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnSponsorRefresh.Name = "btnSponsorRefresh";
            this.btnSponsorRefresh.Size = new System.Drawing.Size(56, 19);
            this.btnSponsorRefresh.TabIndex = 32;
            this.btnSponsorRefresh.Text = "refresh";
            this.btnSponsorRefresh.UseVisualStyleBackColor = true;
            // 
            // cboSponsor
            // 
            this.cboSponsor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSponsor.FormattingEnabled = true;
            this.cboSponsor.Items.AddRange(new object[] {
            "Top of Playlist",
            "Top of Group",
            "Selected Item"});
            this.cboSponsor.Location = new System.Drawing.Point(67, 37);
            this.cboSponsor.Margin = new System.Windows.Forms.Padding(2);
            this.cboSponsor.Name = "cboSponsor";
            this.cboSponsor.Size = new System.Drawing.Size(224, 21);
            this.cboSponsor.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Sponsor:";
            // 
            // btnIntroRefresh
            // 
            this.btnIntroRefresh.Location = new System.Drawing.Point(295, 13);
            this.btnIntroRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnIntroRefresh.Name = "btnIntroRefresh";
            this.btnIntroRefresh.Size = new System.Drawing.Size(56, 19);
            this.btnIntroRefresh.TabIndex = 29;
            this.btnIntroRefresh.Text = "refresh";
            this.btnIntroRefresh.UseVisualStyleBackColor = true;
            // 
            // cboIntro
            // 
            this.cboIntro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntro.FormattingEnabled = true;
            this.cboIntro.Items.AddRange(new object[] {
            "Top of Playlist",
            "Top of Group",
            "Selected Item"});
            this.cboIntro.Location = new System.Drawing.Point(67, 12);
            this.cboIntro.Margin = new System.Windows.Forms.Padding(2);
            this.cboIntro.Name = "cboIntro";
            this.cboIntro.Size = new System.Drawing.Size(224, 21);
            this.cboIntro.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Intro:";
            // 
            // cboStartAt
            // 
            this.cboStartAt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartAt.FormattingEnabled = true;
            this.cboStartAt.Items.AddRange(new object[] {
            "Top of Playlist",
            "Top of Group",
            "Selected Item",
            "Resume"});
            this.cboStartAt.Location = new System.Drawing.Point(67, 61);
            this.cboStartAt.Margin = new System.Windows.Forms.Padding(2);
            this.cboStartAt.Name = "cboStartAt";
            this.cboStartAt.Size = new System.Drawing.Size(92, 21);
            this.cboStartAt.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Start At:";
            // 
            // chkScoreAlerts
            // 
            this.chkScoreAlerts.AutoSize = true;
            this.chkScoreAlerts.Checked = true;
            this.chkScoreAlerts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScoreAlerts.Location = new System.Drawing.Point(436, 33);
            this.chkScoreAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.chkScoreAlerts.Name = "chkScoreAlerts";
            this.chkScoreAlerts.Size = new System.Drawing.Size(83, 17);
            this.chkScoreAlerts.TabIndex = 24;
            this.chkScoreAlerts.Text = "Score Alerts";
            this.chkScoreAlerts.UseVisualStyleBackColor = true;
            // 
            // chkTrackPlay
            // 
            this.chkTrackPlay.AutoSize = true;
            this.chkTrackPlay.Checked = true;
            this.chkTrackPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackPlay.Location = new System.Drawing.Point(436, 12);
            this.chkTrackPlay.Margin = new System.Windows.Forms.Padding(2);
            this.chkTrackPlay.Name = "chkTrackPlay";
            this.chkTrackPlay.Size = new System.Drawing.Size(77, 17);
            this.chkTrackPlay.TabIndex = 23;
            this.chkTrackPlay.Text = "Track Play";
            this.chkTrackPlay.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCSSLog);
            this.tabPage2.Controls.Add(this.lblCSSStatus);
            this.tabPage2.Controls.Add(this.btnCSSConnect);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1101, 90);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CSS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCSSLog
            // 
            this.lblCSSLog.AutoSize = true;
            this.lblCSSLog.Location = new System.Drawing.Point(42, 67);
            this.lblCSSLog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCSSLog.Name = "lblCSSLog";
            this.lblCSSLog.Size = new System.Drawing.Size(13, 13);
            this.lblCSSLog.TabIndex = 2;
            this.lblCSSLog.Text = "--";
            // 
            // lblCSSStatus
            // 
            this.lblCSSStatus.AutoSize = true;
            this.lblCSSStatus.ForeColor = System.Drawing.Color.Red;
            this.lblCSSStatus.Location = new System.Drawing.Point(42, 49);
            this.lblCSSStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCSSStatus.Name = "lblCSSStatus";
            this.lblCSSStatus.Size = new System.Drawing.Size(73, 13);
            this.lblCSSStatus.TabIndex = 1;
            this.lblCSSStatus.Text = "Disconnected";
            // 
            // btnCSSConnect
            // 
            this.btnCSSConnect.Location = new System.Drawing.Point(7, 7);
            this.btnCSSConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnCSSConnect.Name = "btnCSSConnect";
            this.btnCSSConnect.Size = new System.Drawing.Size(85, 32);
            this.btnCSSConnect.TabIndex = 0;
            this.btnCSSConnect.Text = "Connect";
            this.btnCSSConnect.UseVisualStyleBackColor = true;
            this.btnCSSConnect.Click += new System.EventHandler(this.btnCSSConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "PLAYLIST:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1032, 14);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(77, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "version 0.0.0.0";
            this.lblVersion.DoubleClick += new System.EventHandler(this.lblVersion_DoubleClick);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(16)))));
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(294, 55);
            this.lblSelected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 13);
            this.lblSelected.TabIndex = 28;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::Ticker.Properties.Resources.FOX_TICKER;
            this.pbLogo.Location = new System.Drawing.Point(13, 6);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(141, 40);
            this.pbLogo.TabIndex = 27;
            this.pbLogo.TabStop = false;
            this.pbLogo.DoubleClick += new System.EventHandler(this.pbLogo_DoubleClick);
            // 
            // cmdStop
            // 
            this.cmdStop.Image = global::Ticker.Properties.Resources.stop2_48x48;
            this.cmdStop.Location = new System.Drawing.Point(223, 2);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(48, 46);
            this.cmdStop.TabIndex = 10;
            this.cmdStop.TabStop = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Image = global::Ticker.Properties.Resources.Play;
            this.cmdPlay.Location = new System.Drawing.Point(169, 2);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(48, 46);
            this.cmdPlay.TabIndex = 9;
            this.cmdPlay.TabStop = false;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // cmdGamesToggle
            // 
            this.cmdGamesToggle.Location = new System.Drawing.Point(612, 52);
            this.cmdGamesToggle.Margin = new System.Windows.Forms.Padding(2);
            this.cmdGamesToggle.Name = "cmdGamesToggle";
            this.cmdGamesToggle.Size = new System.Drawing.Size(62, 22);
            this.cmdGamesToggle.TabIndex = 31;
            this.cmdGamesToggle.Text = "To&ggle All";
            this.cmdGamesToggle.UseVisualStyleBackColor = true;
            this.cmdGamesToggle.Click += new System.EventHandler(this.cmdGamesToggle_Click);
            // 
            // cmdNotesToggle
            // 
            this.cmdNotesToggle.Location = new System.Drawing.Point(1059, 50);
            this.cmdNotesToggle.Margin = new System.Windows.Forms.Padding(2);
            this.cmdNotesToggle.Name = "cmdNotesToggle";
            this.cmdNotesToggle.Size = new System.Drawing.Size(63, 22);
            this.cmdNotesToggle.TabIndex = 32;
            this.cmdNotesToggle.Text = "Toggle &All";
            this.cmdNotesToggle.UseVisualStyleBackColor = true;
            this.cmdNotesToggle.Click += new System.EventHandler(this.cmdNotesToggle_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1132, 670);
            this.Controls.Add(this.cmdNotesToggle);
            this.Controls.Add(this.cmdGamesToggle);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabPlayoutOptions);
            this.Controls.Add(this.cboClient);
            this.Controls.Add(this.cboPlaylist);
            this.Controls.Add(this.lvGames);
            this.Controls.Add(this.lvNotes);
            this.Controls.Add(this.lvPlayListDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvPlayListDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).EndInit();
            this.tabPlayoutOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDesktopAlert radDesktopAlert1;
        private Telerik.WinControls.UI.RadListView lvPlayListDetail;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadListView lvNotes;
        private System.Windows.Forms.PictureBox cmdPlay;
        private System.Windows.Forms.PictureBox cmdStop;
        private Telerik.WinControls.UI.RadListView lvGames;
        private Telerik.WinControls.UI.RadDropDownList cboPlaylist;
        private Telerik.WinControls.UI.RadDropDownList cboClient;
        private System.Windows.Forms.TabControl tabPlayoutOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSponsorRefresh;
        private System.Windows.Forms.ComboBox cboSponsor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIntroRefresh;
        private System.Windows.Forms.ComboBox cboIntro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStartAt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkScoreAlerts;
        private System.Windows.Forms.CheckBox chkTrackPlay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.CheckBox chkGamesOnlyFinals;
        private System.Windows.Forms.CheckBox chkGamesOnlySorted;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblCSSLog;
        private System.Windows.Forms.Label lblCSSStatus;
        private System.Windows.Forms.Button btnCSSConnect;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button cmdGamesToggle;
        private System.Windows.Forms.Button cmdNotesToggle;
    }
}

