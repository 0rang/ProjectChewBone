using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    }
}
