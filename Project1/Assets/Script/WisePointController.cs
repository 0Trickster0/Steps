using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisePointController : MonoBehaviour {

    public bool[] wisePointArray = new bool[] { false, false, true, true };

    //单例
    private static WisePointController instance;
    public static WisePointController Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clear()
    {
        wisePointArray = new bool[] { false, false, false, false };
    }

    private void PickUpWisePoint(int pointNum)
    {
        wisePointArray[pointNum] = true;
    }

    private void StageFailure(int stageNum)
    {
        wisePointArray[stageNum-1] = false;
    }
}
