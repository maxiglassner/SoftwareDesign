using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
     class PlayerDialog
    {
        public Character DialogPartner;
        public List<PlayerDialogLine> DialogLines = new List<PlayerDialogLine>();
        public int DialogPhase;

        public PlayerDialog (Character dialogPartner)
        {
            DialogPartner = dialogPartner;
            DialogPhase = 0;    
        }
    }
}