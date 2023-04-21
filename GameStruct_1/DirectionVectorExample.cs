using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaInfo
{
    public int data;
}

//[실습3]
// DataInfo 인스턴스 3개를 생성하고 (배열) 맴버변수 a에 정수형 변수 3개를 저장하시오
// a에 저장할 변수는 모두-1이다.
public class DataInfo
{
    public int[] a;
}
public class DirectionVectorExample : MonoBehaviour
{
    Vector3 vStart = Vector3.zero;
    Vector3 vEnd = Vector3.zero;
    Vector3 Dir = Vector3.zero;
    void Start()
    {
        // 자신의 위치에서 10,10,10으로 향하는 방향벡터를 구하는 코드를 작성하세요
        vStart = transform.position;
        vEnd.Set(10, 10, 10);
        Dir = vEnd - vStart;
        Debug.Log("방향벡터 = " + Dir.normalized);
        Debug.Log("방향벡터의 크기 = " + Dir.normalized.magnitude);

        //////////////////////////////////////
        // ChaInfo인스턴스 3개를 생성하고 (배열) 멤버 변수를 -100으로 초기화 하십시오.

        // 배열은 참조타입이므로 new로 메모리 할당
        ChaInfo[] arr = new ChaInfo[3];

        // 배열에 저장된 데이터는 ChaInfo인데 ChaInfo는 클래스 타입(참조)이므로
        // 값을 바로 대입할 수 없고 new로 메모리 할당해서 사용한다.
        arr[0] = new ChaInfo();
        arr[0].data = -1;
        arr[1] = new ChaInfo();
        arr[1].data = -1;
        arr[2] = new ChaInfo();
        arr[2].data = -1;


 
        int[] a = new int[3];
        // 배열에 저장된 데이터는 값타입(int)이므로 값을 바로대입
        a[0] = -100;

        //*****************************************************************
        //[실습3]
        // DataInfo 인스턴스 3개를 생성하고 (배열) 맴버변수 a에 정수형 변수 3개를 저장하시오
        // a에 저장할 변수는 모두-1이다.
        DataInfo[] arrD = new DataInfo[3];

        arrD[0] = new DataInfo();
        arrD[0].a = new int[3];
        arrD[0].a[0] = -1;
        arrD[0].a[1] = -1;
        arrD[0].a[2] = -1;

        arrD[1] = new DataInfo();
        arrD[1].a = new int[3];
        arrD[1].a[0] = -1;
        arrD[1].a[1] = -1;
        arrD[1].a[2] = -1;

        arrD[2] = new DataInfo();
        arrD[2].a = new int[3];
        arrD[2].a[0] = -1;
        arrD[2].a[1] = -1;
        arrD[2].a[2] = -1;

        // 위의 문제를 반복문으로 표현하면?
        for(int i =0; i<arrD.Length; i++)
        {
            arrD[i] = new DataInfo();
            arrD[i].a = new int[3];
            arrD[i].a[0] = -1;
            arrD[i].a[1] = -1;
            arrD[i].a[2] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
