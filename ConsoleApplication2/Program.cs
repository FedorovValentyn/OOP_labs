using System;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            String com0 = "\n0: Close the program\n";
            String com1 = "1: Enter the plane equation coefficients\n";
            String com2 = "2: Derive the coefficients of the equation of the plane\n";
            String com3 = "3: Check if the point belongs to the plane\n";
            String com4 = "4: Find the projection of a point onto the plane\n";
            String com5 = "5: Find the point of intersection of a straight line with a plane\n";
            String com6 = "6: Establish parallelism with another plane\n";

            double a, b, c, d, x, y, z, u, v, w;
            int choice;
            IPlane plane = new Plane(); 
            menu:
            Console.WriteLine(com0 + com1 + com2 + com3 + com4 + com5 + com6);
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                default:
                    Console.WriteLine("Please enter a number");
                    goto menu;
                case 0:
                    break;
                case 1:
                    Console.WriteLine("a : ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("b : ");
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("c : ");
                    c = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("d : ");
                    d = Convert.ToDouble(Console.ReadLine());
                    plane.Input(a, b, c, d);
                    goto menu;
                case 2:
                    Console.WriteLine("");
                    plane.Output();
                    goto menu;
                case 3: 
                    Console.WriteLine("Enter x: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter y: ");
                    y = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter z: ");
                    z = Convert.ToDouble(Console.ReadLine());
                    if (plane.Check(x, y, z))
                        Console.WriteLine("It belongs to the plane.");
                    else
                        Console.WriteLine("It doesn't belong to the plane.");
                    goto menu;
                case 4:
                    Console.WriteLine("Enter x: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter y: ");
                    y = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter z: ");
                    z = Convert.ToDouble(Console.ReadLine()); 
                    plane.Projection(x, y, z);
                    goto menu;
                case 5:
                    Console.WriteLine("Enter x1: ");
                    double x1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter y1: ");
                    double y1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter z1: ");
                    double z1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter u (direction vector component): ");
                    u = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter v (direction vector component): ");
                    v = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter w (direction vector component): ");
                    w = Convert.ToDouble(Console.ReadLine());
                    plane.FindIntersection(x1, y1, z1, u, v, w);
                    goto menu;
                case 6 :
                    Console.WriteLine("Enter coefficients of another plane (a2, b2, c2):");
                    double a2 = Convert.ToDouble(Console.ReadLine());
                    double b2 = Convert.ToDouble(Console.ReadLine());
                    double c2 = Convert.ToDouble(Console.ReadLine());
                    plane.CheckParallelism(a2, b2, c2);
                    goto menu;
            }
        }
    }
    
    interface IPlane
    {
        void Input(double a, double b, double c, double d);
        void Output();
        bool Check(double x, double y, double z);
        void Projection(double x, double y, double z);
        void FindIntersection(double x1, double y1, double z1, double u, double v, double w);
        void CheckParallelism(double a2, double b2, double c2);
    }
    
    class Plane : IPlane
    {
        private double A { get; set; }
        private double B { get; set; }
        private double C { get; set; }
        private double D { get; set; }

        public bool IsEmpty()
        {
            return A == 0 && B == 0 && C == 0 && D == 0;
        }
        
        public void Input(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        
        public void Output()
        {
            if (!IsEmpty())
                Console.WriteLine($"a = {A}\nb = {B}\nc = {C}\nd = {D}");
            else 
                Console.WriteLine("Plane coefficients are not set!");
        }
        
        public bool Check(double x, double y, double z)
        {
            return A * x + B * y + C * z + D == 0;
        }
        
        public void Projection(double x, double y, double z)
        {
            if (!IsEmpty())
            {
                double distance = (A * x + B * y + C * z + D) / Math.Sqrt(A * A + B * B + C * C);
                double x1 = x - A * distance;
                double y1 = y - B * distance;
                double z1 = z - C * distance;

                Console.WriteLine($"Projection point: X = {x1}, Y = {y1}, Z = {z1}");
            }
            else
            {
                Console.WriteLine("Plane coefficients are not set!");
            }
        }
        
        public void FindIntersection(double x1, double y1, double z1, double u, double v, double w)
        {
            if (!IsEmpty())
            {
                double denominator = A * u + B * v + C * w;
                if (denominator == 0)
                {
                    Console.WriteLine("The plane and the line are parallel!");
                }
                else
                {
                    double t = -(A * x1 + B * y1 + C * z1 + D) / denominator;
                    double intersectX = x1 + t * u;
                    double intersectY = y1 + t * v;
                    double intersectZ = z1 + t * w;

                    Console.WriteLine($"Intersection point: X = {intersectX}, Y = {intersectY}, Z = {intersectZ}");
                }
            }
            else
            {
                Console.WriteLine("Plane coefficients are not set!");
            }
        }
        
        public void CheckParallelism(double a2, double b2, double c2)
        {
            if ((a2 != 0 && A / a2 == B / b2 && B / b2 == C / c2) || 
                (A == 0 && a2 == 0 && B / b2 == C / c2) || 
                (B == 0 && b2 == 0 && A / a2 == C / c2) || 
                (C == 0 && c2 == 0 && A / a2 == B / b2))
            {
                Console.WriteLine("The planes are parallel.");
            }
            else
            {
                Console.WriteLine("The planes are not parallel.");
            }
        }
    }
}
