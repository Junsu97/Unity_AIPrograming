using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour,IPointerDownHandler , IPointerUpHandler ,
    IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Image back;
    public Image stick;
    float radius = 0f;
    Vector3 dir = Vector3.zero;
    Vector3 centerPos = Vector3.zero;

    public Vector3 DIR
    {
        get
        {
            Vector3 dir3D = Vector3.zero;
            dir3D.Set(dir.normalized.x, 0, dir.normalized.y);
            return dir3D;
        }
    }
    
    void Start()
    {
        centerPos = back.transform.position;
        radius = back.rectTransform.sizeDelta.x * 0.5f; //반지름
    }

    public void OnPointerDown(PointerEventData eventData) // 클릭할때
    {
        stick.transform.position = eventData.position;
    }

    // 드래그 시작시 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        stick.transform.position = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // 드래그한 거리를 계산( 중앙점으로 부터 )
        float Distance = Vector2.Distance(eventData.position, centerPos);
        Vector3 tmp = eventData.position;

        dir = tmp - centerPos; 
        if( Distance > radius)
        {
            stick.transform.position = centerPos + dir.normalized * radius;
        }
        else
        {
            //stick.transform.position = eventData.position;
            stick.transform.position = centerPos + dir.normalized * Distance;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        stick.transform.position = centerPos;
        dir = Vector3.zero;
    }

    public void OnPointerUp(PointerEventData eventData) // 클릭 뗄때
    {
        // 스틱을 원래 위치로 돌려놓는다.
        // 원래위치보다는 백그라운드 이미지의 중앙으로 계산.

        stick.transform.position = centerPos;
        dir = Vector3.zero;
    }
    void Update()
    {
        
    }
}
