using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
     void Awake()
    {
        // 각종 테이블은 필요할 때 마다 읽는 방식보다는 한번에 읽어서 보관하는 편이 편하다.
        MonsterTableInfo.instance.LoadTable();//씬이 변경되도 사라지지 않음
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
