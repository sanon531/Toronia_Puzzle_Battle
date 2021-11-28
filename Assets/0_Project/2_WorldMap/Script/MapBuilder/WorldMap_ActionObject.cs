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
        ActionObjectKind _objectAction;
        [SerializeField]
        SpriteRenderer _thisSprite,_itemSprite;

        Color _currentColor,_pressedColor;

        [SerializeField] bool _isUsedfalse = true;
        [SerializeField] StageInfo _currentStage;

        public WorldMapNode _thisNode;

        // Start is called before the first frame update
        void Start()
        {
        }
        public void BeginActionObject(int _NodeID)
        {
            _itemSprite.sprite = Resources.Load<Sprite>("WorldMap/" + _objectAction.ToString());
            _currentColor = Color.white;
            _pressedColor = new Color(.5f,.5f,.5f);
        }


        //������ �� ������ ���� ����� �������� �޾ƿͼ� �ش� �κ����� ������. 
        IEnumerator ConnectLineToHigh()
        {
            yield return new WaitForEndOfFrame();
        }



        //Ŭ��, ���� ����
        #region
        private void OnMouseDown()
        {
            SetColorPressed();

            if (_isUsedfalse)
            {
                switch (_objectAction)
                {
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
            }
        }

        private void OnMouseUp() {
            SetColorCurrent();
            WorldMap_MapBuilder.Instance.ActionObjectClicked(transform.localPosition);

        }
        private void OnMouseExit() { SetColorCurrent(); }

        void SetColorPressed() { _itemSprite.color = _pressedColor; _thisSprite.color = _pressedColor; }
        void SetColorCurrent() { _itemSprite.color = _currentColor; _thisSprite.color = _currentColor; }


        void StartEvent()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.�̺�Ʈ);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.�̺�Ʈ);
        }

        void StartBattle()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.�Ϲ�_��Ʋ);
            Global_InGameData.Instance.SetStageData(_currentStage);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�,ActionObjectKind.�Ϲ�_��Ʋ);
            //������Ʈ���� ���ñ�
        }

        void StartBattle_Elite()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����Ʈ_��Ʋ);
            Global_InGameData.Instance.SetStageData(_currentStage);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_������Ʈ_����, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�ʿ�����Ʈ�������̱�, ActionObjectKind.����Ʈ_��Ʋ);
            //������Ʈ���� ���ñ�
        }
        void StartBattle_Boss()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.����_��Ʋ);
            Global_InGameData.Instance.SetStageData(_currentStage);

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
            _isUsedfalse = false;
        }

    }
    #endregion

}
