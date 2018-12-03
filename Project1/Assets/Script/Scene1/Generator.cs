using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    List<int> charList = new List<int>();

    public GameObject[] itemArray;
    public int[] charArray;


	// Use this for initialization
	void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        
        Generate();
	}

    public void Storage(int charNum)
    {
        if (charNum != 7)
        {
            charList.Add(charNum);
        }
        else
        {
            charList.Clear();
        }
    }

    private void Generate()
    {
        charArray = charList.ToArray();
        //生成火
        if (EqualArray(charArray, new int[] { 1, 4, 4, 5}))
        {
            Instantiate(itemArray[0],new Vector3(transform.position.x,transform.position.y,0),transform.rotation);
            charList.Clear();
        }
        //生成金
        if (EqualArray(charArray, new int[] { 4, 5, 2, 2, 3, 1, 4, 2 }))
        {
            Instantiate(itemArray[1], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            charList.Clear();
        }
        //生成木
        if (EqualArray(charArray, new int[] { 2, 3, 4, 5 }))
        {
            Instantiate(itemArray[2], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            charList.Clear();
        }
        //生成水
        if (EqualArray(charArray, new int[] { 6, 2, 4, 4, 5 }))
        {
            Instantiate(itemArray[3], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            charList.Clear();
        }
        //生成土
        if (EqualArray(charArray, new int[] { 2, 3, 2 }))
        {
            Instantiate(itemArray[4], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            charList.Clear();
        }
        //生成羽
        if (EqualArray(charArray, new int[] { 2, 6, 1, 4, 2, 6, 1, 4 }))
        {
            Instantiate(itemArray[5], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            charList.Clear();
        }
    }

    private bool EqualArray(int[] array1, int[] array2)
    {
        bool isEqual = true;
        int i;
        if (array1.Length != array2.Length)
        {
            isEqual = false;
            return isEqual;
        }
        else
        {
            for (i = 0; i < array1.Length; i++)
            {
                if (array1[i] == array2[i])
                {
                    
                }
                else
                {
                    isEqual = false;
                }
            }
            return isEqual;
        }
    }
}
