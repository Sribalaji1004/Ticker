using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Ticker.Data;
using System.Dynamic;

namespace Ticker.Controllers
{
    public class PlaylistItemsController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/playlistitems
        //public IEnumerable<dynamic> GetPlaylistItems(int id)
        //{
        //    var Playlist = db.Playlists.Where(gw => gw.ClientID == id);
        //    if (Playlist == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    Playlist.ToList().ForEach(a => a.PlaylistDetails.Load());

        //    return Playlist.Select(p =>
        //        new
        //        {
        //            p.ID,
        //            p.Name,
        //            hasChildren = p.PlaylistDetails.Any()// .Select(pd => new { ID = pd.ID, Name = pd.OnAirName }).Any()
        //            //p.PlaylistDetails.Select(pd => new Dictionary<string, object>{{"ID", pd.ID}, {"Name",pd.OnAirName} })
        //        })
        //        ;
        //}
        public IEnumerable<dynamic> GetPlaylistItems(int id)
        {
            var Playlist = db.Playlists.Where(gw => gw.ID == id);
            if (Playlist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            Playlist.ToList().ForEach(a => a.PlaylistDetails.Load());

            return Playlist.Select(p =>
                new
                {
                    p.ID,
                    p.Name,
                    hasChildren = p.PlaylistDetails.Any()// .Select(pd => new { ID = pd.ID, Name = pd.OnAirName }).Any()
                    //p.PlaylistDetails.Select(pd => new Dictionary<string, object>{{"ID", pd.ID}, {"Name",pd.OnAirName} })
                })
                ;
        }

        public IEnumerable<dynamic> GetPlaylistItems(int cid, int playlistID)
        {
            var spTICK_Playlist_Details_Get_Result = db.spTICK_Playlist_Details_Get(playlistID).OrderBy(pldo => pldo.SortOrder);
            if (spTICK_Playlist_Details_Get_Result == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return spTICK_Playlist_Details_Get_Result.Select(g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.PlaylistDetailsID,
                g.EntryID,
                g.OnAirName,
                g.EntryTypeID,
                g.Header,
                g.HivePrefix,
                g.PlaylistID,
                g.SortOrder,
                g.Name,
                g.SportDescription,
                g.SportID,
                g.SportShortDisplay,
                g.SportType,
                g.TeamCityName,
                g.TeamID,
                g.TeamNickName,
                g.TeamPrimaryColor,
                g.TeamSecondaryColor,
                g.Type
                ,
                g.DataSource,
                hasChildren = (g.EntryTypeID == (int)Ticker.Data.Enums.EntryType.Group ? db.Notes.Where(gn => gn.GroupID == g.EntryID).Any() :
                g.EntryTypeID == (int)Ticker.Data.Enums.EntryType.HiveGame ? db.GameHiveNotes.Where(gn => gn.HiveID == g.Header).Any() :
                g.EntryTypeID == (int)Ticker.Data.Enums.EntryType.GroupOfGames ? db.GroupGames.Where(gn => gn.GroupID == g.EntryID).Any() :
                db.GameNotes.Where(gn => gn.GameID == g.EntryID).Any()) // true//GetPlaylistItems(id, g.EntryID, g.EntryTypeID).Any()
                ,
                g.RipCount,
                g.NotesTypeID
            }); ;
        }
        private class PlaylistDetailsType
        {
            public int ID;
            public string Name;
            public string ObjectType;
            public bool hasChildren;
            public PlaylistDetailsType(int id, string name, string objectType, bool HasChildren)
            {
                ID = id;
                Name = name;
                ObjectType = objectType;
                hasChildren = HasChildren;
            }
        }

        public class GroupSelectable
        {
            public int ClientID;
            public string CreatedName;
            public bool? Editable;
            public int GroupAnimationTypeID;
            public string Header;
            public int ID;
            public DateTime LastUpdated;
            public string Name;

            public string OnAirName;
            public int? TeamID;
            public string Type;

            public string ObjectType;

            public bool hasChildren;
        }

        public IEnumerable<dynamic> GetPlaylistItems(int cid, string Type)
        {
            Utilities.LoadClientShares(db, cid);

            List<GroupSelectable> retGroups = new List<GroupSelectable>();

            if (Type == "null")
            {
                Type = "User Created";
                //foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                //{
                //    var t = db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID && gw.Type == null).Select(g => new
                //GroupSelectable
                //    {
                //        // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //        ClientID = g.ClientID,
                //        CreatedName = g.CreatedName,
                //        Editable = g.Editable,
                //        GroupAnimationTypeID = g.GroupAnimationTypeID,
                //        Header = g.Header,
                //        ID = g.ID,
                //        LastUpdated = g.LastUpdated,
                //        Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                //        //g.Notes,
                //        OnAirName = g.OnAirName,
                //        TeamID = g.TeamID,
                //        Type = g.Type
                //    ,
                //        ObjectType = "Group"
                //     ,
                //        hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                //    });
                //    retGroups = retGroups.Concat(t).ToList();

                //    retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID && gw.Type == null).Select(g => new
                //    GroupSelectable
                //    {
                //        // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //        ClientID = g.ClientID,
                //        CreatedName = g.CreatedName,
                //        Editable = g.Editable,
                //        GroupAnimationTypeID = g.GroupAnimationTypeID,
                //        Header = g.Header,
                //        ID = g.ID,
                //        LastUpdated = g.LastUpdated,
                //        Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                //        //g.Notes,
                //        OnAirName = g.OnAirName,
                //        TeamID = g.TeamID,
                //        Type = g.Type
                //        ,
                //        ObjectType = "Group"
                //         ,
                //        hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                //    }));
                //}

                //retGroups = retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == cid && gw.Type == null).Select(g => new
                //GroupSelectable
                //{
                //    ClientID = g.ClientID,
                //    CreatedName = g.CreatedName,
                //    Editable = g.Editable,
                //    GroupAnimationTypeID = g.GroupAnimationTypeID,
                //    Header = g.Header,
                //    ID = g.ID,
                //    LastUpdated = g.LastUpdated,
                //    Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                //    //g.Notes,
                //    OnAirName = g.OnAirName,
                //    TeamID = g.TeamID,
                //    Type = g.Type
                //    ,
                //    ObjectType = "Group"
                //     ,
                //    hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                //})).ToList();

                //return retGroups;
            }
            //else
            switch (Type)
            {
                case "Game Group":
                    {
                        foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                            retGroups = retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID && gw.Type == Type).Select(g => new
                            GroupSelectable
                            {
                                ClientID = g.ClientID,
                                CreatedName = g.CreatedName,
                                Editable = g.Editable,
                                GroupAnimationTypeID = g.GroupAnimationTypeID,
                                Header = g.Header,
                                ID = g.ID,
                                LastUpdated = g.LastUpdated,
                                Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.GroupGames.Where(gn => gn.GroupID == g.ID).Count()),//db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                                //g.Notes,
                                OnAirName = g.OnAirName,
                                TeamID = g.TeamID,
                                Type = g.Type
                ,
                                ObjectType = "Group"
                 ,
                                hasChildren = false//db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                            })).ToList();

                        return retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == cid && gw.Type == Type).Select(g => new
                        GroupSelectable
                        {
                            ClientID = g.ClientID,
                            CreatedName = g.CreatedName,
                            Editable = g.Editable,
                            GroupAnimationTypeID = g.GroupAnimationTypeID,
                            Header = g.Header,
                            ID = g.ID,
                            LastUpdated = g.LastUpdated,
                            Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.GroupGames.Where(gn => gn.GroupID == g.ID).Count()),//db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                            //g.Notes,
                            OnAirName = g.OnAirName,
                            TeamID = g.TeamID,
                            Type = g.Type
                         ,
                            ObjectType = "Group"
                          ,
                            hasChildren = false//db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                        }));
                    }
                default:
                    {
                        foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                        {
                            var tg = db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID && gw.Type == Type).Select(g => new
                            GroupSelectable
                            {
                                ClientID = g.ClientID,
                                CreatedName = g.CreatedName,
                                Editable = g.Editable,
                                GroupAnimationTypeID = g.GroupAnimationTypeID,
                                Header = g.Header,
                                ID = g.ID,
                                LastUpdated = g.LastUpdated,
                                Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                                //g.Notes,
                                OnAirName = g.OnAirName,
                                TeamID = g.TeamID,
                                Type = g.Type
                ,
                                ObjectType = "Group"
                 ,
                                hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                            }).Where(p => true);
                            retGroups = retGroups.Concat(tg).ToList();

                            retGroups = retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID && gw.Type == Type).Select(g => new
                            GroupSelectable
                            {
                                ClientID = g.ClientID,
                                CreatedName = g.CreatedName,
                                Editable = g.Editable,
                                GroupAnimationTypeID = g.GroupAnimationTypeID,
                                Header = g.Header,
                                ID = g.ID,
                                LastUpdated = g.LastUpdated,
                                Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                                //g.Notes,
                                OnAirName = g.OnAirName,
                                TeamID = g.TeamID,
                                Type = g.Type
                ,
                                ObjectType = "Group"
                 ,
                                hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                            })).ToList();

                        }

                        return retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == cid && gw.Type == Type).Select(g => new
                        GroupSelectable
                        {
                            ClientID = g.ClientID,
                            CreatedName = g.CreatedName,
                            Editable = g.Editable,
                            GroupAnimationTypeID = g.GroupAnimationTypeID,
                            Header = g.Header,
                            ID = g.ID,
                            LastUpdated = g.LastUpdated,
                            Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                            //g.Notes,
                            OnAirName = g.OnAirName,
                            TeamID = g.TeamID,
                            Type = g.Type
                ,
                            ObjectType = "Group"
                 ,
                            hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                        }));
                    }
            }
        }

        public IEnumerable<dynamic> GetPlaylistItems(int cid, int entryID, int EntryTypeID)
        {
            Utilities.LoadClientShares(db, cid);

            List<dynamic> retGroups = new List<dynamic>();

            if (entryID == 0)
                switch (EntryTypeID)
                {
                    case (int)Ticker.Data.Enums.EntryType.Group: //A group.  The GroupID is defined in the EntryID field.
                        {
                            foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                                retGroups = retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == c.ID).Select(g => new
                                {
                                    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                                    g.ClientID,
                                    g.CreatedName,
                                    g.Editable,
                                    g.GroupAnimationTypeID,
                                    g.Header,
                                    g.ID,
                                    g.LastUpdated,
                                    Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                                    //g.Notes,
                                    g.OnAirName,
                                    g.TeamID,
                                    g.Type
                                    ,
                                    ObjectType = "Group"
                                     ,
                                    hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                                })).ToList();

                            return retGroups.Concat(db.Groups.OrderBy(gob => gob.Name).Where(gw => gw.ClientID == cid).Select(g => new
                            {
                                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                                g.ClientID,
                                g.CreatedName,
                                g.Editable,
                                g.GroupAnimationTypeID,
                                g.Header,
                                g.ID,
                                g.LastUpdated,
                                Name = g.Name + " -" + System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)db.Notes.Where(gn => gn.GroupID == g.ID).Count()),
                                //g.Notes,
                                g.OnAirName,
                                g.TeamID,
                                g.Type
                                ,
                                ObjectType = "Group"
                                 ,
                                hasChildren = db.Notes.Where(gn => gn.GroupID == g.ID).Any()
                            }));
                        }

                    case (int)Ticker.Data.Enums.EntryType.TodaysGames: //All games for a given sport for today.  The sport is defined in the EntryID field.
                        {
                            foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                                retGroups = retGroups.Concat(db.spTICK_Games_GetByEntryID(cid, entryID, entryTypeID: EntryTypeID, onlyFinals: false, onlySorted: false).Select(g => new
                                {
                                    g.ID,
                                    Name = g.Matchup,
                                    ObjectType = "Game",
                                    hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: entryID, clientID: c.ID).Any()
                                })).ToList();

                            return retGroups.Concat(db.spTICK_Games_GetByEntryID(cid, entryID, entryTypeID: EntryTypeID, onlyFinals: false, onlySorted: false).Select(g => new
                            {
                                g.ID,
                                Name = g.Matchup,
                                ObjectType = "Game",
                                hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: entryID, clientID: cid).Any()
                            }));
                        }
                    //         return db.PlaylistDetails.Where(pldw => pldw.EntryID == groupID).Select(g => new
                    //{
                    //    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                    //    g.EntryID,
                    //    Name = g.OnAirName,
                    //    g.EntryTypeID,
                    //    g.PlaylistID,
                    //    g.SortOrder,
                    //    hasChildren = true
                    //}); ;



                    default:
                        return null;
                }
            else
                switch (EntryTypeID)
                {
                    case (int)Ticker.Data.Enums.EntryType.Group: //A group.  The GroupID is defined in the EntryID field.
                        return db.Groups.Where(gw => gw.ID == entryID).Select(g => new
                        {
                            // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                            g.ClientID,
                            g.CreatedName,
                            g.Editable,
                            g.GroupAnimationTypeID,
                            g.Header,
                            g.ID,
                            g.LastUpdated,
                            Name = g.OnAirName,
                            //g.Notes,
                            g.OnAirName,
                            g.TeamID,
                            g.Type
                            ,
                            ObjectType = "Group"
                             ,
                            hasChildren = db.Notes.Where(gn => gn.GroupID == entryID).Any()
                        });
                    default:
                        return null;

                    case (int)Ticker.Data.Enums.EntryType.TodaysGames: //All games for a given sport for today.  The sport is defined in the EntryID field.
                        {
                            foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                                retGroups = retGroups.Concat(db.spTICK_Games_GetByEntryID(cid, entryID, entryTypeID: EntryTypeID, onlyFinals: false, onlySorted: false).Select(g => new
                                {
                                    g.ID,
                                    Name = g.Matchup,
                                    ObjectType = "Game",
                                    hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: entryID, clientID: c.ID).Any()
                                })).ToList();


                            return retGroups.Concat(db.spTICK_Games_GetByEntryID(cid, entryID, entryTypeID: EntryTypeID, onlyFinals: false, onlySorted: false).Select(g => new
                            {
                                g.ID,
                                Name = g.Matchup,
                                ObjectType = "Game",
                                hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: entryID, clientID: cid).Any()
                            }));
                        }

                    //spTICK_Games_GetByEntryID_Result a = new spTICK_Games_GetByEntryID_Result();

                    //dynamic a = new PlaylistDetailsType();
                    //dynamic a = new []{ new {ID = 0}, new {Name = "Today"}, new {ObjectType = "Game"}, new {hasChildren = false} };
                    //a.ID=0;
                    //a.Name="Today";
                    //a.ObjectType="Game";
                    //a.hasChildren=false;
                    //var a = new { ID = 0, Name = "Today", ObjectType = "Game", hasChildren = false };
                    ////IEnumerable<dynamic> b = a;
                    ////ret.Concat(new []{ new {ID = 0}, new {Name = "Today"}, new {ObjectType = "Game"}, new {hasChildren = false} });
                    //ret.Concat(Enumerable.Repeat(a, 1));
                    //ret.Concat(db.spTICK_Games_GetByEntryID(id, entryID, entryTypeID: EntryTypeID, onlyFinals: false, onlySorted: false).Select(g => new
                    //{
                    //    g.ID,
                    //    Name = g.Matchup,
                    //    ObjectType = "Game",
                    //    hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: entryID, clientID: id).Any()
                    //}));
                    //return ret;
                    //         return db.PlaylistDetails.Where(pldw => pldw.EntryID == groupID).Select(g => new
                    //{
                    //    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                    //    g.EntryID,
                    //    Name = g.OnAirName,
                    //    g.EntryTypeID,
                    //    g.PlaylistID,
                    //    g.SortOrder,
                    //    hasChildren = true
                    //}); ;

                    case (int)Ticker.Data.Enums.EntryType.GroupOfGames:
                        return db.GroupGames.Where(gw => gw.GroupID == entryID)
                 .Select(sg => new { sg.ID, sg.HiveID, sg.GroupID, sg.GameID, sg.SportID, sg.SortOrder })
                 .AsEnumerable()
                 .OrderBy(o => o.SortOrder)
                 .Select(g => new
                 {
                     // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                     Name = "",
                     Type = "DataHive",
                     Header = g.HiveID,
                     HivePrefix = db.Sports.Single(s => s.ID == g.SportID).HivePrefix,
                     g.ID,
                     g.HiveID,
                     g.GroupID,
                     g.GameID,
                     g.SportID,
                     g.SortOrder
                 });
                }
        }

        public IEnumerable<dynamic> GetPlaylistItems(string hiveID,int ClientID)
        {
            Utilities.LoadClientShares(db, ClientID);
            List<int> lstclient=new List<int>();
            lstclient.Add(ClientID);
           foreach( Client c in db.Clients.Single(s=>s.ID==ClientID).Clients)
           {
               //Client cl = db.Clients.Where(dc => dc.ID == c.ID).FirstOrDefault();
               lstclient.Add(c.ID);
           }
            var data =  db.GameHiveNotes.Where(g => g.HiveID == hiveID && lstclient.Contains(g.ClientID))// g.ClientID == ClientID)
                        .Select(on => new { on.SportID,on.LeagueCode, on.ID, on.Note, on.UserID, on.LastUpdated, on.HiveID, on.SortOrder,on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                        .OrderBy(s => s.SortOrder)
                        .AsEnumerable()
                        .Select(n => new
                        {
                            // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                            //n.Group,
                            //n.GroupID,
                            //n.Header,
                            n.ID,
                            //n.Imported,
                            //n.LastUpdated,
                            //n.Note1,
                            //Name = n.Note//Utilities.ConvertToHTML(n.NoteColor)
                            Name = n.Note,
                            Note = ( n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? "last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated : ""),
                            ParentID = n.HiveID,
                            n.SortOrder,
                            //HivePrefix = n.SportID == null ? "" : db.Sposrts.Single(s => s.ID == n.SportID).HivePrefix,
                            //HivePrefix = n.SportID == null ? "" : dbSports.Where(s => s.StatsIncName == n.LeagueCode).Select(s => s.HivePrefix).FirstOrDefault(),
                            HivePrefix = n.LeagueCode == null ? "" : n.LeagueCode,
                            ObjectType = "GameNote"
                            //n.TeamID,
                            //n.UserID
                        });
            return data;
        }
        //Error	1	Type 'Ticker.Controllers.PlaylistItemsController' already defines a member called 'GetPlaylistItems' with the same parameter types	C:\Users\areich\Documents\Visual Studio 2012\Projects\Ticker\Ticker.Web\Controllers\PlaylistItemsController.cs	358	37	Ticker.Web
        //public IEnumerable<dynamic> GetPlaylistItems(int entryID, string ObjectType)
        //{
        //    return GetPlaylistItems(0, entryID, ObjectType);
        //}

        public IEnumerable<dynamic> GetPlaylistItems(int cid, int ID, string ObjectType)//,[ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            Utilities.LoadClientShares(db, cid);

            var ret = new List<dynamic>();
            var retGroups = new List<dynamic>();

            switch (ObjectType)
            {
                case "Group":
                    return db.Notes.Where(gn => gn.GroupID == ID).OrderBy(on => on.SortOrder)
                        .Select(on => new { on.ID, on.Note1, on.UserID, on.LastUpdated, on.GroupID, on.SortOrder }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                        .AsEnumerable()
                        .Select(n => new
                        {
                            n.ID,
                            Name = n.Note1,
                            Note = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? "last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : ""),
                            ParentID = n.GroupID,
                            n.SortOrder,
                            ObjectType = "GroupNote"
                        });
                case "Game":
                    {
                        foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                            retGroups = retGroups.Concat(db.spTICK_GameNotes_GetByGameID(gameID: ID, clientID: c.ID)
                            .Select(on => new { on.ID, on.Note, on.UserID, on.LastUpdated, on.GameID, on.SortOrder }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                            .AsEnumerable()
                            .Select(n => new
                            {
                                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                                //n.Group,
                                //n.GroupID,
                                //n.Header,
                                n.ID,
                                //n.Imported,
                                //n.LastUpdated,
                                //n.Note1,
                                //Name = n.Note//Utilities.ConvertToHTML(n.NoteColor)
                                Name = n.Note,
                                Note = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? "last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated : ""),
                                ParentID = n.GameID,
                                n.SortOrder,
                                ObjectType = "GameNote"
                                //n.TeamID,
                                //n.UserID
                            })).ToList();
                        return retGroups.Concat(db.spTICK_GameNotes_GetByGameID(gameID: ID, clientID: cid)
                            .Select(on => new { on.ID, on.Note, on.UserID, on.LastUpdated, on.GameID, on.SortOrder }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                            .AsEnumerable()
                            .Select(n => new
                            {
                                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                                //n.Group,
                                //n.GroupID,
                                //n.Header,
                                n.ID,
                                //n.Imported,
                                //n.LastUpdated,
                                //n.Note1,
                                //Name = n.Note//Utilities.ConvertToHTML(n.NoteColor)
                                Name = n.Note,
                                Note = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? "last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated : ""),
                                ParentID = n.GameID,
                                n.SortOrder,
                                ObjectType = "GameNote"
                                //n.TeamID,
                                //n.UserID
                            }));
                    }
                case "Sports":
                    dynamic expando = new ExpandoObject();
                    expando = new { ID = 0, Name = "Today", ObjectType = "Game", SortOrder = -1, hasChildren = false };
                    ret.Add(expando);

                    expando = new { ID = 0, Name = "Previous", ObjectType = "Game", SortOrder = -1, hasChildren = false };
                    ret.Add(expando);

                    foreach (Client c in db.Clients.Single(s => s.ID == cid).Clients)
                        ret = ret.Concat(db.spTICK_Games_Get(c.ID, ID, null, null, null).Select(g => new
                        {
                            g.ID,
                            Name = g.Matchup,
                            ObjectType = "Game",
                            g.SortOrder,
                            hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: g.ID, clientID: c.ID).Any()
                        })).ToList();

                    return ret.Concat(db.spTICK_Games_Get(cid, ID, null, null, null).Select(g => new
                    {
                        g.ID,
                        Name = g.Matchup,
                        ObjectType = "Game",
                        g.SortOrder,
                        hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: g.ID, clientID: cid).Any()
                    }));
                //return ret.Concat;
                //return db.spTICK_Games_Get(id, entryID, null, null, null).Select(g => new
                //{
                //    g.ID,
                //    Name = g.Matchup,
                //    ObjectType = "Game",
                //    hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: g.ID, clientID: id).Any()
                //});
                default:
                    return null;
            }

            //return db.Notes.Where(gw => gw.ID == id).Single(n => new
            //{
            //    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
            //    //n.Group,
            //    //n.GroupID,
            //    //n.Header,
            //    n.ID,
            //    //n.Imported,
            //    //n.LastUpdated,
            //    //n.Note1,
            //    Name = n.Note1,// Utilities.ConvertToHTML(n.NoteColor),
            //    //n.SortOrder,
            //    //n.TeamID,
            //    n.UserID
            //});
        }

        //public IEnumerable<dynamic> GetPlaylistItems(int id, int sportID)
        //{
        //    return db.spTICK_Games_Get(id, sportID, null, null, null).Select(g => new
        //    {
        //        g.ID,
        //        g.Matchup,
        //        hasChildren = db.spTICK_GameNotes_GetByGameID(gameID: g.ID, clientID: id).Any()
        //    });
        //}
    }
}

