using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticker.Data;
using Ventuz.Kernel.Remoting;
using VentuzRemoting;

namespace Ticker.Data
{
    class SceneFOX : SceneBase
    {
        private bool isatbatvisible;
        private string currenttab;
        private object currentnote;
        private bool bTransitioning = false;
        private TickerCSS css;

        public bool IsAtBatVisible
        {
            get { return isatbatvisible; }
            set { isatbatvisible = value; }
        }

        public string CurrentTab //onairname of gbroup
        {
            get { return currenttab; }
            set { currenttab = value; }
        }

        public object CurrentNote //game or note
        {
            get { return currentnote; }
            set { currentnote = value; }
        }

        public TickerCSS CSS
        {
            get { return css; }
            set { css = value; }
        }

        public delegate void VZ_Callback(object sender, VentuzArgs eventName);
        VZ_Callback ventuz_Callback;
        public SceneFOX(VZ_Callback vc)
        {
            ventuz_Callback = vc;
        }

        protected override void VENTUZ_Callback(object sender, VentuzArgs eventName) //(int connid, int eventid)
        {
            switch (eventName.message.ToUpper())
            {
                case "/GAMENEXT_COMPLETE":
                    ventuz_Callback.Invoke(sender, eventName);
                    break;
                case "/INTRO_COMPLETE": // Ticker Intro is done.
                    Ticker_Tabs_Insert(CurrentTab);
                    System.Threading.Thread.Sleep(1000);
                    //Ticker_Note_Insert(CurrentNote);
                    ventuz_Callback.Invoke(sender, eventName);
                    break;

                case "/NOTE_COMPLETE": // Note Done.
                    ventuz_Callback.Invoke(sender, eventName);
                    break;
                case "/GAMEIN_COMPLETE": // Backplate done.
                    // Bubble up event here - INTROCOMPLETE
                    ventuz_Callback.Invoke(sender, eventName);
                    break;

                default:
                    // We get a lot of events back - some can just be ignored.
                    break;
            }

        }

        public override void Ticker_Clear()
        {
            Ventuz_Property("GAME_SEPARATORALPHA", "0");
            Ventuz_Property("GAMEDETAILS_ATBAT", "");
            Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
            Ventuz_Property("NOTE_HEADERTEXT", "");
            Ventuz_Property("NOTE_TEXT", "");
            Ventuz_Property("GAME_TYPE", "7");
            Ventuz_Method("GAME_NEXT");
            Ventuz_Method("ATBAT_NEXT");
        }

