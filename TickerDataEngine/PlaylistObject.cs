using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using Ticker.Data;

namespace FOXTickerDataEngine
{
    public class PlaylistObject
    {
        private Logger logger = LogManager.GetLogger("FOXTickerDataEngine");
        private FoxTickerEntities db = new FoxTickerEntities();
        public List<spTICK_Playlist_Details_Get_Result> spTICK_Playlist_Details_Get_Results;
        List<spTICK_Playlist_Details_Get_Result>.Enumerator iespTICK_Playlist_Details_Get_Results;
        spTICK_Playlist_Details_Get_Result pld; //current

        public List<spTICK_Playlist_Details_Get_Result> playlistdetailsOmitted = new List<spTICK_Playlist_Details_Get_Result>();

        public bool OmissionsExist(int ID)
        {
            return (playlistdetailsOmissions.Where(pldow => pldow.ID == ID).Count() > 0);
        }
        public PlaylistDetailOmissions CreateOmission(int ID)
        {
            PlaylistDetailOmissions newPLDO = new PlaylistDetailOmissions();
            newPLDO.ID = ID;
            playlistdetailsOmissions.Add(newPLDO);
            return playlistdetailsOmissions.Where(pldow => pldow.ID == ID).First();
        }
        public List<PlaylistDetailOmissions> playlistdetailsOmissions = new List<PlaylistDetailOmissions>();
        public class PlaylistDetailOmissions
        {
            public int ID;
            public List<GameObject> gamesOmitted = new List<GameObject>();
            public List<NoteObject> notesOmitted = new List<NoteObject>();
        }

        // Properties universal to all playlist objects - basically spTICK_Playlist_Details_Get_Results table.
        public string Name;
        public string OnAirName;
        public spTICK_Playlist_Details_Get_Result PlaylistDetailCurrent;
        public int? SortOrder;
        public bool OnAir = false;
        public bool Checked = true;

        // Object can contain only one of these:
        public Group GroupObject = null;
        private GameObject oGame = new GameObject();
        public spTICK_Games_GetByEntryID_Result game;

        public enum PlaylistType { None = 0, Group = 1, Games = 2, Game = 3 }
        public PlaylistType Type;

        private NoteObject oNote = new NoteObject();
        private Object note;
        private Object go;

        public int ID;

        public PlaylistObject()
        { }


        // Custom comparer for the spTICK_Playlist_Details_Get_Result class 
        class spTICK_Playlist_Details_Get_ResultComparer : IEqualityComparer<spTICK_Playlist_Details_Get_Result>
        {
            // spTICK_Playlist_Details_Get_Results are equal if their names and spTICK_Playlist_Details_Get_Result numbers are equal. 
            public bool Equals(spTICK_Playlist_Details_Get_Result x, spTICK_Playlist_Details_Get_Result y)
            {

                //Check whether the compared objects reference the same data. 
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null. 
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the spTICK_Playlist_Details_Get_Results' properties are equal. 
                return x.PlaylistDetailsID == y.PlaylistDetailsID && x.OnAirName == y.OnAirName;
            }

            // If Equals() returns true for a pair of objects  
            // then GetHashCode() must return the same value for these objects. 

            public int GetHashCode(spTICK_Playlist_Details_Get_Result spTICK_Playlist_Details_Get_Result)
            {
                //Check whether the object is null 
                if (Object.ReferenceEquals(spTICK_Playlist_Details_Get_Result, null)) return 0;

                //Get hash code for the OnAirName field if it is not null. 
                int hashspTICK_Playlist_Details_Get_ResultName = spTICK_Playlist_Details_Get_Result.OnAirName == null ? 0 : spTICK_Playlist_Details_Get_Result.OnAirName.GetHashCode();

                //Get hash code for the ID field. 
                int hashspTICK_Playlist_Details_Get_ResultCode = spTICK_Playlist_Details_Get_Result.PlaylistDetailsID.GetHashCode();

                //Calculate the hash code for the spTICK_Playlist_Details_Get_Result. 
                return hashspTICK_Playlist_Details_Get_ResultName ^ hashspTICK_Playlist_Details_Get_ResultCode;
            }

        }

        public void Reset()
        {
            Type = PlaylistType.None;
            oNote = new NoteObject();
            oGame = new GameObject();
            game = null;
            note = null;
            //iespTICK_Playlist_Details_Get_Results = spTICK_Playlist_Details_Get_Results.GetEnumerator();
        }

