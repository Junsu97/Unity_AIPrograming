using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGameObject : MonoBehaviour
{
    void Start()
    {
        // 자식게임오브젝트의 이름을 모두검색
        GetChildTransform(transform);
    }
    public void GetChildTransform(Transform tr)
    {
        if (tr.childCount != 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform chtr = tr.GetChild(i);
                GetChildTransform(chtr);
                Debug.Log(chtr.gameObject.name);

            }
        }
        // 테이블에는 부모를 먼저 작성

    }
    void Update()
    {
        
    }
}
