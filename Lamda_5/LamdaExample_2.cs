using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate int Dof(int a);
public class LamdaExample_2 : MonoBehaviour
{
    Dof doSomething = null;
    Do doo = null;
    void Start()
    {
        // 이름이 없는 함수를 정의하여 doSomething에 대입
        doSomething = (x) => {
            return x + 2;
        };

        int result = doSomething(4);
        Debug.Log(result);

        // 람다식을 이용하여 "안녕하세요"를 출력하는 함수를 정의하고, 델리게이트를 이용하여 호출;
        doo = () => {
            Debug.Log("안녕하세요");
        };
        doo();

        Test(FunctionTest); //FunctionTest가  _param에 대입

        Test(() => {
            Debug.Log("조금있다가 식사합시다.");
        });

        // 실습[1]
        TestLamda((x) => (x + x));

        //TestLamda((x) =>{
        //    return x +71;
        //});
    }

    //실습[1] Dof를 매개변수로 하는 함수 TestLamda를 정의
    //TestLamda의 매개변수로 이름이 없는 함수를 전달하는 예를 작성하시오
    public void TestLamda(Dof _pr)
    {
        if (_pr != null)
        {
           int result = _pr(71);
            Debug.Log(result);
        }
    }
    // delegate를 이용하여 함수를 매개변수로 전달
    public void Test(Do _param)
    {
        if (_param != null)
            _param();
    }

    public void FunctionTest()
    {
        Debug.Log("FunctionTest");
    }
    
    
    void Update()
    {
        
    }
}
