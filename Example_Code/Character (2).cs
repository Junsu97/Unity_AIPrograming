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

    // ������ ���̰� ���ٴ� ����
    // ĳ������ ��ġ�� ���� ��ƽ�� ������ �������� �ݰ�10�� ��ġ 
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
