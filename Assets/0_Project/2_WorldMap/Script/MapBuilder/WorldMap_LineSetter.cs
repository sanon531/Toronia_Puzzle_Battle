using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ToronPuzzle.Data;

public class WorldMap_LineSetter : MonoBehaviour
{
    GameObject _LineRenderObj;
    public void BeginLineSetter()
    {
        _LineRenderObj = Resources.Load("WorldMap/ActionObjectLine") as GameObject;
    }
    [SerializeField]
    Gradient _linePassed, _lineUnPassed, _lineCorrupted;
    List<Vector2Int> _lineList = new List<Vector2Int>();

    Dictionary<Vector2Int, LineRenderer> _vectorLineDic = new Dictionary<Vector2Int, LineRenderer>();
    public void PlaceLineByIntList(List<int> _intList)
    {
        WorldMapGenClass.Set_mapNodeListsConnected();
        string _log = ""; 
        //먼저 라인에대한 정보로 계산을 한뒤 딕셔너리로 만들고 해당 정보를 기반으로 설치를 한다.
        foreach (int target_i in _intList)
        {
            _log += target_i.ToString();
            _log += "_";
            List<WorldMapNode> _nodeList = WorldMapGenClass._mapNodeLists[target_i].GetConnectedNode();
            foreach (WorldMapNode _node in _nodeList)
            {
                if (_intList.Contains(_node.GetNodeID()))
                {
                    if (!_lineList.Contains(new Vector2Int(_node.GetNodeID(), target_i)))
                        _lineList.Add(new Vector2Int(target_i, _node.GetNodeID()));

                }

            }

        }

        foreach (Vector2Int intVec in _lineList)
        {
            GameObject _tempt= Instantiate(_LineRenderObj, new Vector2(), Quaternion.identity, transform);
            LineRenderer _temptRenderer = _tempt.GetComponent<LineRenderer>();
            _vectorLineDic.Add(intVec, _temptRenderer);
            _temptRenderer.SetPosition(0,(Vector3)WorldMapGenClass._NodeIdToPos[intVec.x] + new Vector3(0,0,0.5f));
            _temptRenderer.SetPosition(1, (Vector3)WorldMapGenClass._NodeIdToPos[intVec.y] + new Vector3(0, 0, 0.5f));
            _temptRenderer.colorGradient = _lineUnPassed;
        }
        Debug.Log("SetLine" + _log);
    }
    public void SetNodeColorPassed(Vector2Int _target)
    {
        if (_vectorLineDic.ContainsKey(_target))
            _vectorLineDic[_target].colorGradient = _lineUnPassed;
        else if (_vectorLineDic.ContainsKey(new Vector2Int(_target.y, _target.x)))
            _vectorLineDic[new Vector2Int(_target.y, _target.x)].colorGradient = _lineUnPassed;
        else
            Debug.Log("Did'tContaion");
    }
    public void SetNodeColorCorrupted(Vector2Int _target)
    {
        if (_vectorLineDic.ContainsKey(_target))
            _vectorLineDic[_target].colorGradient = _lineCorrupted;
        else if (_vectorLineDic.ContainsKey(new Vector2Int(_target.y, _target.x)))
            _vectorLineDic[new Vector2Int(_target.y, _target.x)].colorGradient = _lineCorrupted;
        else
            Debug.Log("Did'tContaion");
    }

}
