using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.UI;
using ToronPuzzle.Event;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_ControlPannel : UI_Object, IGameListenerUI
    {
        [SerializeField]
        Button _blockPlaceSetButton, _InventorySetButton;

        public void AssignGameListener()
        {
            _blockPlaceSetButton.onClick.AddListener(CallBlockPlace);
            _InventorySetButton.onClick.AddListener(CallInventory);
        }

        bool _isBPShow = true;
        void CallBlockPlace()
        {
            if (_isBPShow)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
                _isBPShow = false;
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
                _isBPShow = true;
            }

        }

        bool _isInvShow = true;
        void CallInventory()
        {
            if (_isInvShow)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리숨기기);
                _isInvShow = false;
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
                _isInvShow = true;
            }


        }

    }
}
