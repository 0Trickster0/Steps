using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Steps : MonoBehaviour {



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
            GameObject.Find("SceneCanvas").SendMessage("StageSuccess");
        }
    }
}
