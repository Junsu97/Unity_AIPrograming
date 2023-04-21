using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ����ü
// ���� ������ �þ�� ����ؼ� �߰�
public class MobInfo 
{
    public ushort index;
    public string name;
}
public class MonsterTableInfo : SingleTon<MonsterTableInfo> //�̷��� ����ؾ���.
{ //���̺��� Ŭ������ �ϳ��� �����ؾ� �ϰ�,
  //�� ���̺��� ������ ������ �� �ִ� �Լ����� ����� ���ƾ��Ѵ�.
    MultiMap<ushort, MobInfo> mobTableInfo = new MultiMap<ushort,MobInfo>();

    // ���߿� ���Ͽ��� ���̺� ������ �о �����Ѵ�.
     public void LoadTable()
    {
        // ���̺����͸� �о ��Ƽ�ʿ� �����ϴ� �ڵ�� ����
        for (int i = 0; i < 10; i++)
        {
            MobInfo mobData = new MobInfo();
            mobData.name = "������";
            mobData.index = 100;
            mobTableInfo.AddData(mobData.index, mobData);
        }

        for (int i = 0; i < 3; i++)
        {
            MobInfo mobData = new MobInfo();
            mobData.name = "������_"+i.ToString();
            mobData.index = 200;
            mobTableInfo.AddData(mobData.index, mobData);
        }

        List<MobInfo> findlist =  mobTableInfo.GetData(200);
        // Ű�� 200�� �����͸� ��� ���
        foreach(MobInfo one in findlist)
        {
            Debug.Log(one.name);
        }

        // �̸��� ������_1 �� ������ �˻�
        //MobInfo? result = findlist.Find(o=>(o.name=="������_1"));
        // Find�� �� �񱳰� �ȵ�. �׷��� ����Ÿ���� Ŭ���� ��� struct�� ��Ÿ��
        // ����üstruct ����ϰ������ Find �� �ƴ� �ݺ����� ���
        MobInfo result = findlist.Find(o => (o.name.Equals("������_1")));

        if (result != null)
        {
            Debug.Log(result.name);
            Debug.Log(result.index);
        }
        else
        {
            Debug.Log("����");
        }
    }
}
