using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assignment.UI
{
    public class UITapAction : MonoBehaviour, IPointerDownHandler
    {
        public Action OnTapAction;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTapAction?.Invoke();
        }
    }
}