using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp_3 : MonoBehaviour
{
    public Transform sunrise;
    public Transform sunset;

    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        Vector3 center = (sunrise.position + sunset.position) * 0.5f;

        center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;

        
        float fracComplete = (Time.time - startTime) / journeyTime;

        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }
}
