using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour {

    private int changeInterval;
    private int walkInterval;
    private bool isChanging;
    private bool isWalking;
    private bool isParalyzed;
    private SpriteRenderer sr;
    private GameObject policeSprite;
    private Rigidbody2D rb2d;
    private bool isFailed;

    public int moveSpeed;
    public RaycastHit2D hit;
    public Vector2 faceDirection;
    public int behaviorType;
    public float vision;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        policeSprite = gameObject.transform.GetChild(0).gameObject;
        sr = policeSprite.GetComponent<SpriteRenderer>();
        if (faceDirection == Vector2.left)
        {
            sr.flipX = true;
        }
        else if (faceDirection == Vector2.right)
        {
            sr.flipX = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isParalyzed)
        {
            DetectPlayer();
            PoliceBehavior();
        }
    }

    private void FixedUpdate()
    {
        if (isWalking&&!isParalyzed)
        {
            Move();
        }
    }

    private void DetectPlayer()
    {
        if (faceDirection == Vector2.left)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(-0.3f, 0.14f, 0), faceDirection, vision);
        }
        else if (faceDirection == Vector2.right)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(0.3f, 0.14f, 0), faceDirection, vision);
        }
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player"&&!Player.Instance.isFailed)
            {
                Player.Instance.isFailed = true;
                GameObject.Find("SceneCanvas").SendMessage("StageFailure");
            }
        }
    }

    private void ChangeDirection()
    {
        if (faceDirection == Vector2.left)
        {
            faceDirection = Vector2.right;
            sr.flipX = false;
        }
        else if (faceDirection == Vector2.right)
        {
            faceDirection = Vector2.left;
            sr.flipX = true;
        }
    }

    private void PoliceBehavior()
    {
        if (behaviorType == 0)
        {

        }
        else if (behaviorType == 1)
        {
            if (isChanging == false)
            {
                changeInterval = Random.Range(2, 6);
                StartCoroutine("PoliceTuring");
            }
        }
        else if (behaviorType == 2)
        {
            if (isChanging == false)
            {
                changeInterval = Random.Range(3, 6);
                walkInterval = Random.Range(1, 3);
                StartCoroutine("PoliceWalking");
                StartCoroutine("PoliceTuring");
            }
        }
    }

    IEnumerator PoliceTuring()
    {
        isChanging = true;
        //Debug.Log(changeInterval);
        yield return new WaitForSeconds(changeInterval);
        ChangeDirection();
        isChanging = false;
        StopAllCoroutines();
    }

    IEnumerator PoliceWalking()
    {
        Jump();
        isWalking = true;
        yield return new WaitForSeconds(walkInterval);
        isWalking = false;
        StopCoroutine("PoliceWalking");
    }

    private void Move()
    {
        transform.Translate(faceDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, 500));
    }

    public void Paralyzed()
    {
        StopAllCoroutines();
        rb2d.constraints = RigidbodyConstraints2D.None;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
        isParalyzed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player"&&!isParalyzed&&!Player.Instance.isFailed)
        {
            Player.Instance.isFailed = true;
            GameObject.Find("SceneCanvas").SendMessage("StageFailure");
        }
        if (collision.collider.tag == "Object"|| collision.collider.tag == "Police")
        {
            behaviorType = 2;
        }
    }
}
