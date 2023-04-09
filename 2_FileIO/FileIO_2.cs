using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class FileIO_2: MonoBehaviour
{
    void Start()
    {
        // Application.dataPath : Assets 폴더까지
        string path = Application.dataPath + "/" + "Save";
        // 파일이름과 경로를 구분지어야 한다
        string filename = "Test.txt";

        // 디렉토리 검사함수
        if( !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        // StreamWriter는 다른 pc이외의 다른 플랫폼에서 사용가능하나
        // 경로에서 "/"와"\"이 혼용돼서 사용되므로 변경해서 사용해야 한다.

        string data = string.Empty;
        using (StreamWriter sr = new StreamWriter(path+"/"+filename))
        {
            data += "가나다";
            sr.WriteLine(data);
            sr.Close();
        }
        
        // 문자열을 바이트로 변환
        byte [] byData = Encoding.UTF8.GetBytes(data);
        // 바이트를 파일에 저장
        // 플랫폼에 따른 영향을 받지 않는 저장방법
        File.WriteAllBytes(path+"/"+ filename,byData);

        // 바이트 데이터를 파일에서 읽어 문자열로 변환
        byte[] byRead = File.ReadAllBytes(path+"/"+filename);

        string readString = Encoding.Default.GetString(byRead);

        Debug.Log(readString);

        // 디렉토리 관련함수
        string curDir = Directory.GetCurrentDirectory(); //현재 디렉토리 가져오기
        Debug.Log(curDir);

        // 파일 읽어오기
        string [] files = Directory.GetFiles(curDir);
        foreach(string one in files)
        {
            Debug.Log(one);
        }
        string [] subDir = Directory.GetDirectories(curDir); 
        foreach(string one in subDir)
        {
            Debug.Log(one);//현재 디렉토리의 하위 디렉토리
        }

        // 파일 이동함수
        File.Move(path + "/" + filename, path + "/" + "Test22.txt");

        File.Delete(path + "/" + filename);
         

        
    }
    
    void Update()
    {
        
    }
}
