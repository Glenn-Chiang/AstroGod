using UnityEngine;

public class Room : MonoBehaviour
{
    public readonly Vector3 size = new(22, 22);
    public float LeftBound => transform.position.x - size.x / 2;
    public float RightBound => transform.position.x + size.x / 2;
    public float TopBound => transform.position.y + size.y / 2;
    public float BottomBound => transform.position.y - size.y / 2;

}