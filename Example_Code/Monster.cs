using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterInfo info;
    float Distance = 0f;    // 플레이어와의 거리
    public float DISTANCE
    {
        get { return Distance; }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance( MonsterManager.instance.player.transform.position, 
                                     transform.position );
    }
}
