using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{
    public class Battle_DragDropManager : MonoBehaviour
    {
        // Update is called once per frame
        public static Battle_DragDropManager instance;
        bool _isPressed;
        [SerializeField]
        Camera _inputCamera;
        [SerializeField]
        GameObject _mousePointer;


        public void BeginDragDrap()
        {
            if (_inputCamera == null)
                _inputCamera = Camera.main;
            if (_mousePointer == null)
                _mousePointer = GameObject.Find("MousePointer") as GameObject;
        }


        void Update()
        {
            SetMousePointerPos();

            if (Input.GetMouseButtonDown(0))
                OnClicked();

            if (_isPressed)
            {
                HoveringOnClick();
            }
        }
        void SetMousePointerPos()
        {
            Vector2 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            _mousePointer.transform.position = _mouseWorldPos;

        }
        void OnClicked()
        {
            Debug.Log(_mousePointer.transform);

        }


        void HoveringOnClick()
        {


        }

    }

}
