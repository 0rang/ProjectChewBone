using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool InvinsibilityFramesOn;
    public int Health;
    public float NumInvibilityFrames;
    private float CurrentInvinsibilityFrames;
    public GameObject Player;
    // Start is called before the first frame update

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //check if player has been hit
        if (InvinsibilityFramesOn)
        {
            Invinsibility();
        }

    }

    public void TakeDamage(int DamageNumber)
    {
        if (!InvinsibilityFramesOn)
        {
            Health -= DamageNumber;
            if (Health <= 0)
            {
                Debug.Log("Game Over");

            }
            SpriteRenderer PlayerSprite = Player.GetComponent<SpriteRenderer>();
            if (PlayerSprite != null)
            {
                PlayerSprite.color = new Color(40f, 0f, 0f,1f);
            }
            else
            {
                Debug.Log("Error finding Sprite Renderer, PlayerHealth,TakeDamage,Line 46");
            }
            CurrentInvinsibilityFrames = 0;
            InvinsibilityFramesOn = true;
        }

    }

    private void Invinsibility()
    {
        CurrentInvinsibilityFrames+= Time.deltaTime;
        if (CurrentInvinsibilityFrames >= NumInvibilityFrames)
        {
            Debug.Log("Invisibility Frames Finished");
            SpriteRenderer PlayerSprite = Player.GetComponent<SpriteRenderer>();
            if (PlayerSprite != null)
            {
                PlayerSprite.color = new Color(255, 255, 255);

            }
            else
            {
                Debug.Log("Error finding Sprite Renderer, PlayerHealth,Invisibility,Line 65");
            }
            CurrentInvinsibilityFrames = 0;
            InvinsibilityFramesOn = false;

        }
    }
}
