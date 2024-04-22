using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public float BaseValue { get; private set; }
    [field: SerializeField] public float MaxValue { get; private set; }
    public float Value { get; private set; }
    private readonly float incrementFactor = 1.1f;

    public Stat(float _baseValue, float _maxValue)
    {
        BaseValue = _baseValue;
        MaxValue = _maxValue;
        Value = BaseValue;
    }

    public void Upgrade()
    {
        Value = Math.Min(MaxValue, Value * incrementFactor);
    }

    public void Upgrade(float _incrementFactor)
    {
        Value = Math.Min(MaxValue, Value * _incrementFactor);
    }
}