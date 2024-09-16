using System;

namespace Lab2
{
     class Program
    {
        public static void Main(string[] args)
        {
           Console.InputEncoding = System.Text.Encoding.UTF8;
           Console.OutputEncoding = System.Text.Encoding.UTF8;
           
           Console.WriteLine("Constructor by default");
           Vector defaultVector = new Vector();
           PrintVectorInfo(defaultVector);
           
           Console.WriteLine("Constructor with parameters");
           Console.WriteLine("Enter the length of the vector (real non negative number): ");
           double vectorMagnitude = Double.Parse(Console.ReadLine());
           Console.WriteLine("Enter the angle of the vector (in polar system of degrees): ");
           double vectorAngle = Double.Parse(Console.ReadLine());
           Vector paramVector = new Vector(vectorMagnitude, vectorAngle);
           PrintVectorInfo(paramVector);
           
           Console.WriteLine("Constructor of copying vector");
           Vector copyVector = new Vector(paramVector);
           PrintVectorInfo(copyVector);
        }

        public static void PrintVectorInfo(Vector vector)
        {
            Console.WriteLine("\nLength of Vector: {0}", vector.GetMagnitude());
            Console.WriteLine("Angle of Vector: {0}", vector.GetAngle());
            
            double[] coordinates = vector.GetTerminalPointCoordinates();
            Console.WriteLine("Coordinates of end points of the vector: ");
            Console.WriteLine("\tx: {0}", coordinates[0]);
            Console.WriteLine("\ty: {0}\n", coordinates[1]);
        }
    }
    

    public class Vector
    {
        private double magnitude;
        private double angle;

        public const double degreesToRadians = Math.PI / 180.0;
        public const double radiansToDegrees = 180.0 / Math.PI;
        

        public double GetMagnitude()
        {
            return magnitude;
        }

        public double GetAngle()
        {
            return angle;
        }

        public void SetMagnitude(double magnitude)
        {
            if (magnitude >= 0.0)
            {
                this.magnitude = magnitude;
            }
            else
            {
                throw new ArgumentException("Magnitude must be greater than zero");
            }
        }

        public void SetAngle(double angle)
        {
            this.angle = angle;
        }

        public double[] GetTerminalPointCoordinates()
        {
            double x = magnitude * Math.Cos(angle * degreesToRadians);
            double y = magnitude * Math.Sin(angle * degreesToRadians);
            
            x = Math.Abs(x) < 1e-10 ? 0 : x;
            y = Math.Abs(y) < 1e-10 ? 0 : y;
            
            return new double[] { x, y };
        }

        public Vector()
        {
            this.magnitude = 0.0;
            this.angle = 0.0;
        }

        public Vector(double magnitude, double angle)
        {
            if (magnitude >= 0.0)
            {
                this.magnitude = magnitude;
                this.angle = angle;
            }
            else
            {
                throw new ArgumentException("Magnitude must be greater than zero");
            }
        }

        public Vector(Vector other)
        {
            this.magnitude = other.magnitude;
            this.angle = other.angle;
        }
    }
}