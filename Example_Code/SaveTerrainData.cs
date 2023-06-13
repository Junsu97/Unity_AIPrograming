using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveTerrainData_
{
    static List<string> buildinglist = new List<string>();

    [MenuItem("Custom/Save")]
    static void Save()
    {
        Debug.Log("Save 메뉴 선택");
        // 씬에 올려놓은 Building이라는 이름의 태그의 게임오브젝트를
        // 검색하여 파일에 저장 ( csv 형식, 데이터를 쉼표로 구분 )

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
        
        string datas = string.Empty;
        using (StreamWriter writer = new StreamWriter("Building.csv"))
        {
            writer.WriteLine("index,name,parent,posx,posy,posz,resource");

            // 검색한 오브젝트의 이름과 좌표를 출력 ( 차후에는 파일에 기록 )
            for (int i = 0; i < objs.Length; i++)
            {
                datas = (i + 1).ToString();
                datas += ",";
                datas += objs[i].name;
                datas += ",";
                //
                if (IsParent(objs[i].transform))
                    datas += "-1";
                else
                {
                    int? usindex = GetParentObjectIndex(objs[i].transform);
                    if (usindex.HasValue)
                    {
                        datas += usindex.Value.ToString();
                    }
                }

                datas += ",";
                //
                datas += objs[i].transform.position.x;
                datas += ",";
                datas += objs[i].transform.position.y;
                datas += ",";
                datas += objs[i].transform.position.z;
                datas += ",";
                datas += GetResourceName(objs[i].name);

                writer.WriteLine(datas);
                
                buildinglist.Add(datas);
                datas = string.Empty;
            }
            writer.Close();
        }
    }

    public static string GetResourceName(string objname)
    {
        int n = objname.IndexOf('_');
        if (n == -1)
            return objname;

        string name = objname.Substring(0, n);
        return name;
    }

    static bool IsParent(Transform _tr)
    {
        if (_tr.parent.gameObject.name == "Building")
            return true;

        return false;
    }

    static int? GetParentObjectIndex(Transform _tr)
    {
        GameObject obj = _tr.parent.gameObject;

        foreach( string one in buildinglist )
        {
            string[] lineData = one.Split(',');

            ushort index = ushort.Parse(lineData[0]);
            string name = lineData[1];
            int parentindex = int.Parse(lineData[2]);
            float xpos = float.Parse(lineData[3]);
            float ypos = float.Parse(lineData[4]);
            float zpos = float.Parse(lineData[5]);

            if (obj.name == name ) 
                //xpos == obj.transform.position.x && 
                //ypos == obj.transform.position.y && 
                //zpos == obj.transform.position.z )
                return index;
        }

        return null;

    }


    static void GetChildTransform(Transform tr)
    {
        if (tr.childCount != 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform chtr = tr.GetChild(i);
                Debug.Log(chtr.gameObject.name);
                GetChildTransform(chtr);
            }
        }
    }

    [MenuItem("Custom/LoadBuilding")]
    static void LoadBuilding()
    {

        using (StreamReader sr = new StreamReader("Building.csv"))
        {
            sr.ReadLine();
            string data = string.Empty;

            while( (data = sr.ReadLine()) != null )
            {
                // 파일에서읽은 데이터 
                Debug.Log(data);
                // data에는 게임오브젝트 1개의 정보가 포함되어 있다.
                // 문자열에서 1개의 데이터 정보를 실제 값으로 변환
                // csv는 ,쉼표로 구분되어 있기 때문에 ,단위로 데이터를 분리해준다.
                string [] lineData = data.Split(',');

                ushort index = ushort.Parse(lineData[0]);
                string name = lineData[1];
                float xpos = float.Parse(lineData[2]);
                float ypos = float.Parse(lineData[3]);
                float zpos = float.Parse(lineData[4]);

                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(xpos, ypos, zpos);
            }
        }
    }
}
