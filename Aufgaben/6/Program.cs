using System;
using System.Collections.Generic;

namespace _6
{
    class Aufgabe5
    {
        static void Main(string[] args)
        {
            
        }
    }
    
    class Person
    {
        public string Name;
        public int Alter;

    }

    class Teilnehmer : Person 
    {
        public int Matrikelnummer;
        public List<Kurse> Kurse;
    }

    class Dozent : Person
    {
        public string BueroNr;
        public string Sprechstunde;
        public List<Kurse> Kurse;

        public void GegebeneKurse() 
        {
            Console.WriteLine("Ich unterrichte: ");
            foreach (var kurs in Kurse)
            {
                Console.WriteLine("-"+ kurs);
            }
        }
        public List<Teilnehmer> AlleTeilnehmer()
        {
            var teilnehmer = new List<Teilnehmer>();
            foreach(var kurs in Kurse)
            {

                teilnehmer.AddRange(kurs.Teilnehmer);
            }
            return teilnehmer;
        }
    }


    class Kurse
    {
        public string Titel;
        public string Wochentag;
        public int Uhrzeit;
        public string Raum;
        public string Infotext()
        {
            return "Die Veranstaltung '" + Titel + "' von Dozent/in " + Dozent.Name + " findet am " + Wochentag + "um" + Uhrzeit + " im Raum " + Raum + " statt.";
        }
    }
}
