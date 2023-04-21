using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   /* 게임 실행시 Mob_1이라는 이름의 게임오브젝트를 검색해서
    * Mob_1의 위치를 20,10,10 으로 이동 시키시오.
    */

    void Start()
    {
        GameObject obj = GameObject.Find("Mob_1");
        if( obj != null)
             obj.transform.position = new Vector3(20, 10, 10);
    }

    void Update()
    {
        
    }
}
