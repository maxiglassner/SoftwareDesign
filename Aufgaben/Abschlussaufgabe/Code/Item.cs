using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Item: GameObject
    {
        public bool IsCarryable;

        public Item (string name, string description, bool isCarryable)
        {
            Name = name;
            Description = description;
            IsCarryable = isCarryable;
        }
        

    }
}