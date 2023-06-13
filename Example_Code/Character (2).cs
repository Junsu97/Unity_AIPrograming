using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public NavMeshAgent nav;
    public JoyStick sick;
    public bool bAuto = false;
    Monster TargetMonster = null;

    // 지형의 높이가 같다는 가정
    // 캐릭터의 위치로 부터 스틱의 움직인 방향으로 반경10의 위치 
    public Vector3 GETDIRPOS
    {
        get
        {
            return transform.position + sick.DIR * 1f;
        }
    }
    void Start()
    {
        
    }

    public void OnAuto()
    {
        Debug.Log("OnAuto");
        bAuto = !bAuto;
        if( bAuto == false )
        {
            TargetMonster = null;
        }
    }


    void Update()
    {
        if( bAuto == false )
            nav.destination = GETDIRPOS;

        if ( bAuto && TargetMonster == null)
        {
            Monster findMob = MonsterManager.instance.GetClosedMonster();
            if (findMob != null)
            {
                TargetMonster = findMob;
                nav.destination = TargetMonster.transform.position;
            }
        }

        //if( Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;
        //    if( Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        //    {
        //        if (hitInfo.collider.CompareTag("Terrain"))
        //        {
        //            nav.destination = hitInfo.point;
        //        }
        //    }

        //}
    }
}