        public override void Ticker_Insert(string intro_file_path, string sponsor_file_path, object noteobject, string tab)
        {
            try
            {
                Ventuz_Property("INTRO_FILENAME", intro_file_path);
                Ventuz_Property("SPONSOR_FILENAME", "file:///" + sponsor_file_path);
                Ventuz_Property("BACKDROP_ANIMFILENAME", "C:\\Fox Ticker\\Clients\\FSN\\Ventuz\\Movies\\IntroForeground\\BASE_DigiTXR.avi");
                Ventuz_Property("GAME_TYPE", "7");

                System.Threading.Thread.Sleep(200);
                Ventuz_Method("TICKER_IN");

                CurrentTab = tab;
                CurrentNote = noteobject;

                if (noteobject == null)
                    CurrentNote = "";

                if (CurrentTab == null)
                    CurrentTab = "";


                IsPlaying = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void Ticker_Tabs_Insert(string tab)
        {
            Ventuz_Property("NOTE_HEADERTEXT", "");
            Ventuz_Property("NOTE_TEXT", "");
            Ventuz_Property("1QUALIFIER_TEXT", tab);

            Ventuz_Method("1QUALIFIER_IN");
            Ventuz_Method("GAMEBRONZE_IN");
            Ventuz_Method("SPONSOR_IN");

            Tab = tab;
        }

        public override void Ticker_Tab_Update(string tab_name)
        {
            if (tab_name != Tab)
            {
                Ticker_Clear();
                System.Threading.Thread.Sleep(300);

                Ventuz_Method("1QUALIFIER_OUT");
                System.Threading.Thread.Sleep(300);

                Ventuz_Property("1QUALIFIER_TEXT", tab_name);
                System.Threading.Thread.Sleep(300);

                Ventuz_Method("1QUALIFIER_IN");
                System.Threading.Thread.Sleep(500);

                Tab = tab_name;
            }
        }

        public void Ticker_Note_Insert(object note)
        {

            if (note.GetType().Name == "spTICK_Notes_GetByGroup_Result")
            {
                if (((spTICK_Notes_GetByGroup_Result)note).Note != "")
                {
                    Ventuz_Property("NOTE_TICKERSPEED", "0.8");
                    Ventuz_Property("NOTE_TIMEBEFORESCROLL", "1.5");

                    Ventuz_Property("GAME_SEPARATORALPHA", "0");
                    Ventuz_Property("GAMEDETAILS_ATBAT", "");
                    Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
                }
                else
                {
                    Ventuz_Property("NOTE_HEADERTEXT", "");
                    Ventuz_Property("NOTE_TICKERSPEED", "100");
                    Ventuz_Property("NOTE_TIMEBEFORESCROLL", "0");

                    Ventuz_Property("GAME_SEPARATORALPHA", "0");
                    Ventuz_Property("GAMEDETAILS_ATBAT", "");
                    Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
                }
            }
            else if (((spTICK_GameNotes_GetByGameID_Result)note).Note != "")
            {
                Ventuz_Property("NOTE_TICKERSPEED", "0.8");
                Ventuz_Property("NOTE_TIMEBEFORESCROLL", "1.5");

                Ventuz_Property("GAME_SEPARATORALPHA", "0");
                Ventuz_Property("GAMEDETAILS_ATBAT", "");
                Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
            }
            else
            {
                Ventuz_Property("NOTE_HEADERTEXT", "");
                Ventuz_Property("NOTE_TICKERSPEED", "100");
                Ventuz_Property("NOTE_TIMEBEFORESCROLL", "0");

                Ventuz_Property("GAME_SEPARATORALPHA", "0");
                Ventuz_Property("GAMEDETAILS_ATBAT", "");
                Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
            }

            switch (note.GetType().Name)
            {
                case "spTICK_Notes_GetByGroup_Result":
                    spTICK_Notes_GetByGroup_Result groupNote = (spTICK_Notes_GetByGroup_Result)note;
                    Ventuz_Property("GAME_TYPE", "7");
                    if (groupNote.Header != "")
                    {
                        Ventuz_Property("NOTE_HEADERTEXT", groupNote.Header);
                        if (groupNote.TeamID == -1)
                            Ventuz_Property("NOTE_HEADERTEXTCOLOR", "255,255,255");
                        else
                            Ventuz_Property("NOTE_HEADERTEXTCOLOR", groupNote.TeamSecondaryColor);
                        Ventuz_Property("NOTE_HEADERBACKDROPCOLOR", groupNote.TeamPrimaryColor);
                    }
                    else if (groupNote.TeamAbbreviation != "")
                    {
                        Ventuz_Property("NOTE_HEADERTEXT", groupNote.TeamAbbreviation);
                        Ventuz_Property("NOTE_HEADERTEXTCOLOR", groupNote.TeamSecondaryColor);
                        Ventuz_Property("NOTE_HEADERBACKDROPCOLOR", groupNote.TeamPrimaryColor);
                    }

                    if (groupNote.NoteColor != "")
                        Ventuz_Property("NOTE_TEXT", ConvertToVentuz(groupNote.NoteColor));
                    else
                        Ventuz_Property("NOTE_TEXT", groupNote.Note);

                    Ventuz_Property("NOTE_WIDTHCALCTEXT", groupNote.Note);

                    if (groupNote.Note.Trim() != "")
                        System.Threading.Thread.Sleep(400);

                    break;

                case "spTICK_GameNotes_GetByGameID_Result":
                    spTICK_GameNotes_GetByGameID_Result gameNote = (spTICK_GameNotes_GetByGameID_Result)note;
                    Ventuz_Property("GAME_TYPE", "7");
                    if (gameNote.Header != "")
                    {
                        Ventuz_Property("NOTE_HEADERTEXT", gameNote.Header);
                        if (gameNote.TeamID == -1)
                            Ventuz_Property("NOTE_HEADERTEXTCOLOR", "255,255,255");
                        else
                            Ventuz_Property("NOTE_HEADERTEXTCOLOR", gameNote.TeamSecondaryColor);
                        Ventuz_Property("NOTE_HEADERBACKDROPCOLOR", gameNote.TeamPrimaryColor);
                    }
                    else if (gameNote.TeamAbbreviation != "")
                    {
                        Ventuz_Property("NOTE_HEADERTEXT", gameNote.TeamAbbreviation);
                        Ventuz_Property("NOTE_HEADERTEXTCOLOR", gameNote.TeamSecondaryColor);
                        Ventuz_Property("NOTE_HEADERBACKDROPCOLOR", gameNote.TeamPrimaryColor);
                    }

                    if (gameNote.NoteColor != null)
                    {
                        if (gameNote.NoteColor != "")
                            Ventuz_Property("NOTE_TEXT", ConvertToVentuz(gameNote.NoteColor));
                        else
                            Ventuz_Property("NOTE_TEXT", gameNote.Note);
                    }
                    else
                        Ventuz_Property("NOTE_TEXT", gameNote.Note);

                    if (gameNote.Note.Trim() != "")
                        System.Threading.Thread.Sleep(400);

                    break;
            }


            Ventuz_Method("GAME_NEXT");
            Ventuz_Method("ATBAT_NEXT");

        }



        //public override void Ticker_Note_Insert(string header, string text)
        //{
        //    Ticker_Note_Insert(header, "10,30,97", "255,255,255", text);
        //}



        //public override void Ticker_Note_Insert(string header, string headerRGB, string textRGB, string text)
        //{
        //    Ventuz_Property("GAME_TYPE", "7");
        //    Ventuz_Property("NOTE_HEADERTEXT", header);
        //    Ventuz_Property("NOTE_HEADERTEXTCOLOR", textRGB);
        //    Ventuz_Property("NOTE_HEADERBACKDROPCOLOR", headerRGB);
        //    Ventuz_Property("NOTE_TEXT", text);
        //    Ventuz_Property("NOTE_WIDTHCALCTEXT", DateTime.Now.ToString());

        //    System.Threading.Thread.Sleep(400);

        //    Ventuz_Method("GAME_NEXT");
        //}



        public override void Ticker_Schedule_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            // Note:  use game object instead of hard-coded values:

            Ventuz_Property("GAME_SEPARATORALPHA", "0");
            Ventuz_Property("GAME_TYPE", "3"); // 15 would be if there is a network associated with the game.
            Ventuz_Property("GAMETEAM1", gameobject.VisitorsNickName);
            if (gameobject.VisitorsRanking > 0)
                Ventuz_Property("GAME_TEAM1RANKING", gameobject.VisitorsRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM1RANKING", "");

            Ventuz_Property("GAMETEAM2", gameobject.HomeNickName);
            if (gameobject.HomeRanking > 0)
                Ventuz_Property("GAME_TEAM2RANKING", gameobject.HomeRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM2RANKING", "");

            Ventuz_Property("GAMEDETAILS_STATUS", DateTime.Parse(gameobject.GameDateTime.ToString()).ToString("dddd h:mmtt") + " EST"); //"4:00pm");
            Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");

            System.Threading.Thread.Sleep(400);

            Ventuz_Method("ATBAT_NEXT");
            Ventuz_Method("GAME_NEXT");
        }



        public override void Ticker_InProgress_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            // Note:  use game object instead of hard-coded values:
            string possession_arrow = "<YELLOW>&#8734;</YELLOW> ";
            string clock = "";
            string status = "";

            bTransitioning = true;

            try
            {

                Ventuz_Property("GAME_TYPE", "11"); // 2 = MLB with AB, 11 = AB

                if (Details_Get(gameobject.Details, "possession").ToUpper() == "V")
                    possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                else
                    possession_arrow = " ";

                Ventuz_Property("GAMETEAM1", gameobject.VisitorsNickName.Trim() + possession_arrow + "<SCORECOLOR>" + gameobject.VisitorsScore + "</SCORECOLOR>");
                if (gameobject.VisitorsRanking > 0)
                    Ventuz_Property("GAME_TEAM1RANKING", gameobject.VisitorsRanking.ToString());
                else
                    Ventuz_Property("GAME_TEAM1RANKING", "");

                if (Details_Get(gameobject.Details, "possession").ToUpper() == "H")
                    possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                else
                    possession_arrow = " ";

                Ventuz_Property("GAMETEAM2", gameobject.HomeNickName.Trim() + possession_arrow + "<SCORECOLOR>" + gameobject.HomeScore + "</SCORECOLOR>");
                if (gameobject.HomeRanking > 0)
                    Ventuz_Property("GAME_TEAM2RANKING", gameobject.HomeRanking.ToString());
                else
                    Ventuz_Property("GAME_TEAM2RANKING", "");

                if ((css == null) || (css.CurrentGame == null))
                {
                    clock = gameobject.Clock.Trim();
                    status = gameobject.Status.Trim();
                }
                else if (gameobject.CSSID == css.CurrentGame.CSSID)
                {
                    clock = gameobject.Clock.Trim();
                    status = gameobject.Status.Trim();
                }
                else
                {
                    clock = gameobject.Clock.Trim();
                    status = gameobject.Status.Trim();
                }

                Ventuz_Property("GAMEDETAILS_STATUS", status + "    " + "<WHITE>" + clock + "</WHITE>");   // 4th    <WHITE>1:52</WHITE>

                // Show Ball Spot?
                if (Details_Get(gameobject.Details, "ballspot") != "")
                {
                    Ventuz_Property("GAME_SEPARATORALPHA", "100");
                    Ventuz_Property("GAMEDETAILS_ATBAT", Details_Get(gameobject.Details, "ballspot"));
                    Ventuz_Property("GAMEDETAILS_HIDEATBAT", "False");

                    if (Convert.ToBoolean(Details_Get(gameobject.Details, "redzone")))
                        Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "100"); // 100 will show bg color if red zone.
                    else
                        Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "0"); // 100 will show bg color if red zone.
                }
                else
                {
                    Ventuz_Property("GAME_SEPARATORALPHA", "0");
                    Ventuz_Property("GAMEDETAILS_ATBAT", "");
                    Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
                    Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "0"); // 100 will show bg color if red zone.
                }

                //System.Threading.Thread.Sleep(400);

                if (!IsAtBatVisible)
                {
                    Ventuz_Method("ATBATTEXT_IN");
                }
                else
                {
                    Ventuz_Method("ATBAT_NEXT");
                }

                Ventuz_Method("GAME_NEXT");
                bTransitioning = false;

                IsAtBatVisible = true;
            }
            catch (Exception)
            {
                bTransitioning = false;
            }
        }

