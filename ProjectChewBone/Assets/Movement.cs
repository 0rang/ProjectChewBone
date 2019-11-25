
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float thrust, upthrust;
    public BoxCollider2D playercollidor;
    public bool JumpFlag, WallJumpFlag, UpFlag;
    private int Direction;
    private float horizontalInput, verticalInput;
    public float speed, JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //for only touching ground
        if ((Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.UpArrow) && !Input.GetKey(KeyCode.W)))
        {
            UpFlag = false;
        }
        //check if player is pressing any buttons
        /*if (Input.GetKey(KeyCode.D))
        {
            
            player.AddForce(transform.right * thrust * Time.deltaTime, ForceMode2D.Impulse);
            Direction = 1;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction = -1;
            player.AddForce(- transform.right * thrust * Time.deltaTime, ForceMode2D.Impulse);
        }*/

        player.velocity = new Vector2(speed * horizontalInput, player.velocity.y);

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))   //(verticalInput > 0)
        {
            //for wall jumping
            if (!JumpFlag && !UpFlag)
            //add key up check
            {
                player.velocity = new Vector2(player.velocity.x, JumpForce);
                JumpFlag = true;
                UpFlag = true;
                /*player.AddForce(transform.up * upthrust * Time.deltaTime, ForceMode2D.Impulse);
                JumpFlag = true;
                UpFlag = true;*/
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
            //JumpFlag = false;   //set jump flag to on
        }

        
       
    }

    public void Jump()
    {

        player.velocity = new Vector2(player.velocity.x, JumpForce);
        JumpFlag = true;
        UpFlag = true;

    }




}
