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
        Debug.Log("Save �޴� ����");
        // ���� �÷����� Building�̶�� �̸��� �±��� ���ӿ�����Ʈ��
        // �˻��Ͽ� ���Ͽ� ���� ( csv ����, �����͸� ��ǥ�� ���� )

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
        
        string datas = string.Empty;
        using (StreamWriter writer = new StreamWriter("Building.csv"))
        {
            writer.WriteLine("index,name,parent,posx,posy,posz,resource");

            // �˻��� ������Ʈ�� �̸��� ��ǥ�� ��� ( ���Ŀ��� ���Ͽ� ��� )
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
                // ���Ͽ������� ������ 
                Debug.Log(data);
                // data���� ���ӿ�����Ʈ 1���� ������ ���ԵǾ� �ִ�.
                // ���ڿ����� 1���� ������ ������ ���� ������ ��ȯ
                // csv�� ,��ǥ�� ���еǾ� �ֱ� ������ ,������ �����͸� �и����ش�.
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
