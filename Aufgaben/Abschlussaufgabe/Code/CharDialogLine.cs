using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class CharDialogLine
    {
        public string Line;
        public int DialogPhase;
        public Item Reward;

        public CharDialogLine (string line, int dialogPhase, Item reward)
        {
            Line = line;
            DialogPhase = dialogPhase;
            Reward = reward;
        }

    }
}