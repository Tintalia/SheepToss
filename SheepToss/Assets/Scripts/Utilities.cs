using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Utilities
{
    public static void ValidateInt(int input, string name)
    {
        if (input < 0)
        {
            throw new ArgumentOutOfRangeException(name, "The value can't be less than 0");
        }
    }

    public static void ValidateInt(int input, string name, int lowerBoundary, int upperBoundary)
    {
        if (input < 0)
        {
            string exceptionMessage = string.Format("The value must be in the range [{1};{2}]", lowerBoundary, upperBoundary);
            throw new ArgumentOutOfRangeException(name, exceptionMessage);
        }
    }

    public static void ValidateFloat(float input, string name)
    {
        if (input < 0)
        {
            throw new ArgumentOutOfRangeException(name, "The value can't be less than 0");
        }
    }

    public static void ValidateFloat(float input, string name, float lowerBoundary, float upperBoundary)
    {
        if (input < 0)
        {
            string exceptionMessage = string.Format("The value must be in the range [{1};{2}]", lowerBoundary, upperBoundary);
            throw new ArgumentOutOfRangeException(name, exceptionMessage);
        }
    }

    public static void ValidateObject(object input, string name)
    {
        if (input == null)
        {
            throw new ArgumentNullException(name, "The value can't be null");
        }
    }

}
