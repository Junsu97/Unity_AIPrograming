using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct CharacterData
{
    public string name;
    public ushort index;

}

public class DictionaryTest : MonoBehaviour
{   // 실습
    // CharacterData 이름의 구조체 정의
    // 양수값의 인덱스, 이름
    // 위의 구조체 데이터를 Dictionary에 저장 (3개)
    // 값은 임의로 채울것.
    // Dictionary에서 원하는 데이터를 찾아서 리턴하는 함수를 제작
    Dictionary<ushort, CharacterData> dic = new Dictionary<ushort, CharacterData>();
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CharacterData data = new CharacterData();
            data.index = (ushort)(1000 + i);
            data.name = "가나다";
            dic.Add(data.index, data);
        }

        // GetData()함수를 사용해서 null비교 할 수 있도록 제작
        CharacterData? findData = GetData(1000);
        if (!findData.HasValue)
            Debug.Log("키1010값이 존재하지 않습니다.");
        else
            Debug.Log(findData.Value.name);
    }

    public CharacterData? GetData(ushort key) //구조체는 널 비교가 안됨으로 ?(널에이블)필수
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
