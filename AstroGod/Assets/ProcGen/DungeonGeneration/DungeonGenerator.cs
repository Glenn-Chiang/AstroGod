using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonGenerator : MapGenerator
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    private bool[,] grid;

    [SerializeField] private int iterations; // Number of times to split
    [SerializeField] private string seed;
    [SerializeField] private bool useRandomSeed;

    [SerializeField] private MapDisplay mapDisplay;

    // The minimum and maximum ratios along the width/height of the room
    // at which the room can be split
    // These values will affect how similar the room sizes are
    [SerializeField] private float minSplitRatio = 0.4f;
    [SerializeField] private float maxSplitRatio = 0.6f;
    public float MinSplitRatio => minSplitRatio;
    public float MaxSplitRatio => maxSplitRatio;

    // Aspect ratio is width over height of the room
    [SerializeField] private float minAspectRatio;
    [SerializeField] private float maxAspectRatio;
    public float MinAspectRatio => minAspectRatio;
    public float MaxAspectRatio => maxAspectRatio;

    // Minimum width and height of the empty space within a room
    [SerializeField] private int minLength = 10;

    // Padding refers to the number of layers of filled cells around a room
    [SerializeField] private int minRoomPad = 1;
    [SerializeField] private int maxRoomPad = 10;

    // Cost of pathing through filled cells
    [SerializeField, Range(0, 10)] private int wallCost = 5;
    
    // Cost of pathing through empty cells
    [SerializeField, Range(0, 10)] private int emptyCost = 5;

    // Cost of making turns
    [SerializeField, Range(0, 10)] private int turnCost;

    [SerializeField] private int minPathPad = 0;
    [SerializeField] private int maxPathPad = 2;

    private System.Random rng;

    public override void Generate()
    {
        // Create a filled grid
        grid = new bool[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = true;
            }
        }

        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }
        
        rng = new System.Random(seed.GetHashCode());

        // Create a room occupying the full dungeon space and recursively split it into smaller rooms
        List<Room> rooms = new List<Room>();
        var startRoom = new Room(0, 0, width, height, this);
        startRoom.Split(iterations, rooms, rng);

        // Clear out the rooms on the grid
        foreach (var room in rooms)
        {
            BuildRoom(room);
        }

        ConnectAllRooms(rooms);

        mapDisplay.DisplayMap(grid);
    }

    // Create the room within the grid
    private void BuildRoom(Room room)
    {
        // The maximum padding that will not cause the room to become smaller than the minimum room size
        int maxPaddingX = Math.Max(minRoomPad, Math.Min(maxRoomPad, (room.width - minLength) / 2));
        int maxPaddingY = Math.Max(minRoomPad, Math.Min(maxRoomPad, (room.height - minLength) / 2));

        int paddingX = rng.Next(minRoomPad, maxPaddingX + 1);
        int paddingY = rng.Next(minRoomPad, maxPaddingY + 1);

        for (int x = room.x + paddingX; x < room.x + room.width - paddingX; x++)
        {
            for (int y = room.y + paddingY; y < room.y + room.height - paddingY; y++)
            {
                grid[x, y] = false;
            }
        }
    }

    private void ConnectAllRooms(List<Room> rooms)
    {
        // Initially, all rooms are disconnected
        List<Room> disconnectedRooms = rooms.ToList();
        List<Room> connectedRooms = new List<Room>();
        var startRoom = RandomUtils.RandomSelect(rooms, rng);
        disconnectedRooms.Remove(startRoom);
        connectedRooms.Add(startRoom);

        // Repeatedly connect rooms until all rooms are connected
        while (disconnectedRooms.Count > 0)
        {
            Room disconnectedRoom = RandomUtils.RandomSelect(disconnectedRooms, rng);
            Room connectedRoom = RandomUtils.RandomSelect(connectedRooms, rng);

            CreatePath(disconnectedRoom.Center, connectedRoom.Center);
            disconnectedRooms.Remove(disconnectedRoom);
            connectedRooms.Add(disconnectedRoom);
        }
    }

    private void CreatePath(Vector2Int startCell, Vector2Int endCell)
    {
        var pathfinder = new Pathfinder(startCell, endCell, grid, 
            wallCost, emptyCost, turnCost);
        List<Vector2Int> path = pathfinder.FindPath();

        int pathPad = rng.Next(minPathPad, maxPathPad + 1);

        // Clear all cells in the path
        foreach (var cell in path)
        {
            for (int x = cell.x - pathPad; x <= cell.x + pathPad; x++)
            {
                for (int y = cell.y - pathPad; y <= cell.y + pathPad; y++)
                {
                    grid[x, y] = false;
                }
            }
        }
    }

    public class Room
    {
        private readonly DungeonGenerator generator;

        public readonly int x; // Leftmost x
        public readonly int y; // Bottommost y
        public readonly int width;
        public readonly int height;

        public int CenterX => x + width / 2;
        public int CenterY => y + height / 2;
        public Vector2Int Center => new(CenterX, CenterY);

        private int MinSplitX => x + (int)(generator.minSplitRatio * width);
        private int MaxSplitX => x + (int)(generator.maxSplitRatio * width);
        private int MinSplitY => y + (int)(generator.minSplitRatio * height);
        private int MaxSplitY => y + (int)(generator.maxSplitRatio * height);

        public Room(int x, int y, int width, int height, DungeonGenerator generator)
        {
            this.generator = generator;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        // Recursively split itself into smaller rooms using binary space partitioning
        public void Split(int iterations, List<Room> rooms, System.Random rng)
        {
            rooms.Add(this);

            if (iterations == 0) return;

            rooms.Remove(this);

            float aspectRatio = (float) width / height;
            
            // If the room is too tall, split horizontally
            if (aspectRatio < generator.MinAspectRatio)
            {
                HorizontalSplit(iterations, rooms, rng);
                return;
            } 

            // If the room is too wide, split vertically
            if (aspectRatio > generator.maxAspectRatio)
            {
                VerticalSplit(iterations, rooms, rng);
                return;
            }

            // Otherwise, random chance to split either horizontally or vertically
            if (rng.NextDouble() < 0.5)
            {
                HorizontalSplit(iterations, rooms, rng);
            }
            else
            {
                VerticalSplit(iterations, rooms, rng);
            }
        }

        private void HorizontalSplit(int iterations, List<Room> rooms, System.Random rng)
        {
            // Pick a random y position to split at
            int splitY = rng.Next(MinSplitY, MaxSplitY);

            var topRoom = new Room(x, splitY, width, y + height - splitY, generator);
            var bottomRoom = new Room(x, y, width, splitY - y, generator);

            topRoom.Split(iterations - 1, rooms, rng);
            bottomRoom.Split(iterations - 1, rooms, rng);
        }

        private void VerticalSplit(int iterations, List<Room> rooms, System.Random rng)
        {
            // Pick a random x position to split at
            int splitX = rng.Next(MinSplitX, MaxSplitX);

            var leftRoom = new Room(x, y, splitX - x, height, generator);
            var rightRoom = new Room(splitX, y, x + width - splitX, height, generator);

            leftRoom.Split(iterations - 1, rooms, rng);
            rightRoom.Split(iterations - 1, rooms, rng);
        }
    }
}
