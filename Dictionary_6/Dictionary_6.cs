using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary_6 : MonoBehaviour
{
    //List<int> list = new List<int>();
    //List<List<float>> list = new List<List<float>>(); 리스트 안에 리스트를 저장


    
    Dictionary<int, string> dic = new Dictionary<int, string>();//int는 키 string은 값  키값은 유일해야함
    void Start()
    {
        // 데이터 추가 //
        dic.Add(100, "가나다");
        dic.Add(1, "가나다2");
        dic.Add(1000, "가나다3");
        dic.Add(1010, "가나다4");

        // 사용
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
