using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterInfo info;
    float Distance = 0f; // �÷��̾���� �Ÿ�
    public float DISTANCE
    {
        get { return Distance; }
    }
    void Start()
    {
      
    }

    void Update()
    {
        Distance =Vector3.Distance( MonsterManager.instance.player.transform.position,
            transform.position);
    }
}
