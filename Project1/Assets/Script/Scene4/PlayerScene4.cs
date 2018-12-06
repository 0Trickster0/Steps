using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene4 : MonoBehaviour {

    private bool[] itemStatus = new bool[8];
    private bool isDoubleJumping;
    private bool isBoostJump;
    private bool isBoostRun;
    private Rigidbody2D rb2d;

    public bool enableDoubleJump;
    public bool enableWallJump;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        DoubleJump();
        WallJumpClaw();
        DoubleJumpShoes();
        BoostJumpPotion();
        BoostRunPotion();
    }

    private void DoubleJumpShoes()
    {
        if (itemStatus[0] && Input.GetKeyDown(Player.Instance.item1Key))
        {
            Debug.Log("使用喷射靴");
            enableDoubleJump = true;
        }
    }

    private void WallJumpClaw()
    {
        if (itemStatus[1] && Input.GetKeyDown(Player.Instance.item2Key))
        {
            Debug.Log("使用攀爬爪");
            enableWallJump = true;
        }
    }

    private void BoostJumpPotion()
    {
        if (itemStatus[2] && Input.GetKeyDown(Player.Instance.item3Key) &&!isBoostJump)
        {
            Debug.Log("使用跳跃药剂");
            Player.Instance.jumpForce = 1.6f * Player.Instance.jumpForce;
            isBoostJump = true;
            GameObject.Find("Monster").SendMessage("WakeUp");
        }
    }

    private void BoostRunPotion()
    {
        if (itemStatus[3] && Input.GetKeyDown(Player.Instance.item4Key) && !isBoostRun)
        {
            Debug.Log("使用速度药剂");
            Player.Instance.moveSpeed = 2 * Player.Instance.moveSpeed;
            isBoostRun = true;
            GameObject.Find("Monster").SendMessage("WakeUp");
        }
    }

    private void DoubleJump()
    {
        if (enableDoubleJump && Input.GetKeyDown(Player.Instance.jumpKey))
        {
            if (Player.Instance.isJumping && !isDoubleJumping)
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(0, Player.Instance.jumpForce));
                isDoubleJumping = true;
            }
        }
    }

    private void WallJump()
    {
        if (Input.GetKeyDown(Player.Instance.jumpKey))
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(new Vector2(0,Player.Instance.jumpForce));
        }  
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"  || collision.collider.tag == "Object")
        {
            isDoubleJumping = false;
        }
        if(collision.collider.tag == "Wall"&&enableWallJump)
        {
            if(Player.Instance.isJumping && isDoubleJumping)
            {
                WallJump();
            }
            
            rb2d.gravityScale = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" && enableWallJump)
        {
            rb2d.gravityScale = 4;
        }
    }

    public void pickUpItem(int itemNum)
    {
        itemStatus[itemNum] = true;
    }
}
