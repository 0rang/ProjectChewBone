using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text HealthDisplay;
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth HealthScript = GameManager.GetComponent<PlayerHealth>();
        if (HealthScript != null)
        {

            HealthDisplay.text = "Health: " + HealthScript.Health.ToString();
        }
    }


}
