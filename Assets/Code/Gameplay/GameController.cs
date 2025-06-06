using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkPointPos;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRb;
    public ParticleController particleController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        checkPointPos = transform.position;
        playerRb.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        particleController.PlayDeathparticle();
        StartCoroutine(Respawn(0.5f) );
    }

    public void UpdateCkeckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }



    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        spriteRenderer.enabled = true;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
    }

}
