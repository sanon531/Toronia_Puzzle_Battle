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
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_����Ǽ����, SetBPShowBoolFalse);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_����Ǻ��̱�, SetBPShowBoolTrue);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_�κ��丮�����, SetInvShowBoolFalse);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_�κ��丮���̱�, SetInvShowBoolTrue);
            SetInitialConponent();

            _blockPlaceSetButton.onClick.AddListener(CallBlockPlace);
            _InventorySetButton.onClick.AddListener(CallInventory);
            CallBlockPlace();
            CallInventory();
        }

        void SetInitialConponent()
        {
            //���� ������ ���ݶ��̴� �����ϰ� �����
            _blockPlaceSetButton.GetComponent<BoxCollider2D>().size = _blockPlaceSetButton.GetComponent<RectTransform>().rect.size;
            _InventorySetButton.GetComponent<BoxCollider2D>().size = _InventorySetButton.GetComponent<RectTransform>().rect.size;

        }

        #region

        bool _isBPShow = true;
        void CallBlockPlace()
        {
            if (_isBPShow)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǽ����);
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_����Ǻ��̱�);
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
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮�����);
            }
            else
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_�κ��丮���̱�);
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
