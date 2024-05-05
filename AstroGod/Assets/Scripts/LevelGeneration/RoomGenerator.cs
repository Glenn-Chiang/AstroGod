using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private int roomCount = 8;
    [SerializeField] private int rowCount = 4;
    [SerializeField] private int colCount = 4;
    [SerializeField] private float gap = 2;
    private Vector3 origin;
    [SerializeField] private Room roomPrefab;
    private Vector3 RoomSize => roomPrefab.size;
    private Room[,] rooms;

    private void Awake()
    {
        origin = transform.position;
        rooms = new Room[rowCount, colCount];
        GenerateRooms();
    }
    
    public void GenerateRooms()
    {
        var randomWalker = new RandomWalker(rowCount, colCount, roomCount);
        randomWalker.Walk();
        var grid = randomWalker.grid;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                if (!grid[row, col]) continue;

                var roomX = origin.x + col * (RoomSize.x + gap);
                var roomY = origin.y - row * (RoomSize.y + gap);
                var roomPosition = new Vector2(roomX, roomY);
                var room = Instantiate(roomPrefab, roomPosition, Quaternion.identity);
                rooms[row, col] = room;                
            }
        }
    }
}