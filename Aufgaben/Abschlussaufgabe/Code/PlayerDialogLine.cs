using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class PlayerDialogLine: CharDialogLine
    {
        public int LineNumber;
        public int NewPhase;

        public PlayerDialogLine (string line, int dialogPhase, Item reward, int lineNumber, int newPhase): base (line, dialogPhase, reward)
        {
            Line = line;
            DialogPhase = dialogPhase;
            Reward = reward;
            LineNumber = lineNumber;
            NewPhase = newPhase;

        }

    }
}