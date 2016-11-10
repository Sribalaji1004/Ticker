using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FOXTickerDataEngine;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NLog;
using Telerik.WinControls.UI;
using Ticker.Data;
using VentuzRemoting;

namespace Ticker
{
    public partial class Mainform : Form
    {
        Logger logger = LogManager.GetLogger("Ticker");
        FoxTickerEntities db;// = new FoxTickerEntities();
        //System.Data.Objects.ObjectContext objectContext;
        SceneFOX TickerScene;
        TickerCSS css;

        //Lists of lists to ommit
        //List<GroupObject> groupsOmitted = new List<GroupObject>();
        List<PlaylistObject> playlistsOmitted = new List<PlaylistObject>();
        PlaylistObject oPlaylist = null;
        List<spTICK_Games_GetByEntryID_Result> curGames;

        bool bFirstTimeRun = false;

        bool bIntroRun = false;

        bool bTransition = false;

        System.Threading.Timer tmrPlayNext, tmrUIRefresh, tmrDMSNote;

        //private NotifyIcon trayIcon;
        //private ContextMenu trayMenu;


        //protected override void OnLoad(EventArgs e)
        //{
        //    Visible = false; // Hide form window.
        //    ShowInTaskbar = false; // Remove from taskbar.

        //    base.OnLoad(e);
        //}

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //protected override void Dispose(bool isDisposing)
        //{
        //    if (isDisposing)
        //    {
        //        // Release the icon resource.
        //        trayIcon.Dispose();
        //    }

        //    base.Dispose(isDisposing);
        //}
        HubConnection hubConnection;
        IHubProxy ticker;
        public Mainform()
        {
            // Create a simple tray menu with only one item.
            //trayMenu = new ContextMenu();
            //trayMenu.MenuItems.Add("Exit", OnExit);

            //// Create a tray icon. In this example we use a
            //// standard system icon for simplicity, but you
            //// can of course use your own custom icon too.
            //trayIcon = new NotifyIcon();
            //trayIcon.Text = "Ticker";
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            //trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));//new Icon(SystemIcons.Application, 40, 40);

            //// Add menu to tray icon and show it.
            //trayIcon.ContextMenu = trayMenu;
            //trayIcon.Visible = true;

            logger.Trace("Mainform - launch");
            InitializeComponent();
            logger.Trace("Mainform - InitializeComponent");
            db = new FoxTickerEntities();
            if (db.Connection.State == ConnectionState.Closed)
                db.Connection.Open();
            logger.Trace("Mainform - db = new FoxTickerEntities()");
            css = new TickerCSS(CSS_ClockTick);
            logger.Trace("Mainform - css = new TickerCSS()");

            //#if !DEBUG
            TickerScene = new SceneFOX(VZ_Callback);
            TickerScene.Initialize("C:\\Fox Ticker\\Clients\\FSN\\Ventuz\\Director.vzd");
            logger.Trace("Mainform - TickerScene.Initialize");
            //#endif

            tmrPlayNext = new System.Threading.Timer(new System.Threading.TimerCallback(tmrPlayNext_Tick), null, 400000000, 400000000);
            tmrDMSNote = new System.Threading.Timer(new System.Threading.TimerCallback(tmrDMSNote_Tick), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            Timer_Stop();
            logger.Trace("Mainform - tmrPlayNext new/timer_stop");

            // Connect to the service
            hubConnection = new HubConnection("http://localhost:54291/signalr/hubs");

            // Create a proxy to the ticker service
            ticker = hubConnection.CreateHubProxy("tickerHub");

            Action<int> tickerPlayAction;
            tickerPlayAction = (playlistID) => Play(playlistID);
            ticker.On("broadcastMessage", tickerPlayAction);

            // Start the connection
            hubConnection.Start().Wait();


        }
        void Play(int playlistID)
        {
            //oPlaylist.SelectedValue = playlistID;
            cmdPlay_Click(new object(), new EventArgs());
        }

        bool bVZCallbackInProgress = false;
        void VZ_Callback(object sender, VentuzArgs eventName)
        {
            tmrDMSNote.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite); //disable
            if (bScoreAlertPlaying || bVZCallbackInProgress) return;
            if (bBlankNote)
            {
                bVZCallbackInProgress = true;
                Timer_Stop();
                //PlayNextObject();
                Timer_Start(400);
                bVZCallbackInProgress = false;
                return;
            }

            switch (eventName.message)
            {
                case "/GAMENEXT_COMPLETE":
                    //if (oPlaylist.game != null)
                    //{
                    bVZCallbackInProgress = true;
                    Timer_Stop();
                    PlayNextObject();
                    //}
                    //bTimetoPlayNextObject = true;
                    break;
                case "/INTRO_COMPLETE":
                    bVZCallbackInProgress = true;
                    Timer_Stop();
                    PlayNextObject();
                    //bTimetoPlayNextObject = true;
                    break;
                case "/NOTE_COMPLETE":
                    bVZCallbackInProgress = true;
                    Timer_Stop();
                    if (!bBlankNote)
                    {
                        PlayNextObject();
                    }
                    //bTimetoPlayNextObject = true;
                    break;
                case "/GAMEIN_COMPLETE": // Backplate done.
                    bVZCallbackInProgress = true;
                    Timer_Stop();
                    PlayNextObject();
                    //bTimetoPlayNextObject = true;
                    break;
            }
            bVZCallbackInProgress = false;
            //Timer_Start(0);
            //MessageBox.Show(eventName.message);
        }
        //class Options
        //{
        //    [Option("c", "clientid", DefaultValue = 10, HelpText = "ClientID")]
        //    public int ClientID { get; set; }

        //    [Option("cli", "clientname", DefaultValue = 10, HelpText = "Client Name (Abbreviation")]
        //    public string ClientName { get; set; }
        //}

        void SetcboClient(int ClientID)
        {
            foreach (RadListDataItem item in cboClient.Items)
            {
                if (int.Parse(item.Value.ToString()) == ClientID)
                {
                    cboClient.SelectedItem = item;
                    return;
                }
            }
        }
        //void SetcboClient(string ClientName)
        //{
        //    foreach (RadListDataItem item in cboClient.Items)
        //    {
        //        if (item.Text == ClientName)
        //        {
        //            cboClient.SelectedItem = item;
        //            return;
        //        }
        //    }
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "VERSION " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            logger.Trace("Mainform - MainForm_Load");
            cboStartAt.SelectedIndex = 0;
            btnIntroRefresh_Click(null, null);
            btnSponsorRefresh_Click(null, null);
            logger.Trace("Mainform - cbo/btn refreshes");

            cboClient.DataSource = db.Clients.ToList();
            cboClient.ValueMember = "ID";
            cboClient.DisplayMember = "Abbreviation";
            logger.Trace("Mainform - cboClient set");
#if DEBUG
            cboClient.Items[15].Selected = true;
#else

            logger.Trace("Mainform - Args Count (including exe)" + Environment.GetCommandLineArgs().Count());
            if (Environment.GetCommandLineArgs().Count() > 1)
            {

                cboClient.Visible = false;
                logger.Trace("Mainform - Arg 1:" + Environment.GetCommandLineArgs()[1]);
                //if (Environment.GetCommandLineArgs()[1] != "")
                SetcboClient(int.Parse(Environment.GetCommandLineArgs()[1]));

                //cboPlaylist.Location = cboClient.Location;

                //cboPlaylist.Width = 180;
                //lvPlayListDetail.Width = 180;

                //lvPlayListDetail.Left = 213;
            }

            cboPlaylist.Items[0].Selected = true;
            //cboPlaylist.ShowDropDown();
            //cboPlaylist_SelectedIndexChanged(new object(), new Telerik.WinControls.UI.Data.PositionChangedEventArgs(0));

            logger.Trace("Mainform - cboPlaylist_SelectedIndexChanged");
            //Options o = new Options();
            //ICommandLineParser parser = new CommandLineParser();
            //if (parser.ParseArguments(Environment.GetCommandLineArgs(), o))
            //{
            //    if (o.ClientID != 0)
            //        SetcboClient(o.ClientID);

            //    if (o.ClientName != null)
            //        SetcboClient(o.ClientName);
            //}
#endif



            lvNotes.Columns.Add("Note", "Note");
            lvNotes.Columns["Note"].Width = lvNotes.Width - 20;

            lvGames.Columns.Add("GameList", "Game List");
            lvGames.Columns.Add("V", "V");
            lvGames.Columns.Add("H", "H");
            lvGames.Columns.Add("Status", "Status");
            lvGames.Columns.Add("Clock", "Clock");

            lvGames.Columns["GameList"].Width = lvNotes.Width / 5;
            lvGames.Columns["V"].Width = lvNotes.Width / 8;
            lvGames.Columns["H"].Width = lvNotes.Width / 8;
            lvGames.Columns["Status"].Width = lvNotes.Width / 5;
            lvGames.Columns["Clock"].Width = lvNotes.Width / 5;

            //lvNotes.Columns.Add("Header", "Header");
            //lvNotes.Columns.Add("Status", "Status");

            cboStartAt.SelectedIndex = 2; //set Selected Item as default

