using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    static class TextAdventure
    {
      public static Player Player;
      public static List<Room> Rooms = new List<Room>();
      public static List<Item> Items = new List<Item>();
      public static List<NPC> NPCs = new List<NPC>();
      public static bool IsFinished = false;
      public static Room WinningRoom;        
        static void Main(string[] args)
        {
            
        }

        private static void LoadGameData ()
        {
            //Items

            Items.Add(new Item("Orkzahn", "IHHHH stinkt der. Sein Besitzer hatte wohl kein Sinn für Zahnhygienen.", true));
            Items.Add(new Item("Uruk-Horn", "Ob man daraus ein Trinkhorn machen könnte...?", true));
            Items.Add(new Item("Stricknadeln", "Ein Ork der strickt?! Interessant.", true));
            Items.Add(new Item("Licht Herrendils", "Eine Flasche die Leuchten kann... Ist das dann eine Flaschenlampe?", true));
            Items.Add(new Item("Zerbrochene Krone", "Die zerbrochene Krone des Zwergenkönigs. Ob sie noch etwas Wert ist?", true));
            Items.Add(new Item("Grabstein", "Da ist eine Inschrift: 'Hier ruht Balun, Findins Sohn, Herr von Gloria'", false));

            Items.Add(new Potion("Großer Heiltrank", "Riecht ein bisschen wie mit Ingwer versetztem Schwarzbier.", true, 75));
            Items.Add(new Potion("Kleiner Heiltrank", "Richt irgenwie nach Spagel.", true, 25));
            Items.Add(new Potion("Heilshot", "Danach hat ja sogar eine Ameise noch durst.", true, 1));
            Items.Add(new Potion("Metbierhorn", "Ein Horn gefüllt mit Zwergenmet.", true, 50));

            Items.Add(new Weapon("Stock", "Ein gut abgehangenes Stück Holz. Leider etwas biegsam", true, 2));
            Items.Add(new Weapon("Streitaxt des Baluns", "Die legendäre Streitaxt von Balun. Ein bisschen angerostet aber immer noch messerscharf!", true, 10));
            Items.Add(new Weapon("Rostiges Schwert", "Ein rositger 1 1/2-Händer.", true, 4));
            Items.Add(new Weapon("Feuerpeitsche", "Am Griff hängen noch Barthaare-sehen aus wie von einem Zauberer...", true, 1000));
            Items.Add(new Weapon("Thors Hammer", "Niemand außer Thor selbst war bisher würdig genug ihn zu führen oder gabs da nicht mal einen Typen namens Steve?", false, 10000));

            //Rooms
            Rooms.Add(new Room("Eingangstore von Gloria", "Die Eingangstore zu den gewaltigen Minen von Gloria. Sprich Freund und tritt ein!"));
            Rooms.Add(new Room("Eingangshalle", "Herzlich Willkommen in den Minen von Gloria, werdet Zeuge der Gastfreundschaft der Zwerge, gut abgehangenes Fleisch, prasselnde Kaminfeu... Ähm was ist den hier los wieso liegen hier so viele Zwergenskelette?!"));
            Rooms.Add(new Room("Grabkammer von Balun", "Eine Grabkammer, düster und kalt. Eine Grabkammer eben."));
            Rooms.Add(new Room("Schmiede", "Eine gewaltige Zwergenschmiede. Wie es wohl hier früher ausgesehen hat?"));
            Rooms.Add(new Room("Thronsaal", "Der Thronsaal Glorias. Einst prunkvoll geschmückt mit Gold, Silber und Edelsteinen. Doch jetzt ein trostloses Chaos."));
            Rooms.Add(new Room("Einundzwanzigste Halle", "Eine große Halle, deren Dach von mächtigen Säulen getragen wird."));
            Rooms.Add(new Room("Brücke von Khazad-dumm", "Eine zerstörte Brücke. Auf der anderen Seite scheint ein Ausgang zu sein. Ob man da rüberspringen kann?"));
            Rooms.Add(new Room("Bergkamm", "Hinter dem gewaltigen, aber zerstörten Tor liegt eine weite Ebene, wohin wird es dananch weiter gehen?"));
            
            WinningRoom = GetRoomByName("Bergkamm");

            //RoomConnection

            GetRoomByName("Eingangstore von Gloria").Neighbors.Add(Direction.Süden, GetRoomByName("Eingangshalle"));

            GetRoomByName("Eingangshalle").Neighbors.Add(Direction.Norden, GetRoomByName("Eingangstore von Gloria"));
            GetRoomByName("Eingangshalle").Neighbors.Add(Direction.Osten, GetRoomByName("Schmiede"));
            GetRoomByName("Eingangshalle").Neighbors.Add(Direction.Süden, GetRoomByName("Thronsaal"));
            GetRoomByName("Eingangshalle").Neighbors.Add(Direction.Westen, GetRoomByName("Grabkammer von Balun"));

            GetRoomByName("Grabkammer von Balun").Neighbors.Add(Direction.Westen, GetRoomByName("Eingangshalle"));

            GetRoomByName("Schmiede").Neighbors.Add(Direction.Osten, GetRoomByName("Eingangshalle"));
            GetRoomByName("Schmiede").Neighbors.Add(Direction.Süden, GetRoomByName("Einundzwanzigste Halle"));

            GetRoomByName("Thronsaal").Neighbors.Add(Direction.Osten, GetRoomByName("Einundzwanzigste Halle"));
            GetRoomByName("Thronsaal").Neighbors.Add(Direction.Norden, GetRoomByName("Eingangshalle"));

            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Norden, GetRoomByName("Schmiede"));
            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Süden, GetRoomByName("Brücke von Khazad-dumm"));
            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Westen, GetRoomByName("Thronsaal"));

            GetRoomByName("Brücke von Khazad-Dumm").Neighbors.Add(Direction.Norden, GetRoomByName("Einundzwanzigste Halle"));
            GetRoomByName("Brücke von Khazad-Dumm").Neighbors.Add(Direction.Süden, GetRoomByName("Bergkamm"));

            GetRoomByName("Bergkamm").Neighbors.Add(Direction.Norden, GetRoomByName("Brücke von Khazad-Dumm"));

            //Items in the Rooms

            GetRoomByName("Grabkammer von Balun").Inventory.Add(GetItemByName("Grabstein"));

            GetRoomByName("Schmiede").Inventory.Add(GetItemByName("Thors Hammer"));

            GetRoomByName("Thronsaal").Inventory.Add(GetItemByName("Krone"));

            //NPCs

            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));
            NPCs.Add(new NPC("Uruk-hai", "Die Uruks sind meisten anderen Orks an Körpergröße und Kraft überlegen. Ob er uns töten will?", 50, 5, "Sarumaaaaaaaaaaaaaaniiii", false, true));
            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));
            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));
            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));
            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));
            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 50, 5, "ARAHAHAHAHAHAHAHAHA", true, false));



            
            




        }
        private static Room GetRoomByName(string name)
        {
            return Rooms.Find(x => x.Name.ToLower() == name.ToLower());
        }

        private static Item GetItemByName(string name)
        {
            return Items.Find(x => x.Name.ToLower() == name.ToLower());
        }

        private static NPC GetNPCByName(string name)
        {
            return NPCs.Find(x => x.Name.ToLower() == name.ToLower());
        }

        private static PlayerDialog GetPlayerDialogModelByDialogPartnerName(string name)
        {
            return Player.Dialogs.Find(x => x.DialogPartner.Name.ToLower() == name.ToLower());
        }


    }

    
}
