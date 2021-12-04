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

        int _currentSelectedID = 0;
        Dictionary<int, WorldMap_ActionObject> _placedNodeDic = new Dictionary<int, WorldMap_ActionObject>();
        List<int> _targePlaceList = new List<int>();
        [SerializeField]
        int _total_Node = 10;
        [SerializeField]
        int _thirdNodeCounts = 1;
        [SerializeField]
        int _firstLeastNodeCounts = 3;
        [SerializeField]
        List<ActionObjectKind> actionObjectKindList = new List<ActionObjectKind>();


        void GenerateWorldMap()
        {
            _ActionObject = Resources.Load("WorldMap/WorldMap_ActionObject") as GameObject;
            //��� �ʱ�ȭ
            WorldMapGenClass.Set_mapNodeListsConnected();
            var random = new System.Random();

            SetActionObjectKindList();


            //ó���� ��ġ�� �׳� �״�� ��.
            SetActionObjectByInt(0);
            //�����


            //���� �־��� ���̺� ������ ���� ��� �����ؼ�

            //������ �׳� ������ ��� ��ġ�� ��
            //ó�� �ּ� ���� ��ġ�ϱ�
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
            //���������� ��ġ �Ҳ� üũ
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


            //���� �� ��ġ ���Ŀ� ���̰����� ��ġ�Ǵ� ������Ʈ
            _secondnodeList.Clear();
            while (_node_queue.Count != 0)
            {
                int n_i = _node_queue.Dequeue();
                foreach (WorldMapNode _Node in WorldMapGenClass._mapNodeLists[n_i].GetHigerConnectedNode())
                    if (!_secondnodeList.Contains(_Node))
                        _secondnodeList.Add(_Node);
            }
            List<WorldMapNode> _temptSaveList = new List<WorldMapNode>();
            //���� ��� ��ó ��带 1ȸ �߰��� ��������.
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



            //������ 1�� ���鿡�� ���� ������ �Լ��Ѵ� + �ش� ���� �������� ��ó ��嵵 �ִ´�. 
            //. ���� �ش� ������ ������尡 ���� ���� 


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
            //�ּ� ����� �ϳ��� ��� �װ͵��� ������� ����� �Ѵ�,
            _lineSetter.PlaceLineByIntList(_targePlaceList);
        }
        void SetActionObjectKindList()
        {
            //3��°�� ������ ������ ������ �Ƿ� ù��°�� ���� �ϰ� ���ļ� ����.
            int _spawnTargetInt = _total_Node - 1 - _thirdNodeCounts;
            actionObjectKindList = new List<ActionObjectKind>();

            foreach (KeyValuePair<ActionObjectKind, float> _valuepair in WorldMapGenClass.GetCurrentWorldMapSpawn)
            {
                for (int i = 0; i < _valuepair.Value * _spawnTargetInt; i++)
                    actionObjectKindList.Add(_valuepair.Key);
            }
            for (int i = 0; i < _thirdNodeCounts; i++)
                actionObjectKindList.Add(ActionObjectKind.����Ʈ_��Ʋ);

        }
        ActionObjectKind GetRandomObjectList()
        {
            var random = new System.Random();
            ActionObjectKind _returnval = ActionObjectKind.����;

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
            _targePlaceList.Add(i);
            _total_Node--;

            //�����ϰ��
            if (i == 0)
            {
                _temptActionObjScript.BeginActionObject(i, ActionObjectKind.����);
                return true;
            }
            else if (WorldMapGenClass._mapNodeLists[i].GetNodeLevel() == 3)
            {
                _temptActionObjScript.BeginActionObject(i, ActionObjectKind.����_��Ʋ);
            }
            else
            {
                _temptActionObjScript.BeginActionObject(i, GetRandomObjectList());
            }




            return true;
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
                Mathf.Clamp(_startPos.x - _difference.x, -_clampSize.x, _clampSize.x),
                Mathf.Clamp(_startPos.y - _difference.y, -_clampSize.y, _clampSize.y),
               11);


            transform.position = objPosition;


        }
        //Ŭ�� ���� ��
        Tween _tweenMove = null;
        public void ActionObjectClicked(int _ID, Vector3 _targetVector)
        {
            Vector3 _temptVector = new Vector3(-_targetVector.x, -(_targetVector.y - 1.75f), transform.position.z);
            _tweenMove = transform.DOMove(_temptVector, 0.5f);
        }

        #endregion




    }

}
