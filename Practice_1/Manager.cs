using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   /* ���� ����� Mob_1�̶�� �̸��� ���ӿ�����Ʈ�� �˻��ؼ�
    * Mob_1�� ��ġ�� 20,10,10 ���� �̵� ��Ű�ÿ�.
    */

    void Start()
    {
        GameObject obj = GameObject.Find("Mob_1");
        if( obj != null)
             obj.transform.position = new Vector3(20, 10, 10);
    }

    void Update()
    {
        
    }
}