        public void Load(int PlaylistID)//, List<spTICK_Playlist_Details_Get_Result> spTICK_Playlist_Details_Get_ResultsOmitted, List<GameObject> GamesOmitted, List<NoteObject> NotesOmitted)
        {
            ID = PlaylistID;
            //spTICK_Playlist_Details_Get_ResultsOmitted = spTICK_Playlist_Details_Get_ResultsOmitted;
            //gamesOmitted = GamesOmitted;
            //notesOmitted = NotesOmitted;
            spTICK_Playlist_Details_Get_Results = null;
            spTICK_Playlist_Details_Get_Results = db.spTICK_Playlist_Details_Get(ID).ToList();
            spTICK_Playlist_Details_Get_Results = spTICK_Playlist_Details_Get_Results.Except(playlistdetailsOmitted, new spTICK_Playlist_Details_Get_ResultComparer()).ToList();
            spTICK_Playlist_Details_Get_Results = spTICK_Playlist_Details_Get_Results.OrderBy(pldo => pldo.SortOrder).ToList();
            if (spTICK_Playlist_Details_Get_Results == null)
                throw new Exception("No Playlist Details available.");

            iespTICK_Playlist_Details_Get_Results = spTICK_Playlist_Details_Get_Results.GetEnumerator();
            Reset();
            logger.Trace("PlaylistObject Load", PlaylistID, spTICK_Playlist_Details_Get_Results.Count());

        }

        public class Empty
        {
        }

        bool bEmptyNote = false;

        // Will be game or note.
        public Object GetNext()
        {

            //try to process note (if any)
            if (iespTICK_Playlist_Details_Get_Results.Current != null && (Type == PlaylistType.None || Type == PlaylistType.Group))
                note = ProcessNote();
            if (note != null)
            {
                return note;
            }

            //check if already have group or game open
            //if (iespTICK_Playlist_Details_Get_Results.Current != null && (Type == PlaylistType.None || Type == PlaylistType.Group || Type == PlaylistType.Game))
            if (Type == PlaylistType.None || Type == PlaylistType.Group || (Type == PlaylistType.Game && bEmptyNote))
            {
                try
                {
                    iespTICK_Playlist_Details_Get_Results.MoveNext();
                }
                catch (Exception ex)
                {
                    logger.Trace("GetNext", "Tried to movenext on " + ex.Message);
                }

                if (iespTICK_Playlist_Details_Get_Results.Current == null) //if list appears exhausted, fetch from db again and see if new items appear
                {

                    List<spTICK_Playlist_Details_Get_Result> testspTICK_Playlist_Details_Get_Result = db.spTICK_Playlist_Details_Get(ID).ToList();
                    if (testspTICK_Playlist_Details_Get_Result != null)
                    {
                        if (spTICK_Playlist_Details_Get_Results == null)
                            return null; //none left

                        if (spTICK_Playlist_Details_Get_Results.Except(playlistdetailsOmitted, new spTICK_Playlist_Details_Get_ResultComparer()) != null)
                            testspTICK_Playlist_Details_Get_Result = spTICK_Playlist_Details_Get_Results.Except(playlistdetailsOmitted, new spTICK_Playlist_Details_Get_ResultComparer()).ToList();
                        else
                            return null; //none left

                        if (testspTICK_Playlist_Details_Get_Result.Count() > spTICK_Playlist_Details_Get_Results.Count())
                        {
                            logger.Trace("GetNext", "Relaod from db");
                            Load(ID); //reload from db
                        }
                        else
                            return null; //none left
                    }
                    else
                        return null; //none left
                }
            }
            bEmptyNote = false;

            pld = iespTICK_Playlist_Details_Get_Results.Current;
            PlaylistDetailCurrent = pld;

            if (pld != null)
            {
                logger.Trace("GetNext - Playlist_Details_Get_Results " + pld.PlaylistDetailsID + " " + pld.Name);
                switch (pld.EntryTypeID)
                {
                    case 1: //A group.  The GroupID is defined in the EntryID field.
                        List<Group> groups = db.Groups.Where(g => g.ID == pld.EntryID).ToList();
                        if (groups.Count() > 0)
                        {
                            Type = PlaylistType.Group;
                            GroupObject = groups.First();
                            if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).Count() > 0)
                                if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().notesOmitted.Where(now => now.groupID == GroupObject.ID).Count() > 0)
                                    oNote.groupNotesOmitted = playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().notesOmitted.Where(now => now.groupID == GroupObject.ID).First().groupNotesOmitted;
                            oNote.LoadGroup(GroupObject.ID, GroupObject.ClientID);

                            Name = GroupObject.Name;// nte.Header;
                            OnAirName = GroupObject.OnAirName;
                            note = ProcessNote();
                            if (note != null)
                            {
                                return note;
                            }
                            else
                            {
                                bEmptyNote = true;
                                return new Empty(); //none left
                            }
                        }
                        break;
                    case 2: //A singular game.  The GameID is defined in the EntryID field
                        Type = PlaylistType.Game;
                        go = ProcessGame();
                        if (go != null)
                        {
                            return go;
                        }
                        else
                        {
                            bEmptyNote = true;
                            return new Empty(); //none left
                        }
                    //break;
                    case 3: //All games for a given sport for today.  The sport is defined in the EntryID field.
                        Type = PlaylistType.Games;
                        go = ProcessGame();
                        if (go != null)
                        {
                            return go;
                        }
                        else
                        {
                            bEmptyNote = true;
                            return new Empty(); //none left
                        }

