using System;

namespace Aufgabe1
{
    class Program
    {

        static void Main(string[] args)
        {
            string name = args[0];
            double d = Convert.ToDouble(args[1]);
            switch (name)
            {
                case "w":
                Console.WriteLine(getCubeInfo(d));
                break;

                case "k":
                Console.WriteLine(getSphereInfo(d));
                break;

                case "o":
                Console.WriteLine(getOctaInfo(d));
                break;
            }
          
        }

        static public double getCubeSurface(double d)
        {
            double A = Math.Round(6 * (d * d), 2);
            return A;
        }

        static public double getCubeVolume(double d)
        {
            double V = Math.Round(d * d * d, 2);
            return V;
        }
        static public string getCubeInfo(double d)
        {
            string end = "Würfel:   " + "A= " + getCubeSurface(d) + " | " + "V= " + getCubeVolume(d);
            return end;
        }

        public static double getSphereSurface(double d)
        {
           double A = Math.Round(Math.PI * (d * d), 2);
           return A;

        }
        public static double getSphereVolume(double d)
        {
            double V = Math.Round((Math.PI * (d * d * d) / 6), 2);
            return V;
        }
        public static string getSphereInfo(double d)
        {
            string end = "Kugel:   " + "A= " + getOctaSurface(d) + " | " + "V= " + getCubeVolume(d);
            return end;
        }
        public static double getOctaSurface(double d)
        {
            double A = Math.Round(2 * (Math.Sqrt(3) * (d * d)), 2);
            return A;
        }
        public static double getOctaVolume(double d)
        {
            double V = Math.Round((Math.Sqrt(2) * (d * d * d)) / 3, 2);
            return V;
        }
        public static string getOctaInfo(double d)
        {
            string end = "Oktaeder:   " + "A= " + getOctaSurface(d) + " | " + "V= " + getOctaVolume(d);
            return end;
        }
    }
}
