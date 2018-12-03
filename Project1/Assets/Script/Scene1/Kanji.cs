using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanji : MonoBehaviour {

    public bool isActive;
    private SpriteRenderer sr;

    public int charNum;
    public Sprite charSprite;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Activate()
    {
        sr.sprite = charSprite;
        isActive = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player"&&isActive)
        {
            GameObject.Find("Generator").SendMessage("Storage", charNum);
        }
    }
}
