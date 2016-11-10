using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Ticker.Hubs
{
    public class TickerHub : Hub
    {
        public void Play(int playlistID)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(3);
        }
    }
}