                    //break;
                    case 4: //All games for a given sport prior to today.  The sport is defined in the EntryID field.
                        Type = PlaylistType.Games;
                        go = ProcessGame();
                        if (go != null)
                        {
                            return go;
                        }
                        else
                        {
                            bEmptyNote = true;
                            return new Empty(); //none left
                        }

                    //break;
                    case 5: //Ads
                        break;
                }
            }

            return pld;
        }

        spTICK_Games_GetByEntryID_Result curGame = null;
        bool gameNotes = false;
        public bool bOnlySorted = false;
        public bool bOnlyFinals = false;

        private object ProcessGame()
        {
            if (curGame != null)
            {
                if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).Count() > 0)
                    if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().notesOmitted.Where(now => now.gameID == curGame.ID).Count() > 0)
                        oNote.gameNotesOmitted = playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().notesOmitted.Where(now => now.gameID == curGame.ID).First().gameNotesOmitted;
                if (!gameNotes)
                    oNote.LoadGame(curGame.ID, 18);
                //if (oNote != null)
                //    return oNote;
                if (oNote.gameNotes.Count() > 0)
                {
                    gameNotes = true;
                    object retval = ProcessNote();
                    if (retval != null)
                        return retval;
                }
                curGame = null;
                gameNotes = false;
            }

            if (game == null)
            {
                if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).Count() > 0)
                    if (playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().gamesOmitted.Where(now => now.ID == ID).Count() > 0)
                        oGame.GamesOmitted = playlistdetailsOmissions.Where(plow => plow.ID == pld.PlaylistDetailsID).First().gamesOmitted.Where(now => now.ID == ID).First().GamesOmitted;

                oGame.Load(pld.EntryID, 18, pld.EntryTypeID, bOnlyFinals, bOnlySorted);
            }
            game = oGame.GetNext();

            if (game != null)
            {
                Name = game.Matchup;
                OnAirName = pld.OnAirName;



                Name = game.Matchup;
                OnAirName = pld.OnAirName;
                curGame = game;
                logger.Trace("GetNext - ProcessGame - Group " + game.ID + " " + game.Matchup);

                return game;
            }
            else
                Type = PlaylistType.None;

            return null;
        }

        bool bSameAsLastNote = false;
        object lastNote;

        private object ProcessNote()
        {

            if (bSameAsLastNote)
            {
                bSameAsLastNote = false;
                return lastNote;
            }
            switch (oNote.Type)
            {
                case NoteObject.NoteType.Group:
                    spTICK_Notes_GetByGroup_Result groupNote = (spTICK_Notes_GetByGroup_Result)oNote.GetNext();
                    if (groupNote != null)
                    {
                        if (lastNote != null)
                            if (lastNote.GetType().Name == groupNote.GetType().Name)
                                if (((spTICK_Notes_GetByGroup_Result)lastNote).ID == groupNote.ID)
                                {
                                    bSameAsLastNote = true;

                                    spTICK_Notes_GetByGroup_Result blank = new spTICK_Notes_GetByGroup_Result();
                                    blank.Note = "";// DateTime.Now.ToString();
                                    blank.NoteColor = "";// DateTime.Now.ToString();

                                    return blank;
                                }
                        lastNote = groupNote;
                        Name = groupNote.Note;
                        OnAirName = GroupObject.OnAirName;
                        SortOrder = groupNote.SortOrder;

                        logger.Trace("GetNext - ProcessNote - Group " + groupNote.ID + " " + groupNote.Note);
                        return groupNote;
                    }
                    break;
                case NoteObject.NoteType.Game:
                    spTICK_GameNotes_GetByGameID_Result gameNote = (spTICK_GameNotes_GetByGameID_Result)oNote.GetNext();

                    if (gameNote != null)
                    {
                        if (lastNote != null)
                            if (lastNote.GetType().Name == gameNote.GetType().Name)
                                if (((spTICK_GameNotes_GetByGameID_Result)lastNote).ID == gameNote.ID)
                                {
                                    bSameAsLastNote = true;
                                    spTICK_GameNotes_GetByGameID_Result blank = new spTICK_GameNotes_GetByGameID_Result();
                                    blank.Note = "";// DateTime.Now.ToString();
                                    blank.NoteColor = "";// DateTime.Now.ToString();

                                    return blank;
                                }
                        lastNote = gameNote;
                        Name = gameNote.Note;
                        OnAirName = pld.OnAirName;
                        SortOrder = gameNote.SortOrder;
                        logger.Trace("GetNext - ProcessNote - Game " + gameNote.ID + " " + gameNote.Note);
                        return gameNote;
                    }
                    break;
            }
            return null;
        }

        private object ProcessGames()
        {

            game = oGame.GetNext();

            if (game != null)
            {
                Name = game.Matchup;
                OnAirName = pld.OnAirName;
                SortOrder = game.SortOrder;
                return game;
            }

            return null;
        }
    }
}
