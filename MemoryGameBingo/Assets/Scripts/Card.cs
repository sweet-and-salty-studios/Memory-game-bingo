using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Sweet_And_Salty_Studios
{
    public class Card : MonoBehaviour, 
        IPointerEnterHandler,
        IPointerDownHandler,
        IPointerExitHandler,
        IPointerUpHandler
    {
        #region VARIABLES

        public Color FoundedColor;

        private Image cardImage;
        private bool initialized;
        private bool isTurned;
        private bool interactable;

        private Vector2 defaultScale;
        private Vector2 selectedScale;

        #endregion VARIABLES

        #region PROPERTIES

        public Sprite FrontSide
        {
            get;
            private set;
        }

        public Sprite BackSide
        {
            get;
            private set;
        }
        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            cardImage = GetComponentInChildren<Image>();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void Initialize(Sprite frontSide, Sprite backSide, bool isTurned = false)
        {
            if(initialized)
            {
                return;
            }

            this.isTurned = isTurned;

            FrontSide = frontSide;
            BackSide = backSide;

            cardImage.sprite = isTurned ? frontSide : backSide;

            gameObject.name = $"{frontSide.name}";

            defaultScale = transform.localScale;
            selectedScale = defaultScale + new Vector2(0.1f, 0.1f);

            interactable = true;
            initialized = true;
        }

        public void SetFoundedColor()
        {
            cardImage.color = FoundedColor;
        }

        public void Flip()
        {
            isTurned = !isTurned;
            cardImage.sprite = isTurned ? FrontSide : BackSide;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(interactable == false)
            {
                return;
            }

            //Debug.Log($"{gameObject.name} :: OnPointerEnter");
            transform.localScale = selectedScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(interactable == false)
            {
                return;
            }

            //Debug.Log($"{gameObject.name} :: OnPointerDown");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(interactable == false)
            {
                return;
            }

            //Debug.Log($"{gameObject.name} :: OnPointerExit");
            transform.localScale = defaultScale;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(interactable == false)
            {
                return;
            }

            //Debug.Log($"{gameObject.name} :: OnPointerUp");
            GameManager.Instance.CheckCardMatch(this);
        }

        public void SetInteractable(bool isActive)
        {
            interactable = isActive;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
