using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScene2 : MonoBehaviour {

    private Animator anim;

    public bool isBig;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isEnlarged", isBig);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
