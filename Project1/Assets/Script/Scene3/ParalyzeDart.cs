using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzeDart : MonoBehaviour {

    private Rigidbody2D rb;

    public int originVelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Player.Instance.faceDirection * originVelocity;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag =="Police")
        {
            collision.collider.SendMessage("Paralyzed");
            Destroy(gameObject);
        }
    }
}
