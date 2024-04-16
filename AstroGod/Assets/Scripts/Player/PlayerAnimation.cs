using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private bool facingRight = true;
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        var moveDir = playerController.moveDir;
        // Flip direction if moving in opposite direction from direction it is currently facing
        if (facingRight && moveDir.x < 0 || !facingRight && moveDir.x > 0)
        {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
    }
}