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
                case w:
                Console.WriteLine(getCubeInfo(d));
                break;

                case k:
                Console.WriteLine(getSphereInfo(d));
                break;

                case o:
                Console.WriteLine(getOctaInfo(d));
                break;
            }
          
        }

        static public double getCubeSurface(double d)
        {
            return double A = 6 * (d * d);
        }

        static public double getCubeVolume(double d)
        {
            return double V = d * d * d;
        }
        static public string getCubeInfo(double d)
        {
            return string end = "Würfel:   " + "A= " + getCubeSurface(d) + " | " + "V= " + getCubeVolume(d);
        }

        public static double getSphereSurface(double d)
        {
           return double A = Math.PI * (d * d);

        }
        public static double getSphereVolume(double d)
        {
            return double V = (Math.PI * (d * d * d)) / 6;
        }
        public static string getSphereInfo(double d)
        {
            return string end = "Kugel:   " + "A= " + getOctaSurface(d) + " | " + "V= " + getCubeVolume(d);
        }
        public static double getOctaSurface(double d)
        {
            double A = 2 * (Math.Sqrt(3) * (d * d));
            return A;
        }
        public static double getOctaVolume(double d)
        {
            double V = (Math.Sqrt(2) * (d * d * d)) / 3;
            return V;
        }
        public static string getOctaInfo(double d)
        {
            string end = "Oktaeder:   " + "A= " + getOctaSurface(d) + " | " + "V= " + getOctaVolume(d);
            return end;
        }
    }
}
