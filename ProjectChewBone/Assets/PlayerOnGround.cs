
using UnityEngine;


public class PlayerOnGround : MonoBehaviour
{
    public BoxCollider2D playercollidor;
    public bool JumpFlag;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Safe Platform")
        {
            bool JumpFlag = false;   //set jump flag to on
        }
    }
}
