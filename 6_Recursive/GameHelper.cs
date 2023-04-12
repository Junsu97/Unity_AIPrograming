using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class GameHelper 
{
    
     // �̸����� Ư�� ��� ã�� �Լ�
     
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
    
    // ���� ������ �ڽ������� ��� ã�Ƽ� ���
    public static void GetChildFolderName(string curDir)
    {
       // Debug.Log(curDir);
        string[] subdirs = Directory.GetDirectories(curDir);
        foreach(string subdir in subdirs)
        {
            GetChildFolderName(subdir);
        }
    }

    // �Ű������� ���� �� ���ڿ��� �ð��� �Բ� ���Ͽ� �̾ ����
    // [�ð�] ���� �� ���ڿ�
    public static void WriteLog(string data)
    {
        //string path = Application.dataPath + "/";
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/"+"Log.txt"; // �÷����� ������� ���

        //string newdata = "[" + DateTime.Now.ToString() + "]" + data;
        string newdata = "[" + DateTime.Now.Ticks.ToString() + "]" + data+"\n";// ����ð� ƽ
        newdata += "[" + DateTime.Now.ToString() + "]" + data; // ���� �ð� using System �ʿ���

        TimeSpan elapse = new TimeSpan(DateTime.Now.Ticks);// ƽ�� �ð����� ��ȯ
        
        //DateTime.Now.Hour;
        //DateTime.Now.Second;
        
        string ticktime = string.Format("{0:N0} days, {1} hours, {2} minutes,{3} seconds",
            elapse.Days, elapse.Hours, elapse.Minutes, elapse.Seconds);
        Debug.Log(ticktime);

        // ����ð����� 3�� ������ �ð��� ���Ѵ�.
        DateTime butDate = DateTime.Now.AddDays(3);// 3�� ��.
        long elapsedTime = butDate.Ticks - DateTime.Now.Ticks;
        TimeSpan remain = new TimeSpan(elapsedTime);
        Debug.Log(remain.TotalSeconds);// ���� �Ⱓ�� �� ������ ������Ʈ �Լ����� ȣ���ؼ� UI������

        using (StreamWriter sr = new StreamWriter(path,true)) //Ʈ��� �߰��Ѵ�.
        {
            sr.WriteLine(newdata);
            sr.Close();
        }
        
    }
}
