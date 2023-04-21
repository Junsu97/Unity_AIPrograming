using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 정보 구조체
// 몬스터 정보가 늘어나면 계속해서 추가
public class MobInfo 
{
    public ushort index;
    public string name;
}
public class MonsterTableInfo : SingleTon<MonsterTableInfo> //이렇게 사용해야함.
{ //테이블마다 클래스가 하나씩 존재해야 하고,
  //그 테이블의 정보를 가져올 수 있는 함수들을 만들어 놓아야한다.
    MultiMap<ushort, MobInfo> mobTableInfo = new MultiMap<ushort,MobInfo>();

    // 나중엔 파일에서 테이블 정보를 읽어서 저장한다.
     public void LoadTable()
    {
        // 테이블데이터를 읽어서 멀티맵에 저장하는 코드로 수정
        for (int i = 0; i < 10; i++)
        {
            MobInfo mobData = new MobInfo();
            mobData.name = "가나다";
            mobData.index = 100;
            mobTableInfo.AddData(mobData.index, mobData);
        }

        for (int i = 0; i < 3; i++)
        {
            MobInfo mobData = new MobInfo();
            mobData.name = "가나다_"+i.ToString();
            mobData.index = 200;
            mobTableInfo.AddData(mobData.index, mobData);
        }

        List<MobInfo> findlist =  mobTableInfo.GetData(200);
        // 키가 200인 데이터를 모두 출력
        foreach(MobInfo one in findlist)
        {
            Debug.Log(one.name);
        }

        // 이름이 가나다_1 인 데이터 검색
        //MobInfo? result = findlist.Find(o=>(o.name=="가나다_1"));
        // Find는 널 비교가 안됨. 그래서 참조타입인 클래스 사용 struct는 값타입
        // 구조체struct 사용하고싶으면 Find 가 아닌 반복문을 사용
        MobInfo result = findlist.Find(o => (o.name.Equals("가나다_1")));

        if (result != null)
        {
            Debug.Log(result.name);
            Debug.Log(result.index);
        }
        else
        {
            Debug.Log("없음");
        }
    }
}
