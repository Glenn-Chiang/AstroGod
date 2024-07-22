using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width; // Number of tile columns
    [SerializeField] private int height; // Number of tile rows
    
    [SerializeField, Range(0, 100)]
    private int density; // Percentage of map that are walls
    [SerializeField] private int smoothSteps;

    [SerializeField] private string seed;
    [SerializeField] private bool useRandomSeed;

    public bool autoUpdate = false;
    
    [SerializeField] private MapDisplay mapDisplay;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Debug.Log("Generating");

        if (useRandomSeed)
        {
        // Generate random seed
            seed = Time.time.ToString();
        }
        // Seed the random generator
        System.Random rng = new System.Random(seed.GetHashCode());

        var procGenAlgo = new CellularAutomaton(width, height);
        bool[,] map = procGenAlgo.GenerateMap(density, smoothSteps, rng);
        mapDisplay.DisplayMap(map);

    }
}
