using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary_6 : MonoBehaviour
{
    //List<int> list = new List<int>();
    //List<List<float>> list = new List<List<float>>(); ����Ʈ �ȿ� ����Ʈ�� ����


    
    Dictionary<int, string> dic = new Dictionary<int, string>();//int�� Ű string�� ��  Ű���� �����ؾ���
    void Start()
    {
        // ������ �߰� //
        dic.Add(100, "������");
        dic.Add(1, "������2");
        dic.Add(1000, "������3");
        dic.Add(1010, "������4");

        // ���
        Debug.Log(dic[100]);
        Debug.Log(dic[1]);

        string data = string.Empty;
        if(dic.TryGetValue(100,out data))
        {
            Debug.Log(data);
        }
        
        string result = GetData(10);
        if(result != null)
        {
            Debug.Log(data);
        }
    }

    public string GetData(int key)
    {
        string data = null;
        if (dic.TryGetValue(100, out data))
        {
            Debug.Log(data);
        }
        return data;

    }

    void Update()
    {
        
    }
}
