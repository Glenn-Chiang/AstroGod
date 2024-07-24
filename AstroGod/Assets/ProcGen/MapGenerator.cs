using UnityEngine;

public abstract class MapGenerator : MonoBehaviour
{
    private void Start()
    {
        Generate();
    }

    public abstract void Generate();
}