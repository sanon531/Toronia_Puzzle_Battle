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


        //업무가 다 끝나면 이제 연결된 곳데이터 받아와서 해당 부분으로 연결함. 
        IEnumerator ConnectLineToHigh()
        {
            yield return new WaitForEndOfFrame();
        }



        //클릭, 관련 업무
        #region
        private void OnMouseDown()
        {
            SetColorPressed();

            if (_isUsedfalse)
            {
                switch (_objectAction)
                {
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
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.이벤트);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.이벤트);
        }

        void StartBattle()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.일반_배틀);
            Global_InGameData.Instance.SetStageData(_currentStage);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기,ActionObjectKind.일반_배틀);
            //오브젝트세팅 뭐시기
        }

        void StartBattle_Elite()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.엘리트_배틀);
            Global_InGameData.Instance.SetStageData(_currentStage);

            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_오브젝트_실행, true);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, ActionObjectKind.엘리트_배틀);
            //오브젝트세팅 뭐시기
        }
        void StartBattle_Boss()
        {
            Global_InGameData.Instance.SetStageAction(ActionObjectKind.보스_배틀);
            Global_InGameData.Instance.SetStageData(_currentStage);

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
            _isUsedfalse = false;
        }

    }
    #endregion

}
