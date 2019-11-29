
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D bulletPrefab;
    public float thrust, upthrust, OffsetX, OffsetY, FireRate, Damage;
    public LayerMask NotToHit;
    public BoxCollider2D playercollidor;
    public bool JumpFlag, WallJumpFlag, UpFlag;
    public int Direction;
    private float horizontalInput, verticalInput;
    private bool spaceInput;
    public float speed, JumpForce;


    // Start is called before the first frame update
    void Start()
    {
        Direction = 1;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        spaceInput = Input.GetButtonDown("Jump");


        //for only touching ground
        if ((Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.UpArrow) && !Input.GetKey(KeyCode.W)))
        {
            UpFlag = false;
        }
        if (horizontalInput > 0)
        {
            Direction = 1;
        }
        else if (horizontalInput < 0)
        {
            Direction = -1;
        }
 

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
            }
            
        }
        //if pressing buttons, then move

        if (spaceInput)
        {
            Shoot();
        }

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

    public void Shoot()
    {
        Vector3 Offset = new Vector3(OffsetX*Direction,OffsetY,0);
        Instantiate(bulletPrefab,transform.position + Offset,Quaternion.identity);
        Debug.Log("shuut");
    }




}
