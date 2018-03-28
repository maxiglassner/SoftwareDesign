using System;

namespace Aufgabe1
{
    class Program
    {

        static void Main(string[] args)
        {
            string name = args[0];
            double d = Convert.ToDouble(args[1]);
            if (name == "w")
            {
                Console.WriteLine(getCubeInfo(d));
            }
            if (name == "k")
            {
                getSphereSurface(d);
                getSphereVolume(d);
                getSphereInfo(d);
            }
            if (name == "o")
                Console.WriteLine();
        }

        static public double getCubeSurface(double d)
        {
            double A = 6 * (d * d);
            return A;
        }

        static public double getCubeVolume(double d)
        {
            double V = d * d * d;
            return V;
        }
        static public string getCubeInfo(double d)
        {
            string end = "Würfel:   " + "A= " + getCubeSurface(d) + " | " + "V= " + getCubeVolume(d);
            return end;
        }

        public static void getSphereSurface()
        {
            A = Math.PI * (d * d);
        }
        public static void getSphereVolume()
        {
            V = (Math.PI * (d * d * d)) / 6;
        }
        public static void getSphereInfo()
        {
            end = "Kugel:   " + "A= " + A + " | " + "V= " + V;
        }
        public static void getOctaSurface()
        {
            A = 2 * (Math.Sqrt(3) * (d * d));
        }
        public static void getOctaVolume()
        {
            V = (Math.Sqrt(2) * (d * d * d)) / 3;
        }
        public static void getOctaInfo()
        {
            end = "Oktaeder:   " + "A= " + A + " | " + "V= " + V;
        }
    }
}
