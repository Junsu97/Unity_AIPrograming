using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public delegate float Dfun(float a, float b);
public class Practice_2 : MonoBehaviour
{
    Dfun dfun = null;
    //������Ƽ�� �̿��Ͽ� ����
    public Dfun DFUN
    {
        get{ return dfun; }
        set { dfun = value; }
    }
    // ��� ���� delegate �Լ�
    // - ��ݿ����� �̹� �������� delegate�Լ��� ����
    // Action : �Ű����� 1��, ������ ���� ���
    // Func<T, TResult> ( T�� �Ű�����, TResult�� ����Ÿ��)


    // Action�� �̹� ������� �ֱ� ������ delegate�� ������ �������� �ʾƵ� �ȴ�.
    Action<float> act1 = null;
    
    public void TestAction(float a)
    {
        Debug.Log("TestAction");
    }

    Func<int, float> func = null;
    public float TestFunc(int a)
    {
        return (float)a + 10.2f;
    }

    Func<bool> func2 = null; // �Ű����� ����
    public bool  TestFunc2()
    {
        return false;
    }
    //1. �Ǽ��� �����ϰ� �Ǽ��� �Ű����� 2���� �����ϴ� ��������Ʈ �Լ��� ����.
    //2. ���� ��������Ʈ �Լ��� ���� �Լ��� �����ϱ� ���� �Լ��� ����

    //3. �Ű������� �Ǽ��̰� ����Ÿ���� stringdls ��������Ʈ ���� ����
    Func<float, string> func3 = null;

    public string TestFunc3(float a)
    {
        return null;
    }
    void Start()
    {
        DFUN = TestDel;
        float data = DFUN(20.1f, 10.4f);
        Debug.Log(data);

        act1 = TestAction;
        act1(10f);

        func = TestFunc;
        float result =  func(10);
        Debug.Log(result);

        func2 = TestFunc2;
        Debug.Log(func2());
    }

    public float TestDel(float a,float b)
    {
        return a + b;
    }
    // �Լ��� ����Ͽ� delegate������ ����
    public void SetFunction(Dfun _dfun)
    {
        dfun = _dfun;
    }
     

    void Update()
    {
        
    }
}
