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
             {
            LoadGameData();
            Console.WriteLine(Environment.NewLine + "Die Geheimnisse von Gloria!" + Environment.NewLine);
            Console.WriteLine("Du hast dich durch tiefe Täler bis hin zum höchtsen Gipfel durchgeschlagen. Du bist müde und ausgelaugt und weißt nicht wohin mit dir.");
            Console.WriteLine("Du machst halt an einem See. Mittlerweile ist es dunkel geworden und der Mond schiebt sich hinter den Wolken hervor.");
            Console.WriteLine("Doch was ist das. Die Felswand an der du dich bis eben gelehnt hast, erstrahlt im Schein des Mondes und eine Tür zeichnet sich ab.");
            Console.WriteLine("Das muss Mithril sein. Es wird nur im Mond- und Sternenlicht sichtbar. Es ist der sagenumwobene Eingang zu den Minen von Gloria...");

            while(true)
            {
                if(Player.CurrentRoom == WinningRoom)
                {
                    Console.WriteLine("Du hast es geschafft du bist beim " + WinningRoom.Name + " angekommen. Herzlichen Glückwunsch! Um weitere Abendteuer zu erleben hol dir unsere DLCs. Bis zum nächsten Mal.");
                    IsFinished = true;
                }

                if (IsFinished == true)
                {
                    Console.WriteLine("Vielen Dank fürs mitspielen!");
                    break;
                }

                

                Console.WriteLine(Environment.NewLine + "Um Hilfe zu erhalten, gebe einfach ein 'h' ein" + Environment.NewLine);

                string input = Console.ReadLine().ToLower();

                string command = input.IndexOf(" ") > -1 
                  ? input.Substring(0, input.IndexOf(" "))
                  : input;

                string parameter = input.IndexOf(" ") > -1 
                  ? input.Substring(input.IndexOf(" ") + 1, input.Length - (input.IndexOf(" ") + 1))
                  : "";
                
                switch(command)
                {
                    case "e":
                        IsFinished = true;
                        break;
                    case "h":
                        Player.Help();
                        break;
                    case "i":
                        Player.ActualInventory();
                        break;
                    case "u":
                        Player.Look();
                        break;
                    case "g":
                        Player.Move(parameter);
                        break;
                    case "n":
                        Player.Take(parameter);
                        break;
                    case "w":
                        Player.Drop(parameter);
                        break;
                    case "a":
                        Player.LookAt(parameter);
                        break;
                    case "l":
                        Player.Loot(parameter);
                        break;
                    case "atk":
                        Player.Attack(parameter);
                        break;
                    case "inf":
                        Player.PlayerInfo();
                        break;
                    case "b":
                        Player.Use(parameter);
                        break;
                    case "s":
                        Player.SpeakTo(parameter);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe! Für Hilfe einfach (h) eingeben!");
                        break;
                }
            }
        }
            
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
            Items.Add(new Weapon("Schmiedehammer", "Ein Hammer zum Schieden oder um jemanden den Kopf einzuschlagen.", true, 6));
            Items.Add(new Weapon("Feuerpeitsche", "Am Griff hängen noch Barthaare-sehen aus wie von einem Zauberer...", true, 1000));
            Items.Add(new Weapon("Thors Hammer", "Niemand außer Thor selbst war bisher würdig genug ihn zu führen oder gabs da nicht mal einen Typen namens Steve?", false, 10000));

            //Rooms
            Rooms.Add(new Room("Eingangstore von Gloria", "Die Eingangstore zu den gewaltigen Minen von Gloria. Sprich Freund und tritt ein!"));
            Rooms.Add(new Room("Eingangshalle", "Herzlich Willkommen in den Minen von Gloria, werdet Zeuge der Gastfreundschaft der Zwerge, gut abgehangenes Fleisch, prasselnde Kaminfeu... Ähm was ist denn hier los wieso liegen hier so viele Zwergenskelette?!"));
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

            GetRoomByName("Grabkammer von Balun").Neighbors.Add(Direction.Osten, GetRoomByName("Eingangshalle"));

            GetRoomByName("Schmiede").Neighbors.Add(Direction.Osten, GetRoomByName("Eingangshalle"));
            GetRoomByName("Schmiede").Neighbors.Add(Direction.Süden, GetRoomByName("Einundzwanzigste Halle"));

            GetRoomByName("Thronsaal").Neighbors.Add(Direction.Osten, GetRoomByName("Einundzwanzigste Halle"));
            GetRoomByName("Thronsaal").Neighbors.Add(Direction.Norden, GetRoomByName("Eingangshalle"));

            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Norden, GetRoomByName("Schmiede"));
            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Süden, GetRoomByName("Brücke von Khazad-dumm"));
            GetRoomByName("Einundzwanzigste Halle").Neighbors.Add(Direction.Westen, GetRoomByName("Thronsaal"));

            GetRoomByName("Brücke von Khazad-dumm").Neighbors.Add(Direction.Norden, GetRoomByName("Einundzwanzigste Halle"));
            GetRoomByName("Brücke von Khazad-dumm").Neighbors.Add(Direction.Süden, GetRoomByName("Bergkamm"));

            GetRoomByName("Bergkamm").Neighbors.Add(Direction.Norden, GetRoomByName("Brücke von Khazad-Dumm"));

            //Items in the Rooms

            GetRoomByName("Grabkammer von Balun").Inventory.Add(GetItemByName("Grabstein"));

            GetRoomByName("Schmiede").Inventory.Add(GetItemByName("Thors Hammer"));

            GetRoomByName("Thronsaal").Inventory.Add(GetItemByName("Zerbrochene Krone"));

            //NPCs

            NPCs.Add(new NPC("Orkläufer", "Ein ganz normaler Ork. Nicht besonders helle.", 30, 5, "ARAHAHAHAHAHAHAHAHA!", true, false));
            NPCs.Add(new NPC("Uruk-hai", "Die Uruks sind den meisten anderen Orks an Körpergröße und Kraft überlegen. Ob er uns töten will?", 50, 5, "Sarumaaaaaaaaaaaaaaniiii!", false, true));
            NPCs.Add(new NPC("Zombie Balun", "Der arme Balun. Was ihm wohl zugestoßen ist?", 75, 6, "*Hechel* *Hechel*", true, false));
            NPCs.Add(new NPC("Schmied", "Endlich ein Überlebender. Vielleicht kann er mir sagen, was hier passiert ist?", 50, 5, "Für Balun!", false, true));
            NPCs.Add(new NPC("Zwergen", "Ein toter Zwerg. Vielleicht hat er etwas von Wert bei sich. Er braucht es jetzt ja nicht mehr", 0, 0, "...", false, false));
            NPCs.Add(new NPC("Ork", "Ein toter Ork. Vielleicht hat er etwas von Wert bei sich. Er hatte es sowieso nicht verdient", 0, 0, "...", false, false));
            NPCs.Add(new NPC("Balrog", "Der Balrog von Goria. Ein Dämon des Schreckens", 100, 10, "durbaaaaaatulûk!", true, false));

            // NPCs Inventory

            GetNPCByName("Orkläufer").Inventory.Add(GetItemByName("Orkzahn"));
            GetNPCByName("Orkläufer").Inventory.Add(GetItemByName("Stock"));

            GetNPCByName("Uruk-hai").Inventory.Add(GetItemByName("Uruk-Horn"));
            GetNPCByName("Uruk-hai").Inventory.Add(GetItemByName("Rostiges Schwert"));

            GetNPCByName("Zombie Balun").Inventory.Add(GetItemByName("Kleiner Heiltrank"));
            GetNPCByName("Zombie Balun").Inventory.Add(GetItemByName("Streitaxt des Baluns"));

            GetNPCByName("Schmied").Inventory.Add(GetItemByName("Schmiedehammer"));
            GetNPCByName("Schmied").Inventory.Add(GetItemByName("Großer Heiltrank"));

            GetNPCByName("Orkleiche").Inventory.Add(GetItemByName("Heilshot"));
            GetNPCByName("Orkleiche").Inventory.Add(GetItemByName("Stricknadeln"));

            GetNPCByName("Zwergenleiche").Inventory.Add(GetItemByName("Metbierhorn"));
            GetNPCByName("Zwergenleiche").Inventory.Add(GetItemByName("Licht Herrendils"));

            GetNPCByName("Balrog").Inventory.Add(GetItemByName("Feuerpeitsche"));

            //NPC to Rooms

            GetRoomByName("Eingangshalle").NPCs.Add(GetNPCByName("Orkläufer"));
            GetRoomByName("Eingangshalle").NPCs.Add(GetNPCByName("Uruk-hai"));

            GetRoomByName("Grabkammer von Balun").NPCs.Add(GetNPCByName("Zombie Balun"));

            GetRoomByName("Thronsaal").NPCs.Add(GetNPCByName("Zwergenleiche"));

            GetRoomByName("Schmiede").NPCs.Add(GetNPCByName("Schmied"));

            GetRoomByName("Einundzwanzigste Halle").NPCs.Add(GetNPCByName("Orkleiche"));

            GetRoomByName("Brücke von Khazad-dumm").NPCs.Add(GetNPCByName("Balrog"));

            //Player

            Player.Create("Herr Vorragend", "Du bist einfach hervorragend!", 200, 4, GetRoomByName("Eingangstore von Gloria"));
            Player = Player.Instance;

            // NPC Dialoglines

            GetNPCByName("Uruk-hai").DialogLines.Add(new CharDialogLine("Was willst du hier Mensch?", 0, null));
            GetNPCByName("Uruk-hai").DialogLines.Add(new CharDialogLine("Dann geh mir aus den Augen, sonst werde ich dich bei lebendigem Leibe fressen.", 1, null));
            GetNPCByName("Uruk-hai").DialogLines.Add(new CharDialogLine("Dann versuch es doch, solange du noch kannst.", 2, null));

            GetNPCByName("Schmied").DialogLines.Add(new CharDialogLine("Endlich ein Lebender der kein Ork ist! Hast du den Uruk in der Eingangshalle getötet?", 0, null));
            GetNPCByName("Schmied").DialogLines.Add(new CharDialogLine("Vielen Dank! Hier das ist für dich.", 1, GetItemByName("Großer Heiltrank")));
            GetNPCByName("Schmied").DialogLines.Add(new CharDialogLine("Schade. Wenn du das machst, bekommst etwas von mir", 2, GetItemByName("Großer Heiltrank")));



            //PlayerDialog

            Player.Dialogs.Add(new PlayerDialog(GetNPCByName("Uruk-hai")));
            Player.Dialogs.Add(new PlayerDialog(GetNPCByName("Schmied")));

            //PlayerDialoglines

            GetPlayerDialogByDialogPartnerName("Uruk-hai").DialogLines.Add(new PlayerDialogLine("Gar nichts. Ich bin nur auf der Durchreise.", 0, null, 1, 1));
            GetPlayerDialogByDialogPartnerName("Uruk-hai").DialogLines.Add(new PlayerDialogLine("Dich töten.", 0, null, 2, 2));


            GetPlayerDialogByDialogPartnerName("Schmied").DialogLines.Add(new PlayerDialogLine("Ja", 0, null, 1, 1));
            GetPlayerDialogByDialogPartnerName("Schmied").DialogLines.Add(new PlayerDialogLine("Nein", 0, null, 2, 2));

            







            
            




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

        private static PlayerDialog GetPlayerDialogByDialogPartnerName(string name)
        {
            return Player.Dialogs.Find(x => x.DialogPartner.Name.ToLower() == name.ToLower());
        }


    }

    
}
