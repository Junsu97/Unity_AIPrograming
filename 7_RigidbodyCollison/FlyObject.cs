using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObject : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Rigidbody2D rb;
    Rect rc;
    void Start()
    {
        rb.position = transform.position;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x < 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }

        //Vector2 tmp = rb.position;
        //tmp.x += Time.deltaTime * x * 3;
        //tmp.y += Time.deltaTime * y * 3;
        //rb.position = tmp;

        // Vector2 tmp = new Vector2( x * 3,  y * 3);
        // rb.velocity = tmp;  // 속도 변수에 키 입력


        //Vector2 tmp = new Vector2(x * 3, y * 3);
        //rb.AddForce(tmp, ForceMode2D.Force);

        //if(Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    renderer.flipX = true;
        //}
        //if(Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    renderer.flipX = false;
        //}
    }

    void Update()
    {
    }
    
}
