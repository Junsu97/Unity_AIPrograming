using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // 필수
using System.IO; // 입출력
public class SaveTerrainData : EditorWindow
{
    static List<string> buildinglist = new List<string>();
    static string filename = string.Empty;
    
    //사용자 메뉴에 관련된 함수는 static이여야한다
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
        Debug.Log("Save 메뉴 선택");
        //씬에 올려놓은 Building이라는 이름의 태그 게임오브젝트를
        //검색하여 파일에 저장 (csv형식, 데이터를 쉼표로 구분)
        filename = EditorUtility.SaveFilePanel("Export BuildingInfo",
                "",//기본값
                filename,
                "csv");
        if (filename.Equals(""))
        {
            Debug.Log("파일이름이 필요합니다.");
            return;
        }
        GameObject [] objs = GameObject.FindGameObjectsWithTag("Building");

        if (objs.Length == 0)
            return;
        //StreamWriter 저장하기
        string datas = string.Empty;
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("index,name,parent,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez,resource");

            // 검색한 오브젝트의 이름과 좌표를 출력 ( 차후에는 파일에 기록 )
            for (int i =0; i< objs.Length; i++)
            {
                datas += (i + 1).ToString();
                datas += ",";               
                datas += objs[i].name;
                datas += ",";
                if (IsParent(objs[i].transform))
                    datas += "-1"; //-1은 내가 부모
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
                //좌표 뿐 아니라 회전과 스케일값도 저장해야한다.
            }
            writer.Close();
        }
        buildinglist.Clear();
    }
   
    public static string GetResourceName(string objname) // 리소스이름
    {
        int n = objname.IndexOf('_'); //IndexOf objname에서 _ 가 몇 번째 위치하는가
        if (n == -1)
            return objname;

        string name = objname.Substring(0, n );
        return name;
    }
    
    static int? GetParentObjIndex(Transform _ptr) //부모의 인덱스
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
        // 테이블에는 부모를 먼저 작성

    }

    [MenuItem("CSV/ImportBuildingCSV")]
    static void LoadBuilding()
    {
        filename = EditorUtility.OpenFilePanel("Open BuildingInfo",
                "",//기본값
                "csv");
        //StreamReader 읽어오기
        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // 첫 줄은 필요가 없으므로 미리 한 줄 읽기
            string data = string.Empty;

            while( (data = sr.ReadLine())!= null)// 줄별 로 읽은 다음 그 데이터를 처리
            {
                // 파일에서 읽은 데이터
                Debug.Log(data);
                // data에는 게임오브젝트 1개의 정보가 포함되어 있다.
                // 문자열에서 1개의 데이터 정보를  실제 값으로 변환.
                // csv는 , 쉼표로 구분되어 있기 때문에 , 단위로 데이터를 분리해준다.

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
        inputData = EditorGUILayout.TextField("입력하세요 : ",inputData);
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
            Debug.Log("Test버튼 눌림");
        }
    }
}
