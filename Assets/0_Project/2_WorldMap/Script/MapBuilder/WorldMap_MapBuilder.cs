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
        bool _generateNew = true;
        [SerializeField]
        Transform _ActionObjectPlace;
        public static WorldMap_MapBuilder Instance;
        WorldMap_LineSetter _lineSetter;

        GameObject _ActionObject;
        public int _currentSelectedID = 0;
        Dictionary<int, WorldMap_ActionObject> _placedNodeDic = new Dictionary<int, WorldMap_ActionObject>();


        // 맵 이 시작되면 저장된 정보가 있는지 저장된 정보가 없는지 저장해두고 한다.
        public void BeginMapBulider()
        {
            Instance = this;
            _lineSetter = GameObject.Find("WorldMap_LineSetter").GetComponent<WorldMap_LineSetter>();
            _ActionObject = Resources.Load("WorldMap/WorldMap_ActionObject") as GameObject;
            _lineSetter.BeginLineSetter();
            _placedNodeDic.Clear();
            if (_generateNew)
                GenerateWorldMapWithNew();
            else
                GenerateWorldMapWithSavefile();
        }

        [SerializeField]
        List<int> _targetPlace_numList = new List<int>();



        [SerializeField]
        int _total_Node = 10;
        [SerializeField]
        int _thirdNodeCounts = 1;
        [SerializeField]
        int _firstLeastNodeCounts = 3;
        [SerializeField]
        List<ActionObjectKind> actionObjectKindList = new List<ActionObjectKind>();

        // 생성및, 세이브 부분
        void GenerateWorldMapWithNew()
        {
            //노드 초기화
            WorldMapGenClass.Set_mapNodeListsConnected();
            var random = new System.Random();

            SetActionObjectKindList();
            //처음의 배치는 그냥 그대로 함.
            SetActionObjectByInt(0);
            //실험용


            //만약 주어진 세이브 정보가 있을 경우 관련해서

            //지금은 그냥 정해진 대로 배치해 봄
            //처음 최소 노드들 설치하기
            Queue<int> _node_queue = new Queue<int>();
            List<int> _selectedList = new List<int>() { 3, 6, 2, 4, 1, 5 };
            for (int i = 0; i < _firstLeastNodeCounts; i++)
            {
                int j = random.Next(0, _selectedList.Count - 1);
                SetActionObjectByInt(_selectedList[j]);
                _node_queue.Enqueue(_selectedList[j]);
                _selectedList.RemoveAt(j);
            }

            List<WorldMapNode> _secondnodeList = new List<WorldMapNode>();
            //최종점까지 배치 할꺼 체크
            while (_thirdNodeCounts != 0)
            {
                int i = _node_queue.Dequeue();
                _secondnodeList = WorldMapGenClass._mapNodeLists[i].GetHigerConnectedNode();

                int j = random.Next(0, _secondnodeList.Count - 1);
                while (!SetActionObjectByInt(_secondnodeList[j].GetNodeID()))
                {
                    if (_secondnodeList.Count != 0)
                    {
                        _secondnodeList.RemoveAt(j);
                        j = random.Next(0, _secondnodeList.Count - 1);
                    }
                    else
                        break;
                }
                SetActionObjectByInt(_secondnodeList[j].GetNodeID());
                //Debug.Log(_secondnodeList[j].GetNodeID());

                List<WorldMapNode> _thirdNodeList = WorldMapGenClass._mapNodeLists[_secondnodeList[j].GetNodeID()].GetHigerConnectedNode();
                int k = random.Next(0, _thirdNodeList.Count - 1);

                while (!SetActionObjectByInt(_thirdNodeList[k].GetNodeID()))
                {
                    if (_thirdNodeList.Count != 0)
                    {
                        _thirdNodeList.RemoveAt(k);
                        k = random.Next(0, _thirdNodeList.Count - 1);
                    }
                    else
                        break;
                }

                _thirdNodeCounts--;
            }

            //foreach (int i in _node_queue)
                //Debug.Log(i);


            //최종 점 배치 이후에 떨이값으로 배치되는 오브젝트
            _secondnodeList.Clear();
            while (_node_queue.Count != 0)
            {
                int n_i = _node_queue.Dequeue();
                foreach (WorldMapNode _Node in WorldMapGenClass._mapNodeLists[n_i].GetHigerConnectedNode())
                    if (!_secondnodeList.Contains(_Node))
                        _secondnodeList.Add(_Node);
            }
            List<WorldMapNode> _temptSaveList = new List<WorldMapNode>();
            //상위 노드 근처 노드를 1회 추가로 가져간다.
            foreach (WorldMapNode _Node in _secondnodeList)
            {
                foreach (WorldMapNode _NearNodes in _Node.GetNearConnectedNode())
                    _temptSaveList.Add(_NearNodes);
            }
            foreach (WorldMapNode _NearNodes in _temptSaveList)
            {
                if (!_secondnodeList.Contains(_NearNodes))
                    _secondnodeList.Add(_NearNodes);
            }
            //foreach (WorldMapNode _Node in _secondnodeList)
                //Debug.Log("Second nodes" + _Node.GetNodeID() + "," + _Node.GetNodeLevel());



            while (_total_Node > 0&& _secondnodeList.Count > 0)
            {
                int j = _secondnodeList[0].GetNodeID();
                _secondnodeList.RemoveAt(0);
                SetActionObjectByInt(j);

            }

            //기존의 1차 노드들에서 상위 노드들을 입수한다 + 해당 상위 노드들을의 근처 노드도 넣는다. 
            //. 만약 해당 노드들의 상위노드가 더는 존재 


            #region
            /*
            while (_total_Node >0 )
            {
                int j =n_i;
                Debug.Log("Second count : " + _secondnodeList.Count);
                if (_secondnodeList.Count > 0)
                    j = random.Next(0, _secondnodeList.Count - 1);

                while (_secondnodeList.Count == 0)
                {
                    n_i = _node_queue.Dequeue();
                    _secondnodeList = WorldMapGenClass._mapNodeLists[n_i].GetHigerConnectedNode();
                    Debug.Log("Second count : " + _secondnodeList.Count);
                    if (_secondnodeList.Count>0)
                        j = random.Next(0, _secondnodeList.Count - 1);
                }


                while (!SetActionObjectByInt(_secondnodeList[j].GetNodeID()))
                {
                    if (_secondnodeList.Count > 1)
                    {
                        _secondnodeList.RemoveAt(j);
                        j = random.Next(0, _secondnodeList.Count - 1);
                    }
                    else
                    {
                        _secondnodeList = WorldMapGenClass._mapNodeLists[j].GetNearConnectedNode();
                        Debug.Log("Current Count" + _secondnodeList.Count);
                        if(_secondnodeList.Count > 0)
                            j = random.Next(0, _secondnodeList.Count - 1);
                        else
                            j = _node_queue.Dequeue();



                        break;
                    }
                }

            }
            */
            #endregion


            //Debug.Log(_total_Node);
            //최소 노드중 하나를 잡고 그것들을 기반으로 계산을 한다,
            _lineSetter.PlaceLineByIntList(_targetPlace_numList);
            SaveCurrentData();
            CheckActionObjectState();
        }
        void SaveCurrentData()
        {
            Dictionary<int, ActionObjectData> _currentDic = new Dictionary<int, ActionObjectData>();
            foreach (KeyValuePair<int, WorldMap_ActionObject> _pairs in _placedNodeDic)
                _currentDic.Add(_pairs.Key, _pairs.Value._thisData);

            ES3.Save("temptMapBuildDic", _currentDic);
            Debug.Log("save Call");

        }
        void GenerateWorldMapWithSavefile()
        {
            _targetPlace_numList.Clear();
            _placedNodeDic.Clear();
            if (!ES3.KeyExists("temptMapBuildDic"))
            {
                Debug.Log("loadfail");
                GenerateWorldMapWithNew();
                return;
            }
            Debug.Log("load success");

            Dictionary<int, ActionObjectData> _currentDic = ES3.Load<Dictionary<int, ActionObjectData>>("temptMapBuildDic");

            foreach (KeyValuePair<int, ActionObjectData> _pair in _currentDic)
                SetActionObject(_pair.Key, _pair.Value);


            _lineSetter.PlaceLineByIntList(_targetPlace_numList);
            CheckActionObjectState();

        }
        void SetActionObjectKindList()
        {
            //3번째의 라인은 무조건 보스이 므로 첫번째의 시작 턴과 합쳐서 뺀다.
            int _spawnTargetInt = _total_Node - 1 - _thirdNodeCounts;
            actionObjectKindList = new List<ActionObjectKind>();

            foreach (KeyValuePair<ActionObjectKind, float> _valuepair in WorldMapGenClass.GetCurrentWorldMapSpawn)
            {
                for (int i = 0; i < _valuepair.Value * _spawnTargetInt; i++)
                    actionObjectKindList.Add(_valuepair.Key);
            }
            for (int i = 0; i < _thirdNodeCounts; i++)
                actionObjectKindList.Add(ActionObjectKind.엘리트_배틀);
        }
        ActionObjectKind GetRandomObjectList()
        {
            var random = new System.Random();
            ActionObjectKind _returnval = ActionObjectKind.미정;

            int i = random.Next(0, actionObjectKindList.Count - 1);
            _returnval = actionObjectKindList[i];
            actionObjectKindList.RemoveAt(i);
            return _returnval;
        }
        bool SetActionObjectByInt(int i)
        {
            if (_placedNodeDic.ContainsKey(i)) return false;
            //Debug.Log("Spawn  : " + i);
            GameObject _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[i], Quaternion.identity, _ActionObjectPlace);
            WorldMap_ActionObject _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>();
            _tempt.name = "AO" + i + "," + WorldMapGenClass._mapNodeLists[i].GetNodeLevel();
            _placedNodeDic.Add(i, _temptActionObjScript);
            _targetPlace_numList.Add(i);
            _total_Node--;
            //시작일경우
            if (i == 0)
            {
                _temptActionObjScript.BeginActionObject(i, ActionObjectKind.시작);
                return true;
            }
            else if (WorldMapGenClass._mapNodeLists[i].GetNodeLevel() == 3)
            {
                _temptActionObjScript.BeginActionObject(i, ActionObjectKind.보스_배틀);
            }
            else
            {
                _temptActionObjScript.BeginActionObject(i, GetRandomObjectList());
            }
            return true;
        }
        bool SetActionObject(int i, ActionObjectData _data)
        {
            if (_placedNodeDic.ContainsKey(i)) return false;

            GameObject _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[i], Quaternion.identity, _ActionObjectPlace);
            WorldMap_ActionObject _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>();
            _tempt.name = "AO" + i + "," + WorldMapGenClass._mapNodeLists[i].GetNodeLevel();
            _placedNodeDic.Add(i, _temptActionObjScript);
            _targetPlace_numList.Add(i);
            //시작일경우
            _temptActionObjScript.BeginActionObject(i, _data);
            return true;
        }

        void CheckActionObjectState()
        {
            //첫 번째 꺼는 언제든 선택 가능하게 한다. 대신 선택 했을 경우 비활성화 한다.

            _placedNodeDic[0]._thisData._isSelectable = true;
            _placedNodeDic[0]._thisData.CheckSelectable();
            _placedNodeDic[0].SetPanelSpriteByChange();
            Queue<WorldMap_ActionObject> _q2BFS = new Queue<WorldMap_ActionObject>();
            List<int> _alreadyPassed = new List<int>();
            _q2BFS.Enqueue(_placedNodeDic[0]);
            _alreadyPassed.Add(0);

            while (_q2BFS.Count != 0 )
            {
                WorldMap_ActionObject _currentObj = _q2BFS.Dequeue();
                string _log_found = "currrent : ";
                _log_found += _currentObj._thisData._positionNum.ToString();
                _log_found += ": and length : "; 
                _log_found += _q2BFS.Count.ToString();
                _log_found += "=";
                foreach (WorldMapNode _node in WorldMapGenClass._mapNodeLists[_currentObj._thisData._positionNum].GetConnectedNode())
                    if (_placedNodeDic.ContainsKey(_node.GetNodeID()) && !_alreadyPassed.Contains(_node.GetNodeID()))
                    {
                        _q2BFS.Enqueue(_placedNodeDic[_node.GetNodeID()]);
                        _alreadyPassed.Add(_node.GetNodeID());
                        _log_found += _node.GetNodeID().ToString();
                        _log_found += ",";
                        if (_currentObj._thisData._isUsed)
                        {
                            _placedNodeDic[_node.GetNodeID()]._thisData._isSelectable = true;
                            _placedNodeDic[_node.GetNodeID()]._thisData.CheckSelectable();
                            _placedNodeDic[_node.GetNodeID()].SetPanelSpriteByChange();
                        }
                    }
            }

        }


        //해당 월드맵 형태 바꾸기
        public void SetActionObjectUsed()
        {
            Debug.Log(_currentSelectedID);
            _placedNodeDic[_currentSelectedID]._thisData._isUsed = true;
            CheckActionObjectState();
            SaveCurrentData();

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
                Mathf.Clamp(_startPos.x - _difference.x, -_clampSize.x, _clampSize.x),
                Mathf.Clamp(_startPos.y - _difference.y, -_clampSize.y, _clampSize.y),
               11);


            transform.position = objPosition;


        }
        //클릭 했을 때
        Tween _tweenMove = null;
        public void ActionObjectClicked(int _ID, Vector3 _targetVector)
        {
            _currentSelectedID = _ID;
            Vector3 _temptVector = new Vector3(-_targetVector.x, -(_targetVector.y - 1.75f), transform.position.z);
            _tweenMove = transform.DOMove(_temptVector, 0.5f);
        }

        #endregion




    }

}
