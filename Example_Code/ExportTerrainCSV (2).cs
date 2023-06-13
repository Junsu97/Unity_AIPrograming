using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class ExportTerrainCSV
{
    static Dictionary<string, int> savelist = new Dictionary<string, int>();

    [MenuItem("CustomExport/Terrain(NoParent)")]
    static public void ExportTerrain()
    {
        //1. Terrain �±׸� ���� ���ӿ�����Ʈ�� �˻�
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Terrain");

        //2. �����ΰ� �����ϴ��� �˻� / ���ٸ� ���� ����
        if (!Directory.Exists(Application.dataPath + "/Export/TerrainData/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Export/TerrainData/");
        }

        //2. csv ������ ����
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/Export/TerrainData/" + "terrain.csv"))
        {
            string lineData = string.Empty;

            sr.WriteLine("name,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");


            foreach (GameObject one in objs)
            {
                lineData += one.name;
                lineData += ",";
                lineData += one.transform.position.x;
                lineData += ",";
                lineData += one.transform.position.y;
                lineData += ",";
                lineData += one.transform.position.z;
                lineData += ",";
                lineData += one.transform.localEulerAngles.x;
                lineData += ",";
                lineData += one.transform.localEulerAngles.y;
                lineData += ",";
                lineData += one.transform.localEulerAngles.z;
                lineData += ",";
                lineData += one.transform.localScale.x;
                lineData += ",";
                lineData += one.transform.localScale.y;
                lineData += ",";
                lineData += one.transform.localScale.z;
                sr.WriteLine(lineData);
                lineData = string.Empty;
            }

            sr.Close();
        }
    }

    //static public void SearchAndSortParent(GameObject [] arr)
    //{
    //    for( int i = 0; i < arr.Length; i++ )
    //    {
    //        if( arr[i].transform.parent.gameObject.name != "TerrainObject" )
    //        {
    //            for( int j = i+1; j < arr.Length; j++ )
    //            {
    //                if( arr[j].name == arr[i].transform.parent.gameObject.name )
    //                {
    //                    GameObject tmp = arr[j];
    //                    arr[j] = arr[i];
    //                    arr[i] = tmp;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //}

    [MenuItem("CustomExport/Terrain")]
    static public void ExportTerrainHierarchy()
    {
        savelist.Clear();

        //1. Terrain �±׸� ���� ���ӿ�����Ʈ�� �˻�
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Terrain");

        //SearchAndSortParent(objs);

        //2. �����ΰ� �����ϴ��� �˻� / ���ٸ� ���� ����
        if (!Directory.Exists(Application.dataPath + "/Export/HierarchyTerrain/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Export/HierarchyTerrain/");
        }

        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/Export/HierarchyTerrain/" + "terrainH.csv"))
        {
            string lineData = string.Empty;

            for (int i = 0; i < objs.Length; i++)
            {
                lineData = (i + 1).ToString();
                lineData += ",";
                lineData += objs[i].name;
                lineData += ",";

                // �θ� ���ٸ�
                if (objs[i].transform.parent.gameObject.name == "TerrainObject")
                {
                    lineData += "-1";
                }
                else
                {
                    // �θ��ε����� ã�ƾ� �Ѵ�.
                    // �θ� ���ӿ�����Ʈ�� ���� ���´�.
                    GameObject parentObj = objs[i].transform.parent.gameObject;
                    lineData += savelist[parentObj.name].ToString();
                }

                savelist.Add(objs[i].name, (i + 1));

                sr.WriteLine(lineData);

                lineData = string.Empty;
            }


            sr.Close();
        }
    }
}
