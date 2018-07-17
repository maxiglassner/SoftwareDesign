using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Player: Character
    {
        private int MaxHealth;
        private static Player _instance;
        
        public List<PlayerDialog> Dialogs = new List<PlayerDialog>();
        public Room CurrentRoom;
        public Weapon CurrentWeapon;

        private Player (string name, string description, int maxHealth, int damage, Room currentRoom)
        {
            Name = name;
            Description = description;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Damage = damage;
            CurrentRoom = currentRoom;
        }

        public static void Create (string name, string description, int health, int damage, Room currentRoom)
        {
            if (_instance != null)
                throw new Exception ("Player already created!");
            _instance = new Player (name, description, health, damage, currentRoom);
        }
        public static Player Instance
        {
            get
            {
                if(_instance == null)
                    throw new Exception ("Player not created!");
                return _instance;
            }
        }

        public void Help() 
        {
            Console.WriteLine("Du hast folgende Interaktionsmöglichkeiten:");
            Console.WriteLine("(i) 'Inventar' - um zu sehen was du alles mit dir rum schleppst.");
            Console.WriteLine("(u) 'umschauen' - um dich umzusehen, vielleicht entdeckst du ja etwas Wichtiges.");
            Console.WriteLine("(inf) 'Info' - um Informationen über sich selber zu erhalten.");
            Console.WriteLine("(a <Name von etwas im Raum/Inventar) 'ansehen' - um dir etwas im Raum oder in deinem Inventar näher anzuschauen und Details zu erfahren.");
            Console.WriteLine("(l <Name einer toten npc>) 'looten' - um jmd den du getötet hast zu looten.");
            Console.WriteLine("(n <Name eines Inventory im Raum>) 'nehmen' - um ein Item aus dem Raum aufzunehmen.");
            Console.WriteLine("(w <Name eines Inventory in deinem Inventar>) 'weglegen' - um ein Item aus deinem Iventar in dem Raum abzulegen.");
            Console.WriteLine("(b <Name eines Inventory in deinem Inventar>) 'benutzen' - um eine Heiltrank zu trinken oder eine Waffe auszurüsten.");
            Console.WriteLine("(g <Richtung in die du gehen willst bzw jeweiliger Anfangsbuchstabe>)'gehen' - um in die ausgewählte Richtung den Raum zu verlassen (Norden, Osten, Süden oder Westenen)");
            Console.WriteLine("(s <Name einer npc im Raum>) 'sprechen' - um mit einer npc im Raum zu sprechen.");
            Console.WriteLine("(atk <Name eines NPC im Raum> 'angreifen' -um einem NPC anzugreifen.");            
            Console.WriteLine("(e) 'Ende' - um das Spiel zu beenden.");
        }

         public void Look ()
        {
            Console.WriteLine("Du schaust dich in " + CurrentRoom.Name + " um.");
            Console.WriteLine(CurrentRoom.Description);

            Console.WriteLine(Environment.NewLine + "Du kannst von hier aus in folgende Räume gehen:");
            foreach(KeyValuePair<Direction, Room> neighbor in CurrentRoom.Neighbors)
            {
                Console.WriteLine(neighbor.Value.Name + " im " + neighbor.Key);
            }

            Console.WriteLine(Environment.NewLine + "Es befinden sich folgende NPCs hier:");
            if (!CurrentRoom.NPCs.Any())
            {
                Console.WriteLine(" -keine");   
            }
                
            foreach (NPC npc in CurrentRoom.NPCs)
            {
                Console.Write(" -" + npc.Name);
                if (npc.Health <= 0)
                {
                    Console.WriteLine(" (tot)");
                }

            }

            Console.WriteLine(Environment.NewLine + "Beim näheren Hinsehen siehst du noch:");
            if (!CurrentRoom.Inventory.Any())
            {
                Console.WriteLine(" -nichts");         
            }

            foreach (Item item in CurrentRoom.Inventory)
            {
                Console.WriteLine(" -" + item.Name);
            }
                
        }

        public void LookAt (string thing)
        {
           if (String.IsNullOrWhiteSpace(thing))
           {
                Console.WriteLine ("Bitte schreib dazu, was du dir ansehen möchtest.");
           }
            else
            {
                GameObject subject = CurrentRoom.Inventory.Find(x => x.Name.ToLower() == thing);
                if (subject == null)
                {
                    subject = CurrentRoom.NPCs.Find(x => x.Name.ToLower() == thing);
                }
                    
                if(subject == null)
                {
                    subject = Inventory.Find(x => x.Name.ToLower() == thing);
                }
                    
                if(subject == null)
                {
                    Console.WriteLine("Es gibt hier niemanden der '" + thing + "' heißt.");
                }
                else
                {
                    Console.WriteLine(subject.Description);

                    if(subject is Weapon)
                    {
                        Weapon weapon = (Weapon) subject;
                        Console.WriteLine(weapon.Name + " kann als Waffe benutzt werden und verleiht dir " + weapon.DamageBonus + " mehr Angriff.");
                    } 
                    if (subject is Potion)
                    {
                        Potion potion = (Potion) subject;
                        Console.WriteLine(potion.Name  + " kann getrunken werden und gibt dir " + potion.HealthRecover + " Lebenspunkte wieder.");
                    } 
                  
                }
                
            }
        }

        public void Attack (string npc)
        {
           if (String.IsNullOrWhiteSpace(npc))
                Console.WriteLine ("Bitte wähle ein NPC aus den du angreifen möchtest, sonst würdest du gegen die Luft kämpfen und ganz ehrlich, das würde lächerlich aussehen!");
            else
                if(CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc) != null)
                    if(CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc).Health == 0)
                        Console.WriteLine("Der ist schon tod. Möchtest du wirklich gegen eine Leiche kämpfen? Du könntest sie aber looten!");
                    else
                        Fight(TextAdventure.Player, CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc));
                else if (CurrentRoom.Inventory.Find(x =>  x.Name.ToLower() == npc) != null)
                    Console.WriteLine ("Das kannst du nicht angreifen!");
                else
                    Console.WriteLine ("Es gibt kein " + npc + " hier...");
        }  

        public void PlayerInfo ()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine("Deine aktuellen Werte:");
            Console.WriteLine("Gesundheit: " + Health + " / " + MaxHealth );
            Console.WriteLine("Angriffsstärke: " + Damage);
            if(CurrentWeapon != null)
            {
                Console.WriteLine("Ausgerüstet Waffe: " + CurrentWeapon.Name);
                Console.WriteLine("Waffenschaden: " + CurrentWeapon.DamageBonus);
            }
            else
                Console.WriteLine("Ausgerüstete Waffe: keine");
        }

        public void ActualInventory ()
        {
            Console.WriteLine("Das hast du alles dabei:");
            foreach (Item item in Inventory)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void Loot (string corpse)
        {
            if (String.IsNullOrWhiteSpace(corpse))
                Console.WriteLine ("Du musst schon spezifizieren, wen du looten möchtest.");
            else 
            {
                if (CurrentRoom.NPCs.Find(x => x.Name.ToLower() == corpse) != null)
                {
                    NPC subject = CurrentRoom.NPCs.Find(x => x.Name.ToLower() == corpse);
                    if (subject.Health == 0)
                    {
                        Console.WriteLine("Du hast von " + subject.Name + "s Leiche folgendes gelootet:");
                        foreach(Item item in subject.Inventory.ToList())
                        {
                            Console.WriteLine(item.Name);
                            Inventory.Add(item);
                            subject.Inventory.Remove(item);
                        }
                    }
                    else
                     Console.WriteLine("Spielen wir hier 'Thieves'? Du musst " + subject.Name + " schon erst umbringen, damit du an seine Sachen dran kommst.");
                } 
                else
                    Console.WriteLine("Es gibt hier keine Leiche von " + corpse + " .");     
            } 
        }

        public void Take (string item)
        {
            if (String.IsNullOrWhiteSpace(item))
                Console.WriteLine ("Du musst schon sagen, was du aufheben möchtest.");
            else
            {
                Item roomItem = CurrentRoom.Inventory.Find(x => x.Name.ToLower() == item);
            
                if (roomItem == null)
                    Console.WriteLine("Es gibt hier kein Item, das '" + item + "' heißt.");
                else
                {
                    if(!roomItem.IsCarryable)
                        Console.WriteLine("Du kannst " + roomItem.Name + " nicht aufheben.");
                    else
                    {
                        Inventory.Add(roomItem);
                        CurrentRoom.Inventory.Remove(roomItem);
                        Console.WriteLine("Du hast '" + roomItem.Name + "' erhalten.");
                    }
                }
            }
        }

        public void Drop (string item)
        {
            if (String.IsNullOrWhiteSpace(item))
                Console.WriteLine ("Du musst schon spezifizieren was du fallen lassen möchtest!");
            else
            {
                Item inventoryItem = Inventory.Find(x => x.Name.ToLower() == item);
                if (inventoryItem == null)
                    Console.WriteLine("Du hast kein '" + item + "' in deinem Inventar.");
                else
                {
                    CurrentRoom.Inventory.Add(inventoryItem);
                    Inventory.Remove(inventoryItem);
                    Console.WriteLine("Du hast " + inventoryItem.Name + " in den Raum geworfen. Hoffentlich war es kein Müll, sonst wird das teuer...");
                }
            }
        }

        public void Use (string item)
        {
            if (String.IsNullOrWhiteSpace(item))
                Console.WriteLine ("Du musst schon spezifieren, was du benutzen möchtest!");
            else
            {
                Item inventoryItem = Inventory.Find(x => x.Name.ToLower() == item);
                if (inventoryItem == null)
                    Console.WriteLine("Du hast kein '" + item + "' in deinem Inventar.");
                else
                {
                    if(inventoryItem is Weapon)
                    {
                        if(CurrentWeapon != null)
                        {
                            Damage -= CurrentWeapon.DamageBonus;
                        }                        
                        Weapon newWeapon = (Weapon) inventoryItem;
                        CurrentWeapon = newWeapon;
                        Damage +=  newWeapon.DamageBonus;
                        Console.WriteLine("Du hast jetzt " + newWeapon.Name + " als Waffe ausgerüstet. Du machst jetzt einen unglaublichen Schaden von " + Damage + ".");
                    } 
                    else if (inventoryItem is Potion)
                    {
                        Potion potion = (Potion) inventoryItem;
                        Health += potion.HealthRecover;
                        if(Health >= MaxHealth)
                            Health = MaxHealth;
                        Inventory.Remove(potion);
                        Console.WriteLine("Du hast ein " + potion.Name  + " getrunken. Deine Lebenspunkte betragen jetzt " + Health + " .");
                    } 
                    else
                        Console.WriteLine("Du kannst das nicht benutzen.");
                }
            }
        }

        public void Move (string direction)
        {
            Room nextRoom = null;
            bool validDirection = false;
            Direction selectedDirection = Direction.Norden;

            switch (direction)
            {
                case "Norden": case "N": case "n":
                    CurrentRoom.Neighbors.TryGetValue(Direction.Norden, out nextRoom);
                    validDirection = true;
                    selectedDirection = Direction.Norden;
                    break;
                case "Süden": case "S": case "s":
                    CurrentRoom.Neighbors.TryGetValue(Direction.Süden, out nextRoom);
                    validDirection = true;
                    selectedDirection = Direction.Süden;
                    break;
                case "Osten": case "E": case "e":
                    CurrentRoom.Neighbors.TryGetValue(Direction.Osten, out nextRoom);
                    validDirection = true;
                    selectedDirection = Direction.Osten;
                    break;
                case "Westen": case "W": case "w":
                    CurrentRoom.Neighbors.TryGetValue(Direction.Westen, out nextRoom);
                    validDirection = true;
                    selectedDirection = Direction.Westen;
                    break;
                default:
                    Console.WriteLine("'" + direction + "'" + " ist keine zur Verfügung stehende Richtung.");
                    break;
            }

            if (validDirection && nextRoom == null)
            {
                Console.WriteLine("Es gibt keinen Raum im " + selectedDirection.ToString() + ".");
            }
            else if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                Console.WriteLine("Du bist jetzt in dem Raum: " + CurrentRoom.Name + ".");
                Look();

                if(!CurrentRoom.AlreadyVisited)
                {
                    CurrentRoom.Start();
                }
           
            }   
        }

        public void SpeakTo (string npc)
        {
           if (String.IsNullOrWhiteSpace(npc))
                Console.WriteLine ("Bitte wähle jemanden aus mit dem du sprechen willst. Leute die Selbstgespräche führen, sind hier nicht sehr beliebt.");
            else
                if(CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc) != null)
                    if(CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc).Health == 0)
                        Console.WriteLine("Du kannst du mit keiner Leiche sprechen. Schließlich ist sie naja tot und wird dir nicht mehr antworten können.");
                    else
                        Dialog(TextAdventure.Player, CurrentRoom.NPCs.Find(x =>  x.Name.ToLower() == npc));
                else if (CurrentRoom.Inventory.Find(x =>  x.Name.ToLower() == npc) != null)
                    Console.WriteLine ("Damit kannst du nicht sprechen!");
                else
                    Console.WriteLine ("Es gibt hier keinen mit dem Namen '" + npc + "'.");
        }



        


    }
}