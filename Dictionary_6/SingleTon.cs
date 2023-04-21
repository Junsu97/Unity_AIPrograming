using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new() //����Ÿ���̿��� �ϰ� �Ű������� ���� �����ڸ� �������־���Ѵ�
{ 
    private static T inst = null;
    public SingleTon()
    {

    }
    public static T instance //�ܺο����� T�� ������Ƽ instance�� ���
    {
        get
        {
            if (inst == null)
                inst = new T();
            return null;
        }
    }
}
