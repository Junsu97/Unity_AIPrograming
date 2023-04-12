using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class GameHelper 
{
    
     // 이름으로 특정 노느 찾는 함수
     
    public static Transform FindWeapon(Transform tr, string findname)
    {
        if (tr.name == findname)
            return tr;

        for(int i =0; i<tr.childCount; i++)
        {
            Transform bone = FindWeapon(tr.GetChild(i), findname);
            if (bone != null)
            {
                return bone;
            }
        }
        return null;
    }
    
    // 현재 폴더의 자식폴더를 모두 찾아서 출력
    public static void GetChildFolderName(string curDir)
    {
       // Debug.Log(curDir);
        string[] subdirs = Directory.GetDirectories(curDir);
        foreach(string subdir in subdirs)
        {
            GetChildFolderName(subdir);
        }
    }

    // 매개변수로 전달 된 문자열을 시간과 함께 파일에 이어서 저장
    // [시간] 전달 된 문자열
    public static void WriteLog(string data)
    {
        //string path = Application.dataPath + "/";
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/"+"Log.txt"; // 플랫폼에 상관없는 경로

        //string newdata = "[" + DateTime.Now.ToString() + "]" + data;
        string newdata = "[" + DateTime.Now.Ticks.ToString() + "]" + data+"\n";// 현재시간 틱
        newdata += "[" + DateTime.Now.ToString() + "]" + data; // 현재 시간 using System 필요함

        TimeSpan elapse = new TimeSpan(DateTime.Now.Ticks);// 틱을 시간으로 변환
        
        //DateTime.Now.Hour;
        //DateTime.Now.Second;
        
        string ticktime = string.Format("{0:N0} days, {1} hours, {2} minutes,{3} seconds",
            elapse.Days, elapse.Hours, elapse.Minutes, elapse.Seconds);
        Debug.Log(ticktime);

        // 현재시간에서 3일 이후의 시간을 구한다.
        DateTime butDate = DateTime.Now.AddDays(3);// 3일 뒤.
        long elapsedTime = butDate.Ticks - DateTime.Now.Ticks;
        TimeSpan remain = new TimeSpan(elapsedTime);
        Debug.Log(remain.TotalSeconds);// 남은 기간을 초 단위로 업데이트 함수에서 호출해서 UI에적용

        using (StreamWriter sr = new StreamWriter(path,true)) //트루면 추가한다.
        {
            sr.WriteLine(newdata);
            sr.Close();
        }
        
    }
}
