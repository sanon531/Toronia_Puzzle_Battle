using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using ToronPuzzle.Event;
namespace ToronPuzzle.UI
{
    public class Global_CanvasUI : UIManager
    {
        public static Global_CanvasUI Instance;
        [SerializeField] Image _globalDim = default;
        public override void BeginUIManager()
        {
            base.BeginUIManager();
            Instance = this;
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_암전, GlobalDimOn, EventRegistOption.Permanent);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_암전해제, GlobalDimOff, EventRegistOption.Permanent);
        }
        public void SetInGameListeners()
        {
            foreach (var ui in uI_Objects.OfType<IGameListenerUI>())
            {
                ui.AssignGameListener();
            }
        }
        int _dimRequest = 0;
        void GlobalDimOn()
        {
            _dimRequest++;
            _globalDim.gameObject.SetActive(true);
            _globalDim.DOKill();
            _globalDim.color = Color.clear;
            _globalDim.DOColor(Color.black, 0.8f).SetUpdate(true);
        }
        void GlobalDimOff()
        {
            _dimRequest--;
            if (_dimRequest == 0)
            {
                _globalDim.DOKill();
                _globalDim.DOColor(Color.clear, 0.8f).SetUpdate(true).OnComplete(() => {
                    _globalDim.gameObject.SetActive(false);
                });
            }
            else if (_dimRequest < 0)
            {
                _dimRequest = 0;
                Debug.LogError("Blocking On Off 짝이 맞지않음");
            }
        }


        void SetCalcData(int _argAttack, int _argDefence)
        {

        }





    }



}