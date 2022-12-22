namespace MathProject;

public readonly struct Solution
{
    public double Result { get; init; }

    public bool Error { get; init; }

    public string ErrorMessage { get; init; }
}

public static class Functions
{
    internal static double Hypotenuse(double x, double y) => Math.Sqrt(x * x + y * y);

    
    //Calculates the rate of change of the distance of two moving objects, with two independant speeds, an initial distance, 
    //and a time interval starting from zero.
    //returnsThe rate of change of distance between the two objects

    public static Solution Solve(double distance, double aSpeed, double bSpeed, double time)
    {
        if (distance < 0) return new Solution
        {
            Result = 0,
            Error = true,
            ErrorMessage = "intial distance cannot be negative"
        };

        if (time == 0) return new Solution
        {
            Result = distance,
            Error = false,
            ErrorMessage = string.Empty
        };
        else if (time < 0) return new Solution
        {
            Result = 0,
            Error = true,
            ErrorMessage = "time cannot be negative"
        };

        double x, y, defF, hypo, result;

        x = distance - (time * aSpeed);
        y = time * bSpeed;

        if (x == 0 && y == 0) return new Solution
        {
            Result = 0,
            Error = true,
            ErrorMessage = "the speed of object B cannot be zero, when the total distance travelled by object A is equal to the initial distance"
        };

        defF = ((aSpeed * -1) * x) + (bSpeed * y);

        hypo = Hypotenuse(x, y);

        result = defF / hypo;

        return new Solution
        {
            Result = result,
            Error = false,
            ErrorMessage = string.Empty
        };
    }
}