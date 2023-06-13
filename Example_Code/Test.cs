using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public NavMeshAgent nav;


    [MenuItem("Test/ExportTurrain")]// 터레인 저장
    static void SaveTurrain()
    {
         string path = Application.dataPath;
        GameObject[] T = GameObject.FindGameObjectsWithTag("Turrain");
        string fileTerrain = "Terrain.txt";


        string Tdata = string.Empty;
        for (int i = 0; i < T.Length; i++)
        {
            Tdata += T[i].transform.position.x;
            Tdata += ",";
            Tdata += T[i].transform.position.y;
            Tdata += ",";
            Tdata += T[i].transform.position.z;
            Tdata += ",";
            Tdata += T[i].transform.rotation.x;
            Tdata += ",";
            Tdata += T[i].transform.rotation.y;
            Tdata += ",";
            Tdata += T[i].transform.rotation.z;
            Tdata += ",";
            Tdata += T[i].transform.localScale.x;
            Tdata += ",";
            Tdata += T[i].transform.localScale.y;
            Tdata += ",";
            Tdata += T[i].transform.localScale.z;
            Tdata += ",";
            Tdata += GetResourceName(T[i].name);

            byte[] byTdata = Encoding.UTF8.GetBytes(Tdata); // 터레인 데이터 바이트 변환
            File.WriteAllBytes(path + "/" + fileTerrain, byTdata);



        }
    }
    [MenuItem("Test/ImportTurrainCSV")] // 터레인 로드
    static void LoadTurrain()
    {
        string path = Application.dataPath;
        string fileTerrain = "Terrain.txt";

        byte[] readT = File.ReadAllBytes(path + "/" + fileTerrain);
        string readString = Encoding.Default.GetString(readT);

        string curT = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(curT);
        foreach (string one in files)
        {
            string[] linedata = one.Split(',');

            float xpos = float.Parse(linedata[0]);
            float ypos = float.Parse(linedata[1]);
            float zpos = float.Parse(linedata[2]);

            float xrot = float.Parse(linedata[3]);
            float yrot = float.Parse(linedata[4]);
            float zrot = float.Parse(linedata[5]);

            float xscale = float.Parse(linedata[6]);
            float yscale = float.Parse(linedata[7]);
            float zscale = float.Parse(linedata[8]);
            string resource = linedata[9];

            GameObject obj = Resources.Load<GameObject>("TestCube/" + resource);
            obj.transform.position = new Vector3(xpos, ypos, zpos);
            obj.transform.localScale = new Vector3(xscale, yscale, zscale);
            obj.transform.rotation = Quaternion.Euler(xrot, yrot, zrot);

        }
    }

    [MenuItem("Test/ExportBuilding")] // 빌딩 저장
    static void saveBuilding()
    {
        string path = Application.dataPath;

        string fileBuilding = "Building.txt";

        GameObject[] B = GameObject.FindGameObjectsWithTag("Building");
        string Bdata = string.Empty;
        for (int i = 0; i < B.Length; i++)
        {
            Bdata += B[i].transform.position.x;
            Bdata += ",";
            Bdata += B[i].transform.position.y;
            Bdata += ",";
            Bdata += B[i].transform.position.z;
            Bdata += ",";
            Bdata += B[i].transform.rotation.x;
            Bdata += ",";
            Bdata += B[i].transform.rotation.y;
            Bdata += ",";
            Bdata += B[i].transform.rotation.z;
            Bdata += ",";
            Bdata += B[i].transform.localScale.x;
            Bdata += ",";
            Bdata += B[i].transform.localScale.y;
            Bdata += ",";
            Bdata += B[i].transform.localScale.z;
            Bdata += ",";
            Bdata += GetResourceName(B[i].name);

            byte[] byBdata = Encoding.UTF8.GetBytes(Bdata);//빌딩 데이터 바이트 변환
            File.WriteAllBytes(path + "/" + fileBuilding, byBdata);  //path경로에 각각의 이름으로 내용저장
            byte[] readB = File.ReadAllBytes(path + "/" + fileBuilding);
        }
    }

    [MenuItem("Test/ImportBuildingCSV")] // 빌딩 로드
    static void LoadBuilding()
    {
        string path = Application.dataPath;
        string fileTerrain = "Building.txt";

        byte[] readT = File.ReadAllBytes(path + "/" + fileTerrain);
        string readString = Encoding.Default.GetString(readT);

        string curT = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(curT);
        foreach (string one in files)
        {
            string[] linedata = one.Split(',');

            float xpos = float.Parse(linedata[0]);
            float ypos = float.Parse(linedata[1]);
            float zpos = float.Parse(linedata[2]);

            float xrot = float.Parse(linedata[3]);
            float yrot = float.Parse(linedata[4]);
            float zrot = float.Parse(linedata[5]);

            float xscale = float.Parse(linedata[6]);
            float yscale = float.Parse(linedata[7]);
            float zscale = float.Parse(linedata[8]);
            string resource = linedata[9];

            GameObject obj = Resources.Load<GameObject>("TestCube/" + resource);
            obj.transform.position = new Vector3(xpos, ypos, zpos);
            obj.transform.localScale = new Vector3(xscale, yscale, zscale);
            obj.transform.rotation = Quaternion.Euler(xrot, yrot, zrot);

            obj.AddComponent<Test>(); // 컴포넌트추가

        }
    }
    public static string GetResourceName(string objname) // 리소스이름
    {
        int n = objname.IndexOf('_');
        if (n == -1)
            return objname;

        string name = objname.Substring(0, n);
        return name;
    }
    void Start()
    {
        nav.destination = transform.position; // 마우스픽킹
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 픽킹
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                nav.destination = hitInfo.point;
            }
        }

        if (Input.GetMouseButtonDown(1)) // 넉백
        {
            nav.Move(-transform.forward); 
        }
    }
}
