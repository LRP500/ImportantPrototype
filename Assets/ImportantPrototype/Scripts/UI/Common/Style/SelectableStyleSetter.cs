﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ImportantPrototype.UI.Common.Style
{
    public abstract class SelectableStyleSetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Image _targetGraphic;

        [SerializeField]
        private Color _normal;
        
        [SerializeField]
        private Color _hovered;

        [SerializeField]
        private Color _selected;
        
        protected virtual void Awake()
        {
            SetNormal();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            SetHovered();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Refresh();
        }

        protected virtual void Refresh()
        {
            SetNormal();
        }
        
        protected void SetSelected()
        {
            SetTargetColor(_selected);
        }

        protected void SetHovered()
        {
            SetTargetColor(_hovered);
        }

        protected void SetNormal()
        {
            SetTargetColor(_normal);
        }
        
        private void SetTargetColor(Color color)
        {
            _targetGraphic.color = color;
        }
    }
}