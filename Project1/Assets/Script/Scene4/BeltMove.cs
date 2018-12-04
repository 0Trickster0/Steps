using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour {

    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //水平移动为true 竖直移动为false
    public bool isHorizontal;
    //开始时间
    public float startTime;
    //移动方向
    float dir = 1;
    //起始位置
    float start_x;
    float start_y;
    private bool isStart;

    void Start()
    {
        start_x = transform.position.x;//水平移动的起点
        start_y = transform.position.y;//竖直移动的起点
        StartCoroutine("StopTime");
    }

    void FixedUpdate()
    {
        if (isStart)
        {
            if (isHorizontal)
            {
                transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
                if (System.Math.Abs(transform.position.x - start_x) <= 0.1f || System.Math.Abs(transform.position.x - start_x) >= dis) { dir = -dir; }
            }
            //水平移动
            else
            {
                transform.Translate(Vector2.up * dir * speed * Time.deltaTime);
                if (System.Math.Abs(transform.position.y - start_y) <= 0.1f || System.Math.Abs(transform.position.y - start_y) >= dis) { dir = -dir; }
            }
        }
          
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(startTime);
        isStart = true;
        StopAllCoroutines();
    }
}
