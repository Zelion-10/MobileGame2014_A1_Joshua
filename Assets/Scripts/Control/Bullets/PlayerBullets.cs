using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;  // Speed at which the bullet moves
    private GameController gameController; // Reference to GameController

    private void Awake()
    {
        // Find the GameController in the scene
        gameController = FindObjectOfType<GameController>();

        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
        }

        // Ensure the bullet has a Collider2D component and set it as a trigger
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }
        collider.isTrigger = true;

        // Ensure the bullet has a Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.isKinematic = true;
    }

    private void Update()
    {
        // Move the bullet forward constantly
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameController != null)
            {
                gameController.ChangeScore(9);
            }

            EnemyBehavior enemyBehavior = collision.GetComponent<EnemyBehavior>();
            if (enemyBehavior != null)
            {
                enemyBehavior.DyingSequence();
            }

            Destroy(gameObject);  // Destroy the bullet
        }
    }
}
