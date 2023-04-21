using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGameObject : MonoBehaviour
{
    void Start()
    {
        // �ڽİ��ӿ�����Ʈ�� �̸��� ��ΰ˻�
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
        // ���̺��� �θ� ���� �ۼ�

    }
    void Update()
    {
        
    }
}
