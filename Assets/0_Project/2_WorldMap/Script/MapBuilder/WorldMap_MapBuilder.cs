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
        Dictionary<int, WorldMap_ActionObject> _placedNodeDic = new Dictionary<int, WorldMap_ActionObject>();
        List<int> _targePlaceList = new List<int>();
        [SerializeField]
        int _total_Node = 10;
        [SerializeField]
        int _thirdNodeCounts = 1;
        [SerializeField]
        int _firstLeastNodeCounts = 3;
        List<ActionObjectKind> actionObjectKindList = new List<ActionObjectKind>();

        void GenerateWorldMap()
        {
            _ActionObject = Resources.Load("WorldMap/WorldMap_ActionObject") as GameObject;
            //��� �ʱ�ȭ
            WorldMapGenClass.Set_mapNodeListsConnected();

            var random = new System.Random();

            //ó���� ��ġ�� �׳� �״�� ��.
            SetActionObjectByInt(0);
            //�����


            //���� �־��� ���̺� ������ ���� ��� �����ؼ�

            //������ �׳� ������ ��� ��ġ�� ��
            //ó�� �ּ� ���� ��ġ�ϱ�
            Stack<int> _node_stack = new Stack<int>();
            List<int> _selectedList = new List<int>() { 3, 6, 2 , 4, 1, 5 };
            for (int i = 0; i < _firstLeastNodeCounts; i++)
            {
                int j = random.Next(0,_selectedList.Count-1);
                SetActionObjectByInt(_selectedList[j]);
                _node_stack.Push(_selectedList[j]);
                _selectedList.RemoveAt(j);
            }

            List<WorldMapNode> _secondnodeList;
            //���������� ��ġ �Ҳ� üũ
            while (_thirdNodeCounts !=0)
            {
                int i = _node_stack.Pop();
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
                SetActionObjectByInt(j);
                _node_stack.Push(j);

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



            int n_i = _node_stack.Pop();
            _secondnodeList = WorldMapGenClass._mapNodeLists[n_i].GetHigerConnectedNode();
            while (_total_Node >0 && _node_stack.Count >0)
            {
                int j = random.Next(0, _secondnodeList.Count - 1);
                while (!SetActionObjectByInt(_secondnodeList[j].GetNodeID()))
                {
                    if (_secondnodeList.Count != 0)
                    {
                        _secondnodeList.RemoveAt(j);
                        j = random.Next(0, _secondnodeList.Count - 1);
                    }
                    else
                    {
                        n_i = _node_stack.Pop();
                        _secondnodeList = WorldMapGenClass._mapNodeLists[n_i].GetNearConnectedNode();
                        break;
                    }
                }

            }





            Debug.Log(_total_Node);
            //�ּ� ����� �ϳ��� ��� �װ͵��� ������� ����� �Ѵ�,
            _lineSetter.PlaceLineByIntList(_targePlaceList);
        }

        bool SetActionObjectByInt(int i)
        {
            if (_placedNodeDic.ContainsKey(i)) return false;
            //Debug.Log(i);
            GameObject _tempt = Instantiate(_ActionObject, WorldMapGenClass._NodeIdToPos[i], Quaternion.identity, _ActionObjectPlace);
            WorldMap_ActionObject _temptActionObjScript = _tempt.GetComponent<WorldMap_ActionObject>();
            _tempt.name = "AO" + i + ","+ WorldMapGenClass._mapNodeLists[i].GetNodeLevel();
            _temptActionObjScript.BeginActionObject(i);
            _placedNodeDic.Add(i, _temptActionObjScript);
            _targePlaceList.Add(i);
            _total_Node--;
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
