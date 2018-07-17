using System;
using System.Collections.Generic;

namespace TextAdeventure_Die_Minen_von_Gloria
{
    class Character: GameObject
    {
        public int Health;
        public int Damage;
        public List<Item> Inventory = new List<Item>();

    

    public void Fight(Player player, NPC opponent)
    {
        bool leaveFight = false;
        
        Console.WriteLine(opponent.FightQuote + " " + opponent.Name + " kommt auf dich zu und greift an.");

        while(!leaveFight)
        {
            Console.WriteLine(Environment.NewLine + "Was willst du tun? Du hast 3 Optionen:");
            Console.WriteLine("Wenn du einen leichten, aber präzisen Angriff starten möchtest, dann drücke die (1).");
            Console.WriteLine("Wenn du einen gewältigen, beidhändig ausgeführten Angriff ausgeführen möchtest dann drücke die (2). Aber sei gewarnt! Wenn es kann dabei passieren, dass du dein Ziel verfehlst.");
            Console.WriteLine("Die dritte Option ist wie ein Weichei davon zu laufen und das Abenteuer hier und jetzt zu beenden. Wenn du mit dieser Bürde bis zum Ende deiner Tage leben möchtest, dann bitte schön, einfach die (3) drücken und nach Hause zu Mami laufen.");
            
            string command = Console.ReadLine();
            Random rnd = new Random();

            switch (command)
            {
                case "1":
                    Attack(player, opponent, false);
                    break;

                case "2":
                    Attack(player, opponent, true);
                    break;

                case "3":
                    TextAdventure.IsFinished = true;
                    leaveFight = true;
                    break;

                default:
                    Console.WriteLine("Ist es so schwer einfach eine der Zahlen 1, 2 oder 3 ein zu tippen? Tja jetzt ist dein Gegner dran!");
                    break;                  
            }

             if (opponent.Health == 0)
                {
                    Console.WriteLine("Du hast ihn besiegt. Herzlichen Glückwunsch! Du kannst in jetzt looten.");
                    opponent.Description += " " + " Oh stimmt ja und du hast ihn umgebracht.";
                    break;
                }

                int opponentAttack = rnd.Next(1, 3);
                
                
            Console.WriteLine("Jetzt greift dein Gegner dich an...");

                   switch  (opponentAttack)
                   {
                       case 1:
                           Attack (opponent, player, false);
                           break;
                       case 2:
                           Attack (opponent, player, true);
                           break;
                       default:
                           break;
                   }

               if (player.Health == 0)
               {
                   Console.WriteLine("Dieses Mal warst du nicht stark genug. Die Minen von Gloria sind ein rauer Ort. Hoffentlich wirst du bei nächsten Mal besser sein!");
                   TextAdventure.IsFinished = true;
                   break;
               }  
            }
        }

        public void Attack (Character attacker, Character victim, bool hardHit)
        {
            Random rnd = new Random();
            int chanceToHit;
            int minDamageMultiplier;
            int maxDamageMultiplier;
            
            if(hardHit)
            {
                chanceToHit = 50;
                minDamageMultiplier = 2;
                maxDamageMultiplier = 4;
            } 
            else
            {
                chanceToHit = 80;
                minDamageMultiplier = 1;
                maxDamageMultiplier = 2;
            }
            if (rnd.Next(1, 101) > chanceToHit)
            {
                Console.WriteLine(attacker.Name + " hat sein Ziel verfehlt!");
            }
            else 
            {
                var damage = attacker.Damage * rnd.Next(minDamageMultiplier, maxDamageMultiplier+1);
                victim.Health -= damage;
                if (victim.Health <= 0)
                    victim.Health = 0;
                Console.WriteLine(victim.Name + " hat " + damage + " Schaden erlitten. " + victim.Name + " hat jetzt noch " + victim.Health + " Leben.");
            }
            
        }

        public void Dialog (Player player, NPC dialogPartner)
        {
            if(player.Health <=0)
            {
                return;
            }

            if(!dialogPartner.CanSpeak)
            {
                Console.WriteLine("Sorry, aber mit " + dialogPartner.Name + " dem kannst du nicht sprechen. Das hättest du dir auch denken können, so wie der aussieht.");
                return;
            }

            PlayerDialog playerDialog = player.Dialogs.Find(x => x.DialogPartner.Name == dialogPartner.Name);

            Console.WriteLine("Du hast ein Gespräch mit " + dialogPartner.Name + " angefangen. Um deine Anwort auszuwählen, gib einfach die Zahl der zur Verfügung stehenden Möglichkeiten ein.");

            while(dialogPartner.CanSpeak)
            {
                CharDialogLine npcLine = dialogPartner.DialogLines.Find(x => x.DialogPhase == playerDialog.DialogPhase);
                Console.WriteLine(Environment.NewLine + dialogPartner.Name + ": " + npcLine.Line);

                if (npcLine.Reward != null && dialogPartner.Inventory.Contains(npcLine.Reward))
                {
                    player.Inventory.Add(npcLine.Reward);
                    dialogPartner.Inventory.Remove(npcLine.Reward);
                }
                foreach(PlayerDialogLine playerDialogLine in playerDialog.DialogLines)
                { 
                    if(playerDialogLine.DialogPhase == playerDialog.DialogPhase)
                    {
                        Console.WriteLine(playerDialogLine.LineNumber + ": " + playerDialogLine.Line);
                    }
                }
                Console.WriteLine("0: (Auf Wiedersehen!)");

                string command = Console.ReadLine();
                int commandNumber;

                if (command == "0")
                {
                    Console.WriteLine("Du hast das Gespräch beendet");
                    break;
                }
                else if (Int32.TryParse(command, out commandNumber))
                {
                    PlayerDialogLine playerDialogLine = playerDialog.DialogLines.Find(x => x.LineNumber == commandNumber && x.DialogPhase == playerDialog.DialogPhase);
                    if(playerDialogLine == null)
                        Console.WriteLine("Bitte wähle eine Zahl aus, die einer Antwortzeile entspricht.");
                    else
                    {
                        if (playerDialogLine.Reward != null)
                        {
                            if(player.Inventory.Contains(playerDialogLine.Reward))
                            {
                                dialogPartner.Inventory.Add(playerDialogLine.Reward);
                                player.Inventory.Remove(playerDialogLine.Reward);
                                Console.WriteLine("Du: " + playerDialogLine.Line);
                                playerDialog.DialogPhase = playerDialogLine.NewPhase;
                            } 
                            else
                                Console.WriteLine("Du hast " + playerDialogLine.Reward.Name + " nicht in deinem Inventar");
                        }
                        else
                        {
                            Console.WriteLine("Du: " + playerDialogLine.Line);
                            playerDialog.DialogPhase = playerDialogLine.NewPhase;
                        }
                    }
                } 
                else
                    Console.WriteLine("Bitte gebe eine gültige Zahl ein, komm schon so schwer ist das gar nicht!");
            }


        }

    }
    

}