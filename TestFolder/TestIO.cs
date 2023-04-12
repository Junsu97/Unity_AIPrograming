using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AI;
public class TestIO : MonoBehaviour
{
    public NavMeshAgent nav;

    void Start()
    {
        nav.destination = transform.position;
    }

    public void SaveBuilding(string _path)
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        string data = string.Empty;
        using (StreamWriter sr = new StreamWriter(_path))
        {
            for( int i = 0; i < buildings.Length; i++)
            {
                data += buildings[i].name;
                data += ",";
                data += "Cube";
                data += ",";
                data += buildings[i].transform.position.x;
                data += ",";
                data += buildings[i].transform.position.y;
                data += ",";
                data += buildings[i].transform.position.z;
                data += ",";
                data += buildings[i].transform.eulerAngles.x;
                data += ",";
                data += buildings[i].transform.eulerAngles.y;
                data += ",";
                data += buildings[i].transform.eulerAngles.z;
                data += ",";
                data += buildings[i].transform.localScale.x;
                data += ",";
                data += buildings[i].transform.localScale.y;
                data += ",";
                data += buildings[i].transform.localScale.z;

                sr.WriteLine(_path);
                data = string.Empty;
                
            }
            sr.Close();
        }
    }
    public void LoadBuilding(string _path)
    {
        string readData = string.Empty;

        using(StreamReader sr = new StreamReader(_path))
        {
            while ((readData = sr.ReadLine()) != null)
            {
                readData = sr.ReadLine();

                //쉼표 단위로 분리
                //오브젝트 이름, 리소스 이름,위치,회전,스케일
            }
            sr.Close();
        }
        
    }

    void Update()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,Mathf.Infinity))
            {
                nav.destination = hit.point;
            }
        }
    }
}
