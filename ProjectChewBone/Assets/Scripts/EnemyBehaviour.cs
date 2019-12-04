using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject GameManager;
    public int EnemyHealth;
    private bool EnemyHurt;
    public float EnemyHurtDuration;
    private float EnemyHurtTime;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            Debug.Log("Game manager in enemy Found");
        }
        else
        {
            Debug.Log("Game Manager in Enemy not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHurt)
        {
            EnemyDamageRed();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (StopGameMotion.instance.Motion)
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth HealthScript = GameManager.GetComponent<PlayerHealth>();
                if (HealthScript != null)
                {

                    HealthScript.TakeDamage(1);
                }
                else
                {
                    Debug.Log("EnemyBehaviour Could not find HealthScript");
                }
            }
            else if (collision.gameObject.tag == "Bullets")
            {
                EnemyDamage();
            }
    }

    public void EnemyDamage()
    {
        EnemyHealth -= 1;
        SpriteRenderer EnemySprite = GetComponent<SpriteRenderer>();
        if (EnemySprite != null)
        {
            EnemySprite.color = new Color(40f, 0f, 0f, 1f);
            EnemyHurtTime = 0;
            EnemyHurt = true;
        }
        else
        {
            Debug.Log("Could not find enemy sprite???");
        }
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyDamageRed()
    {
        EnemyHurtTime += Time.deltaTime;
        if (EnemyHurtTime>=EnemyHurtDuration)
        {
            EnemyHurt = false;
            SpriteRenderer EnemySprite = GetComponent<SpriteRenderer>();
            if (EnemySprite != null)
            {
                EnemySprite.color = new Color(1f, 0.6432734f, 0.3726415f, 1f);
            }
        }
    }
}
