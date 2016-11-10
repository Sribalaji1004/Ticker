using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticker
{
    public class TickerCSSGame
    {
        protected CSSObjects.Game.UpdateDelegate _gameupdate = null;
        protected CSSObjects.Game.PropertyUpdateDelegate _propertyupdate = null;

        private CSSObjects.Game _Game;

        // Save high level properties - simplifies CSS logic required.
        public string Visitors;
        public string Home;
        public string Status;
        private string _Clock;
        public int VisitorsScore;
        public int HomeScore;
        public int GameStatusID;
        public string Details;

        private VentuzRemoting.VentuzRemoting _VentuzRemoting;

        // Callbacks
        public delegate void TickerCSSGame_ClockTick(object sender, int gameid, string status, string clock);
        TickerCSSGame_ClockTick _Game_ClockTick;

        public TickerCSSGame(TickerCSSGame_ClockTick game_clockTick, CSSObjects.Game game, ref VentuzRemoting.VentuzRemoting ventuzremoting)
        {
            _Game_ClockTick = game_clockTick;
            _Game = game;
            _VentuzRemoting = ventuzremoting;

            // Register for callbacks for any updates to this game.
            _gameupdate = new CSSObjects.Game.UpdateDelegate(Game_Update);
            _Game.RegisterForUpdates(ref _gameupdate, false);

            _propertyupdate = new CSSObjects.Game.PropertyUpdateDelegate(Property_Update);
            _Game.RegisterForPropertyUpdates(ref _propertyupdate, false);

            // Initialize game
            Game_Update(ref game);
        }

        public string Clock
        {
            get
            {
                switch (Status.ToUpper())
                {
                    case "LATER":
                    case "HALF":
                    case "H":
                        return "";
                    default:
                        if (Status == "")
                            return "";
                        else
                            if ((Status.Substring(0, 1) == "F"))
                            {
                                return "";
                            }
                            else
                            {
                                return _Clock;
                            }
                }
            }
            set { _Clock = value; }
        }

        public int ID
        {
            get
            {
                return _Game.ID;
            }
        }

        protected void Property_Update(ref CSSObjects.Game game, ref CSSObjects.ICSSProperty property)
        {
            if (property.Name == "Clock")
            {
                // Just update clock!
                Clock_Update(ref game);
                _Game_ClockTick.Invoke(null, game.ID, Status, Clock);  // bubble up the tick to TickerCSS class.
            }
            else
            {
                Game_Update(ref game);
                _Game_ClockTick.Invoke(null, game.ID, Status, Clock);  // bubble up the tick to TickerCSS class.
            }
        }

        public void Clock_Update(ref CSSObjects.Game game)
        {
            string visitors = "";
            string home = "";
            string clock = "";

            foreach (CSSObjects.ICSSProperty property in game.Properties)
            {
                CSSObjects.ICSSProperty prop = property;

                switch (prop.Name)
                {
                    case "Clock":
                        clock = ((CSSObjects.CSSProperty)property).Value == null || ((CSSObjects.CSSProperty)property).Value == "0" ? "00:00" : ((CSSObjects.CSSProperty)property).Value;
                        Clock = clock;
                        break;

                    case "HomeTeam":
                        home = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        Home = home;
                        break;

                    case "VisitorTeam":
                        visitors = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        Visitors = visitors;
                        break;

                    default:
                        break;

                }
            }
        }

        public void Game_Update(ref CSSObjects.Game game)
        {
            string gamename = game.Name;
            string visitors = "";
            string visitorsid = "";
            string visitorsname = "";
            string visitorscity = "";
            string home = "";
            string homeid = "";
            string homename = "";
            string homecity = "";
            string visitorsscore = "";
            string homescore = "";
            string status = "";
            string status_as_time = ""; ;
            string clock = "";
            string down = "";
            int ydstogo = -1;
            string ballspot = "";
            string possession = "";
            int gameid = game.ID;
            bool redzone = false;
            int spot = 0;

            foreach (CSSObjects.ICSSProperty property in game.Properties)
            {
                CSSObjects.ICSSProperty prop = property;

                switch (prop.Name)
                {
                    case "Status":
                        status = ((CSSObjects.CSSProperty)property).Value == null ? "Unknown" : ((CSSObjects.CSSProperty)property).Value;
                        switch (status)
                        {
                            case "F":
                                status = "FINAL";
                                break;

                            case "F/OT":
                                status = "FINAL/OT";
                                break;
                        }
                        if (status.IndexOf("!") >= 0)
                        {
                            status_as_time = status.Replace("!", "");
                            status = "ASTIME";
                        }
                        break;

                    case "Clock":
                        clock = ((CSSObjects.CSSProperty)property).Value == null || ((CSSObjects.CSSProperty)property).Value == "0" ? "00:00" : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "Down":
                        down = ((CSSObjects.CSSProperty)property).Value == null ? "0" : ((CSSObjects.CSSProperty)property).Value;
                        switch (down)
                        {
                            case ("0"):
                                down = "0th &";
                                break;
                            case ("1"):
                                down = "1st &";
                                break;
                            case ("2"):
                                down = "2nd &";
                                break;
                            case ("3"):
                                down = "3rd &";
                                break;
                            case ("4"):
                                down = "4th &";
                                break;
                            default:
                                break;
                        }
                        break;

                    case "YardsToGo":
                        string ydstogo_raw = ((CSSObjects.CSSProperty)property).Value;
                        int number;
                        bool result = Int32.TryParse(ydstogo_raw, out number);
                        if (result)
                        {
                            ydstogo = ydstogo_raw == null ? 0 : Convert.ToInt16(ydstogo_raw);
                        }
                        else
                        {
                            ydstogo = -1;
                        }

                        //footballGame.YardsToGo = yardsToGo == null ? 0 : Convert.ToInt16(yardsToGo);
                        break;

                    case "BallSpot":
                        //ballspot = ((CSSObjects.CSSProperty)property).Value == null ? "-" : ((CSSObjects.CSSProperty)property).Value;
                        break;
                    case "BallOn":
                        spot = Convert.ToInt16(((CSSObjects.CSSProperty)property).Value == null ? "0" : ((CSSObjects.CSSProperty)property).Value);
                        if (spot == 0)
                        {
                            redzone = false;
                            ballspot = "";
                        }
                        else
                        {
                            redzone = (spot <= 20);
                            ballspot = spot.ToString();
                        }
                        break;
                    case "Possession":
                        possession = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        if (possession == "true" || possession == "H")
                        {
                            possession = "H";
                        }
                        else if (possession == "false" || possession == "V")
                        {
                            possession = "V";
                        }
                        else
                        {
                            possession = "";
                        }
                        break;

                    case "HomeTeam":
                        home = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        Home = home;
                        break;

                    case "hometeam_id":
                        homeid = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "hometeam_name":
                        homename = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "hometeam_city":
                        homecity = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "HomeScore":
                        homescore = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        if (homescore != " ")
                            HomeScore = Convert.ToInt32(homescore);
                        break;

                    case "VisitorTeam":
                        visitors = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        Visitors = visitors;
                        break;

                    case "visteam_id":
                        visitorsid = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "visteam_name":
                        visitorsname = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "visteam_city":
                        visitorscity = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        break;

                    case "VisitorScore":
                        visitorsscore = ((CSSObjects.CSSProperty)property).Value == null ? " " : ((CSSObjects.CSSProperty)property).Value;
                        if (visitorsscore != " ")
                            VisitorsScore = Convert.ToInt32(visitorsscore);
                        break;

                    default:
                        break;

                }
            }

            // BUILD DETAILS
            string details = "";
            string spot_details = "";
            if ((spot == 0) || (ydstogo == 0))
            {
                spot_details = "";
                redzone = false;
            }
            else if (spot == 50)
            {
                spot_details = "Ball at Midfield";
            }
            else if (spot < 50)
            {
                if (possession.ToUpper() == "V")
                {
                    spot_details = "Ball on " + home + " " + spot.ToString();
                }
                else
                {
                    spot_details = "Ball on " + visitors + " " + spot.ToString();
                }
            }
            else
            {
                if (possession.ToUpper() == "V")
                {
                    spot_details = "Ball on " + visitors + " " + (100 - spot).ToString();
                }
                else
                {
                    spot_details = "Ball on " + home + " " + (100 - spot).ToString();
                }
            }
            details = "<details possession=\"" + possession + "\" ballspot=\"" + spot_details + "\" redzone=\"" + redzone.ToString() + "\" />";

            GameStatusID = 2; //1=Pre-Game, 2=In-Progress, 3=Final
            switch (status.ToUpper())
            {
                case "LATER":
                case "PRE-GAME":
                case "ASTIME":
                case "0":
                    GameStatusID = 1;
                    details = "<details possession=\"" + "" + "\" ballspot=\"" + "" + "\" redzone=\"" + "false" + "\" />";
                    clock = "";
                    if (status == "0")
                    {
                        status = "PRE-GAME";
                    }
                    else if (status == "ASTIME")
                    {
                        status = status_as_time;
                    }
                    break;

                case "1ST":
                case "2ND":
                case "3RD":
                case "4TH":
                case "HALF":
                case "HALFTIME":
                case "H":
                case "OT":
                case "OVERTIME":
                    if (clock == "0:00")
                    {
                        clock = "";
                    }
                    GameStatusID = 2;
                    break;

                default:
                    //case "FINAL":
                    //case "FINAL/OT":
                    GameStatusID = 3;
                    details = "<details possession=\"" + "" + "\" ballspot=\"" + "" + "\" redzone=\"" + "false" + "\" />";
                    clock = "";
                    break;

            }

            // Save status.
            Status = status;
            Clock = clock;
            Visitors = visitors;
            Home = home;
            Details = details;
        }
    }
}
