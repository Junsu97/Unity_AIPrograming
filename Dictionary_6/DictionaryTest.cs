using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct CharacterData
{
    public string name;
    public ushort index;

}

public class DictionaryTest : MonoBehaviour
{   // �ǽ�
    // CharacterData �̸��� ����ü ����
    // ������� �ε���, �̸�
    // ���� ����ü �����͸� Dictionary�� ���� (3��)
    // ���� ���Ƿ� ä���.
    // Dictionary���� ���ϴ� �����͸� ã�Ƽ� �����ϴ� �Լ��� ����
    Dictionary<ushort, CharacterData> dic = new Dictionary<ushort, CharacterData>();
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CharacterData data = new CharacterData();
            data.index = (ushort)(1000 + i);
            data.name = "������";
            dic.Add(data.index, data);
        }

        // GetData()�Լ��� ����ؼ� null�� �� �� �ֵ��� ����
        CharacterData? findData = GetData(1000);
        if (!findData.HasValue)
            Debug.Log("Ű1010���� �������� �ʽ��ϴ�.");
        else
            Debug.Log(findData.Value.name);
    }

    public CharacterData? GetData(ushort key) //����ü�� �� �񱳰� �ȵ����� ?(�ο��̺�)�ʼ�
    {
        CharacterData _data;

        if(dic.TryGetValue(key, out _data))
        {
            return _data;
        }
        return null;
    }
    
    void Update()
    {
        
    }
}
