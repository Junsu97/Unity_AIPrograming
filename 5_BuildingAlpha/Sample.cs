using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public GameObject player;
    List<MeshRenderer> Alphalist = new List<MeshRenderer>();
    void Start()
    {
        StartCoroutine(FadeOut(0.2f));
       // StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut(float time)
    {
        WaitForSeconds uptime = new WaitForSeconds(time);
        while(true)
        {
            
            Ray ray =
                new Ray(transform.position, player.transform.position - transform.position);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                MeshRenderer mesh = hits[i].collider.GetComponent<MeshRenderer>();
                Color col = mesh.material.color;
                col.a -= Time.deltaTime *5f ;
                mesh.material.color = col;
                if (col.a <= 0.2f)
                {
                    col.a = 0.2f;
                    mesh.material.color = col;
                }
                
                Alphalist.Add(mesh);
                if (hits[1].collider.name == player.name)
                {
                    foreach (var one in Alphalist)
                    {
                        Color col_ = one.material.color;
                        col_.a += Time.deltaTime * 5f;
                        one.material.color = col_;
                    }
                    Alphalist.Clear();
                }
            }
            yield return uptime;

        }
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            
            
        }
    }


}
