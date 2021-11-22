using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_MapBuilder : MonoBehaviour
    {
        [SerializeField]
        Transform _ActionObjectPlace;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        Vector3 
            _startPos,
            _dragStartPos,
            _difference;

        [SerializeField]
        Vector3 _clampSize;
        private void OnMouseDown()
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_배틀전환허용, false);


            _dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
        }

        private void OnMouseUp(){ }


        private void OnMouseDrag()
        {
            _difference = _dragStartPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 objPosition = new Vector3(
                Mathf.Clamp(_startPos.x +_difference.x, -_clampSize.x, _clampSize.x), 
                Mathf.Clamp(_startPos.y+ _difference.y, -_clampSize.y, _clampSize.y),
               11);


            transform.position = objPosition;


        }

    }

}
