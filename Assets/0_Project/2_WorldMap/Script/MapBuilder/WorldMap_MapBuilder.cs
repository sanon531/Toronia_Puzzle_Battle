using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using DG.Tweening;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_MapBuilder : BlockCase
    {
        [SerializeField]
        Transform _ActionObjectPlace;
        public static WorldMap_MapBuilder Instance;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }
        Vector3 
            _startPos,
            _dragStartPos,
            _difference;


        public override bool CheckLiftable() {
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_배틀전환허용, false);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_전투정보숨기기);

            return false;
        }
        public override bool CheckPlaceable(BlockInfo blockinfo){
            return false;}

        //드래그시 업무와 관함
        #region
        [SerializeField]
        Vector3 _clampSize;
        private void OnMouseDown()
        {
            _dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
        }
        private void OnMouseUp()
        {
        }
        private void OnMouseDrag()
        {
            _difference = _dragStartPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 objPosition = new Vector3(
                Mathf.Clamp(_startPos.x -_difference.x, -_clampSize.x, _clampSize.x), 
                Mathf.Clamp(_startPos.y - _difference.y, -_clampSize.y, _clampSize.y),
               11);


            transform.position = objPosition;


        }
        #endregion


        //클릭 했을 때
        Tween _tweenMove=null;
        public void ActionObjectClicked(Vector3 _targetVector)
        {
            Vector3 _temptVector = new Vector3(-_targetVector.x, -(_targetVector.y - 1.5f), transform.position.z);
            Debug.Log(_temptVector);
            _tweenMove = transform.DOMove(_temptVector, 0.5f);
        }


    }

}
