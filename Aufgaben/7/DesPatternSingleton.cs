using System;
using System.Collections.Generic;

namespace DesPatternSingleton
{

    public class Person
    {
        public string Name;
        public int Age;
        private int Id;

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", " + "Id: " + Id;
        }
        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
            this.Id = IDGenerator.GetInstance().GibMirNeId();
        }
    }

    /*
    class GlobalVariables
    {
        // public static int letzteID = 1;
        public static IDGenerator DerIdMacher = new IDGenerator();
    }
    */

    public class IDGenerator
    {
        private IDGenerator()
        {
            letzteID = 1;
        }

        private static IDGenerator _instance;

        public static IDGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new IDGenerator();
            return _instance;
        }

        private int letzteID;
        public int GibMirNeId()
        {
            return letzteID++;
        }
    } 

    class Program
    {

        static void Main(string[] args)
        {
            

            List<Person> personen = new List<Person>();

            // Eine Stelle, an der Personen angelegt werden
            personen.Add(new Person("Dieter", 44));
            personen.Add(new Person("Horst", 45));
            personen.Add(new Person("Walter", 33));
            personen.Add(new Person("Karl-Heinz", 22));


            // Eine ANDERE Stelle, an der Personen angelegt werden
            personen.Add(new Person("Brunhilde", 56));
            personen.Add(new Person("Maria", 75));
            personen.Add(new Person("Kunigunde", 22));
            personen.Add(new Person("Tusnelda", 12));





            foreach (var person in personen)
                Console.WriteLine(person);

        }
    }
}
