using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public bool isFailed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!Player.Instance.isFailed)
        {
            Player.Instance.isFailed = true;
            GameObject.Find("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Debug.Log("Game Over");
            GameObject.Find("SceneCanvas").SendMessage("StageFailure");
            
        }
    }
}
