using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using CSSObjects;
using Ticker.Data;

namespace Ticker
{
    public class TickerCSS
    {
        private bool _Initialized = false;
        private string _ConnectionString;
        public CSS _CSS;
        public Sources _Universe;
        public Games _Games;

        public spTICK_Games_GetByEntryID_Result CurrentGame;

        private VentuzRemoting.VentuzRemoting _VentuzRemoting;

        // CSS Delegates:
        CSSObjects.CSS.BlastEndDelegate _delegateBlastEnd = null;
        CSSObjects.Games.GameUpdateDelegate _delegateGameUpdate = null;

        // Collection handler for games:
        public ArrayList _cssGames = new ArrayList();

        // Callbacks
        public delegate void TickerCSS_ClockTick(object sender, spTICK_Games_GetByEntryID_Result currentgame, string status, string clock);
        TickerCSS_ClockTick _clockTick;

        public VentuzRemoting.VentuzRemoting VentuzRemoting
        {
            set
            {
                _VentuzRemoting = value;
            }
            get
            {
                return _VentuzRemoting;
            }
        }

        public bool Connected
        {
            get
            {
                if (_CSS == null)
                {
                    return false;
                }
                else
                {
                    return (_CSS.Games.Count > 0);
                }
            }
        }

        public TickerCSS(TickerCSS_ClockTick cssclocktick)
        {
            _clockTick = cssclocktick;
        }

        protected void Game_ClockTick(object sender, int gameid, string status, string clock) 
        {
            if (CurrentGame == null)
                return;

            if (gameid == CurrentGame.CSSID) // .CSSID
            {
                // bubble up!
                _clockTick.Invoke(null, CurrentGame, status, clock);
            }
        }

        public void Connect(string css_server, int css_port)
        {
            _CSS = new CSS();
            _Games = _CSS.Games;

            // Register for updates going forward (this helps in case games are added after blast):
            _delegateGameUpdate = new Games.GameUpdateDelegate(Games_GameUpdated);
            _Games.RegisterForGameUpdate(ref _delegateGameUpdate, false);

            CSSConnect(css_server, css_port);
            System.Threading.Thread.Sleep(5000);
        }

        public TickerCSSGame GetGame(int gameid)
        {
            foreach (TickerCSSGame game in _cssGames)
            {
                if (game.ID == gameid)
                {
                    return game;
                }
            }

            return null;
        }

        public string GetClock()
        {
            string clock = "";

            foreach (TickerCSSGame game in _cssGames)
            {
                if (game.ID == CurrentGame.ID)
                {
                    clock = game.Clock;
                    break;
                }
            }

            return clock;
        }

        public string GetStatus()
        {
            string status = "";

            foreach (TickerCSSGame game in _cssGames)
            {
                if (game.ID == CurrentGame.ID)
                {
                    status = game.Status;
                    break;
                }
            }

            return status;
        }

        private void CSSConnect(string server, int port)
        {
            bool bRetVal = false;

            try
            {
                _CSS.TcpClient.Connect(server, port);
                bRetVal = true;
            }
            catch (Exception)
            {

            }

            if (bRetVal == true)
            {
                try
                {
                    if (_delegateBlastEnd == null)
                    {
                        _delegateBlastEnd += new CSSObjects.CSS.BlastEndDelegate(CSS_BlastEnd);
                        _CSS.RegisterForBlastEnd(ref _delegateBlastEnd, false);
                    }
                }
                catch (Exception)
                {
                    bRetVal = false;
                }
            }
        }

        private void CSS_BlastEnd(string timetaken)
        {
            // Blast received.
            ProcessGameBlast();

            // Clear out current games:
            // DeleteOldCSSGames();
        }

        public void ProcessGameBlast()
        {
            int numGames = _CSS.Games.Count;

            for (int i = 0; i < numGames; i++)
            {
                CSSObjects.Game game = (CSSObjects.Game)_CSS.Games.GameCollection().GetByIndex(i);
                int nEventType = 0;
                if (game != null)
                {
                    nEventType = Int32.Parse(game.EventType);
                    //if (nEventType == 1)
                    //{
                    TickerCSSGame objGame = new TickerCSSGame(Game_ClockTick, game, ref _VentuzRemoting);
                    _cssGames.Add(objGame);
                    /*}
                    else
                    {
                        string test1 = game.Description;
                        string test2 = game.ID.ToString();
                        string test3 = game.Key;
                        string test = "game not added.";
                        
                    }*/
                }
            }

            _Initialized = true;
        }

        private void Games_GameUpdated(ref CSSObjects.Game game)
        {
            if (_Initialized)
            {
                TickerCSSGame objGame = new TickerCSSGame(Game_ClockTick, game, ref _VentuzRemoting);
                _cssGames.Add(objGame);
            }
        }
    }
}
