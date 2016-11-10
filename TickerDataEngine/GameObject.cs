using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticker.Data;

namespace FOXTickerDataEngine
{
    public class GameObject
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        public List<spTICK_Games_GetByEntryID_Result> Games;
        List<spTICK_Games_GetByEntryID_Result>.Enumerator ieGames;
        spTICK_Games_GetByEntryID_Result game;

        public List<spTICK_Games_GetByEntryID_Result> GamesOmitted = new List<spTICK_Games_GetByEntryID_Result>();

        public int ID; //EntryID not GameID
        private int clientID;
        private int entryTypeID;
        bool bOnlySorted = false;
        bool bOnlyFinals = false;

        public GameObject()
        { }

        public void Load(int EntryID, int ClientID, int EntryTypeID, bool onlyFinals, bool onlySorted)
        {
            ID = EntryID;
            clientID = ClientID;
            entryTypeID = EntryTypeID;

            bOnlyFinals = onlyFinals;
            bOnlySorted = onlySorted;

            Games = db.spTICK_Games_GetByEntryID(clientID, ID, entryTypeID, bOnlyFinals, bOnlySorted).Except(GamesOmitted, new spTICK_Games_GetByEntryID_ResultComparer()).ToList();

            if (Games == null)
                throw new Exception("No Games available.");

            ieGames = Games.GetEnumerator();
        }

        // Custom comparer for the spTICK_Games_GetByEntryID_Result class 
        class spTICK_Games_GetByEntryID_ResultComparer : IEqualityComparer<spTICK_Games_GetByEntryID_Result>
        {
            // spTICK_Games_GetByEntryID_Results are equal if their names and spTICK_Games_GetByEntryID_Result numbers are equal. 
            public bool Equals(spTICK_Games_GetByEntryID_Result x, spTICK_Games_GetByEntryID_Result y)
            {

                //Check whether the compared objects reference the same data. 
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null. 
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the spTICK_Games_GetByEntryID_Results' properties are equal. 
                return x.ID == y.ID && x.Matchup == y.Matchup;
            }

            // If Equals() returns true for a pair of objects  
            // then GetHashCode() must return the same value for these objects. 

            public int GetHashCode(spTICK_Games_GetByEntryID_Result spTICK_Games_GetByEntryID_Result)
            {
                //Check whether the object is null 
                if (Object.ReferenceEquals(spTICK_Games_GetByEntryID_Result, null)) return 0;

                //Get hash code for the Matchup field if it is not null. 
                int hashspTICK_Games_GetByEntryID_ResultName = spTICK_Games_GetByEntryID_Result.Matchup == null ? 0 : spTICK_Games_GetByEntryID_Result.Matchup.GetHashCode();

                //Get hash code for the ID field. 
                int hashspTICK_Games_GetByEntryID_ResultCode = spTICK_Games_GetByEntryID_Result.ID.GetHashCode();

                //Calculate the hash code for the spTICK_Games_GetByEntryID_Result. 
                return hashspTICK_Games_GetByEntryID_ResultName ^ hashspTICK_Games_GetByEntryID_ResultCode;
            }

        }

        public spTICK_Games_GetByEntryID_Result GetNext()
        {
            ieGames.MoveNext();

            if (ieGames.Current == null) //if list appears exhausted, fetch from db again and see if new items appear
                if (db.spTICK_Games_GetByEntryID(clientID, ID, entryTypeID, bOnlyFinals, bOnlySorted).Count() > Games.Count())
                {
                    Games = db.spTICK_Games_GetByEntryID(clientID, ID, entryTypeID, bOnlyFinals, bOnlySorted).Except(GamesOmitted, new spTICK_Games_GetByEntryID_ResultComparer()).ToList();
                    List<spTICK_Games_GetByEntryID_Result>.Enumerator ieN;
                    ieN = Games.GetEnumerator();
                    for (int i = 0; i < Games.Count(); i++)
                    {
                        ieN.MoveNext();

                        if (ieN.Current == ieGames.Current)
                            break;
                    }
                    ieGames.MoveNext();
                }
                else
                    return null; //none left

            return ieGames.Current;
        }
    }
}
