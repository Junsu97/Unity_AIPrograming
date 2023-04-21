using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //네비게이션 이용을 위해 유징
public class Character : MonoBehaviour
{
    public NavMeshAgent nav;
    public JoyStick joy;
    public bool bAuto = false;
    Monster TargetMonster = null;

    public Vector3 GETDIRPOS
    {
        get
        {
            return transform.position + joy.DIR * 1.5f;
        }
    }
    void Start()
    {
        
    }
    // 지형의 높이가 같다는 가정
    // 캐릭터의 위치로부터 스틱의 움직인 방향으로 반경10의 위치
    public void OnAuto()
    {
        Debug.Log("OnAuto");
        // bAuto = true;
        bAuto = !bAuto;
        if (bAuto == false)
        {
            TargetMonster = null;  
        }
    }

    public Monster FindClosedMonster()
    {

        return MonsterManager.instance.moblist[0];
    }
    void Update()
    {
        if (bAuto == false)
        {
            nav.destination = GETDIRPOS;
        }

        if (bAuto && TargetMonster == null)            //오토사냥
        {
            Monster findmob = MonsterManager.instance.GetCloesedMonster();
            if (findmob != null)
            {
                TargetMonster = findmob;
                nav.destination = TargetMonster.transform.position;
            }
        }
        
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;
        //    if(Physics.Raycast(ray,out hitInfo, Mathf.Infinity))
        //    {
        //        if (hitInfo.collider.CompareTag("Terrain"))
        //        {
        //            nav.destination = hitInfo.point;
        //        }
        //    }
        //}
    }
}
