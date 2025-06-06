using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameController gameController;
    public Transform respawnPoint;
    public Sprite passive, active;

    SpriteRenderer spriteRenderer;

    bool activated;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            gameController.UpdateCkeckPoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            activated = true;
        }
    }

}
