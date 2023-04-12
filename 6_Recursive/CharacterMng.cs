using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CharacterMng : MonoBehaviour
{
    // 이러한 기능을 하는 것은 캐릭터 클래스나 게임헬퍼 클래스에 모아둔다
    const string WeaponNode = "Weapon"; //const 를 붙인 이유는 상수 == 고정 변경 불가
    const string DefenceNode = "Defence";
    void Start()
    {
        Transform findweapon = GameHelper.FindWeapon(transform,WeaponNode);
        Debug.Log(findweapon);

        GameHelper.GetChildFolderName(Directory.GetCurrentDirectory());

        GameHelper.WriteLog("가나다");
    }

    void Update()
    {
        
    }
}
