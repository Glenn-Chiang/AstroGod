using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder
{
    private readonly Vector2Int startCell;
    private readonly Vector2Int targetCell;

    // Nodes that we are interested in exploring
    private readonly HashSet<Node> openNodes = new HashSet<Node>();
    // Nodes that we are no longer interested in exploring
    private readonly HashSet<Node> closedNodes = new HashSet<Node>();

    private readonly Node[,] nodeGraph;

    // Pathfinder can only move in orthogonal directions
    private static readonly Vector2Int[] directions = { new(0, -1), new(0, 1), new(-1, 0), new(1, 0) };

    public Pathfinder(Vector2Int startCell, Vector2Int targetCell, bool[,] grid, int wallCost, int emptyCost)
    {
        this.startCell = startCell;
        this.targetCell = targetCell;

        // Initialize a node for each cell in the grid
        nodeGraph = new Node[grid.GetLength(0), grid.GetLength(1)];
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                int cost = grid[x, y] ? wallCost : emptyCost;
                int distanceToTarget = (int) Vector2Int.Distance(new Vector2Int(x, y), targetCell);
                nodeGraph[x, y] = new Node(x, y, cost, distanceToTarget);
            }
        }
    }

    // Get the list of cells that make up the path
    public List<Vector2Int> FindPath()
    {
        var path = new List<Vector2Int>();

        var startNode = nodeGraph[startCell.x, startCell.y];
        var targetNode = nodeGraph[targetCell.x, targetCell.y];
        openNodes.Add(startNode);

        // Repeat while there are still nodes to explore
        while (openNodes.Count != 0)
        {
            var currentNode = GetBestNode(openNodes);
            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

            // Found path
            if (currentNode == targetNode)
            {
                return currentNode.GetPath();
            }

            foreach (var neighbor in GetNeighbors(currentNode))
            {
                // Skip closed nodes
                if (closedNodes.Contains(neighbor)) continue;

                // The cost of the neighbor node added to the cost of getting to the current node
                // We are essentially finding the cost of the current path to the neighbor
                int newGCost = currentNode.gCost + neighbor.cost;

                // If the neighbor has not been explored,
                // or if the current path to the neighbor is better than the neighbor's previous cost
                if (!openNodes.Contains(neighbor) || newGCost < neighbor.gCost)
                {
                    neighbor.gCost = newGCost;
                    neighbor.parent = currentNode;
                    openNodes.Add(neighbor);
                }
            }
        }

        return path;
    }

    private List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        foreach (var dir in directions)
        {
            int neighborX = node.x + dir.x;
            int neighborY = node.y + dir.y;
            if (neighborX >= 0 && neighborY >= 0 
                && neighborX < nodeGraph.GetLength(0) && neighborY < nodeGraph.GetLength(1))
            {
                neighbors.Add(nodeGraph[neighborX, neighborY]);
            }
        }
        return neighbors;
    }

    private Node GetBestNode(HashSet<Node> nodes)
    {
        // The best node is the one with the lowest f cost
        return nodes.OrderBy(node => node.FCost).FirstOrDefault();
    }

    class Node
    {
        public readonly int x;
        public readonly int y;
        private readonly int distanceToTarget;

        public readonly int cost;
        public int HCost => distanceToTarget + cost;
        public int gCost;
        public int FCost => gCost + HCost;

        public Node parent;

        public Node(int x, int y, int cost, int distanceToTarget)
        {
            this.x = x;
            this.y = y;
            this.cost = cost;
            this.distanceToTarget = distanceToTarget;
        }

        public List<Vector2Int> GetPath()
        {
            return RecursiveGetPath(new List<Vector2Int>());
        }
        // Get the list of nodes from this node to the start node by recursively
        // finding parent nodes
        private List<Vector2Int> RecursiveGetPath(List<Vector2Int> path)
        {
            path.Add(new Vector2Int(x, y));
            if (parent == null)
            {
                return path;
            }
            return parent.RecursiveGetPath(path);
        }

    }
}