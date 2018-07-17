using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Room: GameObject
    {
        public Dictionary<Direction, Room> Neighbors = new Dictionary<Direction,Room>();
        public List<Item> Inventory = new List<Item>();
        public List<NPC> NPCs = new List<NPC>();
        public bool AlreadyVisited;

        public Room (string name, string description)
        {
            Name = name;
            Description = description;
            AlreadyVisited = false;
        }

        public void Start()
        {
            this.AlreadyVisited = true;
            foreach (NPC npc in NPCs)
            {
                if(npc.IsAgressive)
                {
                    npc.Fight(TextAdventure.Player, npc);
                } 
                else
                {
                    npc.Dialog(TextAdventure.Player, npc);
                }
            }
        }



    }

    public enum Direction {Norden=0, Osten=1, Süden=2, Westen=3};
}
