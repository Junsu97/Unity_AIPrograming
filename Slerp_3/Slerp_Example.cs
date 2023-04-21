using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp_Example : MonoBehaviour
{
    float t = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        t += Time.deltaTime * 0.5f;
        transform.position = Vector3.Slerp(gameObject.transform.position,
            new Vector3(5, 0, 0), t);

        if( t>1.0f)
        {
            t = 0f;
        }
    }
}
