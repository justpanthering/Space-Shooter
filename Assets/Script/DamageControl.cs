using UnityEngine;
using System.Collections;

public class DamageControl : MonoBehaviour
{
    public float health = 1;
    private float invulTimer = 0f;
    int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Triggered");

        health--;
        invulTimer = 0.25f;
        gameObject.layer = 10;
    }

    void Update()
    {
        invulTimer -= Time.deltaTime;
        if (invulTimer <= 0)
            gameObject.layer = correctLayer;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
