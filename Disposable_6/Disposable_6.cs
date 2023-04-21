using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UserData_2 : IDisposable
{
    public UserData_2()
    {
    }

    // IDisposable�������̽��� �ʼ� �����Լ�
    // using �����ȿ��� ������ �ν��Ͻ��� �޸𸮿��� ����� �� ȣ��
    public void Dispose()
    {
        Debug.Log("�޸𸮿��� �Ҹ�(����) ���� �ݵ�� �ؾ� �� ��");
    }
    public void Test()
    {
        Debug.Log("Test");
    }
    ~UserData_2()
    {
        Debug.Log("�Ҹ��� ȣ��");
    }
}

public class Disposable_6 : MonoBehaviour
{

    void Start()
    {
        // Ŭ���� �ν��Ͻ��� using �������� �Ҵ��Ѵٸ�
        // using���� ���������� ���ÿ� �޸𸮿��� ����
        // �� Ŭ������ IDisposable�ν������̽��� �����ؾ��Ѵ�

        // ��� ��) ��������°� ���� ��� ������ ������ ��� �аų� ��ٸ� �� �̻� �ʿ���� ��ü�̹Ƿ�
        // �޸𸮿��� �����ǵ��� �����ϴ°��� ����
        using (UserData_2 obj = new UserData_2())
        {
            obj.Test();
        }
    }

    void Update()
    {
        
    }
}
