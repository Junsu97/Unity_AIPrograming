using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct NpcData
{
    public string name;
    public ushort index;

}
public class MultiMap<TKey, TValue>
{
    //�ϳ��� Ű���� �������� ������
    Dictionary<TKey, List<TValue>> npclist = new Dictionary<TKey, List<TValue>>();

    // �����͸� �Է� ���� �� ������ Ű ���� �����ϸ� ����Ʈ���� �����ϰ�
    // ������ Ű�� ������ ���� ����
    public void AddData(TKey key, TValue val)
    {
        List<TValue> list;
        if(npclist.TryGetValue(key,out list))
        {
            npclist[key].Add(val);
        }
        else
        {
            list = new List<TValue>();
            list.Add(val);
            npclist.Add(key, list);
        }
    }
    public List<TValue>? GetData(TKey key)
    {
        List<TValue> _list;

        if (npclist.TryGetValue(key, out _list))
        {
            return _list;
        }
        else
        {
            return null;
        }
    }
}
