using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Weapon: Item
    {
        public int DamageBonus;

        public Weapon (string name, string description, bool isCarryable, int damageBonus): base (name, description, isCarryable)
        {
            Name = name;
            Description = description;
            DamageBonus = damageBonus;
        }
        

    }
}