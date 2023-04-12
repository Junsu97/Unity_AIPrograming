using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // �ʼ�
using System.IO; // �����
public class SaveTerrainData : EditorWindow
{
    static List<string> buildinglist = new List<string>();
    static string filename = string.Empty;
    
    //����� �޴��� ���õ� �Լ��� static�̿����Ѵ�
    [MenuItem("Custom/Tool")]
    static void Init()
    {
        SaveTerrainData window =
            (SaveTerrainData)EditorWindow.GetWindow(typeof(SaveTerrainData));

        window.Show();
    }

    [MenuItem("CSV/ExportBuildingCSV")]
    static void Save()
    {
        Debug.Log("Save �޴� ����");
        //���� �÷����� Building�̶�� �̸��� �±� ���ӿ�����Ʈ��
        //�˻��Ͽ� ���Ͽ� ���� (csv����, �����͸� ��ǥ�� ����)
        filename = EditorUtility.SaveFilePanel("Export BuildingInfo",
                "",//�⺻��
                filename,
                "csv");
        if (filename.Equals(""))
        {
            Debug.Log("�����̸��� �ʿ��մϴ�.");
            return;
        }
        GameObject [] objs = GameObject.FindGameObjectsWithTag("Building");

        if (objs.Length == 0)
            return;
        //StreamWriter �����ϱ�
        string datas = string.Empty;
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("index,name,parent,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez,resource");

            // �˻��� ������Ʈ�� �̸��� ��ǥ�� ��� ( ���Ŀ��� ���Ͽ� ��� )
            for (int i =0; i< objs.Length; i++)
            {
                datas += (i + 1).ToString();
                datas += ",";               
                datas += objs[i].name;
                datas += ",";
                if (IsParent(objs[i].transform))
                    datas += "-1"; //-1�� ���� �θ�
                else
                {
                    int? usindex = GetParentObjIndex(objs[i].transform);
                    if(usindex.HasValue)
                    {
                        datas += usindex.Value.ToString();
                    }
                }
                datas += ",";
                datas += objs[i].transform.position.x;
                datas += ",";
                datas += objs[i].transform.position.y;
                datas += ",";
                datas += objs[i].transform.position.z;
                datas += ",";
                datas += objs[i].transform.rotation.x;
                datas += ",";
                datas += objs[i].transform.rotation.y;
                datas += ",";
                datas += objs[i].transform.rotation.z;
                datas += ",";
                datas += objs[i].transform.localScale.x;
                datas += ",";
                datas += objs[i].transform.localScale.y;
                datas += ",";
                datas += objs[i].transform.localScale.z;
                datas += ",";
                datas += GetResourceName(objs[i].name);

                writer.WriteLine(datas);

                buildinglist.Add(datas);

                datas = string.Empty;
                //��ǥ �� �ƴ϶� ȸ���� �����ϰ��� �����ؾ��Ѵ�.
            }
            writer.Close();
        }
        buildinglist.Clear();
    }
   
    public static string GetResourceName(string objname) // ���ҽ��̸�
    {
        int n = objname.IndexOf('_'); //IndexOf objname���� _ �� �� ��° ��ġ�ϴ°�
        if (n == -1)
            return objname;

        string name = objname.Substring(0, n );
        return name;
    }
    
    static int? GetParentObjIndex(Transform _ptr) //�θ��� �ε���
    {
        GameObject obj = _ptr.parent.gameObject;
        
        foreach(string one in buildinglist)
        {
            string[] lineData = one.Split(',');

            ushort index = ushort.Parse(lineData[0]);
            string name = lineData[1];
            int parentindex = int.Parse(lineData[2]);
            float xpos = float.Parse(lineData[3]);
            float ypos = float.Parse(lineData[4]);
            float zpos = float.Parse(lineData[5]);

            if (obj.name == name&&
                Mathf.Approximately(xpos, obj.transform.position.x)&&
                Mathf.Approximately(ypos,obj.transform.position.y)&&
                Mathf.Approximately(zpos,obj.transform.position.z))
                return index;
        }
        return null;
    }
    static bool IsParent(Transform ptr)
    {
        if (ptr.gameObject.name == "Building")
            return true;

        return false;
    }
    
    public static void GetChildTransform(Transform tr)
    {
        if (tr.childCount != 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform chtr = tr.GetChild(i);
                GetChildTransform(chtr);
                //Debug.Log(chtr.gameObject.name);
            }
        }
        // ���̺��� �θ� ���� �ۼ�

    }

    [MenuItem("CSV/ImportBuildingCSV")]
    static void LoadBuilding()
    {
        filename = EditorUtility.OpenFilePanel("Open BuildingInfo",
                "",//�⺻��
                "csv");
        //StreamReader �о����
        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // ù ���� �ʿ䰡 �����Ƿ� �̸� �� �� �б�
            string data = string.Empty;

            while( (data = sr.ReadLine())!= null)// �ٺ� �� ���� ���� �� �����͸� ó��
            {
                // ���Ͽ��� ���� ������
                Debug.Log(data);
                // data���� ���ӿ�����Ʈ 1���� ������ ���ԵǾ� �ִ�.
                // ���ڿ����� 1���� ������ ������  ���� ������ ��ȯ.
                // csv�� , ��ǥ�� ���еǾ� �ֱ� ������ , ������ �����͸� �и����ش�.

                string [] lineData = data.Split(',');

                ushort index = ushort.Parse(lineData[0]);
                string name = lineData[1];
                int parentIndex =int.Parse( lineData[2]);
                float xpos = float.Parse(lineData[3]);
                float ypos = float.Parse(lineData[4]);
                float zpos = float.Parse(lineData[5]);

                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(xpos, ypos, zpos);
            }
        }
    }
    static string inputData = string.Empty;
    private int index = 0;
    private string[] option = new string[] { "Single", "Open Field", "Dungeon" };
    private void OnGUI()
    {
        GUILayout.Label("Fill out filename and press save button");
        inputData = EditorGUILayout.TextField("�Է��ϼ��� : ",inputData);
        index = EditorGUILayout.Popup(index, option);
        Debug.Log(index);


        GUILayoutOption[] op = new GUILayoutOption[2];
        op[0] = GUILayout.Height(30);
        op[1] = GUILayout.Width(400);

        Color col = EditorGUILayout.ColorField(new Color(1, 1, 1), op);
        GUILayoutOption[] opbutton = new GUILayoutOption[2];
        opbutton[0] = GUILayout.Height(30);
        opbutton[1] = GUILayout.Width(150);
        if ( GUILayout.Button("Test", opbutton))
        {
            Debug.Log("Test��ư ����");
        }
    }
}
