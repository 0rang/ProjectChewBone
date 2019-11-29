using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckIfPlayerGrounded : MonoBehaviour
{
    private Collider2D playerCollider;
    private GameObject PlayerObject; 

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        playerCollider = PlayerObject.GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            Debug.Log("neat");
        }
        else
        {
            Debug.Log("yeet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D =  Physics2D.Raycast(new Vector2(playerCollider.bounds.min.x, playerCollider.bounds.min.y - 0.1f),Vector2.down, 0.1f);
        RaycastHit2D hit2D2 = Physics2D.Raycast(new Vector2(playerCollider.bounds.max.x, playerCollider.bounds.min.y - 0.1f), Vector2.down, 0.1f);
        if (hit2D || hit2D2)
        {
            PlayerObject = GameObject.Find("Player");
            Movement MyScript = PlayerObject.GetComponent<Movement>();
            if (MyScript != null)
            { MyScript.JumpFlag = false;
                Debug.Log("Jump Flag");
            }
            else
            { Debug.Log("Jump Flag not working help"); }
            

        }
    }
}
