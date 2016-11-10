using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticker.Data;
using Ventuz.Kernel.Remoting;
using VentuzRemoting;

namespace Ticker
{
    class SceneBase
    {
        private bool isPlaying = false;
        private string tab = "";
        private VentuzRemoting.VentuzRemoting ventuzRemoting;

        public SceneBase()
        {}

        public bool IsPlaying
        {
            get{return isPlaying;}
            set{isPlaying = value;}
        }

        public string Tab
        {
            get { return tab; }
            set { tab = value; }
        }

        public void Close()
        {
            ventuzRemoting.CloseVentuzApplication();
        }

        // Initializes Ventuz and loads the appropriate scene:
        public void Initialize(string ventuz_director_path)
        {
            try
            {
                ventuzRemoting = new VentuzRemoting.VentuzRemoting();

                string ventuzPresenterExeLocation = ventuzRemoting.SetPresenterLocation("C:\\Program Files\\Ventuz Technology Group\\Ventuz 2008\\VentuzPresenter.exe");
                ventuzRemoting.SetIPAddress("127.0.0.1");
                ventuzRemoting.SetPort("19200");
                ventuzRemoting.VEvent += new VentuzRemoting.VentuzRemoting.EventHandler(VENTUZ_Callback);
                
                if (ventuzRemoting.LaunchVentuz(ventuz_director_path, false) == false) 
                {
                    throw new System.Exception("Unable to launch Ventuz.");
                };

                System.Threading.Thread.Sleep(4000);

                if (ventuzRemoting.OpenVentuzConnection() == false) 
                {
                    throw new System.Exception("Unable to open connection to Ventuz.");
                };

                string ventuzCurrentScene = "";
                string[] ventuzLoadedScenes = ventuzRemoting.GetVentuzLoadedScenes(out ventuzCurrentScene);

                int externalCount;
                string[] externalTypes;
                string[] externalNames = ventuzRemoting.GetVentuzExternals(ventuzCurrentScene, out externalTypes, out externalCount);

                // activate the current scene
                bool ventuzSceneIsActive = false;
                ventuzSceneIsActive = ventuzRemoting.ActivateVentuzScene(ventuzCurrentScene);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Sets a proper within Ventuz:
        protected void Ventuz_Property(string property, string value)
        {
            // We should log this.
            if (ventuzRemoting.SetVentuzProperty("/" + property, value) == false)
            { }; 
        }

        // Calls a method within Ventuz:
        protected void Ventuz_Method(string method)
        {
            // We should log this.
            if (ventuzRemoting.InvokeVentuzMethod("/" + method) == false)
            { }
        }

        // Method to handle Ventuz callbacks.
        protected virtual void VENTUZ_Callback(object sender, VentuzArgs eventName) //(int connid, int eventid)
        {
            // stub.
        }

        // Insert the ticker using the on-move file as well as the sponsor.
        public virtual void Ticker_Insert(string intro_file_path, string sponsor_file_path, object gameornote, string tab)
        {
            // stub.
        }

        // Clear the ticker:  clearing out what's there for next item.
        public virtual void Ticker_Clear()
        {
        }

        // Retract the ticker.
        public void Ticker_Retract()
        {
            Ventuz_Method("TICKER_OUT");
            IsPlaying = false;
        }

        public bool Ticker_Note_IsScrolling()
        {
            if (ventuzRemoting != null)
                return !Convert.ToBoolean(ventuzRemoting.GetVentuzProperty("/NOTE_ISSTATIC"));
            else
                return true;
        }

        // Update the tab
        public virtual void Ticker_Tab_Update(string tab_name)
        {
            // stub.
        }

        // Insert the ticker tabs.
        protected virtual void Ticker_Tabs_Insert(string tab)
        {
            // stub.
        }

        // Insert a ticker note - input parameter is the note object.
        public virtual void Ticker_Note_Insert(object noteobject)
        {
            // stub.
        }

        // Insert a ticker note with a header - probably will go away once we get the note object to work with.
        public virtual void Ticker_Note_Insert(string header, string text, object gameornoteobject)
        {
            // stub.
        }

        // Insert a ticker note with a colored header - probably will go away once we get the note object to work with.
        public virtual void Ticker_Note_Insert(string header, string headerRGB, string textRGB, string text)
        {
            // stub.
        }

        // Insert an upcoming game.
        public virtual void Ticker_Schedule_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            // stub.
        }

        // Insert an in-progress game.
        public virtual void Ticker_InProgress_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            // stub.
        }

        // Insert a final game.
        public virtual void Ticker_Final_Insert(spTICK_Games_GetByEntryID_Result gameobject)
        {
            // stub.
        }

        // Insert a Ticker Flow:
        public virtual void Ticker_Platinum_Insert(string tickerflow_platinum_path, string tickerflow_static_path)
        {
            // stub.
        }

        // Insert a Score Alert for a game.
        public virtual void Ticker_ScoreAlert_Insert(spTICK_ScoreAlerts_Get_FTL_Result scorelalert)//object gameobject)
        {
            // stub.
        }
    }
}
