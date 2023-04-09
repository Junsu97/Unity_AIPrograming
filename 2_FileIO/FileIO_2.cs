using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class FileIO_2: MonoBehaviour
{
    void Start()
    {
        // Application.dataPath : Assets ��������
        string path = Application.dataPath + "/" + "Save";
        // �����̸��� ��θ� ��������� �Ѵ�
        string filename = "Test.txt";

        // ���丮 �˻��Լ�
        if( !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        // StreamWriter�� �ٸ� pc�̿��� �ٸ� �÷������� ��밡���ϳ�
        // ��ο��� "/"��"\"�� ȥ��ż� ���ǹǷ� �����ؼ� ����ؾ� �Ѵ�.

        string data = string.Empty;
        using (StreamWriter sr = new StreamWriter(path+"/"+filename))
        {
            data += "������";
            sr.WriteLine(data);
            sr.Close();
        }
        
        // ���ڿ��� ����Ʈ�� ��ȯ
        byte [] byData = Encoding.UTF8.GetBytes(data);
        // ����Ʈ�� ���Ͽ� ����
        // �÷����� ���� ������ ���� �ʴ� ������
        File.WriteAllBytes(path+"/"+ filename,byData);

        // ����Ʈ �����͸� ���Ͽ��� �о� ���ڿ��� ��ȯ
        byte[] byRead = File.ReadAllBytes(path+"/"+filename);

        string readString = Encoding.Default.GetString(byRead);

        Debug.Log(readString);

        // ���丮 �����Լ�
        string curDir = Directory.GetCurrentDirectory(); //���� ���丮 ��������
        Debug.Log(curDir);

        // ���� �о����
        string [] files = Directory.GetFiles(curDir);
        foreach(string one in files)
        {
            Debug.Log(one);
        }
        string [] subDir = Directory.GetDirectories(curDir); 
        foreach(string one in subDir)
        {
            Debug.Log(one);//���� ���丮�� ���� ���丮
        }

        // ���� �̵��Լ�
        File.Move(path + "/" + filename, path + "/" + "Test22.txt");

        File.Delete(path + "/" + filename);
         

        
    }
    
    void Update()
    {
        
    }
}
