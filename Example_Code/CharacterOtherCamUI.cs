using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CharacterOtherCamUI : MonoBehaviour
{
    // 다른 카메라가 랜더링하는 hp게이지
    public Image hp;
    public Camera UICamera;

    Vector3 vEnd = Vector3.zero;
    float speed = 10f;

    void Start()
    {
        vEnd = transform.position;
        UpdateUI();
        
    }
    
    void UpdateUI()
    {
        float xMoveDelta = UICamera.transform.position.x - Camera.main.transform.position.x;
        Vector3 tmpCharPos = transform.position + new Vector3(xMoveDelta, 0, 0);

        Vector2 UIPos =
            UICamera.WorldToScreenPoint(tmpCharPos);

        UIPos.x -= Screen.width / 2;
        UIPos.y -= Screen.height / 2;
        hp.transform.localPosition = UIPos;
    }


    bool IsPointerOverUIObject()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return true;
                }
            }
        }
        else    // pc
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            if (IsPointerOverUIObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                vEnd = hitInfo.point;
            }
        }

        transform.position =
            Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime * speed);
    }


    /*
     *         if (Input.GetMouseButtonDown(0))
        {
            if (Application.platform == RuntimePlatform.Android ||
                 Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        return;
                    }
                }
            }
            else    // pc
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Clicked on the UI");
                    return;
                }
            }
        }

         */
    private void LateUpdate()
    {
        UpdateUI();
    }
}
