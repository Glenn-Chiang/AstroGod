using System.Collections.Generic;
using System;

public static class RandomUtils
{
    public static T RandomSelect<T>(List<T> elements)
    {
        Random random = new();
        int randomIndex = random.Next(0, elements.Count);
        return elements[randomIndex];
    }
}