using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Vector2 movement;

    public Quaternion movementAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != Vector2.zero)
            movementAngle = Quaternion.LookRotation(movement);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetLocation(Vector2 positionVector)
    {
        playerTransform.position = positionVector;
    }
    
    
    
}
