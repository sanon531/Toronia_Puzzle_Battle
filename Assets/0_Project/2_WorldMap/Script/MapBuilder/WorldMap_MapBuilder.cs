using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using ToronPuzzle.Data;
using DG.Tweening;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_MapBuilder : MonoBehaviour
    {
        [SerializeField]
        Transform _ActionObjectPlace;
        public static WorldMap_MapBuilder Instance;
        WorldMap_LineSetter _lineSetter;


        // 맵 이 시작되면 저장된 정보가 있는지 저장된 정보가 없는지 저장해두고 한다.
        public void BeginMapBulider()
        {
            Instance = this;
            _lineSetter = GameObject.Find("WorldMap_LineSetter").GetComponent<WorldMap_LineSetter>();
            _lineSetter.BeginLineSetter();
            GenerateWorldMap();

        }


        GameObject _ActionObject;
        void GenerateWorldMap()
        {
            _ActionObject = Resources.Load("WorldMap/WorldMap_ActionObject") as GameObject;
            //노드 초기화
            WorldMapGenClass.Set_mapNodeListsConnected();
            int _total_Node = 10;
            int _thirdNodeCounts = 1;
            int _firstLeastNodeCounts = 3;
            Dictionary<int, WorldMap_ActionObject> _placedNodeList = new Dictionary<int, WorldMap_ActionObject>();
            List<int> _targePlaceList = new List<int>();

            //실험용
            GameObject _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[0], Quaternion.identity, _ActionObjectPlace);
            WorldMap_ActionObject _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>();
            _targePlaceList.Add(0);
            //지금은 그냥 정해진 대로
            for (int i = 1; i< 10; i++)
            {
                _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[i], Quaternion.identity, _ActionObjectPlace);
                _tempt.name = i.ToString();
                _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>(); 
                _temptActionObjScript.BeginActionObject();
                _targePlaceList.Add(i);
            }
            //처음 최소 노드들 설치하기

            
            //최소 노드중 하나를 잡고 그것들을 기반으로 계산을 한다,
            _lineSetter.PlaceLineByIntList(_targePlaceList);

        }




        // Update is called once per frame
        void Update()
        {

        }
        Vector3 
            _startPos,
            _dragStartPos,
            _difference;

        //드래그,클릭시 업무와 관함
        #region
        [SerializeField]
        Vector3 _clampSize;
        private void OnMouseDown()
        {
            _dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, false);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보숨기기);


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
        //클릭 했을 때
        Tween _tweenMove = null;
        public void ActionObjectClicked(Vector3 _targetVector)
        {
            Vector3 _temptVector = new Vector3(-_targetVector.x, -(_targetVector.y - 1.75f), transform.position.z);
            _tweenMove = transform.DOMove(_temptVector, 0.5f);
        }

        #endregion




    }

}
