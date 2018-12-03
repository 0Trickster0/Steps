using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene4 : MonoBehaviour {

    private bool[] itemStatus = new bool[8];
    private bool isDoubleJumping;
    private Rigidbody2D rb2d;

    public bool enableDoubleJump;
    public bool enableWallJump;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        DoubleJump();
        DoubleJumpShoes();
	}

    private void DoubleJumpShoes()
    {
        if (itemStatus[0] && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("使用喷射靴");
            enableDoubleJump = true;
        }
    }

    private void WallJumpClaw()
    {
        if (itemStatus[1] && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("使用攀爬爪");
            enableWallJump = true;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"  || collision.collider.tag == "Object")
        {
            isDoubleJumping = false;
        }
    }

    public void pickUpItem(int itemNum)
    {
        itemStatus[itemNum] = true;
    }
}
