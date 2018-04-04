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
            int zahlend;

            Boolean usedsub = true;
            Boolean usedver = true;
            Boolean usedobj = true;

            while (usedsub)
            {
                zahlend = random.Next(0, 6);

                if (subjects[zahlend] != "used")
                {
                    end = subjects[zahlend] + " ";
                    subjects[zahlend] = "used";
                    usedsub = false;
                }
                else
                {
                    zahlend = random.Next(0, 6);
                }
            }
            while (usedver)
            {
                zahlend = random.Next(0, 6);
                if (verbs[zahlend] != "used")
                {
                    end += verbs[zahlend] + " ";
                    verbs[zahlend] = "used";
                    usedver = false;
                }
                else
                {
                    zahlend = random.Next(0, 6);
                }
            }
            while (usedobj)
            {
                zahlend = random.Next(0, 6);
                if (objects[zahlend] != "used")
                {
                    end += objects[zahlend] + ".";
                    objects[zahlend] = "used";
                    usedobj = false;
                }
                else
                {
                    zahlend = random.Next(0, 6);
                }
            }
            return end;
        }
    }
}
