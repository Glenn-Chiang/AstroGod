using UnityEngine;

public class XpDropper : MonoBehaviour
{
    [SerializeField] private XpOrb xpOrb;

    public void DropXP(float xpAmount)
    {
        int numOrbs = (int)(xpAmount / xpOrb.xpAmount);
        for (int i = 0; i < numOrbs; i++)
        {
            Instantiate(xpOrb, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomXOffset = Random.Range(-0.5f, 0.5f);
        float randomYOffset = Random.Range(-0.5f, 0.5f);
        return new Vector2(transform.position.x + randomXOffset, transform.position.y + randomYOffset);
    }
}