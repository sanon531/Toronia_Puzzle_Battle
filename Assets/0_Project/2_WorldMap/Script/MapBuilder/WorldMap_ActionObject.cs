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
            if (_kind == ActionObjectKind.�Ϲ�_��Ʋ || _kind == ActionObjectKind.����Ʈ_��Ʋ || _kind == ActionObjectKind.����_��Ʋ)
            {
                _thisData._stageInfo = StageDataPool.StageinfoDic["����_1"];
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
                case ActionObjectKind.����:
                    _itemSprite.color = new Color(.25f, .25f, .25f);
                    break;
                case ActionObjectKind.����:
                    break;
                case ActionObjectKind.�̺�Ʈ:
                    break;
                case ActionObjectKind.�Ϲ�_��Ʋ:
                    break;
                case ActionObjectKind.����Ʈ_��Ʋ:
                    _AuraSprite.enabled = true;
                    _AuraSprite.color = Color.white;
                    break;
                case ActionObjectKind.����_��Ʋ:
                    _AuraSprite.enabled = true;
                    _AuraSprite.color = Color.red;
                    break;
                case ActionObjectKind.������:
                    break;
                case ActionObjectKind.����:
                    break;
                case ActionObjectKind.��������:
                    _this_Mat.SetColor("_Color", new Color(.25f, .25f, .25f));
                    _this_Mat.SetFloat("_DistortAmount", 0.8f);
                    break;
            }


        }




        //Ŭ��, ���� ����
        #region
        private void OnMouseDown()
        {
            if (!_thisData._isUsed && _thisData._isSelectable)
            {
                Debug.Log("selectable");
                SetColorPressed();
                switch (_thisData._objectKind)
                {
                    case ActionObjectKind.����:
                        StartStartEvent();
                        break;
                    case ActionObjectKind.�̺�Ʈ:
                        StartEvent();
                        break;
                    case ActionObjectKind.�Ϲ�_��Ʋ:
                        StartBattle();
                        break;
                    case ActionObjectKind.������:
                        StartItem();
                        break;
                    case ActionObjectKind.����:
                        StartShop();
                        break;
                    case ActionObjectKind.��������:
                        StartCorrupted();
                        break;
                    case ActionObjectKind.����Ʈ_��Ʋ:
                        StartBattle_Elite();
                        break;
                    case ActionObjectKind.����_��Ʋ:
                        StartBattle_Boss();
                        break;
                    case ActionObjectKind.����:
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
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.�̺�Ʈ);
        }

        void StartEvent()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.�̺�Ʈ);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.�̺�Ʈ);
        }

        void StartBattle()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.�Ϲ�_��Ʋ);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�,ActionObjectKind.�Ϲ�_��Ʋ);
            //������Ʈ���� ���ñ�
        }

        void StartBattle_Elite()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����Ʈ_��Ʋ);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.����Ʈ_��Ʋ);

        }
        void StartBattle_Boss()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����_��Ʋ);
            Global_InGameData.Instance.SetStageData(_thisData._stageInfo);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.����_��Ʋ);
            //������Ʈ���� ���ñ�
        }


        void StartItem()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.������);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.������);

        }

        void StartShop()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.����);

        }
        void StartCorrupted()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.��������);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.��������);

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
