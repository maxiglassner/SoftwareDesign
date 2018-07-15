using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class NPC: Character
    {
        public string FightQuote;                
        public bool IsAgressive;
        public List<CharDialogLine> DialogLines = new List<CharDialogLine>();
        public int DialogPhase;
        public int MaxDialogPhase;
        public bool CanSpeak;

        public NPC (string name, string description, int health, int damage, string fightQuote, bool isAgressive, bool canSpeak)
        {
            Name = name;
            Description = description;
            Health = health;
            Damage = damage;
            FightQuote = fightQuote;
            IsAgressive = isAgressive;
            CanSpeak = canSpeak;
        }
    }
}