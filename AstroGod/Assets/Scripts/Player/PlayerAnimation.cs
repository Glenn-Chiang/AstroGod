using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private SpriteRenderer sprite;
    private bool facingRight = true;

    private void Awake()
    {
        player = PlayerController.Instance;
    }

    private void Update()
    {
        var moveDir = player.Movement.moveDir;
        // Flip direction if moving in opposite direction from direction it is currently facing
        if (facingRight && moveDir.x < 0 || !facingRight && moveDir.x > 0)
        {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
    }
}