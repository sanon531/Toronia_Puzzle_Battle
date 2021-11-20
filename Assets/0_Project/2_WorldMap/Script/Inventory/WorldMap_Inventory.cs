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
            _inventoryCase = GameObject.Find("WorldMap_InventoryCase").GetComponent<WorldMap_InventoryCase>();
            _caseImage = _inventoryCase.GetComponent<Image>();
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
            //인벤토리 사이즈 변경하기.
            _inventoryRect = GameObject.Find("WorldMap_InventorySet").GetComponent<RectTransform>();
            _inventoryRect.sizeDelta = new Vector2(Screen.width*0.45f, Screen.height * 0.25f);
            _inventoryRect.anchoredPosition = new Vector2(-_inventoryRect.sizeDelta.x*0.5f, -_inventoryRect.sizeDelta.y * 0.75f);

            //케이스 데이터 인풋.
            _caseRectWidth = Screen.width * 0.15f;
            _content_LayoutGroup = GameObject.Find("WorldMap_Inventory_Content").GetComponent<GridLayoutGroup>();
            _content_LayoutGroup.cellSize = new Vector2(_caseRectWidth, _caseRectWidth);
            _inventoryCase.BeginInventoryCase(this,_caseRectWidth);

        }

        [SerializeField] [ReadOnly] List<ModuleID> _inventoryModule = new List<ModuleID>();

        public void SetModuleList(List<ModuleID> _ModuleList) { _inventoryModule = _ModuleList; }
        public List<ModuleID> GetModuleList(){ return _inventoryModule; }


    }
}