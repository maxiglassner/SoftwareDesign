using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Potion: Item
    {
        public int HealthRecover;

        public Potion (string name, string description, bool isCarryable, int healthRecover): base (name, description, isCarryable)
        {
            Name = name;
            Description = description;
            HealthRecover = healthRecover;
        }
        

    }
}