using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    Boundary VerticalSpeedRange;

    [SerializeField]
    Boundary HorizontalSpeedRange;

    float Verticalspeed;
    float Horizontalspeed;

    [SerializeField]
    Boundary verticalBoundary;

    [SerializeField]
    Boundary horizontalBoundary;

    SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    [Header("SFX")]
    [SerializeField]
    private AudioClip deathSFX; // Sound effect for enemy death
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy movement logic
        transform.position = new Vector2(
            Mathf.PingPong(Horizontalspeed * Time.time, horizontalBoundary.max - horizontalBoundary.min) + horizontalBoundary.min,
            transform.position.y + Verticalspeed * Time.deltaTime
        );

        if (transform.position.y < verticalBoundary.min)
        {
            Reset();
        }
    }

    public void DyingSequence()
    {
        // Play death sound effect
        if (audioSource != null && deathSFX != null)
        {
            audioSource.PlayOneShot(deathSFX);
        }

        // Disable enemy's sprite and collider after death
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Delay resetting the enemy so the sound can play fully
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(deathSFX.length); // Wait for the death sound to finish playing
        Reset();
    }

    private void Reset()
    {
        // Reset the enemy's position, speed, and enable components
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(true);
        transform.position = new Vector2(Random.Range(horizontalBoundary.min, horizontalBoundary.max), verticalBoundary.max);
        Verticalspeed = Random.Range(VerticalSpeedRange.min, VerticalSpeedRange.max);
        Horizontalspeed = Random.Range(HorizontalSpeedRange.min, HorizontalSpeedRange.max);
        spriteRenderer.color = new Color(Random.value, Random.value, Random.value); // Randomize enemy color
    }
}
