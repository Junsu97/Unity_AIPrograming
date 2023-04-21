using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TE : MonoBehaviour
{
    //Dictionary<int, int> dic = new Dictionay<int, int>();
    Rigidbody rg;
    void Start()

    {
        

        for (int j = 2; j < 10; j++)

        {

            for (int i = 1; i < 10; i++)

            {

                Debug.Log( j + "*" + i +"=" + (j*i) );

                //dic.Add();

            }
            
        }

    }
}
