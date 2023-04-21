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

        // ����Ʈ���� 1�� ���� ���� ã�Ƽ� ����
        int result = list.Find(o => (o == 1));
        Debug.Log(result);

        // ����Ʈ ���� ( �������� )
        list.Sort((x, y) => x.CompareTo(y));

        foreach( int one in list)
        {
            Debug.Log(one);
        }
        Debug.Log("****************************************************");
        // ��������
        list.Sort((x, y) => y.CompareTo(x));
        foreach (int one in list)
        {
            Debug.Log(one);
        }
        /////////////////////////////////////////////////////////////////////////////////////
        UserData tmp = new UserData();
        tmp.index = 98;
        tmp.name = "������";
        ulist.Add(tmp);

        UserData tmp2 = new UserData();
        tmp2.index = 2;
        tmp2.name = "ȫȫȫ";
        ulist.Add(tmp2);

        UserData tmp3 = new UserData();
        tmp3.index = 1000;
        tmp3.name = "������";
        ulist.Add(tmp3);

        // Find�Լ��� ����ؼ� �̸��� ȫȫȫ �� �����͸� �˻�
        UserData findUser = ulist.Find(o=>(o.name == "ȫȫȫ"));
        if (findUser != null)
            Debug.Log("�̸� = "+findUser.name +"   "+"index ="+findUser.index);

        // ulist���� Sort�Լ��� ����Ͽ� �ε����� ���� ������ �Ͻÿ�
        // ���ĵ� ��� �����͸� �ֺܼ信 ����ϼ���
        ulist.Sort((x, y) => x.index.CompareTo(y.index));
        foreach(UserData one in ulist)
        {
            Debug.Log("�̸� = " + one.name + "   " + "index =" + one.index);
        }
        Debug.Log("*************************************************************");
        ulist.Sort((x, y) => y.index.CompareTo(x.index));
        foreach (UserData one in ulist)
        {
            Debug.Log("�̸� = " + one.name + "   " + "index =" + one.index);
        }
    }

    void Update()
    {
        
    }
}
