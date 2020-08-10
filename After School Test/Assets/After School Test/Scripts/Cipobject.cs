using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cipobject : MonoBehaviour/*, IPointerDownHandler*/
{
    //private void OnMouseDown()
    //{
    //    Debug.Log("오브젝트를 눌렀습니다.");
    //}
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("오브젝트를 눌렀습니다.");
    //}

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Debug.Log("오브젝트를 눌렀습니다.");
    }
}