            tmrUIRefresh = new System.Threading.Timer(new System.Threading.TimerCallback(tmrUIRefresh_Tick), null, 0, 1000);

            logger.Trace("Mainform - UI complete- tmrUIRefresh new");
        }

        private void cboClient_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RefreshPlaylist();
        }

        Group curGroup;
        private void cmdStop_Click(object sender, EventArgs e)
        {
            logger.Trace("cmdStop");
            bPlaying = false;
            bPlayingNextObject = false;
            bFirstTimeRun = false;
            bIntroRun = false;
            bStopped = true;
            //tmrPlayNextObject.Enabled = false;
            cmdStop.Image = global::Ticker.Properties.Resources.stop2_48x48;
            cmdPlay.Image = global::Ticker.Properties.Resources.Play;
            TickerScene.Ticker_Retract();
            css.CurrentGame = null; // don't use CSS if off.
            Timer_Stop();
            //tmrPlayNextObject.Enabled = false;

            //if (cboStartAt.SelectedItem.ToString() == "Selected Item")
            //{
            //    //lviCurrent = lvGames.SelectedItem;
            //    lastActiveControl = lvGames;
            //    SetLastActiveControl();
            //}
        }

        bool bPlaying = false;
        private void cmdPlay_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
{

    if (bPlaying)
    {
        MessageBox.Show("Playback already in progress.");
        return;
    }

    //apply omitted playlist details if playlist has them
    switch (cboStartAt.SelectedItem.ToString())
    {
        case "Top of Playlist": //default
            LoadPlaylist();
            break;
        case "Resume":
            break;
        case "Top of Group":
            LoadPlaylist();
            break;
        case "Selected Item":
            if (lastActiveControl == null)
            {
                MessageBox.Show("No selection found. Please select a group, note or game.");
                cmdStop_Click(sender, e);
                return;
            }
            if (lvPlayListDetail.SelectedItem.CheckState != Telerik.WinControls.Enumerations.ToggleState.On)
            {
                MessageBox.Show("Please select a group, note or game that is checked.");
                cmdStop_Click(sender, e);
                return;
            }
            if (lastActiveControl.GetType().Name == "RadListView")
                if (((RadListView)lastActiveControl).SelectedItem == null)
                {
                    MessageBox.Show("Please select a group, note or game that is checked.");
                    cmdStop_Click(sender, e);
                    return;
                }
                else if (((RadListView)lastActiveControl).SelectedItem.CheckState != Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    MessageBox.Show("Please select a group, note or game that is checked.");
                    cmdStop_Click(sender, e);
                    return;
                }

            if (lastActiveControl.Name == "lvGames")
            {
                int ID = ((spTICK_Games_GetByEntryID_Result)lvGames.SelectedItem.Tag).ID;
                int playlistID = int.Parse(cboPlaylist.SelectedValue.ToString());
                int entryID = (int)lvPlayListDetail.SelectedItem.Key;
                if (oPlaylist.playlistdetailsOmissions.Count() > 0)
                    if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).Count() > 0)
                        if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Count > 0)
                            if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Where(gow => gow.ID == playlistID).Count() == 0)
                            {
                                MessageBox.Show("Please select a group, note or game that is checked.");
                                cmdStop_Click(sender, e);
                                return;
                            }
            }
            LoadPlaylist();
            break;

    }

    logger.Trace("cmdPlay");
    bPlaying = true;
    bStopped = false;
    lvGames.SelectedItem = null;
    lvNotes.SelectedItem = null;
    TickerScene.CurrentTab = "";
    bFirstTimeRun = true;

    cmdStop.Image = global::Ticker.Properties.Resources.stop_48x48;
    cmdPlay.Image = global::Ticker.Properties.Resources.play_48x48;

    PlayNextObject();
});
            //tmrPlayNextObject.Enabled = true;


            //// Get first note and pass it into Insert call so scene can handle.
            //foreach (ListViewDataItem lvi in lvPlayListDetail.Items)
            //{
            //    if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
            //    {
            //        Group g = (Group)lvi.Tag;
            //        switch (lvi.Tag.GetType().BaseType.Name)
            //        {
            //            case "Group":
            //                List<spTICK_Notes_GetByGroup_Result> lngbg = db.spTICK_Notes_GetByGroup(g.ID, g.ClientID).ToList();

            //                foreach (spTICK_Notes_GetByGroup_Result note in lngbg)
            //                {
            //                    //skip notes that are unchecked
            //                    ListViewDataItem testNote = lvNotes.FindItemByKey(note);
            //                    if (testNote != null)
            //                        if (testNote.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
            //                            continue;

            //                    if (note.GroupID == g.ID)
            //                    {
            //                        TickerScene.Ticker_Insert("C:\\Fox Ticker\\Clients\\FSN\\Ventuz\\Movies\\Intro\\NFL.COM.avi", "C:\\Fox Ticker\\Clients\\FSN\\Elements\\Sponsors\\TF-MLBonFOX.tga", note, g.OnAirName);

            //                        System.Threading.Thread.Sleep(4000); //sleep for 4 seconds

            //                        tmrPlayNextObject.Enabled = true;
            //                        return;
            //                    }
            //                }
            //                break;
            //        }
            //    }
            //}
        }

        private void LoadPlaylist()
        {
            if (playlistsOmitted.Where(pow => pow.ID == oPlaylist.ID).Count() > 0)
                oPlaylist.playlistdetailsOmitted = playlistsOmitted.Where(pow => pow.ID == oPlaylist.ID).FirstOrDefault().playlistdetailsOmitted;
            oPlaylist.Load(oPlaylist.ID);
        }

        private void cboPlaylist_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            RefreshPlaylistDetail(AutoRefresh: false);
            //ProcessNotes();

            Cursor = Cursors.Default;
        }

        int UIRefreshCountdown = 60;// every 30 seconds
        private void tmrUIRefresh_Tick(object obj)//runs every 500 miliseconds (twice a second)
        {
            //#if !DEBUG
            UIRefreshCountdown--;
            if (UIRefreshCountdown == 0)
            {
                if (!bPlayingNextObject)
                    RefreshPlaylist();
                UIRefreshCountdown = 60;
            }
            if (!bPlayingNextObject)
                RefreshPlaylistDetail();
            //#endif
        }

        bool bRefreshing = false;
        private void RefreshPlaylistDetail(bool AutoRefresh = true)
        {
            if (bPlayingNextObject) return;

            if (AutoRefresh)
                bRefreshing = true;

            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    if (db.Connection.State == ConnectionState.Closed)
                        db.Connection.Open();

                    int curiPLD = lvPlayListDetail.SelectedIndex;
                    int curiGames = lvGames.SelectedIndex;
                    int curiNotes = lvNotes.SelectedIndex;

                    Point asoPLD = lvPlayListDetail.AutoScrollOffset;
                    Point asoGames = lvGames.AutoScrollOffset;
                    Point asoNotes = lvNotes.AutoScrollOffset;

                    Point aspPLD = lvPlayListDetail.AutoScrollPosition;
                    Point aspGames = lvGames.AutoScrollPosition;
                    Point aspNotes = lvNotes.AutoScrollPosition;


                    //curGames = new List<spTICK_Games_GetByEntryID_Result>();
                    try
                    {

                        if (cboPlaylist.SelectedValue != null)
                            if (!cboPlaylist.SelectedValue.GetType().Equals(typeof(Playlist)))
                            {
                                int counter = 0;
                                int playlistID = int.Parse(cboPlaylist.SelectedValue.ToString());
                                //if (db.Database.Connection.State == ConnectionState.Closed)
                                //    db.Database.Connection.Open();
                                IOrderedEnumerable<spTICK_Playlist_Details_Get_Result> pldg = db.spTICK_Playlist_Details_Get(playlistID).OrderBy(pldo => pldo.SortOrder);
                                if (pldg != null)
                                {

                                    List<spTICK_Playlist_Details_Get_Result> lpld = pldg.ToList();
                                    List<spTICK_Playlist_Details_Get_Result> lopld = new List<spTICK_Playlist_Details_Get_Result>();
                                    //objectContext.Refresh(System.Data.Objects.RefreshMode.StoreWins, lpld);


                                    try
                                    {
                                        //save current playlistOmitted
                                        if (playlistsOmitted.Where(pldow => pldow.ID == oPlaylist.ID).Count() > 0) //remove old instance
                                            playlistsOmitted.Remove(playlistsOmitted.Where(pldow => pldow.ID == oPlaylist.ID).First());
                                    }
                                    catch (Exception ex)
                                    {
                                        logger.Trace("RefrehsPlaylistDetail1 - " + ex.Message);
                                    }


                                    try
                                    {
                                        if (oPlaylist != null)
                                            playlistsOmitted.Add(oPlaylist);
                                    }
                                    catch (Exception ex)
                                    {
                                        logger.Trace("RefrehsPlaylistDetail2 - " + ex.Message);
                                    }


                                    try
                                    {
                                        if (playlistsOmitted.Where(pldow => pldow.ID == playlistID).Count() > 0)
                                        {
                                            oPlaylist = playlistsOmitted.Where(pldow => pldow.ID == playlistID).First();
                                            //if (playlistOmitted.PlaylistDetails != null)
                                            lopld = oPlaylist.playlistdetailsOmitted;
                                        }
                                        else
                                        {
                                            oPlaylist = new PlaylistObject();
                                            oPlaylist.ID = playlistID;
                                            //oPlaylist.playlistdetailsOmitted = new List<spTICK_Playlist_Details_Get_Result>();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        logger.Trace("RefrehsPlaylistDetail3 - " + ex.Message);
                                    }



                                    int ID;
                                    //foreach (spTICK_Playlist_Details_Get_Result pld in lpld.Except(lopld))
                                    lvPlayListDetail.BeginUpdate();
                                    lvPlayListDetail.Items.Clear();

                                    lvGames.BeginUpdate();
                                    lvGames.Items.Clear();
                                    //lvNotes.BeginUpdate();

                                    foreach (spTICK_Playlist_Details_Get_Result pld in lpld)
                                    {
                                        ListViewDataItem lvi = new ListViewDataItem();
                                        switch (pld.EntryTypeID)
                                        {
                                            case 1: //A group.  The GroupID is defined in the EntryID field.
                                                IQueryable<Group> grp = db.Groups.Where(g => g.ID == pld.EntryID);
                                                List<Group> groups = grp.ToList();
                                                //System.Data.Objects.ObjectContext objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
                                                //objectContext.Refresh(System.Data.Objects.RefreshMode.StoreWins, groups);

                                                db.Refresh(System.Data.Objects.RefreshMode.StoreWins, groups);
                                                try
                                                {
                                                    if (groups != null)
                                                        if (groups.Count() > 0)
                                                        {
                                                            lvi.Key = pld.PlaylistDetailsID;
                                                            lvi.Tag = pld;// 
                                                            Group group = groups.First();
                                                            // Group group = ((Group)lvi.Tag);
                                                            ID = pld.EntryID;
                                                            lvi.Text = group.Name;

                                                            //if (groupsOmitted.Where(gow => gow.group.ID == group.ID).Count() == 0)
                                                            if (lopld.Where(lopldw => lopldw.PlaylistDetailsID == pld.PlaylistDetailsID).Count() == 0)
                                                                lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                                            lvPlayListDetail.Items.Add(lvi);

                                                            //val = int.Parse(cboPlaylist.SelectedValue.ToString());
                                                            //List<Game> g = db.Games.Where(gw => gw.ID == val).ToList();

                                                        }
                                                }
                                                catch (Exception ex)
                                                {
                                                    logger.Trace("RefrehsPlaylistDetail - group - " + ex.Message);
                                                }


                                                break;
                                            case 2: //A singular game.  The GameID is defined in the EntryID field
                                                //List<Game> games = db.Games.Where(g => g.ID == pld.EntryID).ToList();
                                                //if (games.Count() > 0)
                                                //{
                                                //    Game game = games.First();
                                                //    ID = pld.PlaylistDetailsID;
                                                //    //if (lopld.Where(lopldw => lopldw.EntryID == ID).Count() == 0)
                                                //    //    lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

                                                //    string gameText = "";
                                                //    if (game.Header != null)
                                                //        gameText = game.Header;
                                                //    else if (game.ScoreDescription != "")
                                                //        gameText = game.ScoreDescription;
                                                //    else
                                                //        gameText = game.ScoreDescriptionAlt;

                                                //    Telerik.WinControls.Enumerations.ToggleState chk = Telerik.WinControls.Enumerations.ToggleState.On;

                                                //    if (oPlaylist.OmissionsExist(ID))
                                                //    {
                                                //        List<GameObject> loGame = oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == ID).First().gamesOmitted.Where(gow => gow.ID == ID).ToList();
                                                //        if (loGame.Count() > 0)
                                                //            if (loGame.First().GamesOmitted.Where(lgow => lgow.ID == game.ID).Count() > 0)
                                                //                chk = Telerik.WinControls.Enumerations.ToggleState.Off;
                                                //    }


                                                //    var itemName = String.Format("listItem{0}", counter++);
                                                //    var values = new string[] { gameText, game.VisitorsScore.ToString(), game.HomeScore.ToString(), db.Statuses.Where(sw => sw.ID == game.StatusID).FirstOrDefault().Description, game.Clock };
                                                //    var nlvi = new Telerik.WinControls.UI.ListViewDataItem(itemName, values) { Tag = game, CheckState = chk, Text = gameText };
                                                //    lvGames.Items.Add(nlvi);
                                                //}
                                                try
                                                {
                                                    lvi.Tag = pld;
                                                    lvi.Key = pld.PlaylistDetailsID;
                                                    ID = pld.EntryID;
                                                    lvi.Text = pld.Name;
                                                    //lvi.Value = pld.EntryID;
                                                    if (lopld.Where(lopldw => lopldw.PlaylistDetailsID == pld.PlaylistDetailsID).Count() == 0)
                                                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                                    lvPlayListDetail.Items.Add(lvi);
                                                }
                                                catch (Exception ex)
                                                {
                                                    logger.Trace("RefrehsPlaylistDetail - game - " + ex.Message);
                                                }


                                                break;
                                            case 3: //All games for a given sport for today.  The sport is defined in the EntryID field.
                                                try
                                                {
                                                    lvi.Tag = pld;
                                                    lvi.Key = pld.PlaylistDetailsID;
                                                    ID = pld.EntryID;
                                                    lvi.Text = pld.Name;
                                                    //lvi.Value = pld.EntryID;
                                                    if (lopld.Where(lopldw => lopldw.PlaylistDetailsID == pld.PlaylistDetailsID).Count() == 0)
                                                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                                    lvPlayListDetail.Items.Add(lvi);
                                                }
                                                catch (Exception ex)
                                                {
                                                    logger.Trace("RefrehsPlaylistDetail - games - " + ex.Message);
                                                }



                                                break;
                                            case 4: //All games for a given sport prior to today.  The sport is defined in the EntryID field.
                                                try
                                                {
                                                    lvi.Tag = pld;
                                                    lvi.Key = pld.PlaylistDetailsID;
                                                    ID = pld.EntryID;
                                                    lvi.Text = pld.Name;
                                                    //lvi.Value = pld.EntryID;
                                                    if (lopld.Where(lopldw => lopldw.PlaylistDetailsID == pld.PlaylistDetailsID).Count() == 0)
                                                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                                    lvPlayListDetail.Items.Add(lvi);
                                                }
                                                catch (Exception ex)
                                                {
                                                    logger.Trace("RefrehsPlaylistDetail - all games - " + ex.Message);
                                                }

                                                break;
                                            case 5: //Ads
                                                break;
                                        }
                                    }
                                    //lvPlayListDetail.EndUpdate();
                                }

                                //set back or
                                //set to top
                                lvPlayListDetail.EndUpdate();
                                //lvPlayListDetail_SelectedItemChanged(new object(), new EventArgs());

                                try
                                {
                                    if (curiPLD != -1)
                                    {
                                        lvPlayListDetail.SelectedIndex = curiPLD;
                                        lvPlayListDetail.AutoScrollPosition = aspPLD;
                                        lvPlayListDetail.AutoScrollOffset = asoPLD;
                                    }
                                    else
                                        if (lvPlayListDetail.Items.Count > 0)
                                        {
                                            lvPlayListDetail.SelectedIndex = 0;
                                            lvPlayListDetail.AutoScrollPosition = aspPLD;
                                            lvPlayListDetail.AutoScrollOffset = asoPLD;
                                        }

                                    lvGames.EndUpdate();
                                    if (curiGames != -1)
                                    {
                                        lvGames.SelectedIndex = curiGames;
                                        lvGames.AutoScrollPosition = aspGames;
                                        lvGames.AutoScrollOffset = asoGames;
                                    }

                                    //else
                                    //    if (lvGames.Items.Count > 0)
                                    //        lvGames.SelectedIndex = 0;

                                    lvNotes.EndUpdate();
                                    if (curiNotes != -1)
                                    {
                                        lvNotes.SelectedIndex = curiNotes;
                                        lvNotes.AutoScrollPosition = aspNotes;
                                        lvNotes.AutoScrollOffset = asoNotes;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    logger.Trace("RefrehsPlaylistDetail - reselecting - " + ex.Message);
                                }

                            }
                    }
                    catch (Exception ex)
                    {
                        logger.Trace("RefrehsPlaylistDetail - " + ex.Message);
                    }

                    //else
                    //if (lvNotes.Items.Count > 0)
                    //    lvNotes.SelectedIndex = 0;

                    //if (lvPlayListDetail.Items.Count > 0)
                    //    lvPlayListDetail.SelectedIndex = 0;

                });

            }
            catch (Exception ex)
            {
                logger.Trace("RefrehsPlaylistDetail - Invoker - " + ex.Message);
            }

            if (AutoRefresh)
                bRefreshing = false;


        }

        private void RefreshPlaylist()
        {
            bRefreshing = true;

            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    if (cboClient.SelectedItem != null)
                        if (cboClient.SelectedValue.GetType().Name != "Client")
                        {
                            int curPlaylist = (int)cboPlaylist.SelectedIndex;
                            int clientID = int.Parse(cboClient.SelectedValue.ToString());
                            IQueryable<Playlist> dpl = db.Playlists.Where(pl => pl.ClientID == clientID).OrderBy(plo => plo.Name);
                            if (dpl == null)
                                cboPlaylist.DataSource = new DataTable();
                            else if (dpl.Count() > 0)
                            {
                                List<Playlist> pld = dpl.ToList();
                                //System.Data.Objects.ObjectContext objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
                                //objectContext.Refresh(System.Data.Objects.RefreshMode.StoreWins, pld);
                                db.Refresh(System.Data.Objects.RefreshMode.StoreWins, pld);

                                cboPlaylist.DataSource = pld;
                            }
                            else
                                cboPlaylist.DataSource = new DataTable();
                            cboPlaylist.DisplayMember = "Name";
                            cboPlaylist.ValueMember = "ID";

                            cboPlaylist.SelectedIndex = curPlaylist;
                        }
                });
            }
            catch (Exception ex)
            {
                logger.Trace("RefreshPlaylist - " + ex.Message);
            }

            bRefreshing = false;
        }

        private void lvPlayListDetail_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem lvi = (ListViewDataItem)e.Item;
            PlaylistObject po;
            int clientID = int.Parse(cboClient.SelectedValue.ToString());
            int entryID = (int)lvi.Key;
            int playlistID = (int)cboPlaylist.SelectedItem.Value;
            //switch (lvi.Tag.GetType().BaseType.Name)
            //{
            //    case "Group": //A group.  The GroupID is defined in the EntryID field.
            //        ID = db.Groups.Where(g => g.ID == ID).First().ID;//(int)lvi.Tag;//((Group)lvi.Tag).ID;
            //        break;
            //    case "spTICK_Games_GetByEntryID_Result":
            //        //ID = ((spTICK_Games_GetByEntryID_Result)lvi.Tag).ID;
            //        break;
            //}
            //int playlistID = int.Parse(cboPlaylist.SelectedValue.ToString());

            if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                if (!oPlaylist.OmissionsExist(entryID))
                {
                    oPlaylist.CreateOmission(entryID);
                    CreatePlaylistDetailsOmitted(entryID, playlistID);
                }
                else
                {
                    if (oPlaylist.playlistdetailsOmitted.Where(pldow => pldow.PlaylistDetailsID == entryID).Count() == 0)
                    {
                        //po = new PlaylistObject();

                        //po.ID = playlistID;
                        //po.playlistdetailsOmitted = new List<spTICK_Playlist_Details_Get_Result>();

                        CreatePlaylistDetailsOmitted(entryID, playlistID);
                        //playlistsOmitted.Add(po);
                        //po.Load(pld.ID);
                    }
                    //else
                    //{
                    //    //po = playlistsOmitted.Where(pldow => pldow.ID == playlistID).First();

                    //    if (po.playlistdetailsOmitted.Where(pldw => pldw.EntryID == entryID).Count() == 0)
                    //    {
                    //        List<spTICK_Playlist_Details_Get_Result> pld = db.spTICK_Playlist_Details_Get(playlistID).Where(pldw => pldw.PlaylistDetailsID == entryID).ToList();
                    //        if (pld.Count() > 0)
                    //            po.playlistdetailsOmitted.Add(pld.First());
                    //    }
                    //}
                    //}
                    //}
                }
            }
            else //user re-checking box
            {
                //po = oPlaylist.playlistdetailsOmitted.Where(pldow => pldow.PlaylistDetailsID == entryID).First();

                //if (po.playlistdetailsOmitted.Where(pldw => pldw.EntryID == entryID).Count() > 0)
                //{
                if (oPlaylist.playlistdetailsOmitted.Where(pldow => pldow.PlaylistDetailsID == entryID).Count() > 0)
                {
                    spTICK_Playlist_Details_Get_Result pld = oPlaylist.playlistdetailsOmitted.Where(pldow => pldow.PlaylistDetailsID == entryID).First();
                    oPlaylist.playlistdetailsOmitted.Remove(pld);
                }
                //}

            }


            //NoteObject no;
            // switch (lvi.Tag.GetType().BaseType.Name)
            //        {
            //     case "Group":
            //                 int groupID = ((Group)lvi.Tag).ID;
            //                int clientID = int.Parse(cboClient.SelectedValue.ToString());
            //                if (notesOmitted.Where(now => now.groupID == groupID && now.clientID == clientID).Count() == 0)
            //                {
            //                    no = new NoteObject();
            //                    no.LoadGroup(groupID,clientID);
            //                }
            //                else
            //                    no = notesOmitted.Where(now => now.groupID == groupID && now.clientID == clientID).First();

            //         if (no.groupNotes.Where(gnw => gnw.
            //         no.groupNotes.a
            //         break;
            //}
        }

        private void CreatePlaylistDetailsOmitted(int entryID, int playlistID)
        {
            spTICK_Playlist_Details_Get_Result pld = db.spTICK_Playlist_Details_Get(playlistID).Where(pldw => pldw.PlaylistDetailsID == entryID).First();
            oPlaylist.playlistdetailsOmitted.Add(pld);
        }

        //bool bTimetoPlayNextObject = false;
        //private void tmrPlayNextObject_Tick(object sender, EventArgs e)
        //{
        //    if (bTimetoPlayNextObject)
        //        PlayNextObject();
        //}

        private delegate void cboStartAtSelectedItemDelegate(string s);

        private delegate void SetListViewSelectedItemDelegate(RadListView lv, object Key);
        private void SetListViewSelectedItem(RadListView lv, object Key)
        {
            if (lv.InvokeRequired)
            {
                SetListViewSelectedItemDelegate lvg = new SetListViewSelectedItemDelegate(SetListViewSelectedItem);
                this.Invoke(lvg, new object[] { lv, Key });
            }
            else
            {
                try
                {
                    lv.SelectedItem = lv.FindItemByKey(Key, true);
                    SetLastActiveControl();
                }
                catch (Exception ex)
                {
                    logger.Trace("SetListViewSelectedItem Failure - " + ex.Source + " - " + ex.Message);
                }
            }
        }

        bool bScoreAlertPlaying = false;

        bool IsGameOmitted(int entryID, int gameID)
        {
            bool bFoundOmitted = false;
            foreach (spTICK_Playlist_Details_Get_Result pld in oPlaylist.spTICK_Playlist_Details_Get_Results)
            {
                bFoundOmitted = IsGameOmittedInPlaylistDetail(gameID, pld);
                if (bFoundOmitted)
                    break;
            }

            if (bFoundOmitted)
                //found at least 1 instance of unchecked - check to see if at least 1 instance of checked to override
                foreach (spTICK_Playlist_Details_Get_Result pld in oPlaylist.spTICK_Playlist_Details_Get_Results)
                    if (pld.EntryTypeID == 2 || pld.EntryTypeID == 3)//game or games
                        if (db.spTICK_Games_GetByEntryID(int.Parse(cboClient.SelectedValue.ToString()), pld.EntryID, pld.EntryTypeID, chkGamesOnlyFinals.Checked, chkGamesOnlySorted.Checked).Where(p => p.ID == gameID).Count() > 0)
                            if (!IsGameOmittedInPlaylistDetail(gameID, pld))
                                return false;

            if (bFoundOmitted)
                return true;
            else
                return false;
        }

        private bool IsGameOmittedInPlaylistDetail(int gameID, spTICK_Playlist_Details_Get_Result pld)
        {
            if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == pld.PlaylistDetailsID).Count() > 0)
                foreach (GameObject go in oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == pld.PlaylistDetailsID).First().gamesOmitted.ToList())
                    if (go.GamesOmitted.Where(gow => gow.ID == gameID).Count() > 0)
                        return true;
            return false;
        }


        bool bPlayingNextObject = false;
        bool bBlankNote = false;
        bool bPlayingNote = false;

        object listobject = null;
        //object lastListobject = null;
        private void PlayNextObject()
        {
            //this.Invoke((MethodInvoker)delegate()
            //{

            if (bPlayingNextObject) return;

            Timer_Stop();
            bPlayingNextObject = true;
            oPlaylist.bOnlyFinals = chkGamesOnlyFinals.Checked;
            oPlaylist.bOnlySorted = chkGamesOnlySorted.Checked;

            // Every time the timer ticks (~ 4 seconds) we need to advance and play the next avaible "object" (game or note.)


            if (!bFirstTimeRun && bIntroRun)
                bIntroRun = false; //skip moving to next record if intro just played out
            else
                listobject = oPlaylist.GetNext(); //normal

            while (listobject != null)
                if (listobject.GetType().Name != "Empty")
                    break;
                else
                    //while (listobject != null)
                    //{
                    //    while (listobject.GetType().Name == "Empty")
                    listobject = oPlaylist.GetNext();

            //if (listobject == lastListobject)
            //    listobject = null;

            //lastListobject = listobject;
            //}

            //if (listobject != null)
            //{
            //    if (listobject.GetType().Name == "Empty")
            //    {
            //        bPlayingNextObject = false;

            //        //PlayNextObject();
            //        return;
            //    }
            //}


            //check alerts
            string ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length - 1].ToString();
            try
            {
                if (oPlaylist.PlaylistDetailCurrent != null && !bFirstTimeRun && chkScoreAlerts.Checked)
                    if ((db.spTICK_ScoreAlerts_Get(int.Parse(cboClient.SelectedValue.ToString()), 0, ip).Count() > 0))//oPlaylist.PlaylistDetailCurrent.SportID
                    {

                        //check if alert is available for current game being played out
                        spTICK_ScoreAlerts_Get_FTL_Result alert = db.spTICK_ScoreAlerts_Get_FTL(int.Parse(cboClient.SelectedValue.ToString()), 0,
                        ip).First(); //oPlaylist.PlaylistDetailCurrent.SportID

                        if (oPlaylist.PlaylistDetailCurrent != null)
                        {
                            int entryID = oPlaylist.PlaylistDetailCurrent.PlaylistDetailsID;

                            if (!IsGameOmitted(entryID, alert.ID))
                            {
                                Timer_Stop();
                                bScoreAlertPlaying = true;
                                db.spTICK_ScoreAlert_SetClientComplete(int.Parse(cboClient.SelectedValue.ToString()), alert.ID, ip);

                                css.CurrentGame = null; // don't use CSS for score alert.
                                TickerScene.Ticker_ScoreAlert_Insert(alert);

                                System.Threading.Thread.Sleep(500);
                                bScoreAlertPlaying = false;
                            }
                            else
                            {
                                db.spTICK_ScoreAlert_SetClientComplete(int.Parse(cboClient.SelectedValue.ToString()), alert.ID, ip);
                                logger.Trace("Alert Failure - didn't play out! " + entryID + " " + alert.ID);
                            }
                        }
                        else //no omission for this playlist
                        {
                            Timer_Stop();
                            bScoreAlertPlaying = true;
                            db.spTICK_ScoreAlert_SetClientComplete(int.Parse(cboClient.SelectedValue.ToString()), alert.ID, ip);

                            css.CurrentGame = null; // don't use CSS for score alert.
                            TickerScene.Ticker_ScoreAlert_Insert(alert);

                            System.Threading.Thread.Sleep(500);
                            bScoreAlertPlaying = false;
                        }

                    }
            }
            catch (Exception ex)
            {
                logger.Trace("Alert Failure - " + ex.Source + " - " + ex.Message);
            }

            if (listobject != null)
            {
                //switch (cboStartAt.SelectedItem.ToString())

                if (bFirstTimeRun)
                {
                    string StartAtVal = "";
                    this.Invoke((MethodInvoker)delegate()
                    {
                        StartAtVal = cboStartAt.SelectedItem.ToString();
                    });

                    logger.Trace("FirstTimeRun - " + StartAtVal);
                    switch (StartAtVal)
                    {
                        case "Top of Playlist":
                            break;
                        case "Resume":
                            break;
                        case "Top of Group":
                            while (oPlaylist.PlaylistDetailCurrent.PlaylistDetailsID != (int)lvPlayListDetail.Items[0].Key)
                                listobject = oPlaylist.GetNext();
                            break;
                        case "Selected Item":
                            logger.Trace("Selected Item - " + lviCurrent + " - " + lviCurrent.Key);
                            if (lastActiveControl != null && listobject != null)
                            {
                                while (oPlaylist.PlaylistDetailCurrent.PlaylistDetailsID != (int)lvPlayListDetail.SelectedItem.Key)
                                    listobject = oPlaylist.GetNext();
                                switch (lastActiveControl.Name)
                                {
                                    case "lvPlayListDetail":
                                        break;
                                    case "lvNotes":
                                        while (true)
                                        {
                                            if (listobject != null)
                                            {
                                                if (listobject.GetType().Name == "spTICK_Notes_GetByGroup_Result")
                                                {
                                                    if (((spTICK_Notes_GetByGroup_Result)listobject).ID == (int)lviCurrent.Key)
                                                        break;
                                                }
                                                else if (listobject.GetType().Name == "spTICK_GameNotes_GetByGameID_Result")
                                                {
                                                    if (((spTICK_GameNotes_GetByGameID_Result)listobject).ID == (int)lviCurrent.Key)
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                logger.Trace("Can't find selected note - " + lviCurrent + " - " + lviCurrent.Key);
                                                MessageBox.Show("Can't find selected note.");
                                                cmdStop_Click(new object(), new EventArgs());
                                                return;
                                            }

                                            listobject = oPlaylist.GetNext();
                                        }

                                        break;
                                    case "lvGames":
                                        while (true)
                                        {
                                            if (listobject != null)
                                            {
                                                if (listobject.GetType().Name == "spTICK_Games_GetByEntryID_Result")
                                                {
                                                    //while (((spTICK_Games_GetByEntryID_Result)listobject).ID != (int)lviCurrent.Key)
                                                    //    listobject = oPlaylist.GetNext();
                                                    if (((spTICK_Games_GetByEntryID_Result)listobject).ID == (int)lviCurrent.Key)
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                logger.Trace("Can't find selected game - " + lviCurrent + " - " + lviCurrent.Key);
                                                MessageBox.Show("Can't find selected game.");
                                                cmdStop_Click(new object(), new EventArgs());
                                                return;
                                            }
                                            listobject = oPlaylist.GetNext();
                                        }
                                        break;
                                }
                            }
                            lastActiveControl = null;
                            lblSelected.Text = "";

                            break;
                    }
                    bFirstTimeRun = false;
                    if (cboStartAt.SelectedText != "Resume")
                    {
                        bIntroRun = true;
                        bPlayingNextObject = false;
                        TickerScene.Ticker_Insert(Client.Default.IntroMoviePath + "\\" + cboIntro.Text, Client.Default.SponsorPath + "\\" + cboSponsor.Text, null, oPlaylist.OnAirName);
                        return;
                    }
                }




                if (listobject.GetType().Name != "Empty")
                {
                    if (TickerScene.Tab != oPlaylist.OnAirName)
                    {
                        TickerScene.Ticker_Tab_Update(oPlaylist.OnAirName);
                    }
                    if (chkTrackPlay.Checked)
                        if (oPlaylist.PlaylistDetailCurrent != null)
                            SetListViewSelectedItem(lvPlayListDetail, oPlaylist.PlaylistDetailCurrent.PlaylistDetailsID);
                }

                switch (listobject.GetType().Name)
                {
                    case "spTICK_Notes_GetByGroup_Result":
                        spTICK_Notes_GetByGroup_Result groupNote = ((spTICK_Notes_GetByGroup_Result)listobject);

                        if (chkTrackPlay.Checked)
                        {
                            SetListViewSelectedItem(lvNotes, groupNote.ID);

                            //override
                            this.Invoke((MethodInvoker)delegate()
{

    lblSelected.Text = "Selected: " + lvNotes.SelectedItem.SubItems[0].ToString();
    lviCurrent = lvNotes.SelectedItem;
    lastActiveControl = lvNotes;
});
                        }

                        //turn on note timer based on length
                        tmrDMSNote.Change(groupNote.Note.Length * 1000, System.Threading.Timeout.Infinite); //disable

                        TickerScene.Ticker_Note_Insert(listobject);
                        css.CurrentGame = null; // don't use CSS for note.

                        if (groupNote.Note != "")
                        {
                            bBlankNote = false;
                            System.Threading.Thread.Sleep(500);
                        }
                        else
                            bBlankNote = true;
                        bPlayingNote = true;

                        break;
                    case "spTICK_GameNotes_GetByGameID_Result":
                        spTICK_GameNotes_GetByGameID_Result gameNote = (spTICK_GameNotes_GetByGameID_Result)listobject;

                        if (chkTrackPlay.Checked)
                        {
                            SetListViewSelectedItem(lvGames, gameNote.GameID);
                            SetListViewSelectedItem(lvNotes, gameNote.ID);
                        }

                        //turn on note timer based on length
                        tmrDMSNote.Change(gameNote.Note.Length * 1000, System.Threading.Timeout.Infinite); //disable

                        TickerScene.Ticker_Note_Insert(listobject);
                        css.CurrentGame = null; // don't use CSS for note.

                        if (gameNote.Note != "")
                        {
                            bBlankNote = false;
                            System.Threading.Thread.Sleep(500);
                        }
                        else
                            bBlankNote = true;
                        bPlayingNote = true;
                        break;
                    case "spTICK_Games_GetByEntryID_Result":
                        bBlankNote = false;
                        spTICK_Games_GetByEntryID_Result game = (spTICK_Games_GetByEntryID_Result)listobject;
                        if (chkTrackPlay.Checked)
                            SetListViewSelectedItem(lvGames, game.ID);

                        lastActiveControl = lvGames;
                        //if (!bStopped)
                        //lviCurrent = lvGames.SelectedItem;

                        // Use CSS if available:
                        bool css_found = false;
                        if (game.CSSID > 0)
                        {
                            // Look up game in CSS to determine template to use:
                            TickerCSSGame cssgame = css.GetGame(game.CSSID);
                            if (cssgame != null)
                            {
                                css_found = true;
                                switch (cssgame.GameStatusID)  ////1=Pre-Game, 2=In-Progress, 3=Final
                                {
                                    case 1:
                                        css.CurrentGame = null;
                                        TickerScene.Ticker_Schedule_Insert(game);
                                        break;

                                    case 2:
                                        // override with CSS variables:
                                        game.Clock = cssgame.Clock;
                                        game.Status = cssgame.Status;
                                        game.VisitorsScore = cssgame.VisitorsScore;
                                        game.HomeScore = cssgame.HomeScore;
                                        // game.Details = cssgame.Details; disabled per Rich.
                                        css.CurrentGame = game;
                                        TickerScene.Ticker_InProgress_Insert(game);
                                        break;

                                    case 3:
                                        game.Clock = "";
                                        game.Status = cssgame.Status;
                                        game.VisitorsScore = cssgame.VisitorsScore;
                                        game.HomeScore = cssgame.HomeScore;
                                        css.CurrentGame = game;
                                        TickerScene.Ticker_Final_Insert(game);
                                        break;
                                }
                            }
                        }
                        if (!css_found)
                        {
                            css.CurrentGame = null;
                            switch (game.GameStatusID)
                            {
                                case 1:
                                    TickerScene.Ticker_Schedule_Insert(game);
                                    break;
                                case 2:
                                    TickerScene.Ticker_InProgress_Insert(game);
                                    break;
                                case 3:
                                    TickerScene.Ticker_Final_Insert(game);
                                    break;
                            }
                        }
                        System.Threading.Thread.Sleep(500);
                        break;
                }

                //TickerScene.Ticker_Insert("C:\\Fox Ticker\\Clients\\FSN\\Ventuz\\Movies\\Intro\\NFL.COM.avi", "C:\\Fox Ticker\\Clients\\FSN\\Elements\\Sponsors\\TF-MLBonFOX.tga", listobject, oPlaylist.Name);
            }
            else
            {
                //oPlaylist.Reset();
                LoadPlaylist();

                bPlayingNextObject = false;
                bPlayingNote = false;
                //#if DEBUG
                //                System.Diagnostics.Debug.WriteLine(TickerScene.Ticker_Note_IsScrolling() == false);
                //#endif

                if (!bStopped)
                    if (listobject != null)
                        Timer_Start(4000);
                    else
                        Timer_Start(0);
                return;
            }

            // For non-scrolling objects start timer --- if scrolling we need to wait for an event.
            //else
            //{
            if (!bStopped)
                if (TickerScene.Ticker_Note_IsScrolling() || !bPlayingNote)// && !bVZCallbackInProgress)
                {
                    if (!bBlankNote)
                    {
                        if (listobject.GetType().Name.Contains("Note"))
                            System.Threading.Thread.Sleep(4000);
                        else
                            Timer_Start(4000);

                        //Timer_Start(4000);
                    }
                    //else
                    //    Timer_Start(0);

                    //bTimetoPlayNextObject = true;
                }
            //}

            logger.Trace("PlayNextObject - RefreshPlaylistDetail");
            RefreshPlaylistDetail();

            bPlayingNextObject = false;
            //bBlankNote = false;
            bPlayingNote = false;

            logger.Trace("End of PlayNextObject");
            //});
        }

        private void lvPlayListDetail_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!bPlaying && !bRefreshing && cboClient.SelectedItem != null)
                SetLastActiveControl();

            if (curGames != null)
                curGames.Clear();
            else
                curGames = new List<spTICK_Games_GetByEntryID_Result>();
            lvGames.Items.Clear();
            lvNotes.Items.Clear();
            int ID = 0;
            if (lvPlayListDetail.SelectedItem != null && cboPlaylist.SelectedItem != null)
            //switch (lvPlayListDetail.SelectedItem.Tag.GetType().BaseType.Name)
            {

                if (db.Connection.State == ConnectionState.Closed)
                    db.Connection.Open();

                //    case "Group":
                int entryID = (int)lvPlayListDetail.SelectedItem.Key;
                int playlistID = (int)cboPlaylist.SelectedItem.Value;
                ObjectResult<spTICK_Playlist_Details_Get_Result> pldg = db.spTICK_Playlist_Details_Get(playlistID);
                List<spTICK_Playlist_Details_Get_Result> lpldg = pldg.ToList();
                spTICK_Playlist_Details_Get_Result pld = lpldg.Where(pldw => pldw.PlaylistDetailsID == entryID).First();

                switch (pld.EntryTypeID)
                {
                    case 1://A group.  The GroupID is defined in the EntryID field.
                        int counter = 0;
                        int groupID = db.Groups.Where(gw => gw.ID == pld.EntryID).First().ID; //((Group)lvPlayListDetail.SelectedItem.Tag).ID;
                        int clientID = int.Parse(cboClient.SelectedValue.ToString());
                        NoteObject oNote = new NoteObject();
                        oNote.LoadGroup(groupID, clientID);
                        List<spTICK_Notes_GetByGroup_Result> lngbg = oNote.groupNotes; //db.spTICK_Notes_GetByGroup(groupID, clientID).ToList();

                        lvNotes.BeginUpdate();
                        foreach (spTICK_Notes_GetByGroup_Result ngbg in lngbg)
                        {
                            var itemName = String.Format("listItem{0}", counter++);
                            var values = new string[] { ngbg.Note, ngbg.Header };
                            var nlvi = new Telerik.WinControls.UI.ListViewDataItem(itemName, values) { BackColor = Color.FromName(ngbg.NoteColor), Tag = ngbg };
                            //nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            if (oPlaylist.OmissionsExist(entryID))
                            {
                                if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().notesOmitted.Where(now => now.groupID == ngbg.GroupID).Count() > 0)
                                {
                                    if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().notesOmitted.Where(now => now.groupID == ngbg.GroupID).First().groupNotesOmitted.Where(gnw => gnw.ID == ngbg.ID).Count() == 0)
                                        nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                }
                                else
                                    nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            }
                            else
                                nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

                            nlvi.Key = ngbg.ID;
                            lvNotes.Items.Add(nlvi);
                        }
                        lvNotes.EndUpdate();
                        break;
                    //                    spTICK_Playlist_Details_Get_Result pld = (spTICK_Playlist_Details_Get_Result)lvPlayListDetail.SelectedItem.Tag;
                    //                  switch (pld.EntryTypeID)
                    //{
                    case 2:
                        RefreshGames(ID, entryID, pld);
                        break;
                    case 3: //All games for a given sport for today.  The sport is defined in the EntryID field.
                        RefreshGames(ID, entryID, pld);
                        break;
                    case 4: //All games for a given sport prior to today.  The sport is defined in the EntryID field.
                        RefreshGames(ID, entryID, pld);
                        break;


                }

                if (!bPlaying && !bRefreshing && cboClient.SelectedItem != null)
                {
                    if (lvGames.Items.Count() > 0)
                        lvGames.SelectedIndex = 0;
                    if (lvNotes.Items.Count() > 0)
                        lvNotes.SelectedIndex = 0;
                }

            }
        }

        private void SetLastActiveControl()
        {
            if (bFirstTimeRun || bRefreshing) return;
            lastActiveControl = ActiveControl;
            if (cboStartAt.SelectedItem.ToString() == "Selected Item")
                switch (lastActiveControl.Name)
                {
                    case "lvPlayListDetail":
                        if (lvPlayListDetail.SelectedItem != null)
                        {
                            lblSelected.Text = "Selected: " + lvPlayListDetail.SelectedItem.Text;
                            lviCurrent = lvPlayListDetail.SelectedItem;
                        }
                        break;
                    case "lvNotes":
                        if (lvNotes.SelectedItem != null)
                        {
                            lblSelected.Text = "Selected: " + lvNotes.SelectedItem.SubItems[0].ToString();
                            lviCurrent = lvNotes.SelectedItem;
                        }
                        break;
                    case "lvGames":
                        if (lvGames.SelectedItem != null)
                        {
                            lblSelected.Text = "Selected: " + lvGames.SelectedItem.SubItems[0].ToString();
                            lviCurrent = lvGames.SelectedItem;
                        }
                        break;
                }
            else
                lblSelected.Text = "";
        }

        private void RefreshGames(int ID, int entryID, spTICK_Playlist_Details_Get_Result pld)
        {
            int counter = 0;
            ObjectResult<spTICK_Games_GetByEntryID_Result> ggbe = db.spTICK_Games_GetByEntryID(int.Parse(cboClient.SelectedValue.ToString()), pld.EntryID, pld.EntryTypeID, chkGamesOnlyFinals.Checked, chkGamesOnlySorted.Checked);
            //if (ggbe.Count() > 0)
            if (ggbe != null)
            {
                curGames.AddRange(ggbe.ToList());

                lvGames.BeginUpdate();
                foreach (spTICK_Games_GetByEntryID_Result game in curGames)
                {
                    Telerik.WinControls.Enumerations.ToggleState chk = Telerik.WinControls.Enumerations.ToggleState.On;

                    ID = int.Parse(cboPlaylist.SelectedValue.ToString());
                    if (oPlaylist.OmissionsExist(entryID))
                    {
                        List<GameObject> loGame = oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Where(gow => gow.ID == ID).ToList();
                        if (loGame.Count() > 0)
                        {
                            if (loGame.First().GamesOmitted.Where(lgow => lgow.ID == game.ID).Count() > 0)
                                chk = Telerik.WinControls.Enumerations.ToggleState.Off;
                            else
                                chk = Telerik.WinControls.Enumerations.ToggleState.On;
                        }
                        else
                            chk = Telerik.WinControls.Enumerations.ToggleState.On;
                    }
                    else
                        chk = Telerik.WinControls.Enumerations.ToggleState.On;


                    var itemName = String.Format("listItem{0}", counter++);
                    string[] values;
                    if (css.Connected)
                    {
                        TickerCSSGame tcg = css.GetGame(game.ID);
                        if (tcg != null) //if css has game info, use it
                            values = new string[] { game.Matchup, tcg.VisitorsScore.ToString(), tcg.HomeScore.ToString(), tcg.Status, tcg.Clock };
                        else
                            values = new string[] { game.Matchup, game.VisitorsScore.ToString(), game.HomeScore.ToString(), game.Status, game.Clock };
                    }
                    else
                        values = new string[] { game.Matchup, game.VisitorsScore.ToString(), game.HomeScore.ToString(), game.Status, game.Clock };
                    var nlvi = new Telerik.WinControls.UI.ListViewDataItem(itemName, values) { Tag = game, CheckState = chk, Value = entryID };
                    nlvi.Key = game.ID;
                    lvGames.Items.Add(nlvi);
                }
                lvGames.EndUpdate();
            }
        }

        private void lvGames_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem lvi = (ListViewDataItem)e.Item;
            GameObject go;
            int clientID = int.Parse(cboClient.SelectedValue.ToString());

            int ID = ((spTICK_Games_GetByEntryID_Result)lvi.Tag).ID;
            int playlistID = int.Parse(cboPlaylist.SelectedValue.ToString());
            int entryID = (int)lvPlayListDetail.SelectedItem.Key;
            if (!oPlaylist.OmissionsExist(entryID))
            {
                oPlaylist.CreateOmission(entryID);
                go = CreateGamesOmitted(ID, playlistID, entryID);
            }
            else
            {
                if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Where(gow => gow.ID == playlistID).Count() == 0)
                {
                    go = CreateGamesOmitted(ID, playlistID, entryID);
                }
                else
                {
                    go = oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Where(gow => gow.ID == playlistID).First();
                    spTICK_Games_GetByEntryID_Result g = curGames.Where(cgw => cgw.ID == ID).First();

                    if (go.GamesOmitted.Where(pldw => pldw.ID == ID).Count() == 0)
                    {
                        go.GamesOmitted.Add(g);
                    }
                    else
                    {
                        go.GamesOmitted.Remove(go.GamesOmitted.Where(cgw => cgw.ID == ID).First());
                    }
                }
            }

        }

        private GameObject CreateGamesOmitted(int ID, int playlistID, int entryID)
        {
            GameObject go;
            go = new GameObject();
            go.ID = playlistID;
            go.GamesOmitted = new List<spTICK_Games_GetByEntryID_Result>();

            spTICK_Games_GetByEntryID_Result g = curGames.Where(cgw => cgw.ID == ID).First();
            go.GamesOmitted.Add(g);
            oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().gamesOmitted.Add(go);
            return go;
        }

        private void lvNotes_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem lvi = (ListViewDataItem)e.Item;
            NoteObject no;
            int clientID = int.Parse(cboClient.SelectedValue.ToString());
            int ID;
            //int playlistID = int.Parse(lvPlayListDetail.SelectedItem.ToString());
            object pld = lvPlayListDetail.SelectedItem.Tag;
            int entryID = (int)lvPlayListDetail.SelectedItem.Key;
            int noteID;
            switch (lvi.Tag.GetType().Name)
            {
                case "spTICK_Notes_GetByGroup_Result":
                    ID = ((spTICK_Notes_GetByGroup_Result)lvi.Tag).GroupID;

                    Group group = db.Groups.Where(gw => gw.ID == ID).First();
                    if (!oPlaylist.OmissionsExist(entryID))
                    {
                        oPlaylist.CreateOmission(entryID);
                        CreateUpdateGroupNotesOmission(lvi, entryID, group);
                    }
                    else
                    {
                        if (e.Item.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
                        {
                            //if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.groupID == group.ID).Count() == 0)
                            CreateUpdateGroupNotesOmission(lvi, entryID, group);
                        }
                        else
                        {
                            no = oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.groupID == group.ID).First();
                            noteID = ((spTICK_Notes_GetByGroup_Result)lvi.Tag).ID;
                            if (no.groupNotesOmitted.Where(gnw => gnw.ID == noteID).Count() > 0)
                            {
                                spTICK_Notes_GetByGroup_Result n = no.groupNotesOmitted.Where(gnw => gnw.ID == noteID).First();// (spTICK_Notes_GetByGroup_Result)lvi.Tag;
                                no.groupNotesOmitted.Remove(n);
                            }
                        }
                    }
                    break;
                case "spTICK_GameNotes_GetByGameID_Result":
                    MessageBox.Show("Game notes are not cannot be unchecked.");
                    return;

                    ID = ((spTICK_GameNotes_GetByGameID_Result)lvi.Tag).ID;
                    spTICK_Games_GetByEntryID_Result game;
                    if (lvGames.SelectedItem == null)
                        game = (spTICK_Games_GetByEntryID_Result)lvGames.Items[0].Tag;
                    else
                        game = (spTICK_Games_GetByEntryID_Result)lvGames.SelectedItem.Tag;
                    if (!oPlaylist.OmissionsExist(entryID))
                    {
                        oPlaylist.CreateOmission(entryID);
                        CreateUpdateGameNotesOmission(lvi, entryID, game);
                    }
                    else
                    {
                        if (e.Item.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
                        {

                            //if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.gameID == game.ID).Count() == 0)
                            CreateUpdateGameNotesOmission(lvi, entryID, game);
                        }
                        else
                        {
                            no = oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.gameID == game.ID).First();
                            noteID = ((spTICK_GameNotes_GetByGameID_Result)lvi.Tag).ID;
                            if (no.gameNotesOmitted.Where(gnw => gnw.ID == noteID).Count() > 0)
                            {
                                spTICK_GameNotes_GetByGameID_Result n = no.gameNotesOmitted.Where(gnw => gnw.ID == noteID).First(); //(spTICK_GameNotes_GetByGameID_Result)lvi.Tag;
                                //no.gameNotesOmitted.Add(n);
                                no.gameNotesOmitted.Remove(n);
                            }
                        }
                    }

                    break;
            }


        }

        private void CreateUpdateGameNotesOmission(ListViewDataItem lvi, int entryID, spTICK_Games_GetByEntryID_Result game)
        {
            NoteObject no;
            no = new NoteObject();
            no.gameID = game.ID;
            no.gameNotesOmitted = new List<spTICK_GameNotes_GetByGameID_Result>();

            spTICK_GameNotes_GetByGameID_Result n = (spTICK_GameNotes_GetByGameID_Result)lvi.Tag;
            no.gameNotesOmitted.Add(n);

            if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Count() > 0)
                if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.gameID == game.ID).Count() == 0)
                    oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Add(no);
                else
                    oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.gameID == game.ID).First().gameNotesOmitted.Add(n);
            else
                oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Add(no);

        }

        private void CreateUpdateGroupNotesOmission(ListViewDataItem lvi, int entryID, Group group)
        {
            NoteObject no;
            no = new NoteObject();
            no.groupID = group.ID;
            no.groupNotesOmitted = new List<spTICK_Notes_GetByGroup_Result>();

            spTICK_Notes_GetByGroup_Result n = (spTICK_Notes_GetByGroup_Result)lvi.Tag;
            no.groupNotesOmitted.Add(n);

            if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Count() > 0)
                if (oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.groupID == group.ID).Count() == 0)
                    oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Add(no);
                else
                    oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Where(now => now.groupID == group.ID).First().groupNotesOmitted.Add(n);
            else
                oPlaylist.playlistdetailsOmissions.Where(plow => plow.ID == entryID).First().notesOmitted.Add(no);

        }

        private void lvGames_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!bPlaying && !bRefreshing)
            {
                if (bStopped)
                {
                    //lviCurrent = lvGames.SelectedItem;
                    lastActiveControl = lvGames;
                    SetLastActiveControl();
                }
                //if (!bStopping)
                //    lviCurrent = ((RadListViewElement)sender).SelectedItem;
            }
            int counter = 0;
            if (lvGames.SelectedItem != null)
            {
                lvNotes.Items.Clear();

                int entryID = (int)lvPlayListDetail.SelectedItem.Key;
                int gameID = 0;
                switch (lvGames.SelectedItem.Tag.GetType().Name)
                {
                    case "spTICK_Games_GetByEntryID_Result":
                        gameID = ((spTICK_Games_GetByEntryID_Result)lvGames.SelectedItem.Tag).ID;
                        break;
                    case "Game":
                        gameID = ((Game)lvGames.SelectedItem.Tag).ID;
                        break;
                }

                int clientID = int.Parse(cboClient.SelectedValue.ToString());
                NoteObject oNote = new NoteObject();
                oNote.LoadGame(gameID, clientID);
                List<spTICK_GameNotes_GetByGameID_Result> lngbg = oNote.gameNotes; //db.spTICK_Notes_GetByGroup(groupID, clientID).ToList();

                lvNotes.BeginUpdate();
                foreach (spTICK_GameNotes_GetByGameID_Result ngbg in lngbg)
                {
                    var itemName = String.Format("listItem{0}", counter++);
                    var values = new string[] { ngbg.Note, ngbg.Header };
                    var nlvi = new Telerik.WinControls.UI.ListViewDataItem(itemName, values) { Tag = ngbg, Key = ngbg.ID };
                    //if (ngbg.NoteColor != null)
                    //    if (ngbg.NoteColor != "")
                    //        BackColor = Color.FromName(ngbg.NoteColor);
                    if (oPlaylist.OmissionsExist(entryID))
                    {
                        if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().notesOmitted.Where(now => now.gameID == ngbg.GameID).Count() > 0)
                        {
                            if (oPlaylist.playlistdetailsOmissions.Where(pldow => pldow.ID == entryID).First().notesOmitted.Where(now => now.gameID == ngbg.GameID).First().gameNotesOmitted.Where(gnw => gnw.ID == ngbg.ID).Count() == 0)
                                nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                        }
                        else
                            nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                    }
                    else
                        nlvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

                    lvNotes.Items.Add(nlvi);
                }
                lvNotes.EndUpdate();
            }
        }

        private void btnIntroRefresh_Click(object sender, EventArgs e)
        {
            // Read available movies from path and present them....
            cboIntro.Items.Clear();
            foreach (string intro_file in System.IO.Directory.GetFiles(Client.Default.IntroMoviePath))
            {
                switch (intro_file.Substring(intro_file.Length - 3, 3).ToUpper())
                {
                    case "MOV":
                    case "AVI":
                        cboIntro.Items.Add(intro_file.Replace(Client.Default.IntroMoviePath + "\\", "").ToUpper());
                        break;
                }
            }
            try
            {
                cboIntro.SelectedIndex = cboIntro.Items.IndexOf(Client.Default.IntroMovieDefault.ToUpper());
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to find default intro file '" + Client.Default.IntroMovieDefault + "' at " + Client.Default.IntroMoviePath);
                cboIntro.SelectedItem = 0;
            }
        }

        private void btnSponsorRefresh_Click(object sender, EventArgs e)
        {
            // Read available movies from path and present them....
            cboSponsor.Items.Clear();
            foreach (string sponsor_file in System.IO.Directory.GetFiles(Client.Default.SponsorPath))
            {
                switch (sponsor_file.Substring(sponsor_file.Length - 3, 3).ToUpper())
                {
                    case "MOV":
                    case "AVI":
                    case "TGA":
                    case "PNG":
                        cboSponsor.Items.Add(sponsor_file.Replace(Client.Default.SponsorPath + "\\", "").ToUpper());
                        break;
                }
            }
            try
            {
                cboSponsor.SelectedIndex = cboSponsor.Items.IndexOf(Client.Default.SponsorDefault.ToUpper());
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to find default intro file '" + Client.Default.IntroMovieDefault + "' at " + Client.Default.IntroMoviePath);
                cboIntro.SelectedItem = 0;
            }
        }


        Control lastActiveControl = null;
        ListViewDataItem lviCurrent = null;

        private void lvNotes_SelectedItemChanged(object sender, EventArgs e)
        {
            if (bRefreshing) return;
            if (!bPlaying && !bRefreshing)
            {
                if (bStopped)
                {
                    //lviCurrent = lvNotes.SelectedItem;
                    lastActiveControl = lvNotes;
                    SetLastActiveControl();
                }
                //if (!bStopping)
                //    lviCurrent = ((RadListViewElement)sender).SelectedItem;
            }
        }

        private void tmrPlayNext_Tick(object obj)
        {
            if (!bScoreAlertPlaying)
            {
                bTransition = true;
                PlayNextObject();
                bTransition = false;
            }
        }

        bool bStopped = true;
        private void Timer_Stop()
        {
            tmrPlayNext.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite); //disable
            //tmrPlayNext.Change(4294967294u, -1u); 

        }

        private void tmrDMSNote_Tick(object sender)
        {
            logger.Trace("DMS fired after last note");
            tmrDMSNote.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite); //disable
            //bPlayingNote = false;
            //bPlayingNextObject = false;
            //PlayNextObject();
        }

        private void Timer_Start(int interval)
        {
            tmrPlayNext.Change(interval, interval); //enable
            bStopped = false;
        }

        protected void CSS_ClockTick(object sender, spTICK_Games_GetByEntryID_Result currentgame, string status, string clock)
        {
            bool tickplayed = false;
            int loopcount = 0;
            int ClockMaxLoopCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ClockMaxLoopCount"]);
            int ClockSleep = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ClockSleep"]);

            // our game has ticked... update!
            if (oPlaylist.game != null && css.CurrentGame != null)
                while ((!tickplayed) && (loopcount < ClockMaxLoopCount)) // wait until we are ready to tick -- to a point / loop count.
                {
                    if (bPlaying && !bPlayingNextObject)
                    {
                        TickerScene.Ticker_InProgress_Update(currentgame, status, clock);
                        tickplayed = true;
                    }
                    else
                    {
                        loopcount += 1;
                        System.Threading.Thread.Sleep(ClockSleep);
                    }
                }
        }


        private void btnCSSConnect_Click(object sender, EventArgs e)
        {
            if (css.Connected)
            {
                // disconnect.
                css = new TickerCSS(CSS_ClockTick);
                TickerScene.CSS = css;

                System.Threading.Thread.Sleep(1000);

                if (!css.Connected)
                {
                    lblCSSStatus.Text = "Disconnected.";
                    lblCSSStatus.ForeColor = Color.Red;
                    btnCSSConnect.Text = "Connect";
                }
            }
            else
            {

                lblCSSStatus.Text = "Connecting to 10.136.102.50 port 9980...";
                lblCSSStatus.ForeColor = Color.Orange;
                Application.DoEvents();

                css.Connect("10.136.102.50", 9980);
                TickerScene.CSS = css;

                if (css.Connected)
                {
                    lblCSSStatus.Text = "Connected: " + css._cssGames.Count + " games in the system.";
                    lblCSSStatus.ForeColor = Color.Green;
                    btnCSSConnect.Text = "Disconnect";
                }
                else
                {
                    lblCSSStatus.Text = "Unable to connect.";
                    lblCSSStatus.ForeColor = Color.Red;
                }
            }
        }

        private void cmdGamesToggle_Click(object sender, EventArgs e)
        {
            bPlayingNextObject = true;
            foreach (ListViewDataItem lvi in lvGames.Items)
                if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                else
                    lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            bPlayingNextObject = false;
        }

        private void cmdNotesToggle_Click(object sender, EventArgs e)
        {
            bPlayingNextObject = true;
            foreach (ListViewDataItem lvi in lvNotes.Items)
                if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                else
                    lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            bPlayingNextObject = false;
        }

        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Count() == 1)
            {
                foreach (ListViewDataItem lvi in lvPlayListDetail.Items)
                    if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    else
                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Count() == 1)
            {
                foreach (ListViewDataItem lvi in lvPlayListDetail.Items)
                {
                    if (lvi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    else
                        lvi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

                    lvPlayListDetail.SelectedItem = lvi;
                    foreach (ListViewDataItem lviGames in lvGames.Items)
                    {
                        if (lviGames.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                            lviGames.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                        else
                            lviGames.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

                        lvGames.SelectedItem = lviGames;
                        foreach (ListViewDataItem lviNotes in lvNotes.Items)
                            if (!lviNotes.Tag.GetType().ToString().Contains("Game"))
                            {

                                if (lviNotes.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                                    lviNotes.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                                else
                                    lviNotes.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            }
                    }
                    foreach (ListViewDataItem lviNotes in lvNotes.Items)
                        if (lviNotes.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                            lviNotes.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                        else
                            lviNotes.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
                lvPlayListDetail.SelectedIndex = 0;
            }
        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            TickerScene.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    cmdPlay_Click(new object(), new EventArgs());
                    return true;
                case Keys.F4:
                    cmdStop_Click(new object(), new EventArgs());
                    return true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lvGames_Click(object sender, EventArgs e)
        {
            if (bStopped)
            {
                //lviCurrent = lvGames.SelectedItem;
                lastActiveControl = lvGames;
                SetLastActiveControl();
            }
        }
        private void lvNotes_Click(object sender, EventArgs e)
        {
            if (bStopped)
            {
                //lviCurrent = lvNotes.SelectedItem;
                lastActiveControl = lvNotes;
                SetLastActiveControl();
            }
        }

    }
}
