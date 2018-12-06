using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public int moveSpeed;
    private bool isAwaken;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (isAwaken&&transform.position.x<=152)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void WakeUp()
    {
        if (!isAwaken)
        {
            isAwaken = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&isAwaken&& !Player.Instance.isFailed)
        {
            Player.Instance.isFailed = true;
            Debug.Log("Game Over");
            GameObject.Find("SceneCanvas").SendMessage("StageFailure");
            GameObject.Find("WisePointController").SendMessage("StageFailure", 3);
        }
    }
}
