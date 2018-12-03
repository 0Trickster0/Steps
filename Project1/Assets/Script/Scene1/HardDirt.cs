using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDirt : MonoBehaviour {

    private SpriteRenderer sr; 

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Soften()
    {
        sr.color = new Vector4(178, 142, 81, 255);
        gameObject.name = "SoftenDirt";
    }

    public void Cut()
    {
        Destroy(gameObject);
    }
}