        public void Ticker_InProgress_Update(spTICK_Games_GetByEntryID_Result gameobject, string status, string clock)
        {
            if (bTransitioning)
                return;

            // Note:  use game object instead of hard-coded values:
            string possession_arrow = "<YELLOW>&#8734;</YELLOW> ";

            Ventuz_Property("GAME_TYPE", "11"); // 2 = MLB with AB, 11 = AB

            if (Details_Get(gameobject.Details, "possession").ToUpper() == "V")
                possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
            else
                possession_arrow = " ";

            Ventuz_Property("GAMETEAM1", gameobject.VisitorsNickName.Trim() + possession_arrow + "<SCORECOLOR>" + gameobject.VisitorsScore + "</SCORECOLOR>");
            if (gameobject.VisitorsRanking > 0)
                Ventuz_Property("GAME_TEAM1RANKING", gameobject.VisitorsRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM1RANKING", "");

            if (Details_Get(gameobject.Details, "possession").ToUpper() == "H")
                possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
            else
                possession_arrow = " ";

            Ventuz_Property("GAMETEAM2", gameobject.HomeNickName.Trim() + possession_arrow + "<SCORECOLOR>" + gameobject.HomeScore + "</SCORECOLOR>");
            if (gameobject.HomeRanking > 0)
                Ventuz_Property("GAME_TEAM2RANKING", gameobject.HomeRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM2RANKING", "");

            Ventuz_Property("GAMEDETAILS_STATUS", status.Trim() + "    " + "<WHITE>" + clock.Trim() + "</WHITE>");   // 4th    <WHITE>1:52</WHITE>

            Ventuz_Method("GAMEDETAILS_STATUSINSTANTUPDATE");
        }

        public override void Ticker_Final_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            Ventuz_Property("GAME_SEPARATORALPHA", "0");
            Ventuz_Property("GAME_TYPE", "0");
            Ventuz_Property("GAMETEAM1", gameobject.VisitorsNickName.Trim() + Format_Record(gameobject.VisitorWins, gameobject.VisitorLoss, gameobject.VisitorTie) + " <SCORECOLOR>" + gameobject.VisitorsScore + "</SCORECOLOR>");
            if (gameobject.VisitorsRanking > 0)
                Ventuz_Property("GAME_TEAM1RANKING", gameobject.VisitorsRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM1RANKING", "");

            Ventuz_Property("GAMETEAM2", gameobject.HomeNickName.Trim() + Format_Record(gameobject.HomeWins, gameobject.HomeLoss, gameobject.HomeTie) + " <SCORECOLOR>" + gameobject.HomeScore + "</SCORECOLOR>");
            if (gameobject.HomeRanking > 0)
                Ventuz_Property("GAME_TEAM2RANKING", gameobject.HomeRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM2RANKING", "");

            Ventuz_Property("GAMEDETAILS_STATUS", gameobject.Status);
            Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
            System.Threading.Thread.Sleep(400);

            Ventuz_Method("GAME_NEXT");

            IsAtBatVisible = false;
        }



        public override void Ticker_Platinum_Insert(string tickerflow_platinum_path, string tickerflow_static_path)
        {
            Ventuz_Property("GAMEFLOW_FILENAME", "file:///" + tickerflow_platinum_path);  // "file:///C:\\Fox Ticker\\Clients\\FSN\\Elements\\Sponsors\\TF-Academy_Platinum.avi");
            Ventuz_Property("SPONSOR_FILENAME", "file:///" + tickerflow_static_path);  // "file:///C:\\Fox Ticker\\Clients\\FSN\\Elements\\Sponsors\\TF-Academy.tga"
            Ventuz_Method("GAMEFLOWPLATINUM_IN");
        }



        public override void Ticker_ScoreAlert_Insert(spTICK_ScoreAlerts_Get_FTL_Result scorealert)//object gameobject)
        {
            Ventuz_Property("INTRO_FILENAME", "file:///C:\\Fox Ticker\\Clients\\FSN\\Elements\\GroupIntros\\Score Alert.avi");
#if DEBUG
            System.Threading.Thread.Sleep(500);
#endif
            Ventuz_Method("INTRO_PLAY");

            // Note:  use gameobject instead of hardcoded values:

            // Delay behind scenes and then update data with game with score alert....
            System.Threading.Thread.Sleep(1000);

            // Note:  use game object instead of hard-coded values:
            string possession_arrow = "<YELLOW>&#8734;</YELLOW> ";

            Ventuz_Property("GAME_TYPE", "11"); // 2 = MLB with AB, 11 = AB
            Ventuz_Property("1QUALIFIER_TEXT", scorealert.SportType);
            Tab = scorealert.SportType;

            if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "V")
                possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
            else
                possession_arrow = " ";

            Ventuz_Property("GAMETEAM1", scorealert.VisitorsNickName.Trim() + possession_arrow + "<SCORECOLOR>" + scorealert.LastVisitorsScore + "</SCORECOLOR>");
            if (scorealert.VisitorsRanking > 0)
                Ventuz_Property("GAME_TEAM1RANKING", scorealert.VisitorsRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM1RANKING", "");

            if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "H")
                possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
            else
                possession_arrow = " ";

            Ventuz_Property("GAMETEAM2", scorealert.HomeNickName.Trim() + possession_arrow + "<SCORECOLOR>" + scorealert.LastHomeScore + "</SCORECOLOR>");
            if (scorealert.HomeRanking > 0)
                Ventuz_Property("GAME_TEAM2RANKING", scorealert.HomeRanking.ToString());
            else
                Ventuz_Property("GAME_TEAM2RANKING", "");

            Ventuz_Property("GAMEDETAILS_STATUS", scorealert.StatusPreScore + "    " + "<WHITE>" + scorealert.Clock + "</WHITE>");   // 4th    <WHITE>1:52</WHITE>

            // Show Ball Spot?
            if (Details_Get(scorealert.DetailsPreScore, "ballspot") != "")
            {
                Ventuz_Property("GAME_SEPARATORALPHA", "100");
                Ventuz_Property("GAMEDETAILS_ATBAT", Details_Get(scorealert.DetailsPreScore, "ballspot"));
                Ventuz_Property("GAMEDETAILS_HIDEATBAT", "False");

                if (Convert.ToBoolean(Details_Get(scorealert.DetailsPreScore, "redzone")))
                    Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "100"); // 100 will show bg color if red zone.
                else
                    Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "0"); // 100 will show bg color if red zone.
            }
            else
            {
                Ventuz_Property("GAME_SEPARATORALPHA", "0");
                Ventuz_Property("GAMEDETAILS_ATBAT", "");
                Ventuz_Property("GAMEDETAILS_HIDEATBAT", "True");
                Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "0"); // 100 will show bg color if red zone.
            }

