using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaInfo
{
    public int data;
}

//[�ǽ�3]
// DataInfo �ν��Ͻ� 3���� �����ϰ� (�迭) �ɹ����� a�� ������ ���� 3���� �����Ͻÿ�
// a�� ������ ������ ���-1�̴�.
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
        // �ڽ��� ��ġ���� 10,10,10���� ���ϴ� ���⺤�͸� ���ϴ� �ڵ带 �ۼ��ϼ���
        vStart = transform.position;
        vEnd.Set(10, 10, 10);
        Dir = vEnd - vStart;
        Debug.Log("���⺤�� = " + Dir.normalized);
        Debug.Log("���⺤���� ũ�� = " + Dir.normalized.magnitude);

        //////////////////////////////////////
        // ChaInfo�ν��Ͻ� 3���� �����ϰ� (�迭) ��� ������ -100���� �ʱ�ȭ �Ͻʽÿ�.

        // �迭�� ����Ÿ���̹Ƿ� new�� �޸� �Ҵ�
        ChaInfo[] arr = new ChaInfo[3];

        // �迭�� ����� �����ʹ� ChaInfo�ε� ChaInfo�� Ŭ���� Ÿ��(����)�̹Ƿ�
        // ���� �ٷ� ������ �� ���� new�� �޸� �Ҵ��ؼ� ����Ѵ�.
        arr[0] = new ChaInfo();
        arr[0].data = -1;
        arr[1] = new ChaInfo();
        arr[1].data = -1;
        arr[2] = new ChaInfo();
        arr[2].data = -1;


 
        int[] a = new int[3];
        // �迭�� ����� �����ʹ� ��Ÿ��(int)�̹Ƿ� ���� �ٷδ���
        a[0] = -100;

        //*****************************************************************
        //[�ǽ�3]
        // DataInfo �ν��Ͻ� 3���� �����ϰ� (�迭) �ɹ����� a�� ������ ���� 3���� �����Ͻÿ�
        // a�� ������ ������ ���-1�̴�.
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

        // ���� ������ �ݺ������� ǥ���ϸ�?
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
