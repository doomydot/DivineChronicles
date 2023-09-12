using System.Security.Cryptography;

namespace Engine;

public static class RandomNumberGenerator
{
    private static readonly Random _simpleGenerator = new Random();
    public static int NumberBetween(int minValue, int maxValue) {
        return _simpleGenerator.Next(minValue, maxValue + 1);
    }
}