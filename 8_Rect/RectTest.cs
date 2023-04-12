using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTest : MonoBehaviour
{
    Rect rc;
    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer Obstacle;

    float xRatio;
    float yRatio;

    public Bounds PLAYERBD
    {
        get
        {
            return PlayerRenderer.bounds;
        }
    }
   
    void Start()
    {
       
    }

    void Update()
    {
        if (PlayerRenderer.bounds.Intersects(Obstacle.bounds))
        {
            Debug.Log("Ãæµ¹");
        }
    }
}
