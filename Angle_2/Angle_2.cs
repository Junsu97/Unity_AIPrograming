using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_2 : MonoBehaviour
{
    public GameObject capsule;

    void Start()
    {
        Vector3 tagetDir = capsule.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward,tagetDir.normalized);
        Debug.Log(angle);

        float result = GetAngle(transform.forward, capsule.transform.position - transform.position);
        Debug.Log(result);
    }

    public float GetAngle(Vector3 from, Vector3 to)
    {
        float angle = Vector3.Angle(from.normalized, to.normalized);

        // (조건) ? 참일때리턴 : 거짓일때 리턴
        angle = (Vector3.Angle(Vector3.right, to.normalized) > 90f) ? 360f - angle : angle;
        return angle;
    }
    void Update()
    {
        
    }
}
