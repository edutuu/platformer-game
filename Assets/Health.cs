using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int knockback;
    public int tries = 0;
    public int retry_scene = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && tries == 0) 
        {
            tries++;
            Die();
        }
    }

    private void Update()
    {
        if (health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        LevelReset();
        deathCount.death_cnt += 1;
        SceneManager.LoadScene(retry_scene);
    }

    private void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
