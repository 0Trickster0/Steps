using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public int i;
    public string fileName;
    public List<Node> nodeArray = new List<Node>();
    public Text CanvasText;

    private string shownText;

    public struct Node
    {
        public int id;
        public string text;
        public int fontSize;
        public double textInterval;
        public int next;
    }

    // Use this for initialization
    void Start () {
        nodeArray = ReadJsonFile(fileName);
        StartCoroutine(LoadText(nodeArray[0].text));
    }
	
	// Update is called once per frame
	void Update () {
        ShowJsonText();
	}

    //逐字显示文本
    IEnumerator LoadText(string sentence)
    {
        int j = 0;
        for (j = 0; j < sentence.Length; j++)
        {
            shownText = shownText + sentence[j].ToString();
            CanvasText = GameObject.Find("CanvasText").GetComponent<Text>();
            CanvasText.text = shownText;
            yield return new WaitForSeconds((float)nodeArray[i].textInterval);
        }
        StopAllCoroutines();
    }

    //单击左键后显示所有文字
    private void ShowAllText(string sentence)
    {
        shownText = sentence;
        CanvasText.text = shownText;
        StopAllCoroutines();
    }

    //消除文字
    public void DestoryDialog()
    {
        GameObject.Find("CanvasText").SetActive(false);
    }

    //读取Json文件信息
    public List<Node> ReadJsonFile(string fileName)
    {
        List<Node> nodeList = new List<Node>();
        nodeList = JsonMapper.ToObject<List<Node>>(File.ReadAllText(Application.dataPath + fileName));
        return nodeList;
    }

    //按照Json文件顺序显示文本
    public void ShowJsonText()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shownText != nodeArray[i].text)
            {
                ShowAllText(nodeArray[i].text);
            }
            else
            {
                //正常继续文本
                if (nodeArray[i].next == 0)
                {
                    i++;
                    shownText = "";
                    CanvasText.fontSize = nodeArray[i].fontSize;
                    StartCoroutine(LoadText(nodeArray[i].text));
                }
                //结束文本
                else if (nodeArray[i].next == 1)
                {
                    Debug.Log("文本结束");
                    CanvasText.text = "";
                    StartCoroutine(DarkenScreen());
                } 
            }
        }
    }

    IEnumerator DarkenScreen()
    {
        float trans;
        for (trans = 1; trans >= 0; trans-=0.005f)
        {
            GameObject.Find("DarkenScreenImage").GetComponent<Image>().color = new Vector4(0,0,0,trans);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("SceneCanvas").SetActive(false);
        StopAllCoroutines();
    }
}
