using System.Collections.Generic;

public static class RandomUtils
{
    public static T RandomSelect<T>(List<T> elements)
    {
        return elements[0];
    }
}