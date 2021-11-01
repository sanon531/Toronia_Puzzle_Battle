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
        public static Global_CanvasUI Ins;
        [SerializeField] Image _globalDim = default;

        protected override void Awake()
        {
            base.Awake();
            Ins = this;
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
        private int _dimRequest = 0;
        private void GlobalDimOn()
        {
            _dimRequest++;
            _globalDim.gameObject.SetActive(true);
            _globalDim.DOKill();
            _globalDim.color = Color.clear;
            _globalDim.DOColor(Color.black, 0.8f).SetUpdate(true);
        }

        private void GlobalDimOff()
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



    }



}