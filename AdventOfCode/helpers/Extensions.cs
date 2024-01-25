using System.Numerics;

namespace AdventOfCode.helpers;

public static class Extensions {
    public static T GreatestCommonDivisor<T>(T a, T b) where T : INumber<T>
    {
        while (b != T.Zero)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static T LowestCommonMultiple<T>(T a, T b) where T : INumber<T>
        => a / GreatestCommonDivisor(a, b) * b;
    
    public static T LowestCommonMultiple<T>(this IEnumerable<T> values) where T : INumber<T>
        => values.Aggregate(LowestCommonMultiple);
}