using System;

namespace Aufgabe1
{
    class Program
    {

        static void Main(string[] args)
        {
            string name = args[0];
            double value = Convert.ToDouble(args[1]);
            switch (name)
            {
                case "w":
                Console.WriteLine(GetCubeInfo(value));
                break;

                case "k":
                Console.WriteLine(GetSphereInfo(value));
                break;

                case "o":
                Console.WriteLine(GetOctaInfo(value));
                break;
            }
          
        }

        static public double GetCubeSurface(double value)
        {
            double A = Math.Round(6 * (value * value), 2);
            return A;
        }

        static public double GetCubeVolume(double value)
        {
            double V = Math.Round(value * value * value, 2);
            return V;
        }
        static public string GetCubeInfo(double value)
        {
            string end = "Würfel:   " + "A= " + getCubeSurface(value) + " | " + "V= " + getCubeVolume(value);
            return end;
        }

        public static double GetSphereSurface(double value)
        {
           double A = Math.Round(Math.PI * (value * value), 2);
           return A;

        }
        public static double GetSphereVolume(double value)
        {
            double V = Math.Round((Math.PI * (value * value * value) / 6), 2);
            return V;
        }
        public static string GetSphereInfo(double value)
        {
            string end = "Kugel:   " + "A= " + getOctaSurface(value) + " | " + "V= " + getCubeVolume(value);
            return end;
        }
        public static double GetOctaSurface(double value)
        {
            double A = Math.Round(2 * (Math.Sqrt(3) * (value * value)), 2);
            return A;
        }
        public static double GetOctaVolume(double value)
        {
            double V = Math.Round((Math.Sqrt(2) * (value * value * value)) / 3, 2);
            return V;
        }
        public static string GetOctaInfo(double value)
        {
            string end = "Oktaeder:   " + "A= " + getOctaSurface(value) + " | " + "V= " + getOctaVolume(value);
            return end;
        }
    }
}
