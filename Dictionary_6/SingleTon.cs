using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new() //참조타입이여야 하고 매개변수가 없는 생성자를 가지고있어야한다
{ 
    private static T inst = null;
    public SingleTon()
    {

    }
    public static T instance //외부에서는 T형 프로퍼티 instance를 사용
    {
        get
        {
            if (inst == null)
                inst = new T();
            return null;
        }
    }
}
