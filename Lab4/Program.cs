using System;

namespace FractionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first fraction:");
            Fraction fraction1 = Fraction.InputFraction();
            
            Console.WriteLine("Enter the second fraction:");
            Fraction fraction2 = Fraction.InputFraction();
            
            Console.WriteLine($"Fraction 1: {fraction1}");
            Console.WriteLine($"Fraction 2: {fraction2}");
            
            Fraction sum = fraction1.Add(fraction2);
            Fraction difference = fraction1.Subtract(fraction2);
            Fraction product = fraction1.Multiply(fraction2);
            Fraction quotient = fraction1.Divide(fraction2);
            
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");
            
            Console.WriteLine("Comparison:");
            Console.WriteLine($"Fraction1 == Fraction2: {fraction1.Equals(fraction2)}");
            Console.WriteLine($"Fraction1 > Fraction2: {fraction1 > fraction2}");
            Console.WriteLine($"Fraction1 < Fraction2: {fraction1 < fraction2}");
        }
    }

    public class Fraction
    {
        private int numerator;
        private int denominator;
        
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            this.numerator = numerator;
            this.denominator = denominator;
            Reduce();
        }
        
        private void Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), denominator);
            numerator /= gcd;
            denominator /= gcd;
        }
        
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        
        public static Fraction InputFraction()
        {
            Console.Write("Enter the numerator: ");
            int numerator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the denominator: ");
            int denominator = Convert.ToInt32(Console.ReadLine());
            return new Fraction(numerator, denominator);
        }
        
        public Fraction Add(Fraction other)
        {
            int newNumerator = this.numerator * other.denominator + other.numerator * this.denominator;
            int newDenominator = this.denominator * other.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Subtract(Fraction other)
        {
            int newNumerator = this.numerator * other.denominator - other.numerator * this.denominator;
            int newDenominator = this.denominator * other.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction other)
        {
            return new Fraction(this.numerator * other.numerator, this.denominator * other.denominator);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return new Fraction(this.numerator * other.denominator, this.denominator * other.numerator);
        }
        
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator > b.numerator * a.denominator;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator < b.numerator * a.denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Fraction other = (Fraction)obj;
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }
        
        public override string ToString()
        {
            if (denominator == 1)
            {
                return $"{numerator}";
            }
            return $"{numerator}/{denominator}";
        }
    }
}
