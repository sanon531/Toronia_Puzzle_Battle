using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle.Data
{
    /// <summary>
    /// 
    /// </summary>
    public enum ActionObjectKind
    {
        미정=0,
        시작=2,
        이벤트= 3,
        일반_배틀=4,
        엘리트_배틀=5,
        보스_배틀=6,
        아이템=7,
        상점=8,
        정보오염=9
    }

    public static class WorldMapGenClass
    {
        /// <summary>
        /// </summary>
        public static List<WorldMapNode> _mapNodeLists = new List<WorldMapNode>()
        {
            new WorldMapNode(0,0),

            new WorldMapNode(1,1),new WorldMapNode(2,1),new WorldMapNode(3,1),new WorldMapNode(4,1),new WorldMapNode(5,1),new WorldMapNode(6,1),

            new WorldMapNode(7,2),new WorldMapNode(8,2),new WorldMapNode(9,2),new WorldMapNode(10,2),new WorldMapNode(11,2),new WorldMapNode(12,2),
            new WorldMapNode(13,2),new WorldMapNode(14,2),new WorldMapNode(15,2),new WorldMapNode(16,2),new WorldMapNode(17,2),new WorldMapNode(18,2),

            new WorldMapNode(19,3),new WorldMapNode(20,3),new WorldMapNode(21,3),new WorldMapNode(22,3),new WorldMapNode(23,3),new WorldMapNode(24,3),
            new WorldMapNode(25,3),new WorldMapNode(26,3),new WorldMapNode(27,3),new WorldMapNode(28,3),new WorldMapNode(29,3),new WorldMapNode(30,3),
            new WorldMapNode(31,3),new WorldMapNode(32,3),new WorldMapNode(33,3),new WorldMapNode(34,3),new WorldMapNode(35,3),new WorldMapNode(36,3)
        };
        //임시로 해둠 관련 안전성이 아직 담보 되지않아서
        public static void Set_mapNodeListsConnected()
        {
            _mapNodeLists[0].SetNodeListConnected(new List<int>() { 1, 2, 3, 4, 5, 6 });

            _mapNodeLists[1].SetNodeListConnected(new List<int>() { 0, 2, 6, 7, 8, 18 }); _mapNodeLists[2].SetNodeListConnected(new List<int>() { 0, 1, 3, 8, 9, 10 });
            _mapNodeLists[3].SetNodeListConnected(new List<int>() { 0, 2, 4, 10, 11, 12 }); _mapNodeLists[4].SetNodeListConnected(new List<int>() { 0, 3, 5, 12, 13, 14 });
            _mapNodeLists[5].SetNodeListConnected(new List<int>() { 0, 4, 6, 14, 15, 16 }); _mapNodeLists[6].SetNodeListConnected(new List<int>() { 0, 5, 1, 16, 17, 18 });

            _mapNodeLists[7].SetNodeListConnected(new List<int>() { 1, 8, 18, 19, 20, 36 }); _mapNodeLists[8].SetNodeListConnected(new List<int>() { 1, 2, 7, 9, 20, 21 });
            _mapNodeLists[9].SetNodeListConnected(new List<int>() { 2, 8, 10, 21, 22, 23 }); _mapNodeLists[10].SetNodeListConnected(new List<int>() { 2, 3, 9, 11, 23, 24 });
            _mapNodeLists[11].SetNodeListConnected(new List<int>() { 3, 10, 12, 24, 25, 26 }); _mapNodeLists[12].SetNodeListConnected(new List<int>() { 3, 4, 11, 13, 26, 27 });
            _mapNodeLists[13].SetNodeListConnected(new List<int>() { 4, 12, 14, 27, 28, 29 }); _mapNodeLists[14].SetNodeListConnected(new List<int>() { 4, 5, 13, 15, 29, 30 });
            _mapNodeLists[15].SetNodeListConnected(new List<int>() { 5, 14, 16, 30, 31, 32 }); _mapNodeLists[16].SetNodeListConnected(new List<int>() { 5, 6, 15, 17, 32, 33 });
            _mapNodeLists[17].SetNodeListConnected(new List<int>() { 6, 16, 18, 33, 34, 35 }); _mapNodeLists[18].SetNodeListConnected(new List<int>() { 1, 6, 7, 17, 35, 36 });



            _mapNodeLists[19].SetNodeListConnected(new List<int>() { 7, 20, 36 }); _mapNodeLists[20].SetNodeListConnected(new List<int>() { 7, 8, 19, 21 });
            _mapNodeLists[21].SetNodeListConnected(new List<int>() { 8, 9, 22, 23 }); _mapNodeLists[22].SetNodeListConnected(new List<int>() { 9, 21, 23 });
            _mapNodeLists[23].SetNodeListConnected(new List<int>() { 9, 10, 22, 24 }); _mapNodeLists[24].SetNodeListConnected(new List<int>() { 10, 11, 23, 25 });
            _mapNodeLists[25].SetNodeListConnected(new List<int>() { 11, 24, 26 }); _mapNodeLists[26].SetNodeListConnected(new List<int>() { 11, 12, 25, 27 });
            _mapNodeLists[27].SetNodeListConnected(new List<int>() { 12, 13, 28, 29 }); _mapNodeLists[28].SetNodeListConnected(new List<int>() { 13, 27, 29 });
            _mapNodeLists[29].SetNodeListConnected(new List<int>() { 13, 14, 28, 30 }); _mapNodeLists[30].SetNodeListConnected(new List<int>() { 14, 15, 29, 31 });
            _mapNodeLists[31].SetNodeListConnected(new List<int>() { 15, 30, 32 }); _mapNodeLists[32].SetNodeListConnected(new List<int>() { 15, 16, 31, 33 });
            _mapNodeLists[33].SetNodeListConnected(new List<int>() { 16, 17, 31, 32 }); _mapNodeLists[34].SetNodeListConnected(new List<int>() { 17, 33, 35 });
            _mapNodeLists[35].SetNodeListConnected(new List<int>() { 17, 18, 34, 36 }); _mapNodeLists[36].SetNodeListConnected(new List<int>() { 7, 18, 35, 19 });



        }
        public static Dictionary<int, Vector2> _NodeIdToPos = new Dictionary<int, Vector2>()
        {
            {0,new Vector2(0,0) },

            { 1,new Vector2(-0.875f,1.51f) }, {2,new Vector2(0.875f,1.51f) },{3,new Vector2(1.75f,0) },
            { 4,new Vector2(0.875f,-1.51f) }, { 5,new Vector2(-0.875f,-1.51f) }, { 6,new Vector2(-1.75f,0f) },


            { 7,new Vector2(-1.75f,3.02f) }, {8,new Vector2(0.0f,3.02f) },{9,new Vector2(1.75f,3.02f) },
            { 10,new Vector2(2.625f,1.51f) }, { 11,new Vector2(3.5f,0.0f) }, { 12,new Vector2(2.625f,-1.51f) },
            { 13,new Vector2(1.75f,-3.02f) }, {14,new Vector2(0.0f,-3.02f) },{15,new Vector2(-1.75f,-3.02f) },
            { 16,new Vector2(-2.625f,-1.51f) }, { 17,new Vector2(-3.5f,0.0f) }, { 18,new Vector2(-2.625f,1.51f) },


            { 19,new Vector2(-2.625f,4.53f) }, { 20,new Vector2(-0.875f,4.53f) } , { 21,new Vector2(0.875f,4.53f) },{ 22,new Vector2(2.625f,4.53f) },
            { 23,new Vector2(3.5f,3.02f)}, { 24,new Vector2(4.375f,1.51f) },{ 25,new Vector2(5.25f,0) },
            { 26,new Vector2(4.375f,-1.51f) } ,{ 27,new Vector2(3.5f,-3.02f) },
            { 28,new Vector2(2.625f,-4.53f) }, { 29,new Vector2(0.875f,-4.53f)}, { 30,new Vector2(-0.875f,-4.53f) },{ 31,new Vector2(-2.625f,-4.53f) },
            { 32,new Vector2(-3.5f,-3.02f) } , { 33,new Vector2(-4.375f,-1.51f) },{ 34,new Vector2(-5.25f,0.0f) },
            { 35,new Vector2(-4.375f,1.51f)}, { 36,new Vector2(-3.5f,3.02f) }




        };

        public static void PrintNodeList(int _ID)
        {
            string _Nodestr = _ID.ToString() + " : ";
            foreach (WorldMapNode _node in _mapNodeLists[_ID].GetConnectedNode())
            {
                _Nodestr += _node.GetNodeID() + ", ";
            }
            Debug.Log(_Nodestr);
        }

        public static Dictionary<ActionObjectKind, float> GetCurrentWorldMapSpawn = new Dictionary<ActionObjectKind, float>()
        {
            {ActionObjectKind.일반_배틀,0.5f },
            {ActionObjectKind.이벤트,0.3f },
            {ActionObjectKind.아이템,0.1f },
            {ActionObjectKind.상점,0.1f },



        };

    }
    public class WorldMapNode
    {
        int _nodeID;
        int _nodeLevel;
        List<WorldMapNode> _directlyConnected = new List<WorldMapNode>();
        List<WorldMapNode> _higherConnected = new List<WorldMapNode>();
        List<WorldMapNode> _nearConnected = new List<WorldMapNode>();
        List<WorldMapNode> _lowerConnected = new List<WorldMapNode>();


        public WorldMapNode(int nodeID, int nodeLevel)
        {
            _nodeID = nodeID;
            _nodeLevel = nodeLevel;
        }

        public void SetNodeListConnected(List<int> _nodeIDList)
        {
            _directlyConnected = new List<WorldMapNode>();

            foreach (int i in _nodeIDList)
                _directlyConnected.Add(WorldMapGenClass._mapNodeLists[i]);

            foreach (WorldMapNode _node in _directlyConnected)
            {
                if (_node._nodeLevel == _nodeLevel)
                    _nearConnected.Add(_node);
                else if (_node._nodeLevel > _nodeLevel)
                    _higherConnected.Add(_node);
                else if (_node._nodeLevel < _nodeLevel)
                    _lowerConnected.Add(_node);
                else
                    Debug.LogError("Node _ InputError");

            }



        }

        public void SetNodeListConnected(List<WorldMapNode> _nodeList)
        {
            _directlyConnected = _nodeList;
            foreach (WorldMapNode _node in _directlyConnected)
            {
                if (_node._nodeLevel == _nodeLevel)
                    _nearConnected.Add(_node);
                else if (_node._nodeLevel > _nodeLevel)
                    _higherConnected.Add(_node);
                else if (_node._nodeLevel < _nodeLevel)
                    _lowerConnected.Add(_node);
                else
                    Debug.LogError("Node _ InputError");

            }



        }


        public int GetNodeID() { return _nodeID; }
        public int GetNodeLevel() { return _nodeLevel; }
        public List<WorldMapNode> GetConnectedNode() { return _directlyConnected; }
        public List<WorldMapNode> GetNearConnectedNode() { return _nearConnected; }
        public List<WorldMapNode> GetLowerConnectedNode() { return _lowerConnected; }
        public List<WorldMapNode> GetHigerConnectedNode() { return _higherConnected; }

        public bool IsNodeConnected(WorldMapNode _node) { return _directlyConnected.Contains(_node); }
    }
    [System.Serializable]
    public class ActionObjectData
    {
        public ActionObjectKind _objectKind = ActionObjectKind.미정;
        public int _positionNum  = 0 ;
        public StageInfo _stageInfo;
        public bool _isUsed = false;
        public bool _isSelectable = false;
        public bool _isCorrupted = false;

        public void CheckSelectable() { if (_isUsed) _isSelectable = false; }


    }


}
