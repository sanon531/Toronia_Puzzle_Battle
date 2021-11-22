using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.UI;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_Inventory : UI_Object, IGameListenerUI
    {

        RectTransform _inventoryRect;
        [SerializeField]
        WorldMap_InventoryCase _inventoryCase;
        GridLayoutGroup _content_LayoutGroup;

        Image _caseImage;
        float _caseRectWidth;

        public void AssignGameListener()
        {
            _inventoryModule = Global_InGameData.Instance.GetInventoryModuleList();
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블럭집은후UI, ActivateInventoryPlace, EventRegistOption.None);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블럭놓은후UI, DeactivateInventoryPlace, EventRegistOption.None);
            BeginInventory();

        }
        void DeactivateInventoryPlace()
        {
            _caseImage.enabled = false;

        }
        void ActivateInventoryPlace()
        {
            _caseImage.enabled = true;

        }



        void BeginInventory()
        {
            _inventoryCase = GameObject.Find("WorldMap_InventoryCase").GetComponent<WorldMap_InventoryCase>();
            _caseImage = _inventoryCase.GetComponent<Image>();


            //인벤토리 사이즈 변경하기.
            _inventoryRect = GameObject.Find("WorldMap_InventorySet").GetComponent<RectTransform>();
            _inventoryRect.sizeDelta = new Vector2(Screen.width*0.45f, Screen.height * 0.25f);

            _showPos = new Vector2(-_inventoryRect.sizeDelta.x * 0.5f, -_inventoryRect.sizeDelta.y * 0.6f);
            _hidePos = new Vector2(_inventoryRect.sizeDelta.x * 0.5f, _inventoryRect.sizeDelta.y * 0.6f);
            _inventoryRect.anchoredPosition = _showPos;

            //트윈 설정
            SetInventoryMoveEvent();


            //케이스 데이터 인풋.
            _caseRectWidth = Screen.width * 0.15f;
            _content_LayoutGroup = GameObject.Find("WorldMap_Inventory_Content").GetComponent<GridLayoutGroup>();
            _content_LayoutGroup.cellSize = new Vector2(_caseRectWidth, _caseRectWidth);
            Global_CanvasData.CanvasData._inventoryCellSize = _content_LayoutGroup.cellSize;
            _inventoryCase.BeginInventoryCase(this,_caseRectWidth);



        }
        //트위너 설정
        Vector2 _showPos, _hidePos;
        ObjectTweener _showFunctions, _hideFunctions;
        void SetInventoryMoveEvent()
        {
            _showFunctions = GameObject.Find("Inv_ShowInv").GetComponent<ObjectTweener>();
            _hideFunctions = GameObject.Find("Inv_HideInv").GetComponent<ObjectTweener>();
            _showFunctions._targetpos = _showPos;
            _hideFunctions._targetpos = _hidePos;
            SetBlockTweenEvent();
        }

        private void SetBlockTweenEvent()
        {
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_인벤토리숨기기, HideBlockPannel, EventRegistOption.None);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_인벤토리보이기, ShowBlockPannel, EventRegistOption.None);
        }
        private void HideBlockPannel()
        {
            _hideFunctions.CallTween();
        }
        private void ShowBlockPannel()
        {
            _showFunctions.CallTween();

        }




        //초기화 이후


        [SerializeField] [ReadOnly] List<ModuleID> _inventoryModule = new List<ModuleID>();

        public void SetModuleList(List<ModuleID> _ModuleList) { _inventoryModule = _ModuleList; }
        public List<ModuleID> GetModuleList(){ return _inventoryModule; }


    }
}