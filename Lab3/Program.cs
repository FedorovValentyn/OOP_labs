using System;

namespace Lab3
{
    class Program
    {
        public static void Main(string[] args)
        {
            String com0 = "\n0: Close the program\n";
            String com1 = "1: Enter the value of parameters\n";
            String com2 = "2: Show the value of the parameters\n";
            String com3 = "3: Calculate the square\n";
            String com4 = "4: Calculate the perimeter\n";
            String com5 = "5: Compare to another square\n";
            String com6 = "6: Operators overloading\n";

            double a, b;
            int choice;
            TSquare tsquare = new TSquare(); 
            TSquare otherSquare; 

        menu:
            Console.WriteLine(com0 + com1 + com2 + com3 + com4 + com5 + com6);
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                default:
                    Console.WriteLine("Please enter a valid number.");
                    goto menu;

                case 0:
                    return;

                case 1:
                    Console.WriteLine("Please enter a length of side A: ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter a length of side B: ");
                    b = Convert.ToDouble(Console.ReadLine());
                    tsquare.Input(a, b);
                    goto menu;

                case 2:
                    tsquare.Output();
                    goto menu;

                case 3:
                    double square = tsquare.CalculateSquare();
                    Console.WriteLine($"The area of the square is: {square}");
                    goto menu;

                case 4:
                    double perimeter = tsquare.CalculatePerimeter();
                    Console.WriteLine($"The perimeter of the square is: {perimeter}");
                    goto menu;

                case 5:
                    Console.WriteLine("Enter the side of another square: ");
                    double side = Convert.ToDouble(Console.ReadLine());
                    otherSquare = new TSquare(side, side);
                    if (tsquare.Equals(otherSquare))
                    {
                        Console.WriteLine("Both squares are equal.");
                    }
                    else
                    {
                        Console.WriteLine("The squares are not equal.");
                    }
                    goto menu;

                case 6:
                    PerformOperatorOverloading(tsquare);
                    goto menu;
            }
        }
        
        static void PerformOperatorOverloading(TSquare square)
        {
            Console.WriteLine("Enter the side of another square for operator overloading: ");
            double side = Convert.ToDouble(Console.ReadLine());
            TSquare otherSquare = new TSquare(side, side);
            
            TSquare sumSquare = square + otherSquare;
            Console.WriteLine($"Sum of squares (side length): {sumSquare.A}");
            
            TSquare subSquare = square - otherSquare;
            Console.WriteLine($"Difference of squares (side length): {subSquare.A}");
            
            Console.WriteLine("Enter a multiplier for the square: ");
            double multiplier = Convert.ToDouble(Console.ReadLine());
            TSquare mulSquare = square * multiplier;
            Console.WriteLine($"Square after multiplication (side length): {mulSquare.A}");
        }
    }

    class TSquare
    {
        public double A { get; private set; }
        public double B { get; private set; }
        
        public TSquare()
        {
            A = 0;
            B = 0;
        }
        
        public TSquare(double a, double b)
        {
            if (a != b)
                throw new ArgumentException("Both sides must be equal for a square.");
            A = a;
            B = b;
        }
        
        public void Input(double a, double b)
        {
            try
            {
                if (a != b)
                {
                    throw new Exception("The sides must be equal for a square.");
                }
                A = a;
                B = b;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }
        
        public void Output()
        {
            Console.WriteLine($"Side A: {A}, Side B: {B}");
        }
        
        public double CalculateSquare()
        {
            return A * A; 
        }
        
        public double CalculatePerimeter()
        {
            return 4 * A; 
        }
        
        public bool Equals(TSquare other)
        {
            return this.A == other.A && this.B == other.B;
        }
        
        public static TSquare operator +(TSquare s1, TSquare s2)
        {
            double newSide = s1.A + s2.A;
            return new TSquare(newSide, newSide);
        }
        
        public static TSquare operator -(TSquare s1, TSquare s2)
        {
            double newSide = s1.A - s2.A;
            return newSide < 0 ? new TSquare(0, 0) : new TSquare(newSide, newSide);
        }
        
        public static TSquare operator *(TSquare s, double multiplier)
        {
            double newSide = s.A * multiplier;
            return new TSquare(newSide, newSide);
        }
    }
}
