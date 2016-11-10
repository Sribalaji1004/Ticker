using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOXTickerDataEngine
{
    public class NoteObject
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        public List<spTICK_Notes_GetByGroup_Result> groupNotes = new List<spTICK_Notes_GetByGroup_Result>();
        List<spTICK_Notes_GetByGroup_Result>.Enumerator iegroupNotes;
        spTICK_Notes_GetByGroup_Result groupNote;

        public List<spTICK_GameNotes_GetByGameID_Result> gameNotes = new List<spTICK_GameNotes_GetByGameID_Result>();
        List<spTICK_GameNotes_GetByGameID_Result>.Enumerator iegameNotes;
        spTICK_GameNotes_GetByGameID_Result gameNote;

        public List<spTICK_Notes_GetByGroup_Result> groupNotesOmitted = new List<spTICK_Notes_GetByGroup_Result>();
        public List<spTICK_GameNotes_GetByGameID_Result> gameNotesOmitted = new List<spTICK_GameNotes_GetByGameID_Result>();

        public int groupID;
        public int clientID;
        public int gameID;
        public enum NoteType { Group = 1, Game = 2 }
        public NoteType Type;

        public NoteObject()
        { }

        // Custom comparer for the spTICK_GameNotes_GetByGameID_Result class 
        class spTICK_GameNotes_GetByGameID_ResultComparer : IEqualityComparer<spTICK_GameNotes_GetByGameID_Result>
        {
            // spTICK_GameNotes_GetByGameID_Results are equal if their names and spTICK_GameNotes_GetByGameID_Result numbers are equal. 
            public bool Equals(spTICK_GameNotes_GetByGameID_Result x, spTICK_GameNotes_GetByGameID_Result y)
            {

                //Check whether the compared objects reference the same data. 
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null. 
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the spTICK_GameNotes_GetByGameID_Results' properties are equal. 
                return x.ID == y.ID;// && x.Note == y.Note;
                
            }

            // If Equals() returns true for a pair of objects  
            // then GetHashCode() must return the same value for these objects. 

            public int GetHashCode(spTICK_GameNotes_GetByGameID_Result spTICK_GameNotes_GetByGameID_Result)
            {
                //Check whether the object is null 
                if (Object.ReferenceEquals(spTICK_GameNotes_GetByGameID_Result, null)) return 0;

                //Get hash code for the Note field if it is not null. 
                //int hashspTICK_GameNotes_GetByGameID_ResultName = spTICK_GameNotes_GetByGameID_Result.Note == null ? 0 : spTICK_GameNotes_GetByGameID_Result.Note.GetHashCode();

                //Get hash code for the ID field. 
                int hashspTICK_GameNotes_GetByGameID_ResultCode = spTICK_GameNotes_GetByGameID_Result.ID.GetHashCode();

                //Calculate the hash code for the spTICK_GameNotes_GetByGameID_Result. 
                //return hashspTICK_GameNotes_GetByGameID_ResultName;// ^ hashspTICK_GameNotes_GetByGameID_ResultCode;
                return hashspTICK_GameNotes_GetByGameID_ResultCode;
            }

        }

        // Custom comparer for the spTICK_Notes_GetByGroup_Result class 
        class spTICK_Notes_GetByGroup_ResultComparer : IEqualityComparer<spTICK_Notes_GetByGroup_Result>
        {
            // spTICK_Notes_GetByGroup_Results are equal if their names and spTICK_Notes_GetByGroup_Result numbers are equal. 
            public bool Equals(spTICK_Notes_GetByGroup_Result x, spTICK_Notes_GetByGroup_Result y)
            {

                //Check whether the compared objects reference the same data. 
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null. 
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the spTICK_Notes_GetByGroup_Results' properties are equal. 
                return x.ID == y.ID;// && x.Note == y.Note;
            }

            // If Equals() returns true for a pair of objects  
            // then GetHashCode() must return the same value for these objects. 

            public int GetHashCode(spTICK_Notes_GetByGroup_Result spTICK_Notes_GetByGroup_Result)
            {
                //Check whether the object is null 
                if (Object.ReferenceEquals(spTICK_Notes_GetByGroup_Result, null)) return 0;

                //Get hash code for the Note field if it is not null. 
                //int hashspTICK_Notes_GetByGroup_ResultName = spTICK_Notes_GetByGroup_Result.Note == null ? 0 : spTICK_Notes_GetByGroup_Result.Note.GetHashCode();

                //Get hash code for the ID field. 
                int hashspTICK_Notes_GetByGroup_ResultCode = spTICK_Notes_GetByGroup_Result.ID.GetHashCode();

                //Calculate the hash code for the spTICK_Notes_GetByGroup_Result. 
                //return hashspTICK_Notes_GetByGroup_ResultName;// ^ hashspTICK_Notes_GetByGroup_ResultCode;
                return hashspTICK_Notes_GetByGroup_ResultCode;
            }

        }

        public void LoadGame(int GameID, int ClientID)
        {

            Type = NoteType.Game;
            gameID = GameID;
            clientID = ClientID;

            try
            {
                gameNotes = db.spTICK_GameNotes_GetByGameID(gameID, clientID).Except(gameNotesOmitted, new spTICK_GameNotes_GetByGameID_ResultComparer()).ToList();
            }
            catch (Exception ex)
            {
                if (ex.Message == "The underlying provider failed on Open.")
                {
                    throw ex;
                }
            }
            if (gameNotes == null)
                throw new Exception("No Notes available.");

            iegameNotes = gameNotes.GetEnumerator();
        }

        public void LoadGroup(int GroupID, int ClientID)
        {
            Type = NoteType.Group;
            groupID = GroupID;
            clientID = ClientID;

            groupNotes = db.spTICK_Notes_GetByGroup(groupID, clientID).Except(groupNotesOmitted, new spTICK_Notes_GetByGroup_ResultComparer()).ToList();
            if (groupNotes == null)
                throw new Exception("No Notes available.");

            iegroupNotes = groupNotes.GetEnumerator();
        }
        public Object GetNext()
        {
            switch (Type)
            {
                case NoteType.Group:
                    //if (iegroupNotes.Current == null)
                    //{
                    iegroupNotes.MoveNext();

                    if (iegroupNotes.Current != null)
                        return iegroupNotes.Current;
                    //}

                    if (iegroupNotes.Current == null) //if list appears exhausted, fetch from db again and see if new items appear
                    {
                        if (db.spTICK_Notes_GetByGroup(groupID, clientID).Count() > groupNotes.Count())
                        {
                            groupNotes = db.spTICK_Notes_GetByGroup(groupID, clientID).Except(groupNotesOmitted, new spTICK_Notes_GetByGroup_ResultComparer()).ToList();
                            List<spTICK_Notes_GetByGroup_Result>.Enumerator ieN;
                            ieN = groupNotes.GetEnumerator();
                            for (int i = 0; i < groupNotes.Count(); i++)
                            {
                                ieN.MoveNext();

                                if (ieN.Current == iegroupNotes.Current)
                                    break;
                            }
                            iegroupNotes.MoveNext();
                        }
                        else
                            return null; //none left
                    }

                    break;
                case NoteType.Game:
                    //if (iegameNotes.Current == null)
                    //{
                    iegameNotes.MoveNext();
                    if (iegameNotes.Current != null)
                        return iegameNotes.Current;
                    //}

                    if (iegameNotes.Current == null) //if list appears exhausted, fetch from db again and see if new items appear
                    {

                        if (db.spTICK_GameNotes_GetByGameID(gameID, clientID).Count() > gameNotes.Count())
                        {
                            gameNotes = db.spTICK_GameNotes_GetByGameID(gameID, clientID).Except(gameNotesOmitted, new spTICK_GameNotes_GetByGameID_ResultComparer()).ToList();
                            List<spTICK_GameNotes_GetByGameID_Result>.Enumerator ieN;
                            ieN = gameNotes.GetEnumerator();
                            for (int i = 0; i < gameNotes.Count(); i++)
                            {
                                ieN.MoveNext();

                                if (ieN.Current == iegameNotes.Current)
                                    break;
                            }
                            iegameNotes.MoveNext();
                        }
                        else
                            return null; //none left
                    }

                    break;
            }
            return null;
        }
    }
}
