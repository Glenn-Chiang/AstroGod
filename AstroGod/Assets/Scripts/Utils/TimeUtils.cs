using UnityEngine;
using System;
using System.Collections;

public static class TimeUtils
{
    public static IEnumerator ExecuteAfterDelay(float seconds, Action task)
    {
        yield return new WaitForSeconds(seconds);
        task();
    }

}