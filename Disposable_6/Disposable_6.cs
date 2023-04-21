using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UserData_2 : IDisposable
{
    public UserData_2()
    {
    }

    // IDisposable인터페이스의 필수 구현함수
    // using 구문안에서 생성된 인스턴스가 메모리에서 사라질 때 호출
    public void Dispose()
    {
        Debug.Log("메모리에서 소멸(삭제) 전에 반드시 해야 할 일");
    }
    public void Test()
    {
        Debug.Log("Test");
    }
    ~UserData_2()
    {
        Debug.Log("소멸자 호출");
    }
}

public class Disposable_6 : MonoBehaviour
{

    void Start()
    {
        // 클래스 인스턴스를 using 구문에서 할당한다면
        // using블럭을 빠져나감과 동시에 메모리에서 삭제
        // 단 클래스는 IDisposable인스터페이스를 구현해야한다

        // 사용 예) 파일입출력과 같은 경우 파일의 정보를 모두 읽거나 썼다면 더 이상 필요없는 객체이므로
        // 메모리에서 삭제되도록 구현하는것이 유리
        using (UserData_2 obj = new UserData_2())
        {
            obj.Test();
        }
    }

    void Update()
    {
        
    }
}
