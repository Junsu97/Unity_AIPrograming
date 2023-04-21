using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternion_3 : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 45, 0);
        Debug.Log( transform.rotation.eulerAngles);

        transform.rotation = Quaternion.identity;// 쿼터니언 초기화
    }

    void Update()
    {
        
    }
}
