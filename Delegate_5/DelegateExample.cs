using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ű������� ������ ���������� void�� �븮�� ����.
// ex) 1�� ���� ������ 2�� Ȥ�� 1�� ���� ������ 3���� �� ���� �ұ�Ģ�� ������ �������� ����
// Ŭ���� �ܺ��Լ��� ���԰���
// UI�۾��� ���� ex) ��ų���� ��Ÿ���� ������ �����϶�.
// ���ǹ� ���ϼ��ִ�.
public delegate void Do();
public class DelegateExample : MonoBehaviour
{
    // doSomethig������ �븮�� �����̹Ƿ�, �Լ��� ���� �� �� �ִ�.
    Do doSomething = null;
    void Start()
    {
        doSomething = Test;
        doSomething += RunTest;
        doSomething += TestTest;
        
        // Test�Լ��� ȣ��ȴ�.
        doSomething();

        doSomething -= TestTest;
        doSomething -= RunTest;
        doSomething -= Test;
        if (doSomething != null)
            doSomething();
    }

    public void Test()
    {
        Debug.Log("Test�Լ� ȣ��");
    }

    public void RunTest()
    {
        Debug.Log("RunTest�Լ� ȣ��");

    }

    public void TestTest()
    {
        Debug.Log("TestTest�Լ� ȣ��");
    }

    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            doSomething = Test;
        }
        if( Input.GetMouseButtonDown(1))
        {
            doSomething = RunTest;
        }
        if(Input.GetMouseButtonDown(2))
        {
            doSomething = null;
        }

        if (doSomething != null)
            doSomething();
    }
}
