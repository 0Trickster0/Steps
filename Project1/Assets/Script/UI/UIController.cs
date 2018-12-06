using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Sprite[] imageArray;
    public string[] nameArray;
    public string[] introductionArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickUpItem(int itemNum)
    {
        GameObject.Find("Image" + itemNum.ToString()).GetComponent<Image>().sprite = imageArray[itemNum];
        GameObject.Find("Name" + itemNum.ToString()).GetComponent<Text>().text = nameArray[itemNum];
        GameObject.Find("Image" + itemNum.ToString()).GetComponent<ShowIntroduction>().introduction = introductionArray[itemNum];
    }
}
