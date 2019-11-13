using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorController : MonoBehaviour
{
    public Transform conductorTransform;

    Vector2 teleportLocation;



    // Start is called before the first frame update
    void Start()
    {
        teleportLocation = conductorTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("R");
                teleportLocation.x += conductorTransform.localScale.x / 2 + 1;
                collision.SendMessage("SetLocation", teleportLocation);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                teleportLocation.x -= conductorTransform.localScale.x / 2 + 1;
                collision.SendMessage("SetLocation", teleportLocation);
            }

            Debug.Log("x");
            teleportLocation = conductorTransform.position;
        }
    }
}