            if (!IsAtBatVisible)
            {
                Ventuz_Method("ATBATTEXT_IN");
            }
            else
            {
                Ventuz_Method("ATBAT_NEXT");
            }
            Ventuz_Method("GAME_NEXT");
            IsAtBatVisible = true;

            // Flash score of team that changes:
            System.Threading.Thread.Sleep(2000);
            Flash_ScoreAlert_Score(scorealert, 3);

            // Now show how team scored:
            Ventuz_Property("GAME_SEPARATORALPHA", "100");
            Ventuz_Property("GAMEDETAILS_ATBAT", scorealert.ScoreDescription);
            Ventuz_Property("GAMEDETAILS_HIDEATBAT", "False");
            Ventuz_Property("GAMEDETAILS_BACKDROPALPHA", "100"); // 100 will show bg color if red zone.


            Ventuz_Method("ATBAT_INSTANTUPDATE");

            System.Threading.Thread.Sleep(4000);

        }

        private void Flash_ScoreAlert_Score(spTICK_ScoreAlerts_Get_FTL_Result scorealert, int number_of_times)
        {
            string possession_arrow = "";

            for (int j = 1; j <= number_of_times - 1; j++)
            {
                // fade off:
                for (int i = 0; i < 8; i++)
                {
                    if (scorealert.VisitorsScore != scorealert.LastVisitorsScore)
                    {
                        if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "V")
                            possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                        else
                            possession_arrow = " ";

                        if (scorealert.VisitorsRanking > 0)
                            Ventuz_Property("GAME_TEAM1RANKING", scorealert.VisitorsRanking.ToString());
                        else
                            Ventuz_Property("GAME_TEAM1RANKING", "");

                        Ventuz_Property("GAMETEAM1", scorealert.VisitorsNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastVisitorsScore + "</SCOREFADE" + i + ">");
                    }
                    else
                    {
                        if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "H")
                            possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                        else
                            possession_arrow = " ";

                        if (scorealert.HomeRanking > 0)
                            Ventuz_Property("GAME_TEAM2RANKING", scorealert.VisitorsRanking.ToString());
                        else
                            Ventuz_Property("GAME_TEAM2RANKING", "");

                        Ventuz_Property("GAMETEAM2", scorealert.HomeNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastHomeScore + "</SCOREFADE" + i + ">");
                    }

                    Ventuz_Method("GAME_UPDATETEAMS");

                    System.Threading.Thread.Sleep(50);
                }

                // fade on:
                for (int i = 7; i >= 0; i--)
                {
                    if (scorealert.VisitorsScore != scorealert.LastVisitorsScore)
                    {
                        if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "V")
                            possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                        else
                            possession_arrow = " ";

                        if (scorealert.VisitorsRanking > 0)
                            Ventuz_Property("GAME_TEAM1RANKING", scorealert.VisitorsRanking.ToString());
                        else
                            Ventuz_Property("GAME_TEAM1RANKING", "");

                        Ventuz_Property("GAMETEAM1", scorealert.VisitorsNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastVisitorsScore + "</SCOREFADE" + i + ">");
                    }
                    else
                    {
                        if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "H")
                            possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                        else
                            possession_arrow = " ";

                        if (scorealert.HomeRanking > 0)
                            Ventuz_Property("GAME_TEAM2RANKING", scorealert.VisitorsRanking.ToString());
                        else
                            Ventuz_Property("GAME_TEAM2RANKING", "");

                        Ventuz_Property("GAMETEAM2", scorealert.HomeNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastHomeScore + "</SCOREFADE" + i + ">");
                    }

                    Ventuz_Method("GAME_UPDATETEAMS");

                    System.Threading.Thread.Sleep(50);
                }
            }

            // finally, fade off
            for (int i = 0; i < 8; i++)
            {
                if (scorealert.VisitorsScore != scorealert.LastVisitorsScore)
                {
                    if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "V")
                        possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                    else
                        possession_arrow = " ";

                    if (scorealert.VisitorsRanking > 0)
                        Ventuz_Property("GAME_TEAM1RANKING", scorealert.VisitorsRanking.ToString());
                    else
                        Ventuz_Property("GAME_TEAM1RANKING", "");

                    Ventuz_Property("GAMETEAM1", scorealert.VisitorsNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastVisitorsScore + "</SCOREFADE" + i + ">");
                }
                else
                {
                    if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "H")
                        possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                    else
                        possession_arrow = " ";

                    if (scorealert.HomeRanking > 0)
                        Ventuz_Property("GAME_TEAM2RANKING", scorealert.VisitorsRanking.ToString());
                    else
                        Ventuz_Property("GAME_TEAM2RANKING", "");

                    Ventuz_Property("GAMETEAM2", scorealert.HomeNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.LastHomeScore + "</SCOREFADE" + i + ">");
                }

                Ventuz_Method("GAME_UPDATETEAMS");

                System.Threading.Thread.Sleep(50);
            }

            // fade on with new sore:
            for (int i = 7; i >= 0; i--)
            {
                if (scorealert.VisitorsScore != scorealert.LastVisitorsScore)
                {
                    if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "V")
                        possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                    else
                        possession_arrow = " ";

                    if (scorealert.VisitorsRanking > 0)
                        Ventuz_Property("GAME_TEAM1RANKING", scorealert.VisitorsRanking.ToString());
                    else
                        Ventuz_Property("GAME_TEAM1RANKING", "");

                    Ventuz_Property("GAMETEAM1", scorealert.VisitorsNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.VisitorsScore + "</SCOREFADE" + i + ">");
                }
                else
                {
                    if (Details_Get(scorealert.DetailsPreScore, "possession").ToUpper() == "H")
                        possession_arrow = " <YELLOW>&#8734;</YELLOW> ";
                    else
                        possession_arrow = " ";

                    if (scorealert.HomeRanking > 0)
                        Ventuz_Property("GAME_TEAM2RANKING", scorealert.VisitorsRanking.ToString());
                    else
                        Ventuz_Property("GAME_TEAM2RANKING", "");

                    Ventuz_Property("GAMETEAM2", scorealert.HomeNickName.Trim() + possession_arrow + "<SCOREFADE" + i + ">" + scorealert.HomeScore + "</SCOREFADE" + i + ">");
                }

                Ventuz_Method("GAME_UPDATETEAMS");

                System.Threading.Thread.Sleep(50);
            }
        }

        private string Format_Record(int wins, int loss, int tie)
        {
            if (wins + loss + tie == 0)
            {
                return "";
            }
            else if (tie == 0)
            {
                return "<style color=\"200,200,200\" scale=\"0.82\" yoff=\"0.008\">( " + wins + "-" + loss + ") </style>";
            }
            else
            {
                return "<style color=\"200,200,200\" scale=\"0.82\" yoff=\"0.008\">( " + wins + "-" + loss + "-" + tie + ") </style>";
            }
        }

        private string Details_Get(string xmldetails, string property)
        {
            System.Xml.XmlDocument xmlData;
            string return_value = "";

            if (xmldetails != "")
            {
                xmlData = new System.Xml.XmlDocument();
                xmlData.LoadXml(xmldetails);

                // "<details possession=\"V\" ballspot=\"Ball on ARZ 12\" redzone=\"False\" />"
                return_value = xmlData["details"].Attributes[property].Value;

                xmlData = null;
            }


            return return_value;
        }

        private static string SnRVentuzTag(string note, string tag, string replaceTag)
        {
            string fulltag = "#" + tag + "#";
            int foundTag = 0;
            int foundDelimiter = 0;
            string replString = "";
            while (true)
            {
                foundTag = note.IndexOf(fulltag);
                if (foundTag > -1)
                {
                    foundDelimiter = note.IndexOf(' ', foundTag);
                    if (foundDelimiter == -1)
                        foundDelimiter = note.IndexOf('.', foundTag);

                    if (foundDelimiter > -1)
                    {
                        replString = note.Substring(foundTag + fulltag.Length, foundDelimiter - foundTag - fulltag.Length + 1);
                        note = note.Substring(0, foundTag) + "&lt;" + replaceTag + "&gt;" + replString + "&lt;/" + replaceTag + "&gt;" + note.Substring(foundDelimiter + 1, note.Length - foundDelimiter - 1);
                    }
                    else
                    {
                        replString = note.Substring(foundTag + fulltag.Length, note.Length - foundTag - fulltag.Length);
                        note = note.Substring(0, foundTag) + "&lt;" + replaceTag + "&gt;" + replString + "&lt;/" + replaceTag + "&gt;";
                        break;
                    }
                }
                else
                    break;
            }
            return note;

        }

        private static string ConvertToVentuz(string note)
        {
            //handle special characters
            note = note.Replace(char.ConvertFromUtf32(34), "&amp;#34;");
            note = note.Replace(char.ConvertFromUtf32(38), "&amp;#38;"); //&
            note = note.Replace(char.ConvertFromUtf32(93), "&amp;#93;");
            note = note.Replace(char.ConvertFromUtf32(60), "&amp;#60;");
            note = note.Replace(char.ConvertFromUtf32(62), "&amp;#62;");
          
            note = SnRVentuzTag(note, "WHITE", "DefaultColor");
            note = SnRVentuzTag(note, "YELLOW", "Color2");
            note = SnRVentuzTag(note, "RED", "Color3");
            note = SnRVentuzTag(note, "BLUE", "Color4");
            note = SnRVentuzTag(note, "GREEN", "Color5");
            note = SnRVentuzTag(note, "BLACK", "Color6");

            note = note.Replace("  ", " "); //replace double space w/single
            return note;
        }
    }
}
