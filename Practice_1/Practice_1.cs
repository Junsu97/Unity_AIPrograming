using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ������ 1���� �����ϰ�
// ������ �迭 1���� �����ϴ�( �迭�� ũ��� 10)
// Ŭ���� ����. ��, ������Ʈ�� �ƴϴ�.
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
    // TestŬ������ �ν��Ͻ��� �ɹ������� ����
    // m_data�� ����Ÿ������ new�� �Ҵ�Ǿ�� �Ѵ�.
    Test m_data;// = new Test();

    // TestŬ������ �ν��Ͻ��� 10�� ����
    Test[] m_d;// = new Test[10];

    
    void Start()
    {

        // m_data Ŭ������ �ɹ������� �ʱ�ȭ 
        //m_data.data = 10;

        // �迭�� �޸� �Ҵ��� �Ǿ��־�� �Ѵ�.

        /*m_data.array = new int[10];
        m_data.array[0] = 100;

         //m_d�� �ɹ����� �ʱ�ȭ
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

        //[�ǽ�2]
        // ���� �÷��� Directional Light ��� �̸���
        // ���ӿ�����Ʈ�� �˻��Ͽ� �ӽú����� �����Ͻÿ�.
        GameObject DL = GameObject.Find("Directional Light");

    }

    void Update()
    {
        
    }
}
