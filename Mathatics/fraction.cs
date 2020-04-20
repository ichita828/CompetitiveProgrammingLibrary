public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }
    public Fraction(int Numer, int Denom) //  x / y
    {
        Numerator = Numer;
        Denominator = Denom;
        Simplify();
    }
    public static implicit operator Fraction(int X) => new Fraction(X, 1);
    public static explicit operator double(Fraction X) => (double)X.Numerator / (double)X.Denominator;
    public void Simplify()
    {
        long x = (int)GCD(Numerator, Denominator);
        Numerator /= x;
        Denominator /= x;
        if (Denominator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;
        }
    }
    public static void tubun(ref Fraction A, ref Fraction B)
    {
        long x = LCM(A.Denominator, B.Denominator);
        A.Numerator = A.Numerator * x / A.Denominator;
        B.Numerator = B.Numerator * x / B.Denominator;
        A.Denominator = x;
        B.Denominator = x;
    }
    public void Write()
    {
        io.Write(Numerator, Denominator);
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        tubun(ref a, ref b);
        int nume = a.Numerator + b.Numerator;
        int deno = a.Denominator;
        return new Fraction(nume, deno);
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        tubun(ref a, ref b);
        int nume = a.Numerator - b.Numerator;
        int deno = a.Denominator;
        var x = new Fraction(nume, deno);
        return x;
    }
    public static Fraction operator *(Fraction a, Fraction b)
    {
        int nume = a.Numerator * b.Numerator;
        int deno = a.Denominator * b.Denominator;
        var x = new Fraction(nume, deno);
        return x;
    }
    public static Fraction operator /(Fraction a, Fraction b)
    {
        int nume = a.Numerator * b.Denominator;
        int deno = a.Denominator * b.Numerator;
        var x = new Fraction(nume, deno);
        return x;
    }
    public static bool operator ==(Fraction a, Fraction b)
    {
        Fraction x = a - b;
        return x.Numerator == 0;
    }
    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }
    public static bool operator >(Fraction a, Fraction b)
    {
        Fraction x = a - b;
        return x.Numerator > 0;
    }
    public static bool operator <(Fraction a, Fraction b)
    {
        Fraction x = a - b;
        return x.Numerator < 0;
    }
    public static bool operator >=(Fraction a, Fraction b)
    {
        Fraction x = a - b;
        return x.Numerator >= 0;
    }
    public static bool operator <=(Fraction a, Fraction b)
    {
        Fraction x = a - b;
        return x.Numerator <= 0;
    }


    public override bool Equals(object obj)
    {
        if (this.GetType() != obj.GetType()) return false;
        var c = (Fraction)obj;
        return (c.Numerator == this.Numerator && c.Denominator == this.Denominator);
    }

    public override int GetHashCode()
    {
        return -1;
    }

}