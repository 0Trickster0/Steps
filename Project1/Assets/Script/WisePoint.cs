using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisePoint : MonoBehaviour {

    public int pointNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.Find("WisePointController").SendMessage("PickUpWisePoint", pointNum);
            Destroy(gameObject);
        }
    }
}
