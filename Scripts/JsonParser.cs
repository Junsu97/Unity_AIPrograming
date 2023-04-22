using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

[Serializable]
public class Mob
{
    [SerializeField]
    int index;
    [SerializeField]
    string name;
    public int INDEX
    {
        get { return index; }
        set { index = value; }
    }
    public string NAME
    {
        get { return name; }
        set { name = value; }
    }
    public Mob()
    {

    }
    public Mob(int _index, string _name)
    {
        index = _index;
        name = _name;
    }   
}
[Serializable]
public class Serialization<T>
{
    [SerializeField]
    List<T> _t;

    public List<T> toList() { return _t; }
    public Serialization(List<T> _tmp)
    {
        _t = _tmp;
    }
}
public class JsonParser : MonoBehaviour
{
    List<Mob> list = new List<Mob>();
    void Start()
    {
      /*  TextAsset txtAsset = Resources.Load<TextAsset>("Data");
        JSONNode root = JSON.Parse(txtAsset.text);
        

        Debug.Log(root["name"].Value);
        Debug.Log(root["age"].Value);

        Debug.Log(root["property"]["str"].Value);
        Debug.Log(root["property"]["intel"].Value);

        JSONNode n1 = root["property"];
        Debug.Log(n1["str"].Value);

        // 리스트에 데이터 저장
        for(int i =0; i<10; i++)
        {
            Mob tmp = new Mob();
            tmp.INDEX = 100;
            tmp.NAME = "홍길동" + i.ToString();
            list.Add(tmp);
        }

        string jsonDatalist = JsonUtility.ToJson(new Serialization<Mob>(list));

        // 리스트를 To Json으로 변환
        List<Mob> _list = JsonUtility.FromJson<Serialization<Mob>>(jsonDatalist).toList();

        for(int i =0; i < _list.Count; i++)
        {
            Debug.Log(_list[i].INDEX);
            Debug.Log(_list[i].NAME);
        }
*/
        /////////////////////////
        TextAsset userInfo = Resources.Load<TextAsset>("UserInfo");
        JSONNode root = JSON.Parse(userInfo.text);

        for(int i = 0; i < root["Info"].Count; i++)
        {
            Debug.Log("Info_1의 정보" + root["Info"][i].Value);
        }
        for (int i = 0; i < root["Info_2"].Count; i++)
        {
            Debug.Log("Info_2의 정보" + root["Info_2"][i].Value);
            SetData(root["Info_2"][i]);
        }

        //////////////////////////////////////////////////
        
        DerivedClass1 info = new DerivedClass1();
        info.SomeMethod(root["Info"][1]);

        DerivedClass2 info2 = new DerivedClass2();
        info2.SomeMethod(root["Info"][0]);

        // 다형성 
        /*Info info_ = new DerivedClass1();
        info.SomeMethod(root["Info"][1]);
        Info info2_ = new DerivedClass2();
        info2.SomeMethod(root["Info"][0]);*/

        List<Info> infolist = new List<Info>();
        for ( int i = 0; i <10; i++)
        {
            Info info_ = new DerivedClass1();
            infolist.Add(info_);
        }
    }

    public void SetData(JSONNode node)
    {
        Debug.Log("함수 = "+node.Value);
    }

    void Update()
    {
        
    }
}
