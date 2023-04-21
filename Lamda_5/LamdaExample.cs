using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public int index;
    public string name;
}
public class LamdaExample : MonoBehaviour
{
    List<int> list = new List<int>();

    List<UserData> ulist = new List<UserData>();
    void Start()
    {
        list.Add(3);
        list.Add(1);
        list.Add(2);
        list.Add(4);

        // 리스트에서 1과 같은 값을 찾아서 리턴
        int result = list.Find(o => (o == 1));
        Debug.Log(result);

        // 리스트 정렬 ( 오름차순 )
        list.Sort((x, y) => x.CompareTo(y));

        foreach( int one in list)
        {
            Debug.Log(one);
        }
        Debug.Log("****************************************************");
        // 내림차순
        list.Sort((x, y) => y.CompareTo(x));
        foreach (int one in list)
        {
            Debug.Log(one);
        }
        /////////////////////////////////////////////////////////////////////////////////////
        UserData tmp = new UserData();
        tmp.index = 98;
        tmp.name = "가나다";
        ulist.Add(tmp);

        UserData tmp2 = new UserData();
        tmp2.index = 2;
        tmp2.name = "홍홍홍";
        ulist.Add(tmp2);

        UserData tmp3 = new UserData();
        tmp3.index = 1000;
        tmp3.name = "나나나";
        ulist.Add(tmp3);

        // Find함수를 사용해서 이름이 홍홍홍 인 데이터를 검색
        UserData findUser = ulist.Find(o=>(o.name == "홍홍홍"));
        if (findUser != null)
            Debug.Log("이름 = "+findUser.name +"   "+"index ="+findUser.index);

        // ulist에서 Sort함수를 사용하여 인덱스에 의한 정렬을 하시오
        // 정렬된 모든 데이터를 콘솔뷰에 출력하세요
        ulist.Sort((x, y) => x.index.CompareTo(y.index));
        foreach(UserData one in ulist)
        {
            Debug.Log("이름 = " + one.name + "   " + "index =" + one.index);
        }
        Debug.Log("*************************************************************");
        ulist.Sort((x, y) => y.index.CompareTo(x.index));
        foreach (UserData one in ulist)
        {
            Debug.Log("이름 = " + one.name + "   " + "index =" + one.index);
        }
    }

    void Update()
    {
        
    }
}
