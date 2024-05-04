using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector3 Size { get; private set; }
    public float LeftBound => transform.position.x - Size.x / 2;
    public float RightBound => transform.position.x + Size.x / 2;
    public float TopBound => transform.position.y + Size.y / 2;
    public float BottomBound => transform.position.y - Size.y / 2;

    private void Awake()
    {
        Size = GetComponent<Renderer>().bounds.size;
    }
}