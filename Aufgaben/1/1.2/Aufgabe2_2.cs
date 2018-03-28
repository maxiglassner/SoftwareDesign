using System;

namespace Aufgabe2_2
{
    class Program
    {
       public static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
       public static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
       public static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static void Main(string[] args)
        {
            string[] safe = new string[6];
            for (int i = 0; i <= 5; i++)
            {
                safe[i] = GetVerse();
            }

            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(safe[i]);
            }
        }
        public static string GetVerse()
        {
            string end = "";

            Random random = new Random();
            int zahlend = random.Next(0, 6);

            Boolean usedsub = true;
            Boolean usedver = true;
            Boolean usedobj = true;

            while (usedsub)
            {
                if (subjects[zahlend] != "used")
                {
                    end = subjects[zahlend] + " ";
                    subjects[zahlend] = "used";
                    usedsub = false;
                }
            }
            while (usedver)
            {
                if (verbs[zahlend] != "used")
                {
                    end += verbs[zahlend] + " ";
                    verbs[zahlend] = "used";
                    usedver = false;
                }
            }
            while (usedobj)
            {
                if (objects[zahlend] != "used")
                {
                    end += objects[zahlend] + ".";
                    objects[zahlend] = "used";
                    usedobj = false;
                }
            }
            return end;
        }
    }
}
