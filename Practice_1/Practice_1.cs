using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 정수형 데이터 1개를 포함하고
// 정수형 배열 1개를 포함하는( 배열의 크기는 10)
// 클래서 정의. 단, 컴포넌트는 아니다.
public class Test
{
    public int data;
    public int[] array = new int[10];
    public void InitArray(int _data)
    {
        for( int i = 0; i< array.Length; i++)
        {
            array[i] = _data;
        }
    }

    public Test()
    {
        data = 0;
        InitArray(-1);
    }
}

public class Practice_1 : MonoBehaviour
{
    // Test클래스의 인스턴스를 맴버변수로 포함
    // m_data는 참조타입으로 new로 할당되어야 한다.
    Test m_data;// = new Test();

    // Test클래스의 인스턴스를 10개 생성
    Test[] m_d;// = new Test[10];

    
    void Start()
    {

        // m_data 클래스의 맴버변수를 초기화 
        //m_data.data = 10;

        // 배열은 메모리 할당이 되어있어야 한다.

        /*m_data.array = new int[10];
        m_data.array[0] = 100;

         //m_d의 맴버변수 초기화
        for (int i = 0; i < m_d.Length; i++)
        {
            m_d[i].data = 0;
            m_d[i].InitArray(-1);
        }*/


        /*m_data = new Test();
        m_data.data = 100;
        m_d = new Test[10];
        for ( int i = 0; i < m_d.Length; i++)
        {
            m_d[i].data = 100;
            m_d[i].array = new int[10];

            for (int j = 0; j < m_d[i].array.Length; j++)
                m_d[i].array[j] = -1;
        }*/

        //[실습2]
        // 씬에 올려진 Directional Light 라는 이름의
        // 게임오브젝트를 검색하여 임시변수에 저장하시오.
        GameObject DL = GameObject.Find("Directional Light");

    }

    void Update()
    {
        
    }
}
