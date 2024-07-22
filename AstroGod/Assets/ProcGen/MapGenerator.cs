using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width; // Number of tile columns
    [SerializeField] private int height; // Number of tile rows

    public bool autoUpdate = false;

    [SerializeField] private MapDisplay mapDisplay;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        bool[,] map = CellularAutomata.GenerateMap(width, height);
        mapDisplay.DisplayMap(map);

    }

}
