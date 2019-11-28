using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorController : MonoBehaviour
{
    public PlayerController player;

    public Transform conductorTransform;

    Vector2 teleportLocation;

    float teleportDistance;



    // Start is called before the first frame update
    void Start()
    {
        teleportLocation = conductorTransform.position;
        teleportDistance = conductorTransform.localScale.x / 2 + 1;
        Debug.Log(Quaternion.Angle(Quaternion.identity, conductorTransform.rotation));
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() 
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("x");
            if (player.movement == Vector2.zero) return;
            float AnglePlayerConductor = Quaternion.Angle(conductorTransform.rotation,
                Quaternion.LookRotation(player.movement));

            Debug.Log(AnglePlayerConductor);


            
            if (AnglePlayerConductor == 90)
            {
                Debug.Log("R");
                teleportLocation.x += teleportDistance;
                collision.SendMessage("SetLocation", teleportLocation);
            }

            else if (AnglePlayerConductor > 90)
            {
                Debug.Log("L");
                teleportLocation.x -= teleportDistance;
                collision.SendMessage("SetLocation", teleportLocation);
            }

            
            teleportLocation = conductorTransform.position;
        }
    }
}
