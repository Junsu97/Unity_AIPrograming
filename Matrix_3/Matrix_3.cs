using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix_3 : MonoBehaviour
{
    Matrix4x4 matrix;
    float minimum = -1;
    float maximum = 1;
    float t = 0f;
    void Start()
    {
        matrix = transform.localToWorldMatrix; // 매트릭스 접근 (읽기 전용)
        Debug.Log(" 00 ="+matrix.m00);
        Debug.Log(" 01 ="+matrix.m01);
        Debug.Log(" 02 ="+matrix.m02);
        Debug.Log(" 03 ="+matrix.m03);
        Debug.Log("*******************************");
        Debug.Log(" 10 =" + matrix.m10);
        Debug.Log(" 11 =" + matrix.m11);
        Debug.Log(" 12 =" + matrix.m12);
        Debug.Log(" 13 =" + matrix.m13);
        Debug.Log("*******************************");
        Debug.Log(" 20 =" + matrix.m20);
        Debug.Log(" 21 =" + matrix.m21);
        Debug.Log(" 22 =" + matrix.m22);
        Debug.Log(" 23 =" + matrix.m23);
        Debug.Log("*******************************");
        Debug.Log(" 30 =" + matrix.m30);
        Debug.Log(" 31 =" + matrix.m31);
        Debug.Log(" 32 =" + matrix.m32);
        Debug.Log(" 33 =" + matrix.m33);
        Debug.Log("*******************************");
        Debug.Log("스케일 출력");
        Debug.Log(matrix.m00);
        Debug.Log(matrix.m11);
        Debug.Log(matrix.m22);
    }

    void Update()
    {
        Vector3 tmp = Vector3.zero;

        tmp.x = matrix.m03;
        tmp.y = matrix.m13;
        tmp.z = matrix.m23;

        transform.position = tmp;


        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

    }
}
