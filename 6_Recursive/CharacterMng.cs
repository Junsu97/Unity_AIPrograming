using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CharacterMng : MonoBehaviour
{
    // �̷��� ����� �ϴ� ���� ĳ���� Ŭ������ �������� Ŭ������ ��Ƶд�
    const string WeaponNode = "Weapon"; //const �� ���� ������ ��� == ���� ���� �Ұ�
    const string DefenceNode = "Defence";
    void Start()
    {
        Transform findweapon = GameHelper.FindWeapon(transform,WeaponNode);
        Debug.Log(findweapon);

        GameHelper.GetChildFolderName(Directory.GetCurrentDirectory());

        GameHelper.WriteLog("������");
    }

    void Update()
    {
        
    }
}
