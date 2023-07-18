using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Personal
{
    public class Group
    {
        public string groupName;
        public int TotalPlayers;
        public int TotalPlayersTicket;
        public List<Player> PlayerList;
        public Group(string groupName)
        {
            this.groupName = groupName;
        }

        public class Player
        {
            public string playerName;
            public int ticketCount;
            public Ticket[] tickets;
        }

        public class Ticket
        {
            public List<int> n = new List<int>();
        }
    }
}

