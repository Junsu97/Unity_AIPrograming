using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Character : MonoBehaviour
{
    public NavMeshAgent nav;
    
    void Start()
    {
        nav.destination = transform.position;
    }

    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo,Mathf.Infinity))
            {
                nav.destination = hitInfo.point;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
             nav.Move(-transform.forward); // ³Ë¹é
        }
    }
}
