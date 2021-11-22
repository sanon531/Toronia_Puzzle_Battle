using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using ToronPuzzle.Data;

namespace ToronPuzzle.WorldMap
{
    public enum ActionObjectKind
    {
        //일반 이벤트,
        Event,
        Battle,
        Item,
        Shop,
        Corrupted
    }

    public class WorldMap_ActionObject : MonoBehaviour
    {
        public ActionObjectKind _objectAction;
        [SerializeField]
        SpriteRenderer _thisSprite,_itemSprite;

        Color _currentColor,_pressedColor;

        [SerializeField]
        bool _isUsedfalse = true;
        [SerializeField]
        StageInfo _currentStage;

 
        // Start is called before the first frame update
        void Start()
        {
            BeginActionObject();
        }
        void BeginActionObject()
        {
            _itemSprite.sprite = Resources.Load<Sprite>("WorldMap/" + _objectAction.ToString());
            _currentColor = Color.white;
            _pressedColor = new Color(.5f,.5f,.5f);
        }

        private void OnMouseDown()
        {
            SetColorPressed();
            if (_isUsedfalse)
            {
                switch (_objectAction)
                {
                    case ActionObjectKind.Event:
                        StartEvent();
                        break;
                    case ActionObjectKind.Battle:
                        StartBattle();
                        break;
                    case ActionObjectKind.Item:
                        StartItem();
                        break;
                    case ActionObjectKind.Shop:
                        StartShop();
                        break;
                    case ActionObjectKind.Corrupted:
                        StartCorrupted();
                        break;
                    default:
                        Debug.LogError("No Action");
                        break;
                }
            }
        }

        private void OnMouseUp() { SetColorCurrent();}
        private void OnMouseExit() { SetColorCurrent(); }

        void SetColorPressed() { _itemSprite.color = _pressedColor; _thisSprite.color = _pressedColor; }
        void SetColorCurrent() { _itemSprite.color = _currentColor; _thisSprite.color = _currentColor; }


        void StartEvent()
        {

        }

        void StartBattle()
        {
            Global_InGameData.Instance.SetStageData(_currentStage);
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_배틀전환허용, true);
        }

        void StartItem()
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_배틀전환허용, false);

        }

        void StartShop()
        {

        }
        void StartCorrupted()
        {

        }

        public void SetDeactivate()
        {
            _currentColor = new Color(.75f, .75f, .75f);
            _itemSprite.color = _currentColor;
            _thisSprite.color = _currentColor;
            _isUsedfalse = false;
        }

    }


}
