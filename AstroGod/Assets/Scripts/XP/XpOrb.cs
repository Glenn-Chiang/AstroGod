using UnityEngine;

public class XpOrb : MonoBehaviour
{
    public readonly float xpAmount = 1f;
    [SerializeField] private float moveSpeed = 10;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<XPManager>(out var xpManager))
        {
            xpManager.AddXp(xpAmount);
            Destroy(gameObject);
        }
    }
}