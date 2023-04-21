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
        // �̸��� ���� �Լ��� �����Ͽ� doSomething�� ����
        doSomething = (x) => {
            return x + 2;
        };

        int result = doSomething(4);
        Debug.Log(result);

        // ���ٽ��� �̿��Ͽ� "�ȳ��ϼ���"�� ����ϴ� �Լ��� �����ϰ�, ��������Ʈ�� �̿��Ͽ� ȣ��;
        doo = () => {
            Debug.Log("�ȳ��ϼ���");
        };
        doo();

        Test(FunctionTest); //FunctionTest��  _param�� ����

        Test(() => {
            Debug.Log("�����ִٰ� �Ļ��սô�.");
        });

        // �ǽ�[1]
        TestLamda((x) => (x + x));

        //TestLamda((x) =>{
        //    return x +71;
        //});
    }

    //�ǽ�[1] Dof�� �Ű������� �ϴ� �Լ� TestLamda�� ����
    //TestLamda�� �Ű������� �̸��� ���� �Լ��� �����ϴ� ���� �ۼ��Ͻÿ�
    public void TestLamda(Dof _pr)
    {
        if (_pr != null)
        {
           int result = _pr(71);
            Debug.Log(result);
        }
    }
    // delegate�� �̿��Ͽ� �Լ��� �Ű������� ����
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
