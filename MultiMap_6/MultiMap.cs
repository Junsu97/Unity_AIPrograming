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
    //하나의 키값에 여러개의 데이터
    Dictionary<TKey, List<TValue>> npclist = new Dictionary<TKey, List<TValue>>();

    // 데이터를 입력 받을 때 동일한 키 값이 존재하면 리스트에만 저장하고
    // 없으면 키와 벨류를 같이 저장
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
