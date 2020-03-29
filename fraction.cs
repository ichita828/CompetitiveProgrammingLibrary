public class fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }
    public fraction(int x, int y) //  x / y
    {

        Numerator = x;
        Denominator = y;
        yakubun();

    }
    public static implicit operator fraction(int x)
    {
        return new fraction(x, 1);
    }
    public static explicit operator double(fraction x)
    {
        return (double)x.Numerator / (double)x.Denominator;
    }
    public void yakubun()
    {
        int x = (int)gcd((long)Numerator, (long)Denominator);
        Numerator /= x;
        Denominator /= x;
    }
    public static void yakubun(ref fraction a)
    {
        int x = (int)gcd((long)a.Numerator, (long)a.Denominator);
        a.Numerator /= x;
        a.Denominator /= x;
    }
    public static void tubun(ref fraction a, ref fraction b)
    {
        int x = (int)lcm(a.Denominator, b.Denominator);
        a.Numerator = a.Numerator * x / a.Denominator;
        b.Numerator = b.Numerator * x / b.Denominator;
        a.Denominator = x;
        b.Denominator = x;
    }
    public static void write(fraction a)
    {
        io.write(a.Numerator, a.Denominator);
    }

    public static fraction operator +(fraction a, fraction b)
    {
        tubun(ref a, ref b);
        int nume = a.Numerator + b.Numerator;
        int deno = a.Denominator;
        return new fraction(nume, deno);
    }
    public static fraction operator -(fraction a, fraction b)
    {
        tubun(ref a, ref b);
        int nume = a.Numerator - b.Numerator;
        int deno = a.Denominator;
        var x = new fraction(nume, deno);
        yakubun(ref x);
        return x;
    }
    public static fraction operator *(fraction a, fraction b)
    {
        int nume = a.Numerator * b.Numerator;
        int deno = a.Denominator * b.Denominator;
        var x = new fraction(nume, deno);
        yakubun(ref x);
        return x;
    }
    public static fraction operator /(fraction a, fraction b)
    {
        int nume = a.Numerator * b.Denominator;
        int deno = a.Denominator * b.Numerator;
        var x = new fraction(nume, deno);
        yakubun(ref x);
        return x;
    }
    public static bool operator ==(fraction a, fraction b)
    {
        fraction x = a - b;
        return (double)x == 0;
    }
    public static bool operator !=(fraction a, fraction b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (this.GetType() != obj.GetType()) return false;
        var c = (fraction)obj;
        return (c.Numerator == this.Numerator && c.Denominator == this.Denominator);
    }

    public override int GetHashCode()
    {
        return -1;
    }

}