using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 매개변수가 없으며 리턴형식이 void인 대리자 선언.
// ex) 1번 끝난 다음에 2번 혹은 1번 끝난 다음에 3번해 와 같은 불규칙적 순서를 가졌을때 유용
// 클래스 외부함수도 대입가능
// UI작업시 유리 ex) 스킬마다 쿨타임이 끝나면 무엇하라.
// 조건문 줄일수있다.
public delegate void Do();
public class DelegateExample : MonoBehaviour
{
    // doSomethig변수는 대리자 변수이므로, 함수를 대입 할 수 있다.
    Do doSomething = null;
    void Start()
    {
        doSomething = Test;
        doSomething += RunTest;
        doSomething += TestTest;
        
        // Test함수가 호출된다.
        doSomething();

        doSomething -= TestTest;
        doSomething -= RunTest;
        doSomething -= Test;
        if (doSomething != null)
            doSomething();
    }

    public void Test()
    {
        Debug.Log("Test함수 호출");
    }

    public void RunTest()
    {
        Debug.Log("RunTest함수 호출");

    }

    public void TestTest()
    {
        Debug.Log("TestTest함수 호출");
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
