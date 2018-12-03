using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene2 : MonoBehaviour {

    private bool[] itemStatus = new bool[8];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        EnlargeGun();
        ShrinkGun();
        GravityGun();
        DimensionDoor();
        AirGun();
        Spring();

    }

    private void EnlargeGun()
    {
        if (itemStatus[0] && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("使用放大枪");
            if (Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.tag == "Object")
                {
                    Player.Instance.hit.collider.gameObject.GetComponent<Animator>().SetBool("isEnlarged", true);
                }
            }
        }
    }

    private void ShrinkGun()
    {
        if (itemStatus[1] && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("使用缩小枪");
            if(Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.tag == "Object")
                {
                    Player.Instance.hit.collider.gameObject.GetComponent<Animator>().SetBool("isEnlarged", false);
                }
            }
        }
    }

    private void Spring()
    {
        if (itemStatus[2] && Input.GetKeyDown(KeyCode.Alpha3)&&!Player.Instance.isJumping)
        {
            Debug.Log("使用马竹");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1500));
        }
    }

    private void DimensionDoor()
    {
        if (itemStatus[3] && Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("使用任意门");
            if (Player.Instance.faceDirection == Vector2.left)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (Player.Instance.faceDirection == Vector2.right)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            }

        }
    }

    private void AirGun()
    {
        if (itemStatus[4] && Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("使用空气炮");
            if(Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.tag == "Object")
                {
                    if (Player.Instance.faceDirection == Vector2.left)
                    {
                        Player.Instance.hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500, 1500));
                    }
                    else if (Player.Instance.faceDirection == Vector2.right)
                    {
                        Player.Instance.hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500, 1500));
                    }
                }
            }
        }
    }

    private void GravityGun()
    {
        if (itemStatus[5] && Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("使用重力枪");
            if(Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.tag == "Object")
                {
                    Player.Instance.hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
            }
        }
    }

    public void pickUpItem(int itemNum)
    {
        itemStatus[itemNum] = true;
    }
}
