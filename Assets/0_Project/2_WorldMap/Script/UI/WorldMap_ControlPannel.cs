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
        //public static WorldMap_ControlPannel Instance;
        [SerializeField]
        Button _blockPlaceSetButton, _InventorySetButton;
        [SerializeField]
        Transform _BPImage, _InvImage;
        public void AssignGameListener()
        {
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블록판숨기기, SetBPShowBoolFalse);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블록판보이기, SetBPShowBoolTrue);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_인벤토리숨기기, SetInvShowBoolFalse);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_인벤토리보이기, SetInvShowBoolTrue);
            SetInitialConponent();

            _blockPlaceSetButton.onClick.AddListener(CallBlockPlace);
            _InventorySetButton.onClick.AddListener(CallInventory);
            CallBlockPlace();
            CallInventory();
        }

        void SetInitialConponent()
        {
            //현재 사이즈 랑콜라이더 동일하게 만들기
            _blockPlaceSetButton.GetComponent<BoxCollider2D>().size = _blockPlaceSetButton.GetComponent<RectTransform>().rect.size;
            _InventorySetButton.GetComponent<BoxCollider2D>().size = _InventorySetButton.GetComponent<RectTransform>().rect.size;

        }

        #region

        bool _isBPShow = true;
        void CallBlockPlace()
        {
            if (_isBPShow)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
            }

        }
        void SetBPShowBoolFalse(){
            _BPImage.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            _isBPShow = false;}
        void SetBPShowBoolTrue() {
            _BPImage.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            _isBPShow = true; }


        bool _isInvShow = true;
        void CallInventory()
        {
            if (_isInvShow)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리숨기기);
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_인벤토리보이기);
            }


        }
        void SetInvShowBoolFalse()
        {
            _isInvShow = false;
            _InvImage.localRotation =  Quaternion.Euler( new Vector3(0, 180, 0));

        }
        void SetInvShowBoolTrue()
        {
            _InvImage.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            _isInvShow = true;
        }




        void CallStageDataPannel()
        {

        }
        #endregion

    }
}
