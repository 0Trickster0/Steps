using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene3 : MonoBehaviour
{

    private int[] itemStatus = new int[8];

    public GameObject paralyzeDart;
    public GameObject paperBox;
    public GameObject stone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ParalyzeDart();
        PaperBox();
        Key();
        Stone();
    }

    private void ParalyzeDart()
    {
        if (itemStatus[0]>0 && Input.GetKeyDown(Player.Instance.item1Key))
        {
            Debug.Log("使用麻醉吹箭");
            if (Player.Instance.faceDirection == Vector2.left)
            {
                Instantiate(paralyzeDart, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), transform.rotation);
            }
            else if (Player.Instance.faceDirection == Vector2.right)
            {
                Instantiate(paralyzeDart, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), transform.rotation);
            }
            itemStatus[0]--;
        }
    }

    private void PaperBox()
    {
        if (itemStatus[1] > 0 && Input.GetKeyDown(Player.Instance.item2Key))
        {
            Debug.Log("使用纸箱");
            Instantiate(paperBox, new Vector3(transform.position.x, transform.position.y + 0.8255f, 0), transform.rotation);
            itemStatus[1]--;
        }
    }

    private void Key()
    {
        if (itemStatus[2] > 0 && Input.GetKeyDown(Player.Instance.item3Key))
        {
            Debug.Log("使用钥匙");
            if (Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.tag == "Door")
                {
                    Destroy(Player.Instance.hit.collider.gameObject);
                    itemStatus[2]--;
                }
            } 
        }
    }

    private void Stone()
    {
        if (itemStatus[3] > 0 && Input.GetKeyDown(Player.Instance.item4Key))
        {
            Debug.Log("使用石头");
            if (Player.Instance.faceDirection == Vector2.left)
            {
                Instantiate(stone, new Vector3(transform.position.x - 0.25f, transform.position.y+0.25f, 0), transform.rotation);
            }
            else if (Player.Instance.faceDirection == Vector2.right)
            {
                Instantiate(stone, new Vector3(transform.position.x + 0.25f, transform.position.y+0.25f, 0), transform.rotation);
            }
            itemStatus[3]--;
        }
    }

    public void pickUpItem(int itemNum)
    {
        itemStatus[itemNum]++;
    }
}
