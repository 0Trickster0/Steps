using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;   //刚体
    public bool isJumping;
    private bool canClimb;
    public Vector2 faceDirection;

    public RaycastHit2D hit;
    public float jumpForce;  //跳跃的力
    public float moveSpeed; //水平移动速度
    public bool isDisabled=true;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode upKey;
    public KeyCode downKey;
    //单例
    private static Player instance;
    public static Player Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件
    }

    void Update()
    {
        Jump();
        GetObjectForward();
    }

    private void FixedUpdate()
    {
        if (!isDisabled)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime);
            faceDirection = Vector2.left;
        }
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime);
            faceDirection = Vector2.right;
        }
        if (Input.GetKey(upKey)&&canClimb)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(downKey) && canClimb)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(jumpKey))
        {
            rig.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void GetObjectForward()
    {
        if (faceDirection == Vector2.left)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(-0.167f, -0.14f, 0), faceDirection, 1.5f);
        }
        else if (faceDirection == Vector2.right)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(0.167f, -0.14f, 0), faceDirection, 1.5f);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"|| collision.collider.tag == "Police" || collision.collider.tag == "Object")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Police" || collision.collider.tag == "Object" )
        {
            isJumping = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            canClimb = true;
            rig.gravityScale = 0;
            rig.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            canClimb = false;
            rig.gravityScale = 4;
        }
    }
}
