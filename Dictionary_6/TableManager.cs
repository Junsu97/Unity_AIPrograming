using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
     void Awake()
    {
        // ���� ���̺��� �ʿ��� �� ���� �д� ��ĺ��ٴ� �ѹ��� �о �����ϴ� ���� ���ϴ�.
        MonsterTableInfo.instance.LoadTable();//���� ����ǵ� ������� ����
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
