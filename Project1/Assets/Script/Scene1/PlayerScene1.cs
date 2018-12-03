using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene1 : MonoBehaviour {

    private bool[] itemStatus= new bool[8];
    private bool canFly;

    public GameObject Tree;
    public GameObject Mud;
    public GameObject Blade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
        Gold();
        Wood();
        Water();
        Earth();
        Wing();
        Fly();
	}

    private void Fire()
    {
        if (itemStatus[0] && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("使用火");
            if(Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.name == "Thorns" || Player.Instance.hit.collider.name == "Tree(Clone)")
                {
                    Player.Instance.hit.collider.SendMessage("Burnt");
                    Debug.Log("燃烧");
                }
            }
        }
    }

    private void Gold()
    {
        if (itemStatus[1] && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("使用金");
            if (Player.Instance.faceDirection == Vector2.left)
            {
                Instantiate(Blade, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), transform.rotation);
            }
            else if(Player.Instance.faceDirection == Vector2.right)
            {
                Instantiate(Blade, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), transform.rotation);
            }
            
        }
    }

    private void Wood()
    {
        if (itemStatus[2] && Input.GetKeyDown(KeyCode.Alpha3)&&!Player.Instance.isJumping)
        {
            Debug.Log("使用木");
            Instantiate(Tree, new Vector3(transform.position.x, transform.position.y + 0.8255f, 0), transform.rotation);
        }
    }

    private void Water()
    {
        if (itemStatus[3] && Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("使用水");
            if(Player.Instance.hit.collider != null)
            {
                if (Player.Instance.hit.collider.name == "Tree(Clone)")
                {
                    Player.Instance.hit.collider.SendMessage("Grow");
                }
            }
        }
    }

    private void Earth()
    {
        if (itemStatus[4] && Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("使用土");
            Instantiate(Mud, new Vector3(transform.position.x, transform.position.y + 0.8255f, 0), transform.rotation);

        }
    }

    private void Wing()
    {
        if (itemStatus[5] && Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("使用羽");
            canFly = true;
        }
    }

    private void Fly()
    {
        if (canFly)
        {
            if (Player.Instance.isJumping)
            {
                Player.Instance.isJumping = false;
            }
        }
        
    }

    public void pickUpItem(int itemNum)
    {
        itemStatus[itemNum] = true;
    }
}
