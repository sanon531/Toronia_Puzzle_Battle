using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using ToronPuzzle.Data;

namespace ToronPuzzle.WorldMap
{

    public class WorldMap_ActionObject : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer _thisSprite,_itemSprite,_AuraSprite;
        [SerializeField]
        Color _currentColor,_pressedColor;

        public ActionObjectData _thisData = new ActionObjectData();


        public WorldMapNode _thisNode;
        [SerializeField]
        int _nodeID;
        Material _this_Mat;


        public void BeginActionObject(int _arg_NodeID,ActionObjectKind _kind)
        {
            _thisData._positionNum = _arg_NodeID;
            _thisData._objectKind = _kind;
            _nodeID = _arg_NodeID;
            _this_Mat = _thisSprite.material;
            if (_kind == ActionObjectKind.일반_배틀 || _kind == ActionObjectKind.엘리트_배틀 || _kind == ActionObjectKind.보스_배틀)
            {
                _thisData._stageInfo = StageDataPool.StageinfoDic["멸고단_1"];
            }
            SetPanelSpriteByChange();
        }


        public void BeginActionObject(int _arg_NodeID, ActionObjectData _data)
        {
            _thisData = _data;
            _nodeID = _arg_NodeID;
            _this_Mat = _thisSprite.material;
            SetPanelSpriteByChange();
        }


        public void SetPanelSpriteByChange()
        {
            if (!_thisData._isUsed && _thisData._isSelectable)
            {
                _currentColor = Color.white;
                _pressedColor = new Color(.5f, .5f, .5f);
            }
            else
            {
                _currentColor = new Color(.75f, .75f, .75f);
                _pressedColor = new Color(.75f, .75f, .75f);
                _itemSprite.color = new Color(.25f, .25f, .25f);

            }
            SetColorCurrent();
            _itemSprite.sprite = Resources.Load<Sprite>("WorldMap/" + _thisData._objectKind.ToString());
            _AuraSprite.enabled = false;

            switch (_thisData._objectKind)
            {
                case ActionObjectKind.미정:
                    _itemSprite.color = new Color(.25f, .25f, .25f);
                    break;
                case ActionObjectKind.시작:
                    break;
                case ActionObjectKind.이벤트:
                    break;
                case ActionObjectKind.일반_배틀:
                    break;
                case ActionObjectKind.엘리트_배틀:
                    _AuraSprite.enabled = true;
                    _AuraSprite.color = Color.white;
                    break;
                case ActionObjectKind.보스_배틀:
                    _AuraSprite.enabled = true;
                    _AuraSprite.color = Color.red;
                    break;
                case ActionObjectKind.아이템:
                    break;
                case ActionObjectKind.상점:
                    break;
                case ActionObjectKind.정보오염:
                    _this_Mat.SetColor("_Color", new Color(.25f, .25f, .25f));
                    _this_Mat.SetFloat("_DistortAmount", 0.8f);
                    break;
            }


        }




        //클릭, 관련 업무
        #region
        private void OnMouseDown()
        {
            if (!_thisData._isUsed && _thisData._isSelectable)
            {
                Debug.Log("selectable");
                SetColorPressed();
                switch (_thisData._objectKind)
                {
                    case ActionObjectKind.시작:
                        StartStartEvent();
                        break;
                    case ActionObjectKind.이벤트:
                        StartEvent();
                        break;
                    case ActionObjectKind.일반_배틀:
                        StartBattle();
                        break;
                    case ActionObjectKind.아이템:
                        StartItem();
                        break;
                    case ActionObjectKind.상점:
                        StartShop();
                        break;
                    case ActionObjectKind.정보오염:
                        StartCorrupted();
                        break;
                    case ActionObjectKind.엘리트_배틀:
                        StartBattle_Elite();
                        break;
                    case ActionObjectKind.보스_배틀:
                        StartBattle_Boss();
                        break;
                    case ActionObjectKind.미정:
                        Debug.LogError("No Action");
                        break;
                    default:
                        Debug.LogError("No Action");
                        break;
                }
                WorldMap_MapBuilder.Instance.ActionObjectClicked(_nodeID,transform.localPosition);
            }
        }

        private void OnMouseUp()
        {
            if (!_thisData._isUsed)
                SetColorCurrent();

        }
        private void OnMouseExit() { SetColorCurrent(); }

        void SetColorPressed() { _itemSprite.color = _pressedColor; _thisSprite.color = _pressedColor; }
        void SetColorCurrent() { _itemSprite.color = _currentColor; _thisSprite.color = _currentColor; }


        void StartStartEvent()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.시작);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.이벤트);
        }

        void StartEvent()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.이벤트);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.이벤트);
        }

        void StartBattle()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.일반_배틀);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기,ActionObjectKind.일반_배틀);
            //오브젝트세팅 뭐시기
        }

        void StartBattle_Elite()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.엘리트_배틀);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.엘리트_배틀);

        }
        void StartBattle_Boss()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.보스_배틀);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.보스_배틀);
            //오브젝트세팅 뭐시기
        }


        void StartItem()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.아이템);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.아이템);

        }

        void StartShop()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.상점);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.상점);

        }
        void StartCorrupted()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.정보오염);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.정보오염);

        }

        public void SetDeactivate()
        {
            _currentColor = new Color(.75f, .75f, .75f);
            _itemSprite.color = _currentColor;
            _thisSprite.color = _currentColor;
            _thisData._isUsed = true;
        }

    }
    #endregion

}
