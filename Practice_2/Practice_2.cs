using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public delegate float Dfun(float a, float b);
public class Practice_2 : MonoBehaviour
{
    Dfun dfun = null;
    //프로퍼티를 이용하여 정의
    public Dfun DFUN
    {
        get{ return dfun; }
        set { dfun = value; }
    }
    // 닷넷 제공 delegate 함수
    // - 닷넷에서는 이미 만들어놓은 delegate함수를 정의
    // Action : 매개변수 1개, 리턴이 없는 경우
    // Func<T, TResult> ( T는 매개변수, TResult는 리턴타입)


    // Action은 이미 만들어져 있기 때문에 delegate를 별도로 선언하지 않아도 된다.
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

    Func<bool> func2 = null; // 매개변수 생략
    public bool  TestFunc2()
    {
        return false;
    }
    //1. 실수를 리턴하고 실수형 매개변수 2개를 전달하는 델리게이트 함수를 정의.
    //2. 위의 델리게이트 함수에 실제 함수를 대입하기 위한 함수를 정의

    //3. 매개변수가 실수이고 리턴타입이 stringdls 델리게이트 변수 선언
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
    // 함수를 사용하여 delegate변수에 대입
    public void SetFunction(Dfun _dfun)
    {
        dfun = _dfun;
    }
     

    void Update()
    {
        
    }
}
