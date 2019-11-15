
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float thrust, upthrust;
    public BoxCollider2D playercollidor;
    public bool JumpFlag, WallJumpFlag, UpFlag;
    public int Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for only touching ground
        if (Input.GetKeyUp(KeyCode.W))
        {
            UpFlag = false;
        }
        //check if player is pressing any buttons
        if (Input.GetKey(KeyCode.D))
        {
            
            player.AddForce(transform.right * thrust * Time.deltaTime, ForceMode2D.Impulse);
            Direction = 1;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction = -1;
            player.AddForce(- transform.right * thrust * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //for wall jumping
            if (!JumpFlag && !UpFlag)
            //add key up check
            {
                player.AddForce(transform.up * upthrust * Time.deltaTime, ForceMode2D.Impulse);
                JumpFlag = true;
                UpFlag = true;
            }
            
        }
        //if pressing buttons, then move

    }


    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Safe Platform")
        {
            Debug.Log("player has collided");
            JumpFlag = false;   //set jump flag to on
        }
//        if (collision.gameObject.tag == "Safe Wall")
//        {
//            Debug.Log("player has hit a wall");
//            if (Input.GetKey(KeyCode.W))
//            {
                //player wall jumps off the wall
//                player.AddForce(-1 * Direction * transform.right * upthrust * Time.deltaTime, ForceMode2D.Impulse);
 //               player.AddForce(transform.up * upthrust/2 * Time.fixedDeltaTime, ForceMode2D.Impulse);
  //          }
  //      }
        
       
    }



}
