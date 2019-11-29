using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int Direction;
    //public GameObject Player;
    //public Movement PlayerMovement;
    public float VelocityofBullet;
    public float TimeOut, TimeMax;
    private Rigidbody2D BulletRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        TimeOut = 0;
        //Direction = PlayerMovement.Direction;
        GameObject Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            Movement PlayerMovement = Player.GetComponent<Movement>();
            if (PlayerMovement != null)
            {
                Direction = PlayerMovement.Direction;
            }
            else
            { Debug.Log("Error getting direction from movement script for bullet"); }
        }
        else
        { Debug.Log("Error creating bullet in bullet script"); }
        
        BulletRigidBody = GetComponent<Rigidbody2D>();
        if (BulletRigidBody != null)
        {
            BulletRigidBody.velocity = new Vector2(VelocityofBullet * Direction, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move

        //add time
        TimeOut += Time.deltaTime;
        if (TimeOut >= TimeMax)
        {
            Destroy(gameObject);
        }
        //if timed out, automatically explode and destroy

        
    }

    private void OnCollisionEnter2D(Collision2D collision)      //only works for dynamic objects. Maybe use raycasting instead
    {
        Debug.Log("Has collided");
        //destroy this object
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.SendMessage("shoot");
            Shoot();
        }
        else
        {
            Debug.Log("No shoot");
        }
        Destroy(gameObject);
    }

    public void Shoot()
    {
        Debug.Log("bam");
    }
}
