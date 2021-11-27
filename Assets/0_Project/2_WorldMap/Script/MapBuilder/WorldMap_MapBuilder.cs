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


        // �� �� ���۵Ǹ� ����� ������ �ִ��� ����� ������ ������ �����صΰ� �Ѵ�.
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
            //��� �ʱ�ȭ
            WorldMapGenClass.Set_mapNodeListsConnected();
            int _total_Node = 10;
            int _thirdNodeCounts = 1;
            int _firstLeastNodeCounts = 3;
            Dictionary<int, WorldMap_ActionObject> _placedNodeList = new Dictionary<int, WorldMap_ActionObject>();
            List<int> _targePlaceList = new List<int>();

            //�����
            GameObject _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[0], Quaternion.identity, _ActionObjectPlace);
            WorldMap_ActionObject _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>();
            _targePlaceList.Add(0);
            //������ �׳� ������ ���
            for (int i = 1; i< 10; i++)
            {
                _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[i], Quaternion.identity, _ActionObjectPlace);
                _tempt.name = i.ToString();
                _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>(); 
                _temptActionObjScript.BeginActionObject();
                _targePlaceList.Add(i);
            }
            //ó�� �ּ� ���� ��ġ�ϱ�

            
            //�ּ� ����� �ϳ��� ��� �װ͵��� ������� ����� �Ѵ�,
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

        //�巡��,Ŭ���� ������ ����
        #region
        [SerializeField]
        Vector3 _clampSize;
        private void OnMouseDown()
        {
            _dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, false);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮�����);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǽ����);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ���������);


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
        //Ŭ�� ���� ��
        Tween _tweenMove = null;
        public void ActionObjectClicked(Vector3 _targetVector)
        {
            Vector3 _temptVector = new Vector3(-_targetVector.x, -(_targetVector.y - 1.75f), transform.position.z);
            _tweenMove = transform.DOMove(_temptVector, 0.5f);
        }

        #endregion




    }

}
