using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


    public class ButtonUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent OnEnter;
        public UnityEvent OnExit;
    public UnityEvent OnUpdate;
    public bool isClick = false;
    private void Update()
    {
        if (isClick == true)
        {
            if (OnUpdate != null) OnUpdate.Invoke();
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
        {
        if (OnEnter != null) OnEnter.Invoke();
        isClick = true;
        print("Нажатие");
    }


    public void OnPointerUp(PointerEventData eventData)
        {
        if (OnExit != null) OnExit.Invoke();
        isClick = false;
        //isClick = false;
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    isClick = true;
    //}
}
